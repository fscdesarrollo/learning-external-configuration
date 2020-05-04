using Refit;

namespace Learning.ExternalConfiguration.Api.Clients.Marvel
{
    public class MarvelApiAuthenticationQueryParams
    {
        public MarvelApiAuthenticationQueryParams(string timestamp, string apiKey, string hash)
        {
            Timestamp = timestamp;
            ApiKey = apiKey;
            Hash = hash;
        }

        /// <summary>
        ///  A timestamp (or other long string which can change on a request-by-request basis)
        /// </summary>
        [AliasAs("ts")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Public Api key
        /// </summary>
        [AliasAs("apikey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// A md5 digest of the ts parameter, your private key and your public key (e.g. md5(ts+privateKey+publicKey)
        /// </summary>
        [AliasAs("hash")]
        public string Hash { get; set; }
    }
}
