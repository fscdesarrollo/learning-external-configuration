using Learning.ExternalConfiguration.Api.Clients.Marvel;
using Learning.ExternalConfiguration.Api.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using Refit;
using System;
using System.Net;
using System.Net.Http;

namespace Learning.ExternalConfiguration.Api.Extensions.ExternalServices
{
    public static class RegisterExternalService
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {

            var marvelConfig = configuration.GetSection("MarvelApiConfig").Get<MarvelApiConfiguration>();
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

            services.AddRefitClient<IMarvelAPI>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(marvelConfig.Url))
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(timeoutPolicy);

            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.InternalServerError)
                .Or<TimeoutRejectedException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)));
        }
    }
}
