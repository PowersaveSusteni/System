using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{

    public class VarTypeItem
    {
        public string Navn { get; set; } = "";
        public string Verdi { get; set; } = "";
    }

    public class ReportPreview
    {
        public string RapId { get; set; } = "";
        public string shipGuid { get; set; } = "";
        public string base64String { get; set; } = "";
        public AccountLogOnInfoItem logonInfo { get; set; } = new();

    }

    public class ReportPreviewItem
    {
        public string Base64String { get; set; } = "";
        public string ErrorTekst { get; set; } = "";
        public int ErrorCode { get; set; } = 0;
    }


    public class ReportImageItem
    {
        public string id { get; set; } = "";
        public string ProfilGuid { get; set; } = "";
        public string Profile { get; set; } = "";
        public string Tittel { get; set; } = "";
        public string Image { get; set; } = "";
        public AccountLogOnInfoItem logonInfo { get; set; } = new();
    }

    public class ReportItems
    {
        public bool Success { get; set; } = true;
        public List<ErrorItem> ErrorInfo { get; set; } = new();

        public List<ReportListeItem> items { get; set; } = new();
    }

    public class ReportItem
    {
        public string ReportGuid { get; set; } = "";
        public string CustomerGuid { get; set; } = "";
        public int PrintCount { get; set; } = 0;
        public string Filnavn { get; set; } = "";
        public string RapId { get; set; } = "";
        public int RapType { get; set; } = 0;
        public string Tittel { get; set; } = "";
        public string Beskrivelse { get; set; } = "";
        public string? Kategori { get; set; } = "";
        public string Skjerm { get; set; } = "";
        public int Orientering { get; set; } = 0;
        public bool HarFiler { get; set; } = false;
        public bool KreverSelektering { get; set; } = false;
        public DateTime? LastPrintDate { get; set; } = null;
        public DateTime? DatoEndret { get; set; } = null;
        public bool Aktiv { get; set; } = false;
        public bool SkjulBunntekst { get; set; } = false;
        public int Sortering { get; set; } = 0;
        public string OpprettetAv { get; set; } = "";
        public DateTime? OpprettetDate { get; set; } = null;
        public string EndretAv { get; set; } = "";
        public DateTime? EndretDato { get; set; } = null;
        public string SlettetAv { get; set; } = "";
        public DateTime? SlettetDato { get; set; } = null;
        public string Mappe { get; set; } = "";
        public int RegType { get; set; } = 0;

        public string ActivTab { get; set; } = "tabGenerell";

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class GetReportItems
    {
        public string RapId { get; set; } = "";
        public string? Screen { get; set; } = "";
        public string? Category { get; set; } = "";
        public int RapType { get; set; } = 0;
        public bool Preview { get; set; } = false;
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class ReportListeItem
    {
        public string RapId { get; set; } = "";
        public string CustomerGuid { get; set; } = "";
        public string Eier { get; set; } = "";
        public string Filnavn { get; set; } = "";
        public string fileGuid { get; set; } = "";
        public string Skjerm { get; set; } = "";
        public string Tittel { get; set; } = "";
        public string Beskrivelse { get; set; } = "";
        public string Mappe { get; set; } = "";
        public string Preview { get; set; } = "";
        public string Farge { get; set; } = "";
        public int RapType { get; set; } = 0;
        public bool HarFiler { get; set; } = false;
        public bool Aktiv { get; set; } = true;
        public bool Skjul { get; set; } = false;
        public bool Godkjent { get; set; } = false;
        public bool EgenSelektering { get; set; } = false;
        public bool KunEnRecord { get; set; } = false;
        public int ProgramId { get; set; } = 0;
        public bool expanded { get; set; }
        public string imageUrl { get; set; }
        public List<RapporterItem> Items { get; set; }
    }

    public class DocumentListeItem
    {
        public string fileGuid { get; set; } = "";
        public string Tittel { get; set; } = "";
    }

    public class TreeviewItems
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public bool HasChildren { get; set; }
        public bool expanded { get; set; }
        public bool checkedFiles { get; set; }
        public bool @checked { get; set; }
        public string FargeNavn { get; set; }
        public int ResType { get; set; }
        public int mappeType { get; set; }
        public string Eier { get; set; }
        public string Klasse { get; set; }

        public List<TreeviewItems> items = new List<TreeviewItems>();
    }

    public class GetReportItem
    {
        public string RapId { get; set; } = "";
        public string CustomerGuid { get; set; } = "";
        public bool Preview { get; set; } = false;

        public List<VarTypeItem> Verdier = new List<VarTypeItem>();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class ReportVerdierItem
    {
        public string RapId { get; set; }
        public int RapType { get; set; }
        public string MasterVerdier { get; set; }
        public string MasterVerdierAlle { get; set; }
        public string VerdiValg { get; set; }
        public string MasterNavn { get; set; }
        public List<ReportValueListItems> Verdier { get; set; }
    }

    public class ReportValueListItems
    {
        public string Kode { get; set; }
        public string Verdi { get; set; }
        public List<string> Verdiliste { get; set; }
    }


    public class UploadReportFilerItem
    {
        public string? RapId { get; set; } = "";
        public string? CustomerGuid { get; set; }
        public string? ReportFilesGuid { get; set; }
        public DateTime? Dato { get; set; }
        public string? FilNavn { get; set; }
        public string? Ext { get; set; } = "";
        public string Base64String { get; set; } = "";
        public string? Preview { get; set; }
        public int? Versjon { get; set; }
        public bool ErstattSiste { get; set; }
        public string EndretAv { get; set; } = "";
        public DateTime? EndretDato { get; set; }
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ReportFilesItem
    {
        public string ReportFilesGuid { get; set; } = "";
        public string RapportGuid { get; set; } = "";
        public string RapId { get; set; } = "";
        public string CustomerGuid { get; set; } = "";
        public DateTime? Dato { get; set; } = null;
        public string FilNavn { get; set; } = "";
        public string Preview { get; set; } = "";
        public int Versjon { get; set; } = 0;
        public string EndretAv { get; set; } = "";
        public DateTime? EndretDato { get; set; } = null;
        public bool BeholdTopptekst { get; set; } = false;
        public bool BeholdBunntekst { get; set; } = false;
    }

    public class ReportSQLItem
    {
        public string ReportSQLGuid { get; set; } = "";
        public string RapId { get; set; } = "";
        public int Type { get; set; } = 0;
        public int Stadie { get; set; } = 0;
        public string Kode { get; set; } = "";
        public int Rekkefolge { get; set; } = 0;
        public string Format { get; set; } = "";
        public string SQL { get; set; } = "";
        public string OpprettetAv { get; set; } = "";
        public DateTime? OpprettetDate { get; set; } = null;
        public string? EndretAv { get; set; } = "";
        public DateTime? EndretDato { get; set; } = null;
        public string? SlettetAv { get; set; } = "";
        public DateTime? SlettetDato { get; set; } = null;
        public string IsNotNullField { get; set; } = "";
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ReportQuestionItem
    {
        public string ReportSporsmalGuid { get; set; } = "";
        public string RapId { get; set; } = "";
        public string Kode { get; set; } = "";
        public int Type { get; set; } = 0;
        public string? TypeNavn { get; set; } = "";
        public string Tekst { get; set; } = "";
        public int PosX { get; set; } = 0;
        public int PosY { get; set; } = 0;
        public int Vidde { get; set; } = 0;
        public int Hoyde { get; set; } = 0;
        public string Font { get; set; } = "";
        public bool Uthevet { get; set; } = false;
        public int Storrelse { get; set; } = 0;
        public string Farge { get; set; } = "";
        public int ReturVerdi { get; set; } = 0;
        public string SQL { get; set; } = "";
        public string StandardVerdi { get; set; } = "";
        public string OpprettetAv { get; set; } = "";
        public DateTime? OpprettetDate { get; set; } = null;
        public string EndretAv { get; set; } = "";
        public DateTime? EndretDato { get; set; } = null;
        public string? SlettetAv { get; set; } = "";
        public DateTime? SlettetDato { get; set; } = null;
        public bool SkalerBredde { get; set; } = false;
        public bool SkalerHoyde { get; set; } = false;
        public bool Flytt { get; set; } = false;
        public bool Flerlinje { get; set; } = false;
        public List<ReportValueListItems> Values { get; set; } = new List<ReportValueListItems>();

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ReportFormelItem
    {
        public string ReportFormelGuid { get; set; }
        public string RapId { get; set; }
        public string FormelNavn { get; set; }
        public string FormelTekst { get; set; }
        public int FormelType { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public int Antall { get; set; }
        public int FormelVerdiType { get; set; }
    }


    public class SQLVerdierItem
    {
        public string FeltNavn { get; set; }
        public string Verdi { get; set; }
        public string FontNavn { get; set; }
        public string Type { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
    }

    public class DocumentItems
    {
        public string Tittel { get; set; }
        public string RapId { get; set; }
        public string MasterVerdier { get; set; }
        public string MasterNavn { get; set; }
        public List<DocumentValueListItem> Verdier { get; set; } = new List<DocumentValueListItem>();

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class DocumentValueListItem
    {
        public string Kode { get; set; }
        public string Verdi { get; set; }
        //public List<string> Verdiliste { get; set; }
    }


}
