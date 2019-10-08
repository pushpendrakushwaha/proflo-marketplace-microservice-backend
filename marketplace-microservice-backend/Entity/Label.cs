﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.Entity
{
    public class Label
    {
        [BsonId]
        public string LabelId { get; set; }

        [BsonElement("labelName")]
        public string LabelName { get; set; }

        [BsonElement("labelColor")]
        public string labelColor { get; set; }
    }
}
