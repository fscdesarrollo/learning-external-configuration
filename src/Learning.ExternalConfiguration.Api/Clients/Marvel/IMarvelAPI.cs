using Refit;
using System.Threading.Tasks;

namespace Learning.ExternalConfiguration.Api.Clients.Marvel
{
    public interface IMarvelAPI
    {
        #region Characters

        [Get("/v1/public/characters")]
        Task<MarvelCharactersResponse> GetCharacters(MarvelApiAuthenticationQueryParams authenticationQueryParams, MarvelApiCharactersQueryParams marvelCharactersQueryParams);

        [Get("/v1/public/characters/{characterId}")]
        Task<MarvelCharactersResponse> GetCharacterById([AliasAs("characterId")]int characterId, MarvelApiAuthenticationQueryParams authenticationQueryParams);

        #endregion Characters
    }
}
