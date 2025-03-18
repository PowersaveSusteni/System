using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class RessursItem
    {
        public string Fellesraad { get; set; }
        public string RessursGuid { get; set; }
        public int RessursId { get; set; }
        public string KontaktGuid { get; set; }
        public int RessId { get; set; }
        public string BrukerId { get; set; }
        public int ResType { get; set; }
        public string Navn { get; set; }
        public string Fornavn { get; set; }
        public string Mellomnavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string PostNr { get; set; }
        public int Kjonn { get; set; }
        public string Telefon { get; set; }
        public string Telefax { get; set; }
        public string Mobil { get; set; }
        public string Beskrivelse { get; set; }
        public string KortNavn { get; set; }
        public string Stilling { get; set; }
        public bool PaaKal { get; set; }
        public bool Aktiv { get; set; }
        public string DistriktGuid { get; set; }
        public int Sortering { get; set; }
        public int Sortering2 { get; set; }
        public string KardRess { get; set; }
        public int Type { get; set; }
        public int Farge { get; set; }
        public string ReknKode { get; set; }
        public int AntBegrPrDag { get; set; }
        public bool Monte { get; set; }
        public string SoknNr { get; set; }
        public int KardRessId { get; set; }
        public string EPost { get; set; }
        public bool MottaSMS { get; set; }
        public bool MottaEPost { get; set; }
        public string FargeNavn { get; set; }
        public string LabOraMRessGuid { get; set; }
        public int SorteringUt { get; set; }
        public int Sortering2Ut { get; set; }
        public bool VisOppslag { get; set; }
        public bool VisVisning { get; set; }
        public bool Liturg { get; set; }
        public bool Predikant { get; set; }
        public bool TekstLeser { get; set; }
        public bool Organist { get; set; }
        public bool Klokker { get; set; }
        public bool Kirketjener { get; set; }
        public bool Kirkevert { get; set; }
        public bool Saksbehandler { get; set; }
        public string PersonNr { get; set; }
        public bool Nattverdsvert { get; set; }
        public bool Daapsvert { get; set; }
        public bool Hjelper1 { get; set; }
        public bool Hjelper2 { get; set; }
        public bool Hjelper3 { get; set; }
        public bool Hjelper4 { get; set; }
        public string RessursEierGuid { get; set; }
        public int MinAntall { get; set; }
        public int MaksAntall { get; set; }
        public int MaxAntall { get; set; }
        public int AnsvId { get; set; }
        public DateTime Fodt { get; set; }
        public bool Gudstjeneste { get; set; }
        public bool Stasjonskanning { get; set; }
        public bool Gravferd { get; set; }
        public bool Mote { get; set; }
        public bool SyncExchange { get; set; }
        public string Gruppering { get; set; }
        public bool Hjelper5 { get; set; }
        public bool Samtalerom { get; set; }
        public bool Moeterom { get; set; }
        public bool Konserter { get; set; }
        public bool Vielser { get; set; }
        public bool Fagarbeider { get; set; }
        public bool SynkExchangeReadOnly { get; set; }
        public bool LukketKalender { get; set; }
        public int StandardTilgang { get; set; }
        public int GruppeType { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public bool Graver { get; set; }
        public bool Solist { get; set; }
        public bool Kor { get; set; }
        public bool SynkExchange2 { get; set; }
        public bool eKirkebok { get; set; }
        public int KirkeDbId { get; set; }
        public string KalenderGruppe { get; set; }
        public bool Medliturg { get; set; }
        public bool Aktiviet { get; set; }
        public bool Aktivitet { get; set; }
        public DateTime SynkFromDate { get; set; }
        public string GPS { get; set; }
        public string PassordWs { get; set; }
        public bool TilgjengeligWs { get; set; }
        public int PostNrId { get; set; }
        public bool Besok { get; set; }
        public bool SynkExchange { get; set; }
        public int Varmestyring { get; set; }
        public DateTime KjopsDato { get; set; }
        public string Produsent { get; set; }
        public Single Verdi { get; set; }
        public Single Lat { get; set; }
        public Single Long { get; set; }
        public bool Kollekt { get; set; }
        public bool Forsanger { get; set; }
        public bool Andre { get; set; }
        public string Tittel { get; set; }
        public int TypeRessurs { get; set; }
        public string StandardBildeGuid { get; set; }
        public string KirkebyggUrl { get; set; }
        public int Region { get; set; }
        public bool AktivMinMenighet { get; set; }
        public bool TilskrivesBrev { get; set; }
        public bool TilskrivesePost { get; set; }
        public bool TilskrivesSMS { get; set; }
        public bool TilskrivesTelefon { get; set; }
        public int GDPRStatus { get; set; }
        public DateTime SistImpersonated { get; set; }
        public DateTime SistImpersonatedFeilet { get; set; }
        public bool TilgangMinKirkeside { get; set; }
        public int Timer { get; set; }
        public bool VisMobil { get; set; }
        public string MobilNavn { get; set; }
        public string webuserId { get; set; }
        public string Poststed { get; set; }
        public string MappeGuid { get; set; }
        public string MappeNavn { get; set; }
        public string aktivTab { get; set; }
        public bool KalenderByra { get; set; }
        public string[] Bruksomrade { get; set; }
    }

    public class RessursListeItem
    {
        public string RessursGuid { get; set; }
        public string Navn { get; set; }
    }

    public class RessursListeNavnItem
    {
        public string Fellesraad { get; set; }
        public string RessursGuid { get; set; }
        public int RessursId { get; set; }
        public string KontaktGuid { get; set; }
        public int RessId { get; set; }
        public int ResType { get; set; }
        public string Navn { get; set; }
        public string Fornavn { get; set; }
        public string Mellomnavn { get; set; }
        public string Etternavn { get; set; }
        public string Stilling { get; set; }
        public string BoldTekst { get; set; }
        public string BoldTekstColor { get; set; }
        public string NavnStilling { get; set; }
        public string SoknNr { get; set; }
        public string SoknId { get; set; }
    }

    public class RessursNavnItem
    {
        public string Fellesraad { get; set; }
        public string RessursGuid { get; set; }
        public string KontaktGuid { get; set; }
        public int RessId { get; set; }
        public string BrukerId { get; set; }
        public int ResType { get; set; }
        public string Navn { get; set; }
        public string Fornavn { get; set; }
        public string Mellomnavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string PostNr { get; set; }
        public int Kjonn { get; set; }
        public string Telefon { get; set; }
        public string Telefax { get; set; }
        public string Mobil { get; set; }
        public string Beskrivelse { get; set; }
        public string KortNavn { get; set; }
        public string Stilling { get; set; }
        public bool PaaKal { get; set; }
        public bool Aktiv { get; set; }
        public string DistriktGuid { get; set; }
        public int Sortering { get; set; }
        public int Sortering2 { get; set; }
        public string KardRess { get; set; }
        public int Type { get; set; }
        public int Farge { get; set; }
        public string ReknKode { get; set; }
        public int AntBegrPrDag { get; set; }
        public bool Monte { get; set; }
        public string SoknNr { get; set; }
        public int KardRessId { get; set; }
        public string EPost { get; set; }
        public bool MottaSMS { get; set; }
        public bool MottaEPost { get; set; }
        public string FargeNavn { get; set; }
        public string LabOraMRessGuid { get; set; }
        public int SorteringUt { get; set; }
        public int Sortering2Ut { get; set; }
        public bool VisOppslag { get; set; }
        public bool VisVisning { get; set; }
        public bool Liturg { get; set; }
        public bool Predikant { get; set; }
        public bool TekstLeser { get; set; }
        public bool Organist { get; set; }
        public bool Klokker { get; set; }
        public bool Kirketjener { get; set; }
        public bool Kirkevert { get; set; }
        public bool Saksbehandler { get; set; }
        public string PersonNr { get; set; }
        public bool Nattverdsvert { get; set; }
        public bool Daapsvert { get; set; }
        public bool Hjelper1 { get; set; }
        public bool Hjelper2 { get; set; }
        public bool Hjelper3 { get; set; }
        public bool Hjelper4 { get; set; }
        public string RessursEierGuid { get; set; }
        public int MinAntall { get; set; }
        public int MaksAntall { get; set; }
        public int MaxAntall { get; set; }
        public int AnsvId { get; set; }
        public DateTime Fodt { get; set; }
        public bool Gudstjeneste { get; set; }
        public bool Stasjonskanning { get; set; }
        public bool Gravferd { get; set; }
        public bool Mote { get; set; }
        public bool SyncExchange { get; set; }
        public string Gruppering { get; set; }
        public bool Hjelper5 { get; set; }
        public bool Samtalerom { get; set; }
        public bool Moeterom { get; set; }
        public bool Konserter { get; set; }
        public bool Vielser { get; set; }
        public bool Fagarbeider { get; set; }
        public bool SynkExchangeReadOnly { get; set; }
        public bool LukketKalender { get; set; }
        public int StandardTilgang { get; set; }
        public int GruppeType { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public bool Graver { get; set; }
        public bool Solist { get; set; }
        public bool Kor { get; set; }
        public bool SynkExchange2 { get; set; }
        public bool eKirkebok { get; set; }
        public int KirkeDbId { get; set; }
        public string KalenderGruppe { get; set; }
        public bool Medliturg { get; set; }
        public bool Aktiviet { get; set; }
        public bool Aktivitet { get; set; }
        public DateTime SynkFromDate { get; set; }
        public string GPS { get; set; }
        public string PassordWs { get; set; }
        public bool TilgjengeligWs { get; set; }
        public int PostnrId { get; set; }
        public bool Besok { get; set; }
        public bool SynkExchange { get; set; }
        public int Varmestyring { get; set; }
        public DateTime KjopsDato { get; set; }
        public string Produsent { get; set; }
        public Single Verdi { get; set; }
        public Single Lat { get; set; }
        public Single Long { get; set; }
        public bool Kollekt { get; set; }
        public bool Forsanger { get; set; }
        public bool Andre { get; set; }
        public string Tittel { get; set; }
        public int TypeRessurs { get; set; }
        public string StandardBildeId { get; set; }
        public string KirkebyggUrl { get; set; }
        public int Region { get; set; }
        public bool AktivMinMenighet { get; set; }
        public bool TilskrivesBrev { get; set; }
        public bool TilskrivesEPost { get; set; }
        public bool TilskrivesSMS { get; set; }
        public bool TilskrivesTelefon { get; set; }
        public int GDPRStatus { get; set; }
        public DateTime SistImpersonated { get; set; }
        public DateTime SistImpersonatedFeilet { get; set; }
        public bool TilgangMinKirkeside { get; set; }
        public int Timer { get; set; }
        public bool VisMobil { get; set; }
        public string MobilNavn { get; set; }
        public string webuserId { get; set; }
        public bool KalenderByra { get; set; }
        public string[] Bruksomrade { get; set; }
    }

    public class RessursDistriktItem
    {
        public string Fellesraad { get; set; }
        public string DistriktGuid { get; set; }
        public int DistriktId { get; set; }
        public string Distrikt { get; set; }
        public string Tlf { get; set; }
        public string Tider { get; set; }
        public string Leder { get; set; }
        public string EPost { get; set; }
        public string FargeNavn { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
    }

    public class RessursTiderItem
    {
        public string Fellesraad { get; set; }
        public string Tid_GUID { get; set; }
        public string Ress_GUID { get; set; }
        public string FraTid { get; set; }
        public string TilTid { get; set; }
        public bool UkeMan { get; set; } = true;
        public bool UkeTir { get; set; } = true;
        public bool UkeOns { get; set; } = true;
        public bool UkeTor { get; set; } = true;
        public bool UkeFre { get; set; } = true;
        public bool UkeLor { get; set; } = false;
        public bool UkeSon { get; set; } = false;
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public int ManUrne { get; set; } = 0;
        public int TirUrne { get; set; } = 0;
        public int OnsUrne { get; set; } = 0;
        public int TorUrne { get; set; } = 0;
        public int FreUrne { get; set; } = 0;
        public int ManKiste { get; set; } = 0;
        public int TirKiste { get; set; } = 0;
        public int OnsKiste { get; set; } = 0;
        public int TorKiste { get; set; } = 0;
        public int FreKiste { get; set; } = 0;
        public string Program_GUID { get; set; }
    }

    public class MinKirkeAppItem {
        public string RessursGuid { get; set; }
        public string Passord { get; set; }
        public bool Aktiv { get; set; }
        public DateTime FraDato { get; set; }
        public DateTime TilDato { get; set; }
        public bool Bygg { get; set; }
        public bool Medarbeider { get; set; }
        public bool KirkeligeHandlinger { get; set; }
        public bool Profil { get; set; }
        public bool Gravlund { get; set; }
        public bool Delta { get; set; }
    }


    public class RessursInboxItem
    {
        public string Mobil { get; set; }
        public DateTime RegistrertDato { get; set; }
        public string RessursInbox_GUID { get; set; }
        public string Slektsnavn { get; set; }
        public string Postadresse { get; set; }
        public string Postnummer { get; set; }
        public string Poststed { get; set; }
        public DateTime Foedselsdato { get; set; }
        public string Merknad { get; set; }
        public string Epostadresse { get; set; }
        public string RessursFrivilligFunksjonSokn_GUID { get; set; }
        public string FulltNavn { get; set; }
        public string Fornavn { get; set; }
        public string Mellomnavn { get; set; }
        public DateTime ImportertDato { get; set; }
        public DateTime SlettBestillingDato { get; set; }
        public string MMRessursGuid { get; set; }
        public string RegistrertRessursGuid { get; set; }
        public string Tittel { get; set; }
        public string TelefonPrivat { get; set; }
        public string TelefonArbeid { get; set; }
        public string MobilArbeid { get; set; }
        public string EpostadresseArbeid { get; set; }
        public string Timer { get; set; }
        public bool Mandag { get; set; }
        public bool Tirsdag { get; set; }
        public bool Onsdag { get; set; }
        public bool Torsdag { get; set; }
        public bool Fredag { get; set; }
        public bool Lordag { get; set; }
        public bool Sondag { get; set; }
        public bool Formiddag { get; set; }
        public bool Ettermiddag { get; set; }
        public bool Kveld { get; set; }
        public bool Natt { get; set; }
        public string Program_GUID { get; set; }
        public bool Status { get; set; }
        public string Tag { get; set; }
    }

}
