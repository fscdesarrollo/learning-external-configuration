using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Learning.ExternalConfiguration.Api.Models
{
    public class MarvelCharactersParams
    {
        /// <summary>
        /// Return only characters matching the specified full character name (e.g. Spider-Man).
        /// </summary>
        [FromQuery(Name = "name")]
        [AliasAs("name")]
        public string Name { get; set; }

        /// <summary>
        /// Return characters with names that begin with the specified string (e.g. Sp).
        /// </summary>
        [FromQuery(Name = "nameStartsWith")]
        [AliasAs("nameStartsWith")]
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Return only characters which have been modified since the specified date.
        /// </summary>
        [FromQuery(Name = "modifiedSince")]
        [AliasAs("modifiedSince")]
        public string ModifiedSince { get; set; }

        /// <summary>
        /// Return only characters which appear in the specified comics (accepts a comma-separated list of ids).
        /// </summary>
        [FromQuery(Name = "comics")]
        [AliasAs("comics")]
        public string Comics { get; set; }

        /// <summary>
        /// Return only characters which appear the specified series (accepts a comma-separated list of ids).
        /// </summary>
        [FromQuery(Name = "series")]
        [AliasAs("series")]
        public string Series { get; set; }

        /// <summary>
        /// Return only characters which appear in the specified events (accepts a comma-separated list of ids).
        /// </summary>
        [FromQuery(Name = "events")]
        [AliasAs("events")]
        public string Events { get; set; }

        /// <summary>
        /// Return only characters which appear the specified stories (accepts a comma-separated list of ids).
        /// </summary>
        [FromQuery(Name = "stories")]
        [AliasAs("stories")]
        public string Stories { get; set; }

        /// <summary>
        /// Order the result set by a field or fields. Add a "-" to the value sort in descending order. Multiple values are given priority in the order in which they are passed. Values: (name|modified)
        /// </summary>
        [FromQuery(Name = "orderBy")]
        [AliasAs("orderBy")]
        public string OrderBy { get; set; }

        /// <summary>
        /// Limit the result set to the specified number of resources.
        /// </summary>
        [FromQuery(Name = "limit")]
        [AliasAs("limit")]
        public string Limit { get; set; }

        /// <summary>
        /// Skip the specified number of resources in the result set.
        /// </summary>
        [FromQuery(Name = "offset")]
        [AliasAs("offset")]
        public string Offset { get; set; }

    }

}
