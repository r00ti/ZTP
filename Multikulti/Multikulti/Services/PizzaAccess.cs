using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Multikulti.Model;
using Multikulti.Interfaces;


namespace Multikulti
{
    public class PizzaAccess : IPizzaAccess
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public PizzaAccess()
        {
            this._client = new MongoClient("mongodb://localhost:27017");
            this._database = this._client.GetDatabase("PizzaStore");
        }

        public IEnumerable<Pizza> getcollection()
        {
            var collection = this._database.GetCollection<Pizza>("pizza");
            return collection.AsQueryable().ToList();
        }
    }
}
