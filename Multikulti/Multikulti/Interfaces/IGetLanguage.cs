using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multikulti.Controllers;
using Multikulti.Model;

namespace Multikulti.Interfaces
{
    public interface IGetLanguage
    {
        PizzaContent getTranslation(Pizza pizza);
    }
}
