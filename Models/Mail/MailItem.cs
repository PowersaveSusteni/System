using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class EpostFoldersItem {
        public string AdmEnhEpostGuid { get; set; }
        public string BrukerNavn { get; set; }
        public string EpostAdresse { get; set; }
        public string Passord { get; set; }
        public int PassordType { get; set; }
        public bool ErVideresendt { get; set; }
        public bool ArkiverEpost { get; set; }
        public string ArkiverFolderId { get; set; }
        public int ePostType { get; set; }
        public string FolderType { get; set; }
        public string RootNavn { get; set; }
        public string FolderId { get; set; }
        public string Name { get; set; }
        public string ParentFolderid { get; set; }
    }

    public class MailItem {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
        public string PDF { get; set; }
        public bool HasAttachments { get; set; }
        public string MainAttachements { get; set; }
        public string Attachements { get; set; }
        public bool IsNew { get; set; }
        public DateTime DateTimeReceived { get; set; }
        public string From { get; set; }
        public string[] Recipients { get; set; }
        public string KontaktGuid { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Sted { get; set; }
        public DateTime JournalDato { get; set; }
        public int ArkivSom { get; set; }
        public string TilgangsGruppe { get; set; }
        public bool SkalIkkeBesvares { get; set; }
        public string mappeGuid { get; set; }
        public int ePostType { get; set; }
        public bool KunVedlegg { get; set; }
        public string ePostGuid { get; set; }
        public string DefaultvalueSet { get; set; }
        public string SoknNr { get; set; }
    }

    public class HierarchicalMailItem
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string Name { get; set; }
        public bool HasChildren { get; set; }
        public bool Expanded { get; set; }
        public string ImageUrl { get; set; }

        public bool checkedFiles { get; set; }

        public bool @checked { get; set; }
        public string FargeNavn { get; set; }
        public int ResType { get; set; }
        public int mappeType { get; set; }
    }

    public class MailAttatchmentItem
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string base64string { get; set; }
    }

    public class SendMailItems
    {
        public string mailTo { get; set; } = "";
        public string mailCC { get; set; } = "";
        public string mailBC { get; set; } = "";
        public string replyAdress { get; set; } = "";
        public string subject { get; set; } = "";
        public string title { get; set; } = "";
        public string body { get; set; } = "";
        public string rapportId { get; set; } = "";
        public string rapportFilter { get; set; } = "";
        public List<MailAttatchmentItem> attatchment = new List<MailAttatchmentItem>();
    }


}
