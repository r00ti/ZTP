using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUSAanalyzer.Models
{
    public class Simc
    {
        public string WOJ { get; set; }
        public string POW { get; set; }
        public string GMI { get; set; }
        public string RODZ_GMI { get; set; }
        public string RM { get; set; }
        public string MZ { get; set; }
        public string NAZWA { get; set; }
        public string SYM { get; set; }
        public string SYMPOD { get; set; }
        public string STAN_NA { get; set; }
    }
   
}
/*
      <WOJ>14</WOJ>
      <POW>32</POW>
      <GMI>01</GMI>
      <RODZ_GMI>5</RODZ_GMI>
      <RM>01</RM>
      <MZ>1</MZ>
      <NAZWA>Białutki</NAZWA>
      <SYM>0000017</SYM>
      <SYMPOD>0000017</SYMPOD>
      <STAN_NA>2017-01-01</STAN_NA>
    */
