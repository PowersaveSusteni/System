using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Susteni.Models.Grunnregister
{
    public class GrunnregisterModel
    {

        public string Overskrift { get; set; }
        public TjenesteItem Tjeneste { get; set; }
        public TjenesteGrupperItem TjenesteGrupper { get; set; }
        public TjenestePrismatriseItem TjenestePrismatrise { get; set; }
        public BankItem Bank { get; set; }
        public BankBrukerItem BankBruker { get; set; }
        public FakturaSystemerItem FakturaSystemer { get; set; }
        public FakturaSerieItem FakturaSerie { get; set; }
        public FakturaTyperItem FakturaTyper { get; set; }
        public SoknItem Sokn { get; set; }
        public TjenesteDimensjonerItem TjenesteDimensjoner { get; set; }
        public DistriktItem Distrikt { get; set; }

        public GrunnregisterModel()
        {
            Overskrift = "Faktura";
            Tjeneste = new TjenesteItem();
            Bank = new BankItem();
            BankBruker = new BankBrukerItem();
            TjenesteGrupper = new TjenesteGrupperItem();
            TjenestePrismatrise = new TjenestePrismatriseItem();
            FakturaSystemer = new FakturaSystemerItem();
            FakturaSerie = new FakturaSerieItem();
            FakturaTyper = new FakturaTyperItem();
            Sokn = new SoknItem();
            TjenesteDimensjoner = new TjenesteDimensjonerItem();
            Distrikt = new DistriktItem();
        }

    }
}
