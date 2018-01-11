using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization.Attributes;

namespace Multikulti.Model
{
    public class Pizza
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<PizzaContent> Contents { get; set; }
    }
}
