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
      
            protected static IMongoCollection<Pizza> _collection;
            protected static IMongoCollection<PizzaContent> _collection2;
            protected static MongoClient _client;
            protected static IMongoDatabase _database;

        public PizzaAccess()
            {
                 _client = new MongoClient("mongodb://localhost:27017");
                 _database = _client.GetDatabase("pizzaStore");
         

        }

            public IEnumerable<Pizza> getcollection()
            {
            _collection = _database.GetCollection<Pizza>("pizza");
            return _collection.AsQueryable().ToList();
            }
     }
}
