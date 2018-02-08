using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multikulti.Services;

namespace Multikulti.Interfaces
{
    public interface IChainOfResp
    {
        GetLanguage getTransLang(string code);
    }
}
