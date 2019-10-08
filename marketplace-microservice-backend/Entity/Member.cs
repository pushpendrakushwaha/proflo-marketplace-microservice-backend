using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.Entity
{
    public class Member
    {
        [BsonId]
        //[BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("memberId")]
        public string MemberId { get; set; }

        [BsonElement("memberName")]
        public string MemberName { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }
}
