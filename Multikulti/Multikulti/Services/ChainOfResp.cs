using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multikulti.Model;
using Multikulti.Interfaces;
using Multikulti.Services;


namespace Multikulti.Services
{
    public IGetLanguage Selector;
    private readonly string languageCode;

    public class ChainOfResp
    {
        private readonly ChainOfResp startLanguageSelector;

        public ChainOfResp()
        {
            var anyLanguageSelector = new LanguageSelector(null);
            var polishLanguageSelector = new LanguageSelector("pl");
            var englishLanguageSelector = new LanguageSelector("en");

            englishLanguageSelector.failureSelector = polishLanguageSelector;
            polishLanguageSelector.failureSelector = anyLanguageSelector;

            this.startLanguageSelector = englishLanguageSelector;
        }

        public LanguageSelector getLanguageSelectorForLanguageCode(string code)
        {
            var languageSelector = new LanguageSelector(code);
            languageSelector.failureSelector = this.startLanguageSelector;
            return languageSelector;
        }
    }
}
