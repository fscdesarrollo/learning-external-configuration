using Learning.ExternalConfiguration.Api.Clients.Marvel;
using Learning.ExternalConfiguration.Api.Extensions.Configuration;
using Learning.ExternalConfiguration.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Learning.ExternalConfiguration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MarvelApiError))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(MarvelApiError))]
    public class MarvelController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IMarvelAPI _marvelAPI;
        private readonly MarvelApiConfiguration _marvelConfig;

        public MarvelController(IConfiguration configuration, IMarvelAPI marvelAPI)
        {
            _configuration = configuration;
            _marvelAPI = marvelAPI;
            _marvelConfig = _configuration.GetSection("MarvelApiConfig").Get<MarvelApiConfiguration>();
        }

        /// <summary>
        /// Fetches lists of comic characters with optional filters. See notes on individual parameters below.
        /// </summary>
        /// <param name="marvelCharactersParams"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarvelCharactersResponse))]
        [HttpGet("characters")]
        public async Task<IActionResult> Get([FromQuery]MarvelCharactersParams marvelCharactersParams)
        {
            try
            {
                var publicKey = _configuration["API_MARVEL_PUBLIC_KEY"];//Get Key from Azure App Configuration
                var hash = _configuration.GetSection("MarvelApiConfig:Hash").Value;
                var marvelAuthenticationQueryParams = new MarvelApiAuthenticationQueryParams(_marvelConfig.Timestamp, publicKey, hash);
                var marvelCharactersQueryParams = new MarvelApiCharactersQueryParams()
                {
                    NameStartsWith = marvelCharactersParams.NameStartsWith,
                    Limit = marvelCharactersParams.Limit ?? "100",
                    Offset = marvelCharactersParams.Offset ?? "0"
                };

                var characters = await _marvelAPI.GetCharacters(marvelAuthenticationQueryParams, marvelCharactersQueryParams);

                return new OkObjectResult(characters);
            }
            catch (ApiException ex)
            {
                var apiError = JsonSerializer.Deserialize<MarvelApiError>(ex.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return new OkObjectResult(apiError) { StatusCode = (int)ex.StatusCode };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method fetches a single character resource. It is the canonical URI for any character resource provided by the API.
        /// </summary>
        /// <param name="marvelCharactersParams"></param>
        /// <param name="characterId"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarvelCharactersResponse))]
        [HttpGet("characters/{characterId}")]
        public async Task<IActionResult> GetCharacterById([FromQuery]MarvelCharactersParams marvelCharactersParams, [FromRoute]int characterId)
        {
            try
            {
                var publicKey = _configuration["API_MARVEL_PUBLIC_KEY"];//Get Key from Azure App Configuration
                var hash = _configuration.GetSection("MarvelApiConfig:Hash").Value;
                var marvelAuthenticationQueryParams = new MarvelApiAuthenticationQueryParams(_marvelConfig.Timestamp, publicKey, hash);
                
                var character = await _marvelAPI.GetCharacterById(characterId, marvelAuthenticationQueryParams);
                
                return new OkObjectResult(character);
            }
            catch (ApiException ex)
            {
                var apiError = JsonSerializer.Deserialize<MarvelApiError>(ex.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return new OkObjectResult(apiError) { StatusCode = (int)ex.StatusCode };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}