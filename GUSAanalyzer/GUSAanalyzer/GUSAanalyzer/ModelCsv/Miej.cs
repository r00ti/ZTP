using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUSAanalyzer.ModelCsv
{
    public class Miej
    {
        public string code { get; set; }
        public string nazwa { get; set; }
        public Gmina Gmina { get; set; }
        public override string ToString()
        {
            return $"{Gmina} /{ code} { nazwa } )";
        }

    }
}
