using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUSAanalyzer.ModelCsv;

namespace GUSAanalyzer
{
    public class CsvCreator
    {


        public Lokalizacje Create(Models.Teryt teryt, bool useNaturalDistricts)
        {
            var loc = new Lokalizacje
            {
                Wojewodztwa = GetWojewodztwa(teryt)
            };
            loc.Powiaty = GetPowiaty(teryt, loc.Wojewodztwa);
            loc.Gminy = GetGminy(teryt, loc.Powiaty, loc.Wojewodztwa);
            loc.Miejscowosci = GetMiejscowosci(teryt);
            loc.Ulice = GetUlice(teryt, loc.Powiaty, loc.Gminy, loc.Wojewodztwa, loc.Miejscowosci);

            return loc;
        }
      
        private List<Woj> GetWojewodztwa(Models.Teryt teryt)
        {
            var list = new List<Woj>();

            list.AddRange(teryt.TercList.TerList.Where(q => string.IsNullOrWhiteSpace(q.POW)).Select(q => new Woj
            {
                nazwa = q.NAZWA.ToLower(),
                code = q.WOJ
            }));

            return list;
        }
   
        private List<Pow> GetPowiaty(Models.Teryt teryt, List<Woj> wojewodztwa)
        {
            var list = new List<Pow>();

            list.AddRange(teryt.TercList.TerList.Where(q => !string.IsNullOrWhiteSpace(q.POW) && string.IsNullOrWhiteSpace(q.GMI)).Select(q => new Pow
            {
                nazwa = q.NAZWA,
                rodzaj = q.NAZWA_DOD,
                code = q.POW,
                Wojewodztwo = wojewodztwa.Single(r => r.code == q.WOJ),
            
            }));

            return list;
        }

        private List<Gmina> GetGminy(Models.Teryt teryt, List<Pow> powiaty, List<Woj> wojewodztwa)
        {
            var list = new List<Gmina>();

            list.AddRange(teryt.TercList.TerList.Where(q => !string.IsNullOrWhiteSpace(q.GMI)).Select(q => new Gmina
            {
                nazwa = q.NAZWA,
                rodzaj = q.NAZWA_DOD,
                rodzajID = q.RODZ,
                code = q.GMI,
                Powiat = powiaty.Single(r => r.code == q.POW && r.Wojewodztwo.code == q.WOJ),
                Wojewodztwo = wojewodztwa.Single(r => r.code == q.WOJ),
              

            }));

            var cityCommunes = list.Where(q => q.rodzaj == "3").ToList();
            foreach (var gm in cityCommunes)
            {
                list.RemoveAll(q => q.code == gm.code && q.Powiat.code == gm.Powiat.code && q.Powiat.Wojewodztwo.code == gm.Powiat.Wojewodztwo.code && q.rodzajID != "3");
            }

            return list;

        }
      
             private List<Miej> GetMiejscowosci(Models.Teryt teryt)
             {
                 var list = new List<Miej>();

                 list.AddRange(teryt.SimcList.SimcsList.Where(q => q.SYM == q.SYMPOD).Select(q =>new Miej
                 { 
                         nazwa = q.NAZWA,
                         rodzajID = q.RM,
                         code = q.SYM,

                 }));
                 return list;
             }
         
        private List<Ulica> GetUlice(Models.Teryt teryt, List<Pow> powiaty, List<Gmina> gminy, List<Woj> wojewodztwa, List<Miej> miejscowosci)
        {
            var list = new List<Ulica>();

            list.AddRange(teryt.UlicList.UliList.Select(q => new Ulica
            {

                cecha = q.CECHA,
                nazwa1 = q.NAZWA_1,
                nazwa2 = q.NAZWA_2,
                code = q.SYM_UL,
                sym = q.SYM,
                Gmina = gminy.Single(r => r.code == q.GMI && r.Powiat.code == q.POW && r.Wojewodztwo.code == q.WOJ && r.rodzajID == q.RODZ_GMI),
                Powiat = powiaty.Single(r => r.code == q.POW && r.Wojewodztwo.code == q.WOJ),
                Wojewodztwo = wojewodztwa.Single(r => r.code == q.WOJ),

              
        }));
     
            

            return list;
            }
        
    }
}
