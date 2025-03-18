using Susteni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
   
    public class ReportModel
    { 
        public ReportPreviewItem ReportPreview { get; set; }
        public ReportListeItem ReportListe { get; set; }
        public ReportItem Report { get; set; }
        public ReportItems Reports { get; set; }
        public GetReportItems GetReports { get; set; }
        public GetReportItem GetReport { get; set; }
        public ReportVerdierItem ReportVerdier { get; set; }
        public ReportSQLItem ReportSQL { get; set; }
        public ReportFormelItem ReportFormel { get; set; }
        public ReportQuestionItem ReportQuestion { get; set; }
        public UploadReportFilerItem ReportFiler { get; set; }
        public SQLVerdierItem SQLVerdier { get; set; }
        public DocumentItems Document { get; set; }

        public ReportModel()
        {
            ReportPreview = new ReportPreviewItem();
            ReportListe = new ReportListeItem();
            Report = new ReportItem();
            Reports = new ReportItems();
            GetReports = new GetReportItems();
            GetReport = new GetReportItem();
            ReportVerdier = new ReportVerdierItem();
            ReportQuestion = new ReportQuestionItem();
            ReportSQL = new ReportSQLItem();
            ReportFormel = new ReportFormelItem();
            ReportFiler = new UploadReportFilerItem();
            SQLVerdier = new SQLVerdierItem();
            Document = new DocumentItems();

        }
    }
}
