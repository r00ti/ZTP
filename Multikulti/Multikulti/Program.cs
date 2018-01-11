using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Multikulti.Services;
using Multikulti.Model;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Multikulti
{
    public class Program 
    {
        protected static IMongoCollection<Pizza> _collection;
        protected static IMongoCollection<PizzaContent> _collection2;
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        

        public static void Main(string[] args) 
        {

            

            var contents = Pizza.Contents;
            var queryGood2 = _collection.AsQueryable().Where(_ => _.Contents.Any(r => r.LanguageCode == t)).FirstOrDefault();
            if (queryGood2 != null)
            {
                return queryGood2;
            }
            else
            {
                return contents.FirstOrDefault();
            }

            //Przykładowy zbiór zadań
            List<Zadania> zadaniaNaDzis = new List<Zadania> {
                Zadania.BMW,
                Zadania.Finanse,
                Zadania.Audi,
                Zadania.Inne
            };

            //Poszukiwanie odpowiedzialnego za dane zadanie
            foreach (var zadanie in zadaniaNaDzis)
            {
                pl.WykonajZadanie(zadanie);
            }

             var items = _collection2.AsQueryable()
               .Where(x => x.LanguageCode == "pl-PL")
               .ToArray();

            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .Build();


       

    }


    

}

