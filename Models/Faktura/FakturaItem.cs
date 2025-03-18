using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class FakturaItem
    {
        public string AvsPostNr { get; set; }
        public string Fellesraad { get; set; }
        public int FaktNr { get; set; } = 0;
        public string FakturaGuid { get; set; }
        public string KontoNr { get; set; }
        public string FaktType_GUID { get; set; }
        public string AvsNavn { get; set; }
        public string AvsAdresse1 { get; set; }
        public string AvsAdresse2 { get; set; }
        public string Kontakt_GUID { get; set; }
        public string Kirkegard_GUID { get; set; }
        public string Stell_Guid { get; set; }
        public int OrigFaktNr { get; set; }
        public string OppdragNr { get; set; }
        public int EkstFaktNr { get; set; }
        public string AvsPostSted { get; set; }
        public string VaarRef { get; set; }
        public string KundeNr { get; set; }
        public string PersonNr { get; set; }
        public string Navn { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string PostNr { get; set; }
        public string PostSted { get; set; }
        public string DeresRef { get; set; }
        public string Info { get; set; }
        public DateTime? UtskDato { get; set; }
        public DateTime FaktDato { get; set; }
        public DateTime ForfDato { get; set; }
        public DateTime? BetaltDato { get; set; }
        public DateTime? KredittertDato { get; set; }
        public Single PrisUMVA { get; set; }
        public Single MVA { get; set; }
        public Single PrisMMVA { get; set; }
        public string BChkSum { get; set; }
        public string KID { get; set; }
        public Single Betalt { get; set; }
        public Single Restbelop { get; set; }
        public int BlankettNr { get; set; }
        public int TekstType { get; set; }
        public bool PaVent { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public int PeriodeFra { get; set; }
        public int PeriodeTil { get; set; }
        public bool Tilbud { get; set; }
        public string AxaptaKundeNr { get; set; }
        public DateTime RegBetaltDato { get; set; }
        public string RegAv { get; set; }
        public DateTime RegDato { get; set; }
        public string Bestilling_GUID { get; set; }
        public string OppdrgNr { get; set; }
        public string Kontakt_GUID_View { get; set; }
        public string Kunde_GUID { get; set; }
        public DateTime EksportDato { get; set; }
        public string Kommentar { get; set; }
        public int KredittertFordi { get; set; }
        public bool AutoGiro { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public int EksportNr { get; set; }
        public bool Last { get; set; }
        public int PostNrId { get; set; }
        public bool Sendtinkasso { get; set; }
        public DateTime SistPurretDato { get; set; }
        public int RapUtskNr { get; set; }
        public string Farge { get; set; }
        public string StatusFarge { get; set; }
        public int Status { get; set; }
    }

    public class FakturaUtskdatoItem
    {
        public DateTime Utskdato { get; set; }
    }

    public class FaktureringItem
    {
        public string KontoNr { get; set; }
        public string FaktType_GUID { get; set; }
        public DateTime FaktDato { get; set; }
        public DateTime ForfDato { get; set; }
        public Single PrisUMVA { get; set; }
        public string kundeTekst { get; set; }
        public string Tekst { get; set; }
        public int TjenesteNr { get; set; }
        public string KundeGuidListe { get; set; }
        public List<FaktureraTjenesterItem> Tjenester { get; set; }
    }

    public class FaktureraTjenesterItem
    {
        public int TjenesteNr { get; set; }
        public string Tekst { get; set; }
        public Single PrisuMVA { get; set; }
    }

    public class FakturaLinjeItem
    {
        public string Fellesraad { get; set; }
        public int FaktNr { get; set; }
        public string KontoNr { get; set; }
        public string FakturaLinje_GUID { get; set; }
        public string FaktType_GUID { get; set; }
        public string Kirkegard_GUID { get; set; }
        public string Grav_GUID { get; set; }
        public bool FesteFornying { get; set; }
        public int FornyTilAar { get; set; }
        public int LopeNr { get; set; }
        public int Sortering { get; set; }
        public int TjenesteNr { get; set; }
        public string Enhet { get; set; }
        public string VareHedder { get; set; }
        public string VareTekst { get; set; }
        public Single Antall { get; set; }
        public bool MomsKode { get; set; }
        public Single MVA { get; set; }
        public Single PrisUMVA { get; set; }
        public Single PrisMMVA { get; set; }
        public Single PrisPrUMVA { get; set; }
        public int FaktLType { get; set; }
        public string Dim1 { get; set; }
        public string Dim2 { get; set; }
        public string Dim3 { get; set; }
        public string Dim4 { get; set; }
        public string Dim5 { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Innskudd_GUID { get; set; }
        public int FornyFraAar { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string Dim6 { get; set; }
        public int Rabatt { get; set; }
    }

    public class FakturaPurringItem
    {
        public string Fellesraad { get; set; }
        public int FaktNr { get; set; }
        public string KontoNr { get; set; }
        public int PurreNr { get; set; }
        public DateTime PurreDato { get; set; }
        public DateTime UtskDato { get; set; }
        public DateTime ForfDato { get; set; }
        public string PurreTekst { get; set; }
        public int TekstType { get; set; }
        public string Navn { get; set; }
        public DateTime FaktDato { get; set; }
        public string FakturaPurringGuid { get; set; }
        public int Status { get; set; }
    }

    public class FakturaPurredatoerItem
    {
        public DateTime PurreDato { get; set; }
        public DateTime? UtskDato { get; set; }
    }

    public class FakturaSkyFilItem
    {
        public DateTime Dato { get; set; }
        public string Filnavn { get; set; }
        public bool Highlight { get; set; }

    }
    public class FakturaSkyDatoItem
    {
        public string Fellesraad { get; set; }
        public int EksportNr { get; set; }
        public string Dato { get; set; }
        public string BrukerId { get; set; }
    }

    public class FakturaSkyListeItem
    {
        public int FaktNr { get; set; }
        public int KundeNr { get; set; }
        public string Navn { get; set; }
        public string PostNr { get; set; }
        public DateTime FaktDato { get; set; }
        public DateTime ForfDato { get; set; }
        public DateTime KredittertDato { get; set; }
        public Single PrisMMVA { get; set; }
        public string Fellesraad { get; set; }
        public bool PaVent { get; set; }
        public string Beskrivelse { get; set; }
        public string PersonNr { get; set; }
        public int Antall { get; set; }
    }

    public class FakturaInnbetalingItem
    {
        public string Fellesraad { get; set; }
        public string FaktInnbetal_GUID { get; set; }
        public int FaktNr { get; set; }
        public string KontoNr { get; set; }
        public DateTime IDato { get; set; }
        public Single Belop { get; set; }
        public string Kommentar { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string LoggInfo { get; set; }
    }

    public class FakturaBBSFilItem
    {
        public string Fellesraad { get; set; }
        public string BBSFiler_GUID { get; set; }
        public string FilNavn { get; set; }
        public DateTime FilDato { get; set; }
        public string ForsNr { get; set; }
        public int AntTrans { get; set; }
        public int AntRec { get; set; }
        public Single Sum { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
    }

    public class FakturaBBSItem
    {
        public string BBSRes_GUID { get; set; }
        public string Fellesraad { get; set; }
        public string BBSFiler_GUID { get; set; }
        public int OppdragNr { get; set; }
        public Single BetBelop { get; set; }
        public string Kid { get; set; }
        public int ArkivRef { get; set; }
        public string OppdragsKonto { get; set; }
        public string DebKonto { get; set; }
        public DateTime OppdDato { get; set; }
        public int Status { get; set; }
        public DateTime BetDato { get; set; }
        public string ForsNr { get; set; }
        public int LopeNr { get; set; }
        public string Fritekst { get; set; }
        public DateTime OppgjDato { get; set; }
        public string Ref { get; set; }
        public bool Utskrift { get; set; }
        public DateTime RegDato { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string StatusTekst { get; set; }
    }
 
    public class FesteForfallItem
    {
        public string KirkegardNavn { get; set; }
        public string Fellesraad { get; set; }
        public string Grav_GUID { get; set; }
        public string Kirkegard_GUID { get; set; }
        public string Gravsted_GUID { get; set; }
        public int Type { get; set; }
        public int Laast { get; set; }
        public int ForfallMnd { get; set; }
        public string MappeId { get; set; }
        public string Mappe_GUID { get; set; }
        public bool Historikk { get; set; }
        public int AntallGravlagte { get; set; }
        public int ForfallAar { get; set; }
        public string SistGravlagt { get; set; }
        public string Plassering { get; set; }
        public DateTime FDato { get; set; }
        public DateTime DDato { get; set; }
        public DateTime GDato { get; set; }
        public int UrneRekke { get; set; }
        public bool ErUrnefelt { get; set; }
        public Single Areal { get; set; }
        public string FulltNavn { get; set; }
        public string PersonNr { get; set; }
        public string PostNr { get; set; }
        public bool ErDod { get; set; }
        public string FakturaMottaker_GUID { get; set; }
        public bool Faktureres { get; set; }
        public int PeriodeFra { get; set; }
        public int PeriodeTil { get; set; }
        public string Tekst { get; set; }
        public Single Antall { get; set; }
        public Single PrisPr { get; set; }
        public Single Pris { get; set; }
        public DateTime? OpprettetDato { get; set; }
        public int Status { get; set; }
        public string FesteTilbud_GUID { get; set; }
        public string Beskrivelse { get; set; }
    }

    public class FakturaOrdreItem
    {
        public DateTime OrdreDato { get; set; }
        public string Fellesraad { get; set; }
        public string OrdreGuid { get; set; }
        public int OrdreNr { get; set; }
        public string BildeGuid { get; set; }
        public string LinkGuid { get; set; }
        public string KontaktGuid { get; set; }
        public string KontaktNavn { get; set; }
        public DateTime? UtfInnenDato { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime? UtfortDato { get; set; }
        public int FaktNr { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public int Modul { get; set; }
        public string KontoNr { get; set; }
        public string infoBestilling { get; set; }
    }

    public class FakturaOrdrelinjeItem
    {
        public bool MomsKode { get; set; }
        public string Fellesraad { get; set; }
        public string OrdreLinjeGuid { get; set; }
        public string OrdreGuid { get; set; }
        public int TjenesteNr { get; set; }
        public Single Antall { get; set; }
        public Single PrisUMVA { get; set; }
        public Single PrisMMVA { get; set; }
        public string Tekst { get; set; }
        public Single MVA { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public Single PrisPr { get; set; }
        public string Enhet { get; set; }
    }

    public class AbonnementTyperItem
    {
        public string Konto { get; set; }
        public string Fellesraad { get; set; }
        public string AbbFaktType_GUID { get; set; }
        public string Beskrivelse { get; set; }
        public int IntervallType { get; set; }
        public int Intervall { get; set; }
        public DateTime NesteFaktDato { get; set; }
        public int Id { get; set; }
        public string MottakerNavn { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string PostNr { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public int PostNrId { get; set; }
        public bool Publiser { get; set; }
        public string Forklaring { get; set; }
        public int Tjenestenummer { get; set; }
        public string Betingelser { get; set; }
        public int AbonnementType { get; set; }
        public string Program_GUID { get; set; }
    }

    public class AbonnementItem
    {
        public string Abbonement_GUID { get; set; }
        public string FulltNavn { get; set; }
        public string Adresse { get; set; }
        public string PostNr { get; set; }
        public string Sted { get; set; }
        public Single Pris { get; set; }
        public bool MidlertidigStop { get; set; }
        public string Kontakt_GUID { get; set; }
    }

    public class AbonnementInnholdItem
    {
        public string AbbonementInnhold_GUID { get; set; }
        public int TjenesteNr { get; set; }
        public Single Antall { get; set; }
        public string Fellesraad { get; set; }
        public string Abbonement_GUID { get; set; }
        public int Rabatt { get; set; }
        public int Pris { get; set; }
        public string Info { get; set; }
        public string Tekst { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Program_GUID { get; set; }
    }

}
