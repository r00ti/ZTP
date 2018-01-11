using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUSAanalyzer.ModelCsv
{
    public class Lokalizacje
    {
        public List<Woj> Wojewodztwa { get; set; }
        public List<Pow> Powiaty { get; set; }
        public List<Gmina> Gminy { get; set; }
        public List<Miej> Miejscowosci { get; set; }
        public List<Ulica> Ulice { get; set; }
    }
}
