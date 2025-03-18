using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Susteni.Models
{

    public class KalenderHuskelisteItem
    {
        public int Maned { get; set; }
        public int Dag { get; set; }
        public DateTime StartDato { get; set; }
        public string StartTid { get; set; }
        public string SluttTid { get; set; }
        public string RessursTekst { get; set; }
        public string Emne { get; set; }
    }

    public class KalenderAvtalerItem
    {
        public string KalenderTiderGuid { get; set; }
        public string Fellesraad { get; set; }
        public string KalenderGuid { get; set; }
        public string Emne { get; set; }
        public string Lokasjon { get; set; }
        public string Plassering { get; set; }
        public string Tekst { get; set; }
        public string Info { get; set; }
        public int Prioritet { get; set; }
        public bool Privat { get; set; }
        public bool Access { get; set; }
        public bool Byraa { get; set; }
        public int Modul { get; set; }
        public string StengHva { get; set; }
        public string EierGuid { get; set; }
        public bool UnngåHelligdag { get; set; }
        public bool Invitasjon { get; set; }
        public bool Varsling { get; set; }
        public string RessursTekst { get; set; }
        public string KontaktGuid { get; set; }
        public bool SynkExchange { get; set; }
        public bool SyncExchange { get; set; }
        public bool PubliserWeb { get; set; }
        public bool Varmestyring { get; set; } = true;
        public int StatusId { get; set; } = 1;
        public string SynkAv { get; set; }
        public bool IsCancelled { get; set; }
        public int Laast { get; set; }
        public bool KollisjonSjekk { get; set; }
        public DateTime StartDato { get; set; }
        public string StartTid { get; set; }
        public DateTime SluttDato { get; set; }
        public string SluttTid { get; set; }
        public bool PaaMin { get; set; }
        public int PaaMinTid { get; set; }
        public int Monster { get; set; }
        public int Dager { get; set; }
        public int DagInt { get; set; }
        public int UkeInt { get; set; }
        public bool UkeMan { get; set; }
        public bool UkeTir { get; set; }
        public bool UkeOns { get; set; }
        public bool UkeTor { get; set; }
        public bool UkeFre { get; set; }
        public bool UkeLor { get; set; }
        public bool UkeSon { get; set; }
        public DateTime MonsterStartDato { get; set; }
        public DateTime MonsterStopDato { get; set; }
        public bool UtenStopp { get; set; }
        public string AnsvarligRessursGuid { get; set; }
        public string KalenderTiderEier { get; set; }
        public bool IgnorerHelligdager { get; set; }
        public int AntallRepiteringer { get; set; }
        public int MndPattern { get; set; }
        public int MndDato { get; set; }
        public int MndDatoIntervall { get; set; }
        public int MndUke { get; set; }
        public int MndDag { get; set; }
        public int MndDagIntervall { get; set; }
        public int AarInt { get; set; }
        public int AarDag { get; set; }
        public int AarMnd { get; set; }
        public int PreTid { get; set; }
        public int PostTid { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SluttTidspunkt { get; set; }
        public string RessursGuidTekst { get; set; }
        public string RessursIdTekst { get; set; }
        public string KalenderUnntak { get; set; }
        public string SluttType { get; set; }
        public int Tilgang { get; set; }
        public string Fornavn { get; set; }
        public string Mellomnavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string PostNr { get; set; }
        public string Sted { get; set; }
        public bool Utleie { get; set; }
        public bool UtleieGodkjent { get; set; }
        public string GodkjentAv { get; set; }
        public DateTime GodkjentDato { get; set; }
        public Single UtleiePris { get; set; }
        public string LeierKontaktGuid { get; set; }
        public string Etiketter { get; set; }
        public string StedRessursGuid { get; set; }
        public bool SkjerIKirken { get; set; }  
        public string LinkGuid { get; set; }
        public List<KalenderEtikettItem> Etikettliste { get; set;}
    }

    public class KalenderDatoerItem
    {
        public DateTime StartDate { get; set; }
    }

    public partial class MeetingAttendee
    {
        public string MeetingID { get; set; }
        public int AttendeeID { get; set; }

        public virtual Meeting Meeting { get; set; }
    }

    public class KalenderGruppeItem
    {
        public string Fellesraad { get; set; }
        public string SoknNr { get; set; }
        public string RessursGruppeGuid { get; set; }
        public string Navn { get; set; }
        public bool Aktiv { get; set; }
        public string Eier { get; set; }
        public bool Privat { get; set; }
        public int Type { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
    }

    public class KalenderRessursItem
    {
        public string RessursGuid { get; set; }
        public int RessursId { get; set; }
        public string Navn { get; set; }
        public string EierNavn { get; set; }
        public string Farge { get; set; }
        public int ResType { get; set; }
        public string Type { get; set; }
        public string GruppeNavn { get; set; }
        public int Sortering { get; set; }
        public string RessursEierGuid { get; set; }
        public bool Checked { get; set; }
        public string FargeNavn { get; set; }
        public bool HarBarn { get; set; }
    }

    public class KalenderRessurserItem
    {
        public string Fellesraad { get; set; }
        public string KalenderGuid { get; set; }
        public string RessursGuid { get; set; }
        public int ResType { get; set; }
        public string Navn { get; set; }
        public string Stilling { get; set; }
    }

    public class HierarchicalKalenderItem
    {
        public string ID { get; set; }
        public string SoknId { get; set; }
        public string ParentID { get; set; }
        public string Text { get; set; }
        public string EierNavn { get; set; }
        public bool HasChildren { get; set; }
        public bool Expanded { get; set; }
        public string ImageUrl { get; set; }
        public bool checkedFiles { get; set; }
        public bool IsChecked { get; set; }
        public bool @checked { get; set; }
        public string ColorName { get; set; }
        public int ResType { get; set; }
    }

    public class HierarchicalTjenesteItem
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string Text { get; set; }
        public bool HasChildren { get; set; }
        public bool Expanded { get; set; }
        public string ImageUrl { get; set; }
        public string ColorName { get; set; }
        public int TjenesteNr { get; set; }
 
    }

    public class HierarchicalBankItem
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string Text { get; set; }
        public bool HasChildren { get; set; }
        public bool Expanded { get; set; }
        public string ImageUrl { get; set; }
        public string ColorName { get; set; }
        public int FakturaSerieNr { get; set; }
        public string Type { get; set; }
    }


    public class KalenderAttentiesItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Color { get; set; }
    }

    public class KalenderEtikettItem
    {
        public string Fellesraad { get; set; }
        public string EtikettGuid { get; set; }
        public string Navn { get; set; }
        public string Farge { get; set; }
        public bool Kollisjonssjekk { get; set; }
        public string Prefiks { get; set; }
        public int PreTid { get; set; }
        public int PostTid { get; set; }
        public string KalenderGuid { get; set; }
        public string base64string { get; set; }
    }


    public class EtikettItem
    {
        public string Fellesraad { get; set; }
        public string EtikettGuid { get; set; }
        public string Navn { get; set; }
        public string Farge { get; set; }
        public bool Kollisjonssjekk { get; set; }
        public string Prefiks { get; set; }
        public int PreTid { get; set; }
        public int PostTid { get; set; }
        public string MedarbeiderEtikettGuid { get; set; }
        public int Modul { get; set; }
        public int Varighet { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public bool Fri { get; set; }
        public bool System { get; set; }
        public bool Tjenesteuke { get; set; }
        public string LabEtikettColor { get; set; }
        public string base64string { get; set; }
    }

    public partial class Meeting
    {
        //public Meeting()
        //{
        //    MeetingAttendees = new HashSet<MeetingAttendee>();
        //}

        public string MeetingID { get; set; }
        public string Description { get; set; }
        public string RessursTekst { get; set; }
        public int RessursType { get; set; }
        public string BestillingGuid { get; set; }
        public bool IkkeOppgis { get; set; }
        public string Image { get; set; }
        public string Etiketter { get; set; }
        public bool Varmestyring { get; set; }
        public int StatusId { get; set; }
        public int Modul { get; set; }
        public DateTime End { get; set; }
        public string EndTimezone { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceException { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceRule { get; set; }
        public string RoomID { get; set; }
        public DateTime Start { get; set; }
        public string StartTimezone { get; set; }
        public string Title { get; set; }
        public bool Access { get; set; }
        public bool Privat { get; set; }

        //public virtual ICollection<MeetingAttendee> MeetingAttendees { get; set; }
        public IEnumerable<string> Attendees { get; set; }
        public virtual Meeting Recurrence { get; set; }
        public virtual ICollection<Meeting> InverseRecurrence { get; set; }
        public List<KalenderEtikettItem> Etikettliste { get; set; }

    }

    public class KalenderRessurserListeItem
    {
        public string Fellesraad { get; set; }
        public string KalenderRessursGuid { get; set; }
        public string KalenderGuid { get; set; }
        public string Type { get; set; }
        public int Sortering { get; set; }
        public string Navn { get; set; }
        public string RessursGuid { get; set; }
        public string EPost { get; set; }
        public string Mobil { get; set; }
        public int ResType { get; set; }
    }

    public class HelligdagerItem
    {
        public DateTime Dato { get; set; }
        public string Farge { get; set; }
        public bool Hoytidsdag { get; set; }
    }

}
