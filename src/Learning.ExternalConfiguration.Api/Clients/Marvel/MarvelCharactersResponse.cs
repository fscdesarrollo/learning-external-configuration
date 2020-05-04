using System.Collections.Generic;

namespace Learning.ExternalConfiguration.Api.Clients.Marvel
{
    public class MarvelCharactersResponse
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public Data Data { get; set; }
        public string Etag { get; set; }
    }

    public class Data
    {
        public string Offset { get; set; }
        public string Limit { get; set; }
        public string Total { get; set; }
        public string Count { get; set; }
        public IEnumerable<Result> Results { get; set; }
    }

    public class Result
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public string ResourceURI { get; set; }
        public IEnumerable<Url> Urls { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public Comics Comics { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
        public Series Series { get; set; }
    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Comics
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }

    public class Item
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Stories
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public IEnumerable<Item1> Items { get; set; }
    }

    public class Item1
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Events
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public IEnumerable<Item2> Items { get; set; }
    }

    public class Item2
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Series
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public IEnumerable<Item3> Items { get; set; }
    }

    public class Item3
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Url
    {
        public string Type { get; set; }
        public string url { get; set; }
    }

}
