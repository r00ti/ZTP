using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using GUSAanalyzer.Models;

namespace GUSAanalyzer
{
 
    public class Parser
    {

        public Models.Teryt Parse()
        {
            var teryt = new Models.Teryt();

            var tercLoc = ("terc.xml");
            var simcLoc = ("simc.xml");
            var ulicLoc = ("ulic.xml");

            teryt.TercList = ParserTerc(tercLoc);
            teryt.SimcList = ParserSimc(simcLoc);
            teryt.UlicList = ParserUlic(ulicLoc);

            return teryt;
        }

        public TercList ParserTerc (string tercLoc)
        {
            XmlDocument tXml = new XmlDocument();
            tXml.Load(tercLoc);

            var terc = new TercList();
            terc.TerList = new List<Terc>();

            foreach (XmlNode row in tXml.SelectNodes("/teryt/catalog/row"))
            {                
                var tercDatas = new Terc();

                foreach (XmlNode kurka in row)
                {
                    tercDatas.WOJ = row["WOJ"].InnerText;
                    tercDatas.POW = row["POW"].InnerText;
                    tercDatas.GMI = row["GMI"].InnerText;
                    tercDatas.RODZ = row["RODZ"].InnerText;
                    tercDatas.NAZWA = row["NAZWA"].InnerText;
                    tercDatas.NAZWA_DOD = row["NAZWA_DOD"].InnerText;
                    tercDatas.STAN_NA = row["STAN_NA"].InnerText;
                }
                    terc.TerList.Add(tercDatas);
            }

            return terc;
        }

        public SimcList ParserSimc (string simcLoc)
        {
            XmlDocument sXml = new XmlDocument();
            sXml.Load(simcLoc);

            var simcs = new SimcList();
            simcs.SimcsList = new List<Simc>();
        

            foreach (XmlNode row in sXml.SelectNodes("/SIMC/catalog/row"))
            {
                var simcsDatas = new Simc();

                foreach (XmlNode kurka in row)
                {
                    simcsDatas.WOJ = row["WOJ"].InnerText;
                    simcsDatas.POW = row["POW"].InnerText;
                    simcsDatas.GMI = row["GMI"].InnerText;
                    simcsDatas.RM = row["RM"].InnerText;
                    simcsDatas.MZ = row["MZ"].InnerText;
                    simcsDatas.NAZWA = row["NAZWA"].InnerText;
                    simcsDatas.SYM = row["SYM"].InnerText;
                    simcsDatas.SYMPOD = row["SYMPOD"].InnerText;
                    simcsDatas.STAN_NA = row["STAN_NA"].InnerText;                   
                }
                    simcs.SimcsList.Add(simcsDatas);

            }
            return simcs;
        }

        public UlicList ParserUlic(string ulicLoc)
        {
            XmlDocument uXml = new XmlDocument();
            uXml.Load(ulicLoc);

            var ulics = new UlicList();
            ulics.UliList = new List<Ulic>();


            foreach (XmlNode row in uXml.SelectNodes("/ULIC/catalog/row"))
            {
                var ulicDatas = new Ulic();

                foreach (XmlNode kurka in row)
                {
                    ulicDatas.WOJ = row["WOJ"].InnerText;
                    ulicDatas.POW = row["POW"].InnerText;
                    ulicDatas.GMI = row["GMI"].InnerText;
                    ulicDatas.RODZ_GMI = row["RODZ_GMI"].InnerText;
                    ulicDatas.SYM = row["SYM"].InnerText;
                    ulicDatas.SYM_UL = row["SYM_UL"].InnerText;
                    ulicDatas.CECHA = row["CECHA"].InnerText;
                    ulicDatas.NAZWA_1 = row["NAZWA_1"].InnerText;
                    ulicDatas.NAZWA_2 = row["NAZWA_2"].InnerText;
                    ulicDatas.STAN_NA = row["STAN_NA"].InnerText;
                }
                    ulics.UliList.Add(ulicDatas);

            }
            return ulics;
        }

    }
}
