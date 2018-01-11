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
            var tercLoc = ("terc.xml");
            var simcLoc = ("simc.xml");
            var ulicLoc = ("ulic.xml");

            var teryt = new Models.Teryt();
            teryt.TercList = ParserTerc(tercLoc);
            teryt.SimcList = ParserSimc(simcLoc);
            teryt.UlicList = ParserUlic(ulicLoc);
            return teryt;

        }

        public TercList ParserTerc (string _tercLoc)
        {
            var tXml = new XmlDocument();
            tXml.Load(_tercLoc);

            var terc = new TercList();


            foreach (XmlNode row in tXml.SelectNodes("/teryt/catalog/row"))
            {
                var tercDatas = new Terc();
                foreach (XmlNode col in row.SelectNodes("col"))
                {
                    var name = col.Attributes["name"].Value;
                    switch(name){
                        case "WOJ":
                            tercDatas.WOJ = col.InnerText;
                            break;
                        case "POW":
                            tercDatas.POW = col.InnerText;
                            break;
                        case "GMI":
                            tercDatas.GMI = col.InnerText;
                            break;
                        case "RODZ":
                            tercDatas.RODZ = col.InnerText;
                            break;
                        case "NAZWA":
                            tercDatas.NAZWA = col.InnerText;
                            break;
                        case "NAZDOD":
                            tercDatas.NAZWA_DOD = col.InnerText;
                            break;
                       }
                }
                terc.TerList.Add(tercDatas);

            }
            return terc;
        }

        public SimcList ParserSimc (string _simcLoc)
        {
            var sXml = new XmlDocument();
            sXml.Load(_simcLoc);

            var simcs = new SimcList();


            foreach (XmlNode row in sXml.SelectNodes("/teryt/catalog/row"))
            {
                var simcsDatas = new Simc();
                foreach (XmlNode col in row.SelectNodes("col"))
                {
                    var name = col.Attributes["name"].Value;
                    switch (name)
                    {
                        case "WOJ":
                            simcsDatas.WOJ = col.InnerText;
                            break;
                        case "POW":
                            simcsDatas.POW = col.InnerText;
                            break;
                        case "GMI":
                            simcsDatas.GMI = col.InnerText;
                            break;
                        case "RODZ_GMI":
                            simcsDatas.RODZ_GMI = col.InnerText;
                            break;
                        case "RM":
                            simcsDatas.RM = col.InnerText;
                            break;
                        case "MZ":
                            simcsDatas.MZ= col.InnerText;
                            break;
                        case "NAZWA":
                            simcsDatas.NAZWA = col.InnerText;
                            break;
                        case "SYM":
                            simcsDatas.SYM = col.InnerText;
                            break;
                        case "SYMPOD":
                            simcsDatas.SYMPOD = col.InnerText;
                            break;
                    }
                }
                simcs.SimcsList.Add(simcsDatas);

            }
            return simcs;
        }

        public UlicList ParserUlic(string _ulicLoc)
        {
            var uXml = new XmlDocument();
            uXml.Load(_ulicLoc);

            var ulics = new UlicList();


            foreach (XmlNode row in uXml.SelectNodes("/teryt/catalog/row"))
            {
                var ulicDatas = new Ulic();
                foreach (XmlNode col in row.SelectNodes("col"))
                {
                    var name = col.Attributes["name"].Value;
                    switch (name)
                    {
                        case "WOJ":
                            ulicDatas.WOJ = col.InnerText;
                            break;
                        case "POW":
                            ulicDatas.POW = col.InnerText;
                            break;
                        case "GMI":
                            ulicDatas.GMI = col.InnerText;
                            break;
                        case "RODZ_GMI":
                            ulicDatas.RODZ_GMI = col.InnerText;
                            break;
                        case "SYM":
                            ulicDatas.SYM = col.InnerText;
                            break;
                        case "SYM_UL":
                            ulicDatas.SYM_UL = col.InnerText;
                            break;
                        case "CECHA":
                            ulicDatas.CECHA= col.InnerText;
                            break;
                        case "NAZWA_1":
                            ulicDatas.NAZWA_1 = col.InnerText;
                            break;
                        case "NAZWA_2":
                            ulicDatas.NAZWA_2 = col.InnerText;
                            break;
                    }
                }
                ulics.UliList.Add(ulicDatas);

            }
            return ulics;
        }

    }
}
