using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GUSAanalyzer;
using GUSAanalyzer.CSV;

namespace Runnerr
{
    public class Program
    {
        public static void Main(string[] args)
        {  
            var natural = args.Length > 1 && args[1] == "1";

            Console.WriteLine("{0:T} Parsowanie plików TERYT...", DateTime.Now);
            var teryt = new Parser().Parse();

            Console.WriteLine("{0:T} Tworzenie pliku CSV.", DateTime.Now);
            var locations = new CsvCreator().Create(teryt, natural);

            new CSVparser().Export(locations);

            Console.WriteLine("{0:T} Plik został zapisany ", DateTime.Now);
//
            Console.ReadKey();       
           
        }
    }
}
