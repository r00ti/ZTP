using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multikulti.Services;
using Multikulti.Model;
using Multikulti.Interfaces;

namespace Multikulti.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly Pizzaservices services;

        public ValuesController(Pizzaservices service)
        {
            this.services = service;
        }

    
        // GET api/pizza/fr
        [HttpGet("{lanCode}")]
        public string Get(string code)
        {
          
                var codeLan = this.services.showPizza(code);
                return codeLan.ToJson();
           
        }
                

    }
}
