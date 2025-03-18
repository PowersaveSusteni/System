using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Kontakt
{
    public class KontaktModel
    {
        public KontaktItem Kontakt { get; set; }
        public KontaktItem Fester { get; set; }
        public KontaktForbindelseItem KontaktForbindelse { get; set; }
        public KontaktAbonnementItem KontaktAbonnement { get; set; }
        public KontaktReskontroItem KontaktReskontro { get; set; }
        public KontaktOrdreItem KontaktOrdre { get; set; }
        public KontaktBestillingItem KontaktBestilling { get; set; }
        public KontaktStellItem KontaktStell { get; set; }
        public KontaktAvtaleItem KontaktAvtale { get; set; }

        public KontaktModel()
        {
            Kontakt = new KontaktItem();
            Fester = new KontaktItem();
            KontaktForbindelse = new KontaktForbindelseItem();
            KontaktAbonnement = new KontaktAbonnementItem();
            KontaktReskontro = new KontaktReskontroItem();
            KontaktOrdre = new KontaktOrdreItem();
            KontaktBestilling = new KontaktBestillingItem();
            KontaktStell = new KontaktStellItem();
            KontaktAvtale = new KontaktAvtaleItem();
        }

    }
}
