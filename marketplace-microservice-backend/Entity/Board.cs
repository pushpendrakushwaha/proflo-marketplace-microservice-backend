using marketplace_microservice_backend.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ProfloPortalBackend.Model
{
    [BsonIgnoreExtraElements]
    public class Board
    {
        private List<BoardList> boardLists;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BoardId { get; set; }
        [BsonElement("teamId")]
        public string TeamId { get; set; }
        [BsonElement("boardname")]
        public string BoardName { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        public List<Member> BoardMembers { get; set; }
        public List<Invitee> BoardInvites { get; set; }
        //public List<List> BoardLists { get; set; }
        [BsonElement("lists")]
        public List<BoardList> BoardLists { get => boardLists; set => boardLists = value; }

    }
}

