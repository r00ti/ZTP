using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multikulti.Model;

namespace Multikulti.Interfaces
{
    interface IPizzaServices
    {
        List<PizzaContent> showPizza(string code);
    }
}
