using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GUSAanalyzer.ModelCsv;
using GUSAanalyzer.Models;

namespace GUSAanalyzer.CSV
{
    public class CSVparser
    {
        double LP;

        public void Export(Lokalizacje loks)
        {
            Export_To_File (loks, "OutFile_GUS.csv");
        }

        private void Export_To_File(Lokalizacje loks, string outputFileName)
        {
            const string header = "Lp.;Województwo;Powiat;Gmina;Ulica";
            WriteFile(outputFileName, loks.Ulice, header, q => $"{LP};{q.Wojewodztwo };{ q.Gmina };{q.Powiat};{q.cecha + " " + q.nazwa2 + " " + q.nazwa1}");
        }

        private void WriteFile<T> (string outputFileName, IReadOnlyList<T> list, string header, Func<T, string> lineProvider)
        {
            using (var fs = new FileStream( outputFileName, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(header);
                    var count = list.Count;
                    
                    for (var i = 0; i < count; i++)
                    {
                        LP = i;                      

                        var loc = list[i];
                        var line = lineProvider(loc);
                        if (i == count - 1)
                        {
                            sw.Write(line);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }       
    }
    
}

