using marketplace_microservice_backend.Entity;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProfloPortalBackend.Model
{
    public class BoardList
    {
        [BsonElement("listId")]
        public string ListId { get; set; }
        [BsonElement("listTitle")]
        public string ListTitle { get; set; }
        [BsonElement("listPosition")]
        public int ListPosition { get; set; }
        
        [BsonElement("creationDate")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public List<Card> Cards {get; set;}
    }
}
