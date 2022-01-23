using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class Greska
    {
        public int GreskaID { get; set; }
        public string greska { get; set; }

        public DateTime VrijemeGreske { get; set; }
    }
}
