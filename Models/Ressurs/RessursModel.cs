using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Ressurs
{
    public class RessursModel
    {
        public string Overskrift { get; set; }

        public RessursItem Ressurs { get; set; }
        public RessursItem RessursRom { get; set; }
        public RessursListeNavnItem RessursListeNavn { get; set; }
        public RessursNavnItem RessursNavn { get; set; }
        public RessursDistriktItem RessursDistrikt { get; set; }
        public RessursTiderItem RessursTider { get; set; }
        public RessursInboxItem RessursInbox { get; set; }
        public MinKirkeAppItem MinKirkeApp { get; set; }

        public RessursModel()
        {
            Overskrift = "Ressurs";
            Ressurs = new RessursItem();
            RessursRom = new RessursItem();
            RessursListeNavn = new RessursListeNavnItem();
            RessursNavn = new RessursNavnItem();
            RessursDistrikt = new RessursDistriktItem();
            RessursTider = new RessursTiderItem();
            RessursInbox = new RessursInboxItem();
            MinKirkeApp = new MinKirkeAppItem();
        }
    }

}
