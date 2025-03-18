using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Faktura
{
    public class FakturaModel
    {
        public string Overskrift { get; set; }
        public FakturaItem Faktura { get; set; }
        public FaktureringItem Fakturering { get; set; }
        public FaktureraTjenesterItem FaktureraTjenester { get; set; }  
        public FakturaSkyDatoItem FakturaSkyDato { get; set; }
        public FakturaSkyListeItem FakturaSkyListe { get; set; }
        public FakturaSkyFilItem FakturaSkyFil { get; set; }
        public FakturaLinjeItem FakturaLinje { get; set; }
        public FakturaPurringItem FakturaPurring { get; set; }
        public FesteForfallItem FesteForfall { get; set; }
        public FakturaInnbetalingItem FakturaInnbetaling { get; set; }
        public FakturaBBSItem FakturaBBS { get; set; }
        public FakturaUtskdatoItem FakturaUtskdato { get; set; }
        public FakturaBBSFilItem FakturaBBSFil { get; set; }
        public FakturaPurredatoerItem FakturaPurredatoer { get; set; }

        public FakturaOrdreItem FakturaOrdre { get; set; }
        public FakturaOrdrelinjeItem FakturaOrdrelinje { get; set; }

        public AbonnementTyperItem AbonnementTyper { get; set; }
        public AbonnementItem Abonnement { get; set; }
        public AbonnementInnholdItem AbonnementInnhold { get; set; }

        public FakturaModel()
        {
            Overskrift = "Faktura";
            Faktura = new FakturaItem();
            Fakturering = new FaktureringItem();
            FaktureraTjenester = new FaktureraTjenesterItem();
            FakturaSkyDato = new FakturaSkyDatoItem();
            FakturaSkyListe = new FakturaSkyListeItem();
            FakturaSkyFil = new FakturaSkyFilItem();
            FakturaLinje = new FakturaLinjeItem();
            FakturaPurring = new FakturaPurringItem();
            FakturaPurredatoer = new FakturaPurredatoerItem();
            FesteForfall = new FesteForfallItem();
            FakturaInnbetaling = new FakturaInnbetalingItem();
            FakturaBBSFil = new FakturaBBSFilItem();
            FakturaBBS = new FakturaBBSItem();
            FakturaUtskdato = new FakturaUtskdatoItem();
            FakturaOrdre = new FakturaOrdreItem();
            FakturaOrdrelinje = new FakturaOrdrelinjeItem();

            AbonnementTyper = new AbonnementTyperItem();
            Abonnement = new AbonnementItem();
            AbonnementInnhold = new AbonnementInnholdItem();
        }

    }
}
