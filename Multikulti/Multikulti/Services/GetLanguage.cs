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
    public class GetLanguage : IGetLanguage
    {
        private readonly string languageCode;
        public IGetLanguage langcode;

        public GetLanguage(string code)
        {
            this.languageCode = code;
        }

        public PizzaContent getTranslation(Pizza pizza)
        {
            var contents = pizza.Contents;
            var queryGood2 = contents.AsQueryable().Where((r => r.LanguageCode == languageCode)).FirstOrDefault();
            if (queryGood2 != null)
            {
                return queryGood2;
            }
            else if (langcode != null)
            {
                return langcode.getTranslation(pizza);
            }
            else
            {
                return contents.FirstOrDefault();
            }
        }
    }
}
