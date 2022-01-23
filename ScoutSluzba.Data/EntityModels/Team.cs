using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Naziv { get; set; }
        public string Trener { get; set; }
        public string Stadion { get; set; }
        public string Manager { get; set; }
        public string President { get; set; }
        public string Lokacija { get; set; }


        public Liga Liga { get; set; }
        public int LigaID { get; set; }
    }
}
