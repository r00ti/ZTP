using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUSAanalyzer.ModelCsv
{
    public class Ulica
    {
        public string code { get; set; }
        public string cecha { get; set; }
        public string nazwa1 { get; set; }
        public string nazwa2 { get; set; }
        public string sym { get; set; }
        public Miej Miejscowosc { get; set; }
        public Woj Wojewodztwo { get; set; }
        public Pow Powiat { get; set; }
        public Gmina Gmina { get; set; }
        public string rodzajGmi { get; set; }

        public override string ToString()
        {
            var name = string.IsNullOrWhiteSpace(nazwa2) ? nazwa1 : string.Concat(nazwa2, " ", nazwa1);
            return $"{Miejscowosc} / {name}";
        }


    }
}
