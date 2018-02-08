using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multikulti.Model;
using Multikulti.Interfaces;
using Multikulti.Services;


namespace Multikulti.Services
{


    public class ChainOfResp : IChainOfResp
    {
        private readonly IGetLanguage langu;

        public ChainOfResp()
        {
            var requestLanguage = new GetLanguage(null);
            var plLanguage = new GetLanguage("pl");
            var enLanguage = new GetLanguage("en");

            enLanguage.langcode = plLanguage;
            plLanguage.langcode = requestLanguage;
            this.langu = enLanguage;
        }
        public GetLanguage getTransLang(string code)
        {
            var chainLan = new GetLanguage(code);
            chainLan.langcode = this.langu;
            return chainLan;
        }
    }
}
