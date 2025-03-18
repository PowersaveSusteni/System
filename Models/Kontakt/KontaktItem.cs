using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class KontaktItem
    {
        public string Fellesraad { get; set; }
        public string KontaktGuid { get; set; }
        public int ID { get; set; }
        public bool ErKontakt { get; set; }
        public bool FakturaEpost { get; set; }
        public string FakturaEpostAdresse { get; set; }
        public int Pub360RecNo { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string KundeNr { get; set; }
        public string PersonNr { get; set; }
        public DateTime Fodt { get; set; }
        public string FulltNavn { get; set; }
        public string Fornavn { get; set; }
        public string Mellomnavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string PostNr { get; set; }
        public string Sted { get; set; }
        public string KommuneNr { get; set; }
        public string KommuneNavn { get; set; }
        public string Telefon { get; set; }
        public string TlfArb { get; set; }
        public string Mobil { get; set; }
        public string Fax { get; set; }
        public string EPost { get; set; }
        public string BostedAdresse { get; set; }
        public string BostedPostNr { get; set; }
        public string BostedSted { get; set; }
        public int TypeKunde { get; set; }
        public int DagerForfall { get; set; }
        public bool ErDod { get; set; }
        public string KortNavn { get; set; }
        public string Kommentar { get; set; }
        public string FodeSted { get; set; }
        public int ChkType { get; set; }
        public DateTime ChkDate { get; set; }
        public DateTime SistEndretdato { get; set; }
        public int SistEndringType { get; set; }
        public bool IkkeSjekk { get; set; }
        public string SlektsnavnUgift { get; set; }
        public string SoknNr { get; set; } = "";
        public int TypeKontakt { get; set; }
        public int Program { get; set; }
        public DateTime DapsDato { get; set; }
        public bool MottaEpost { get; set; }
        public string TrossamfunnGuid { get; set; }
        public string DåpsSted { get; set; }
        public int SivStatId { get; set; }
        public int Kjonn { get; set; }
        public int PostNrId { get; set; }
        public string aktivTab { get; set; } = "tabKontaktinformasjon";
        public string aktivTabBunn { get; set; } = "tabGraver";
    }

    public class KontaktForbindelseItem
    {
        public string Kontakt_GUID { get; set; }
        public string FulltNavn { get; set; }
        public string Forbindelse { get; set; }
        public int KundeType { get; set; }
    }

    public class KontaktAvtaleItem
    {
        public string Plassering { get; set; }
        public string Tekst { get; set; }
        public string PeriodeFra { get; set; }
        public string PeriodeTil { get; set; }
        public string FaktNr { get; set; }
        public DateTime? BetaltDato { get; set; }
        public Single Pris { get; set; }
        public string Kontakt_GUID { get; set; }
    }

    public class KontaktStellItem
    {
        public string Fellesraad { get; set; }
        public string StellAvtale_Guid { get; set; }
        public int StellAvtaleNr { get; set; }
        public string BankId { get; set; }
        public string Kontakt_GUID { get; set; }
        public string Kode { get; set; }
        public int StellType { get; set; }
        public string StellNavn { get; set; }
        public int KontraktType { get; set; }
        public DateTime StartDato { get; set; }
        public int AntallAar { get; set; }
        public int Status { get; set; }
        public int StatusHvorfor { get; set; }
        public Single Saldo { get; set; }
        public DateTime? AvsluttetDato { get; set; }
        public bool Avsluttet { get; set; }
    }

    public class KontaktBestillingItem
    {
        public string Bestilling_GUID { get; set; }
        public string FulltNavn { get; set; }
        public DateTime? AvlFodd { get; set; }
        public DateTime? AvlDod { get; set; }
        public string Kirkegard { get; set; }
        public int BestillingNr { get; set; }
    }

    public class KontaktOrdreItem
    {
        public string Ordre_GUID { get; set; }
        public DateTime OrdreDato { get; set; }
        public DateTime? UtfInnenDato { get; set; }
        public string Beskrivelse { get; set; }
        public string FulltNavn { get; set; }
        public string Kontakt_GUID { get; set; }
    }

    public class KontaktReskontroItem
    {
        public string Fellesraad { get; set; }
        public int FaktNr { get; set; }
        public string FaktType_GUID { get; set; }
        public string Kontakt_GUID { get; set; }
        public int OrigFaktNr { get; set; }
        public DateTime FaktDato { get; set; }
        public DateTime? KredittertDato { get; set; }
        public Single? Inn { get; set; }
        public Single? Ut { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime? PurreDato { get; set; }
        public int? PurreNr { get; set; }
        public DateTime? BetaltDato { get; set; }
        public string KontoNr { get; set; }
        public string Kontakt_GUID_View { get; set; }
        public bool Tilgang { get; set; }
        public string Ikon { get; set; }
    }

    public class KontaktAbonnementItem
    {
        public string Fellesraad { get; set; }
        public string Abbonement_GUID { get; set; }
        public string Kontakt_GUID { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime OpprettetDato { get; set; }
        public DateTime? OpphørtDato { get; set; }
        public bool MidlertidigStop { get; set; }
    }

}
