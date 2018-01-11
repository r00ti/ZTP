using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUSAanalyzer.ModelCsv
{
    public class Pow
    {
        public string code { get; set; }
        public string nazwa { get; set; }
        public string rodzaj { get; set; }
        public Woj Wojewodztwo { get; set; }
        public Miej Miejsowosc { get; set; }

        public override string ToString()
        {
            var type = rodzaj == "powiat" ? string.Empty : string.Concat(" (", rodzaj, ")");
            return $" {nazwa}";
        }
    }
}
