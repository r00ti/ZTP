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
        string nazwaulicy;
        string nazwagminy;
        string nazwapowiatu;
        string nazwawoje;
        string nazwamiejsc;
        string outputfile;

        public void parsing()
        {

            var _ulic = new Ulic();
            var _terc = new Terc();
            var _simc = new Simc();



            if (_ulic.NAZWA_2 == "") nazwaulicy = _ulic.NAZWA_1;
            else nazwaulicy = _ulic.NAZWA_2 + _ulic.NAZWA_1;

            if (_ulic.WOJ == _terc.WOJ)
            {
                if (_terc.POW == "") nazwawoje = _terc.NAZWA;
            }
            if (_ulic.WOJ == _terc.WOJ)
            {
                if (_ulic.POW == _terc.POW)
                {
                    if (_ulic.GMI == "") nazwapowiatu = _terc.NAZWA;
                }

            }
            if (_ulic.WOJ == _terc.WOJ)
            {
                if (_ulic.POW == _terc.POW)
                {
                    if (_ulic.GMI == _terc.GMI)
                    {
                        nazwagminy = _terc.NAZWA;
                    }
                }
            }

            if (_terc.WOJ == _simc.WOJ)
            {
                if (_terc.POW == _simc.POW)
                {
                    if (_terc.GMI == _simc.GMI)
                    {
                        nazwamiejsc = _simc.NAZWA;
                    }
                }
            }


            outputfile = (nazwawoje + nazwapowiatu + nazwagminy + nazwamiejsc + nazwaulicy + _ulic.CECHA);
            //  StreamWriter sw = new StreamWriter("parser.csv");
            //   sw.WriteLine(outputfile);
            File.WriteAllText("parser.csv", outputfile);
        }
    }
}

