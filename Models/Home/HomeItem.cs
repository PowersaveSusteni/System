using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Susteni.Models
{



    public class HomeNyhetItem
    {
        public int KategoriId { get; set; }
        public string NyhetGUID { get; set; }
        public DateTime Dato { get; set; }
        public string Tittel { get; set; }
        public string Nyhet { get; set; }
        public string YouTubeId { get; set; }
        public string LinkId { get; set; }
        public string Picture { get; set; }
        public string Fellesraad { get; set; }
        public string FellesraadNavn { get; set; }
        public int Program { get; set; }
        public int Leverandor { get; set; }
        public string Forfatter { get; set; }
        public string Ingress { get; set; }
    }

    public class FakturaStatusItem
    {
        public int Tid { get; set; }
        public Single Sum { get; set; }
        public string Periode { get; set; }
    }




}
