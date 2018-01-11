using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multikulti.Controllers;
using Multikulti.Interfaces;
using Multikulti.Model;
using Multikulti.Services;

namespace Multikulti.Services
{
    public class GetLanguage
    {
             private readonly string languageCode;

        public LanguageSelector(string code)
        {
            this.languageCode = code;
        }

        public PizzaContent getLanguageDescription(Pizza pizza)
        {
            var contents = pizza.Contents;

            var queryGood2 = contents.AsQueryable().Where((r => r.LanguageCode == languageCode)).FirstOrDefault();
            if (queryGood2 != null)
            {
                return queryGood2;
            }
     
        }

    }
}
