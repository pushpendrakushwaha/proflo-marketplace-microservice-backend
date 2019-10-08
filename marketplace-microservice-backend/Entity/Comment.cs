using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.Entity
{
    public class Comment
    {
        [BsonId]
        public string CommentID { get; set; }

        [BsonElement("authoredBy")]
        public Member authoredBy { get; set; }

        [BsonElement("commentText")]
        public string CommentText { get; set; }
    }
}
