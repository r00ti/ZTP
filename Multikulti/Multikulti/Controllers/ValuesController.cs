using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multikulti.Services;
using Multikulti.Model;
using Multikulti.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Web;



namespace Multikulti.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IPizzaService services;

        public ValuesController(IPizzaService service)
        {
            this.services = service;
        }

      
         [HttpGet("{LanguageCode}")]
       
         public IActionResult Get (string languageCode)
      //  public string Get(string languageCode)
        {
            var codeLan = this.services.showPizza(languageCode);
            if (codeLan == null)
            {
                ;
            }
            return new ObjectResult(codeLan.ToJson());
        }
       
    }
}
