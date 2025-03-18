using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class RolleItem
    {
        public string Fellesraad { get; set; }
        public string RolleGuid { get; set; }
        public string RolleNavn { get; set; }
        public int RolleType { get; set; }
        public string RolleTypeNavn { get; set; }
        public int Aktiviteter { get; set; }
        public int Ansattreg { get; set; }
        public int Bestilling { get; set; }
        public int Daap { get; set; }
        public int Konfirmasjon { get; set; }
        public int Vielse { get; set; }
        public int Gudstjeneste { get; set; }
        public bool Statistikk { get; set; }
        public int BesokTjeneste { get; set; }
        public int Frivillige { get; set; }
        public int Innmelding { get; set; }
        public int Gravregister { get; set; }
        public int Kontakt { get; set; }
        public int Fakturering { get; set; }
        public int Stell { get; set; }
        public int BestillingEnkel { get; set; }
        public int Endringslogg { get; set; }
        public int Kart { get; set; }
        public int Ordre { get; set; }
        public int BestillingKremasjon { get; set; }
        public bool Medlemsregister { get; set; }
        public int Nyhet { get; set; }
        public int Meny { get; set; }
        public int Dokument { get; set; }
        public int Bilde { get; set; }
        public int Menighetsblad { get; set; }
        public int Linker { get; set; }
        public int Lister { get; set; }
        public int Spalter { get; set; }
        public int SMS { get; set; }
        public int Folkeregister { get; set; }
        public bool Avholdt { get; set; }
        public bool GDPRansvarlig { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public bool Innbetaling { get; set; }
        public bool Okonomi { get; set; }
    }
      
    public class BrukerItem
    {
        public string BrukerId { get; set; } = "";
        public string Passord { get; set; } = "";
        public DateTime? FraDato { get; set; }
        public DateTime? TilDato { get; set; }
        public bool ModulMedarbeider { get; set; }
        public bool ModulKH { get; set; }
        public bool ModulByra { get; set; }
        public bool ModulGravplass { get; set; }
        public bool ModulEngrafo { get; set; }
        public bool ModulOkonomi { get; set; }
        public bool ModulStatistikk { get; set; }
        public bool ModulGrunnregister { get; set; }
        public bool ModulKisteskanning { get; set; }
        public bool ModulKrematorium { get; set; }
        public bool ModulBygg { get; set; }
        public bool ModulkWeb { get; set; }
        public bool ModulAdmin { get; set; }
        public string Fellesraad { get; set; }
        public string BrukerGuid { get; set; }
        public string RessursGuid { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Etternavn { get; set; }
        public string Fornavn { get; set; }
        public string FulltNavn { get; set; }
        public string Kontakt_GUID { get; set; }
        public bool BestilingVarsler { get; set; }
        public bool AutoUpdate { get; set; }
        public bool SuperBruker { get; set; }
        public string SoknId { get; set; }
        public bool NhGtj { get; set; }
        public bool NhDåp { get; set; }
        public bool NhKon { get; set; }
        public bool NhVie { get; set; }
        public bool NhGrf { get; set; }
        public bool NhAkt { get; set; }
        public bool NhFri { get; set; }
        public bool NhBes { get; set; }
        public bool NhKal { get; set; }
        public bool NhGGen { get; set; }
        public bool NhGGfd { get; set; }
        public bool NhGStl { get; set; }
        public bool NhGOko { get; set; }
        public bool NhGma { get; set; }
        public int AktivFakturaNrSerie { get; set; }
        public bool HarEpost { get; set; }
        public string DomainUser { get; set; }
        public string DomainPassword { get; set; }
        public bool EWSKalender { get; set; }
        public bool Alfa { get; set; }
        public bool Beta { get; set; }
        public bool SkjulInfo { get; set; }
        public string EWSepost { get; set; }
        public int AutNiva { get; set; }
        public string AktivFellesraad { get; set; }
        public string AktivKonfirmantKull { get; set; }
        public string nBrukerGuid { get; set; }
        public string aktivTab { get; set; } = "tabGenerell";
        public bool Aktiv { get; set; }
        public string FargeNavn { get; set; }
        public int visId { get; set; }
        public string url { get; set; }
    }

    public class BrukerRolleItem
    {
        public string RolleGuid { get; set; }
        public string Navn { get; set; }
        public string SoknId { get; set; }
        public string BrukerId { get; set; }
        public string RolleNavn { get; set; }
        public int RolleType { get; set; }
        public string RolleTypeNavn { get; set; }
        public bool Aktiv { get; set; }
        public DateTime FraDato { get; set; }
        public DateTime? TilDato { get; set; }
    }

    public class BrukerTilgangItem
    {
        public string Fellesraad { get; set; }
        public string SoknNr { get; set; }
        public string BrukerId { get; set; }
        public string SoknId { get; set; }
        public bool ADM { get; set; }
        public bool AKTIVITETER_R { get; set; }
        public bool AKTIVITETER_W { get; set; }
        public bool ANSATTREG_R { get; set; }
        public bool ANSATTREG_W { get; set; }
        public bool BIBLIOTEK { get; set; }
        public bool DOED_R { get; set; }
        public bool DOED_W { get; set; }
        public bool DAAP_R { get; set; }
        public bool DAAP_W { get; set; }
        public bool GUDSTJENESTE_R { get; set; }
        public bool GUDSTJENESTE_W { get; set; }
        public bool INNUTMELDING_R { get; set; }
        public bool INNUTMELDING_W { get; set; }
        public bool KONFIRMASJON_R { get; set; }
        public bool KONFIRMASJON_W { get; set; }
        public bool ARKIV_DOK_R { get; set; }
        public bool ARKIV_DOK_W { get; set; }
        public bool ARKIV_SAK_R { get; set; }
        public bool ARKIV_SAK_W { get; set; }
        public bool ARKIV_MOTE_R { get; set; }
        public bool ARKIV_MOTE_W { get; set; }
        public bool TIDSPLAN_ROM_R { get; set; }
        public bool TIDSPLAN_ROM_W { get; set; }
        public bool TIDSPLAN_PERS_R { get; set; }
        public bool TIDSPLAN_PERS_W { get; set; }
        public bool TIDSPLAN_GUDSTJENESTE { get; set; }
        public bool VIELSE_R { get; set; }
        public bool VIELSE_W { get; set; }
        public bool FASTE_DATA_R { get; set; }
        public bool FASTE_DATA_W { get; set; }
        public bool AVHOLDT { get; set; }
        public bool MEDLEMSREG { get; set; }
        public bool TIDSPLAN_GUDSTJENESTE_W { get; set; }
        public bool STANDARD_KLIENT { get; set; }
        public bool FRIVILLIGREG_R { get; set; }
        public bool FRIVILLIGREG_W { get; set; }
        public bool SMS { get; set; }
        public bool Sentralbord { get; set; }
        public bool RaadUtvalg { get; set; }
        public bool GudstjenesteAdm { get; set; }
        public bool Adresering { get; set; }
        public bool Folkeregister { get; set; }
        public string Ressurs_GUID { get; set; }
        public string DB_PASSORD { get; set; }
        public string DB_BRUKERNAVN { get; set; }
        public string ADRESSE_INFO { get; set; }
        public string SPRAAK { get; set; }
        public string PRESTEGJELD_ID { get; set; }
        public string KLIENT_NAVN { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public bool Konfirmasjon_S { get; set; }
        public bool Frivilligreg_S { get; set; }
        public bool Aktiviteter_U { get; set; }
        public bool Aktiviteter_A { get; set; }
        public bool BesokTj_L { get; set; }
        public bool BesokTj_S { get; set; }
        public bool BesokTj_U { get; set; }
        public bool Innutmelding_A { get; set; }
        public bool Daap_A { get; set; }
        public bool Konfirmasjon_A { get; set; }
        public bool GDPRansvarlig { get; set; }
        public bool Bank { get; set; }
        public bool BesokTjeneste { get; set; }
        public string Program_GUID { get; set; }
        public string BrukerTilgangGuid { get; set; }
    }

    public class KalenderTilgangTypeItem
    {
        public int Tilgang { get; set; }
        public string Navn { get; set; }
    }

    public class KalenderTilgangerItem
    {
        public string RessursGuid { get; set; }
        public string Navn { get; set; }
        public string Tilgang { get; set; }
    }


}
