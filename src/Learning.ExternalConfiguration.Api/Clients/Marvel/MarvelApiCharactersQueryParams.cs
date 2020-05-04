using Refit;

namespace Learning.ExternalConfiguration.Api.Clients.Marvel
{
    public class MarvelApiCharactersQueryParams
    {

        /// <summary>
        /// Return only characters matching the specified full character name (e.g. Spider-Man).
        /// </summary>
        [AliasAs("name")]
        public string Name { get; set; }

        /// <summary>
        /// Return characters with names that begin with the specified string (e.g. Sp).
        /// </summary>
        [AliasAs("nameStartsWith")]
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Return only characters which have been modified since the specified date.
        /// </summary>
        [AliasAs("modifiedSince")]
        public string ModifiedSince { get; set; }

        /// <summary>
        /// Return only characters which appear in the specified comics (accepts a comma-separated list of ids).
        /// </summary>
        [AliasAs("comics")]
        public string Comics { get; set; }

        /// <summary>
        /// Return only characters which appear the specified series (accepts a comma-separated list of ids).
        /// </summary>
        [AliasAs("series")]
        public string Series { get; set; }

        /// <summary>
        /// Return only characters which appear in the specified events (accepts a comma-separated list of ids).
        /// </summary>
        [AliasAs("events")]
        public string Events { get; set; }

        /// <summary>
        /// Return only characters which appear the specified stories (accepts a comma-separated list of ids).
        /// </summary>
        [AliasAs("stories")]
        public string Stories { get; set; }

        /// <summary>
        /// Order the result set by a field or fields. Add a "-" to the value sort in descending order. Multiple values are given priority in the order in which they are passed. Values: (name|modified)
        /// </summary>
        [AliasAs("orderBy")]
        public string OrderBy { get; set; }

        /// <summary>
        /// Limit the result set to the specified number of resources.
        /// </summary>
        [AliasAs("limit")]
        public string Limit { get; set; }

        /// <summary>
        /// Skip the specified number of resources in the result set.
        /// </summary>
        [AliasAs("offset")]
        public string Offset { get; set; }
    }
}
