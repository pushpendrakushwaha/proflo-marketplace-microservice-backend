using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace marketplace_microservice_backend.Entity
{
    public class Issues
    {    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string id { get; set; }

        [BsonElement("title")]
        [JsonProperty("title")]
        public string title { get; set; }

        [BsonElement("body")]
        [JsonProperty("body")]
        public string body { get; set; }

        [BsonElement("comments")]
        [JsonProperty("comments")]
        public string comments { get; set; }

        [BsonElement("labelNames")]
        [JsonProperty("labelNames")]
        public string[] labelNames { get; set; }
    }

    public class User
    {
        [BsonElement("uname")]
        [JsonProperty("uname")]
        public string UName { get; set; }

        [BsonElement("utoken")]
        [JsonProperty("utoken")]
        public string UToken { get; set; }

        [BsonElement("urepository")]
        [JsonProperty("urepository")]
        public string Urepository { get; set; }

        [BsonElement("teamId")]
        [JsonProperty("teamId")]
        public string TeamId { get; set; }
    }
    public class MyGitHub
    {
        public List<MyGitHub> myGitHubs { get; set; }
    }

}
