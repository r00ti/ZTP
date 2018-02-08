using System;
using System.Collections.Generic;
using System.Linq;
using Multikulti.Interfaces;
using Multikulti.Model;


namespace Multikulti.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaAccess access;
        private readonly IChainOfResp getLanSelector;

        public PizzaService(IPizzaAccess access, IChainOfResp getLanSelector)
        {
            this.access = access;
            this.getLanSelector = getLanSelector;
        }
        public List<PizzaContent> showPizza(string code)
        {
            var languageSelector = this.getLanSelector.getTransLang(code);
            var pizza2 = this.access.getcollection();
            var contentPizza= new List<PizzaContent>();
            pizza2.ToList().ForEach(pizza => contentPizza.Add(languageSelector.getTranslation(pizza)));
            return contentPizza;
        }
    }
}
