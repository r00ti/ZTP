using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multikulti.Model;
using Multikulti.Services;
using Multikulti.Interfaces;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace Multikulti.Services
{
    public class Pizzaservices
    {
        public class PizzaService : IPizzaServices
        {   
            public List<PizzaContent> showPizza(string code)
            {
                var pizzas = this.repository.getPizzas();
                var allPizza = this.
                var pizzaContent = new List<PizzaContent>();
                allPizza.ToList().ForEach(pizza => pizzaContent.Add(languageSelector.getLanguageDescription(pizza)));
                return pizzaContents;

                var languageSelector = this.languageSelectorsBuilder.getLanguageSelectorForLanguageCode(code);
                var pizzas = this.repository.getPizzas();
                var pizzaContents = new List<PizzaContent>();
                pizzas.ToList().ForEach(pizza => pizzaContents.Add(languageSelector.getLanguageDescription(pizza)));
                return pizzaContents;               
            }
        }
    }
}
