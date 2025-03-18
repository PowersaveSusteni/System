using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{

    public class HelpDeskItem
    {
        public string? HelpDeskGuid { get; set; }
        public int TiketId { get; set; } = 0;
        public int Program { get; set; } = 0;
        public string? Modul { get; set; }
        public string? Skjermbilde { get; set; }
        public DateTime? OpprettetDato { get; set; }
        public string? OpprettetAv { get; set; }
        public string? OpprettetDatoTekst { get; set; }
        public int Prioritet { get; set; } = 0;
        public string Tittel { get; set; } = "";
        public string? Beskrivelse { get; set; }
        public string? Losning { get; set; }
        public string? BrukerId { get; set; }
        public string? BrukerNavn { get; set; }
        public string? Fellesraad { get; set; }
        public string? Kunde { get; set; }
        public DateTime? StartDato { get; set; }
        public DateTime? Ferdig { get; set; }
        public DateTime? Aksept { get; set; }
        public string? FerdigDatoTekst { get; set; }
        public int Status { get; set; } = 0;
        public string? StatusTekst { get; set; }
        public string? Farge { get; set; }
        public bool bold { get; set; } = false;
        public int TypeId { get; set; } = 1;
        public string? TypeNavn { get; set; }
        public string? Program_GUID { get; set; }
        public string? Saksbehandler { get; set; }
        public string? ePostAdresse { get; set; }
        public string? KommentarKunde { get; set; }
        public int Stjerner { get; set; } = 0;
        public int Fremdrift { get; set; } = 0;
        public string? ikon { get; set; }
        public bool inklBilde { get; set; }
        public string? ikonLogg { get; set; }
        public string? byte64String { get; set; }
        public string? LinkGuid { get; set; }
        public string? Tabell { get; set; }
        public string? PubBeskrivelse { get; set; }
        public bool Publiser { get; set; }
        public string aktivTab { get; set; } = "tabGenerell";
        public string bunnTab { get; set; } = "tabBeskrivelse";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class HelpDeskUtvidetListeItem
    {
        public string HelpDeskGuid { get; set; }
        public int TiketId { get; set; }
        public string ProgramNavn { get; set; }
        public string Modul { get; set; }
        public string Skjermbilde { get; set; }
        public int Prioritet { get; set; }
        public string Tittel { get; set; }
        public string BrukerId { get; set; }
        public string Fellesraad { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime Ferdig { get; set; }
        public DateTime Aksept { get; set; }
        public int Status { get; set; }
        public int TypeId { get; set; }
        public string ePostAdresse { get; set; }
        public string KommentarKunde { get; set; }
        public int Stjerner { get; set; }
        public int Fremdrift { get; set; }
        public string LinkGuid { get; set; }
        public string Tabell { get; set; }
        public string Saksbehandler { get; set; }
        public string Kunde { get; set; }
        public string Bruker { get; set; }
        public string StatusNavn { get; set; }
        public string TypeNavn { get; set; }
    }

    public class HelpDeskBildeItem
    {
        public string HelpDeskBildeGuid { get; set; }
        public string HelpDeskGuid { get; set; }
        public string Bilde { get; set; }
        public string Kommentar { get; set; }
        public int TypeBilde { get; set; }
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class HelpDeskLoggItem
    {
        public string HelpDeskLoggGuid { get; set; }
        public string HelpDeskGuid { get; set; }
        public DateTime Tidspunkt { get; set; }
        public string Kommentar { get; set; }
        public string BrukerId { get; set; }
        public int Type { get; set; }
        public bool Publiser { get; set; }
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class HelpDeskProgramItem
    {
        public int Id { get; set; }
        public string ProgramNavn { get; set; }
    }

    public class HelpDeskStatusItem
    {
        public int Id { get; set; }
        public string StatusNavn { get; set; }
        public int Sortering { get; set; }
    }

    public class HelpDeskTypeItem
    {
        public int Id { get; set; }
        public string TypeNavn { get; set; }
        public int Sortering { get; set; }
    }

    public class HelpdeskStatistikkItem
    {
        public string Tittel { get; set; }
        public string SubTittel { get; set; }
        public int Antall { get; set; }

    }

}
