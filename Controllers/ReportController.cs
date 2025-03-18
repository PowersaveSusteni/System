using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Susteni.Models;
using Susteni.Repository;
using Microsoft.Extensions.Options;


using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Susteni.Controllers
{
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.ViewComponents;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Graph;
    using Microsoft.VisualBasic;

    public partial class ReportController : Controller
    {

        private readonly IConfiguration Configuration;

        public ReportController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            ReportModel modell = new ReportModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            HttpContext.Session.SetString("aktivTab", "tabGenerell");
            return View(modell);
        }

        public IActionResult ReportDef()
        {
            ReportModel modell = new ReportModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            HttpContext.Session.SetString("aktivTab", "tabGenerell");
            return View(modell);
        }

        public IActionResult Templates()
        {
            ReportModel modell = new ReportModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            HttpContext.Session.SetString("aktivTab", "tabGenerell");
            return View(modell);
        }


        public ActionResult DialogTemplates()
        {
            return PartialView("LetterTemplates");
        }



        public ActionResult DialogEditor()
        {
            return PartialView("_Writer");
        }

        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];

            logonInfo.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");

            return logonInfo;
        }

        #region Dialogbokser

        public ActionResult DialogTelerik()
        {
            return PartialView("_Telerik");
        }

        public ActionResult DialogReportList()
        {
            return PartialView("Reportlist");
        }

        public ActionResult DialogSkrivbrevListe()
        {
            return PartialView("SkrivBrev");
        }

        public ActionResult DialogSkrivmassebrev()
        {
            return PartialView("MasseBrev");
        }

        public ActionResult DialogVisPDF()
        {
            return PartialView("_pdfViewer");
        }

        public ActionResult DialogLastOppFil()
        {
            return PartialView("_LastOppFil");
        }

        public ActionResult DialogLastOppPreview()
        {
            return PartialView("_LastOppPreview");
        }
        #endregion

        #region Rapport

        public ActionResult NyRapport()
        {
            ReportModel modell = new ReportModel();
            HttpContext.Session.SetString("aktivTab", "tabGenerell");
            return PartialView("_ReportDefInfo", modell);
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetReport(ReportModel modell)
        {

            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.ReportItem item = new Models.ReportItem();

            item = modell.Report;
            item.logonInfo = logonInfo;

            ReturnValueItem retur = await ReportRepository.SetReport(item);

            return retur;
        }

        public async Task<ActionResult> GetReportItem(string RapId)
        {
            ReportModel modell = new ReportModel();
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "RapId='" + RapId + "'";

            ReportItem items = await ReportRepository.GetReport(logonInfo);
            string activeTab = HttpContext.Session.GetString("aktivTab");

            if (items != null)
            {

                modell.Report = items;
                modell.Report.ActivTab = activeTab;
            }

            return PartialView("_ReportDefInfo", modell);
        }

        public async Task<ActionResult> getRapportListe([DataSourceRequest] DataSourceRequest request, string skjerm, string kategori, int RapType)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            GetReportItems item = new();
            item.Preview = true;
            item.Screen = skjerm;
            item.RapType = RapType;
            item.logonInfo = logonInfo;


            ReportItems report = await ReportRepository.GetRapportListe(item);

            List<Models.ReportListeItem> reports = report.items;

            DataSourceResult result = reports.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> getReportSkjerm([DataSourceRequest] DataSourceRequest request, string skjerm, string kategori)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            GetReportItems item = new();
            item.logonInfo = logonInfo;

            ReportItems report = await ReportRepository.GetRapportListe(item);

            List<Models.ReportListeItem> reports = report.items;

            DataSourceResult result = reports.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> getReportFilerListe([DataSourceRequest] DataSourceRequest request, string RapId)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            List<Models.ReportFilesItem> items = new();

            if (RapId != null)
            {
                logonInfo.Parameters.filter = "RapId='" + RapId + "'";

                items = await ReportRepository.GetReportFilesList(logonInfo);

            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public bool SetTab(string tab)
        {

            HttpContext.Session.SetString("aktivTab", tab);
            return true;
        }

        public async Task<ReturnValueItem> RemoveReport(string RapId)
        {
            ReturnValueItem retur;
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReportItem item = new();
            item.RapId = RapId;
            item.logonInfo = logonInfo;

            retur = await ReportRepository.RemoveReport(item);

            return retur;
        }


        public async Task<IActionResult> RapporterTree(string programModul, string filterTekst, bool preview)
        {
            string img = "";

            if (filterTekst == null) { filterTekst = ""; }

            var result = new List<TreeviewItems>();
            var resultH = new TreeviewItems();

            ReportRepository rapportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            GetReportItems item = new();
            item.RapType = -1;
            item.logonInfo = logonInfo;

            ReportItems report = await rapportRepository.GetReportList(item);

            img = @Url.Content("~/images/archive.svg");
            resultH.id = "Reports";
            resultH.Name = "Reports";
            resultH.expanded = true;
            resultH.imageUrl = img;
            string skjermNavn = "";                       

            if (report != null && report.Success)
            {
                foreach (ReportListeItem i in report.items)
                {
                    if (i.Skjerm != skjermNavn)
                    {
                        img = @Url.Content("~/images/folder.svg");
                        result.Add(new TreeviewItems() { id = i.Tittel, Klasse = "folder", expanded = false, HasChildren = true, Name = i.Skjerm, imageUrl = img, items = getKategoriRecursiv(report.items, i.Skjerm) });
                        skjermNavn = i.Skjerm;
                    }
                }

            }
            resultH.items = result;

            return Json(resultH);
        }

        public async Task<IActionResult> RapporterTree2(string id, string programModul, string filterTekst, bool preview)
        {
            string img = "";

            if (filterTekst == null) { filterTekst = ""; }

            var result = new List<TreeviewItems>();
            var resultH = new TreeviewItems();

            ReportRepository rapportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            GetReportItems item = new();
            item.RapType = -1;
            item.logonInfo = logonInfo;

            ReportItems report = await rapportRepository.GetReportList(item);

            img = @Url.Content("~/images/archive.svg");
            string skjermNavn = "";
            string kategoriNavn = "";

            result.Add(new TreeviewItems() { id = "Reports", Klasse = "folder", expanded = true, HasChildren = true, Name = "Reports", imageUrl = img });

            if (report != null && report.Success)
            {
                foreach (ReportListeItem i in report.items)
                {
                    if (i.Skjerm != skjermNavn)
                    {
                        img = @Url.Content("~/images/folder.svg");
                        result.Add(new TreeviewItems() { id = i.Tittel, Eier = "Reports", Klasse = "folder", expanded = true, HasChildren = true, Name = i.Skjerm, imageUrl = img });
                        skjermNavn = i.Skjerm;
                    }
                }

                skjermNavn = "";
                kategoriNavn = "";

                foreach (ReportListeItem i in report.items)
                {
                    if (i.Skjerm != skjermNavn && i.Mappe != kategoriNavn)
                    {
                        img = @Url.Content("~/images/folder.svg");
                        result.Add(new TreeviewItems() { id = i.Tittel + "." + i.Mappe, Eier = i.Tittel, Klasse = "folder", expanded = false, HasChildren = true, Name = i.Mappe, imageUrl = img });
                        kategoriNavn = i.Mappe;
                        skjermNavn = i.Skjerm;
                    }
                }

                foreach (ReportListeItem i in report.items)
                {
                    img = @Url.Content("~/images/script-filled.svg");
                    if (i.RapType == 1)
                    {
                        img = @Url.Content("~/images/DOCX.svg");
                    }
                    else if (i.RapType == 5)
                    {
                        img = "https://www.kirkene.net/img/TelerikReport.png";
                    }
                    else if (i.RapType == 0)
                    {
                        img = "https://www.kirkene.net/img/Crw32.png";
                    }

                    result.Add(new TreeviewItems() { id = i.RapId, Eier = i.Tittel + "." + i.Mappe, Klasse = "Rapporter", expanded = false, HasChildren = false, Name = i.Tittel + " [" + i.RapId + "]", imageUrl = img, FargeNavn = i.Farge });
                }

            }

            var result2 = result
                .Where(x => !string.IsNullOrEmpty(id) ? x.Eier == id : x.Eier == null)
                .Select(item => new
                {
                    id = item.id,
                    Text = item.Name,
                    FargeNavn = item.FargeNavn,
                    expanded = item.expanded,
                    imageUrl = item.imageUrl,
                    hasChildren = item.HasChildren,
                    checkedfiles = item.checkedFiles,
                    ResType = item.ResType
                });

            return Json(result2);
        }


        public async Task<ActionResult> GetReportDocumentList([DataSourceRequest] DataSourceRequest request, string screen)
        {
            ReportRepository reportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            GetReportItems item = new();
            item.Screen = screen;
            item.logonInfo = logonInfo;

            List<DocumentListeItem> items = new();

            items = await reportRepository.GetReportDocumentList(item);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<string> GetReportDocumentListNew(string screen)
        {
            ReportRepository reportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            GetReportItems item = new();
            item.Screen = screen;
            item.logonInfo = logonInfo;


            List<DocumentListeItem> items = new();

            items = await reportRepository.GetReportDocumentList(item);


            string htmlCode = "";

            int iC = 0;

            foreach (var i in items)
            {
                iC++;

                htmlCode += "<button class='commandPDF' onclick='ShowDocument(¤" + i.fileGuid + "¤)'><img alt='Ships' src='/images/pdfNew.svg' width=24 height=24 />" + i.Tittel + "</button>";
            }

            return htmlCode;
        }


        [HttpGet]
        public async Task<string> GetReportDocument(string reportFilesGuid)
        {
            ReportRepository rapportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.fieldValue = reportFilesGuid;

            string items = await rapportRepository.GetReportDocument(logonInfo);

            if (items != null)
            {
                HttpContext.Session.SetString("Base64String", items);
            }
            else
            {
                HttpContext.Session.SetString("Base64String", "");
            }

            return items;
        }


        [HttpGet]
        public FileStreamResult ShowReport(string rapId)
        {
            string base64string = HttpContext.Session.GetString("Base64String");

            Byte[] bytes = Convert.FromBase64String(base64string);

            Stream stream = new MemoryStream(bytes);

            HttpContext.Session.SetString("Base64String", "");

            return new FileStreamResult(stream, "application/pdf");
        }


        public List<TreeviewItems> getKategoriRecursiv(List<ReportListeItem> items, string skjerm)
        {
            var result = new List<TreeviewItems>();
            string img = "";
            string kategori = "";

            foreach (ReportListeItem i in items)
            {
                if (i.Skjerm == skjerm && i.Mappe != kategori)
                {
                    img = @Url.Content("~/images/folder.svg");
                    result.Add(new TreeviewItems() { id = i.Mappe, Klasse = "folder", expanded = false, HasChildren = true, Name = i.Mappe, imageUrl = img, items = getRapportRecursiv(items, i.Skjerm, i.Mappe) });
                    kategori = i.Mappe;
                }
            }

            return result;
        }


        public List<TreeviewItems> getRapportRecursiv(List<ReportListeItem> items, string skjerm, string mappe)
        {
            var result = new List<TreeviewItems>();
            string img = "";
            string eier = "";

            foreach (ReportListeItem i in items)
            {
                if (i.Skjerm == skjerm && i.Mappe == mappe)
                {
                    eier = "";
                    img = @Url.Content("~/images/script-filled.svg");
                    if (i.RapType == 1)
                    {
                        img = @Url.Content("~/images/DOCX.svg");
                    }
                    else if (i.RapType == 5)
                    {
                        img = "https://www.kirkene.net/img/TelerikReport.png";
                    }
                    else if (i.RapType == 0)
                    {
                        img = "https://www.kirkene.net/img/Crw32.png";
                    }

                    result.Add(new TreeviewItems() { id = i.RapId, Eier = eier, Klasse = "Rapporter", expanded = false, HasChildren = false, Name = i.Tittel + " [" + i.RapId + "]", imageUrl = img, FargeNavn = i.Farge });
                }
            }

            return result;
        }



        #endregion

        #region Rapport filer

        public async Task<ActionResult> getRapportFilerListe([DataSourceRequest] DataSourceRequest request, string RapId)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.ReportFilesItem> items = await ReportRepository.GetReportFilesList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        //public async Task removeRapportFiler(string RapportFilerGuid)
        //{
        //    ReportRepository ReportRepository = new ReportRepository(Configuration);
        //    AccountLogOnInfoItem logonInfo = GetLogonInfo();

        //    await ReportRepository.removeRapportFilerItemWs(logonInfo, RapportFilerGuid);
        //}

        public async Task<string> GetReportFileImagePreview(string RapportFilerGuid)
        {
            ReportModel modell = new ReportModel();
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.field = RapportFilerGuid;
            string fil = "";

            fil = await ReportRepository.GetReportFileImagePreview(logonInfo);

            return fil;
        }

        #endregion

        #region Rapport SQL


        public ActionResult NewSQL()
        {
            ReportModel modell = new ReportModel();
            modell.ReportSQL.Type = 2;
            modell.ReportSQL.Stadie = 1;
            return PartialView("_ReportSQL", modell);
        }


        public async Task<ActionResult> GetReportSQLListe([DataSourceRequest] DataSourceRequest request, string skjerm, string kategori, string filterTekst)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();


            List<Models.ReportSQLItem> items = await ReportRepository.GetReportSQLListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<IActionResult> ReportSQLTree(string RapId)
        {
            string img = "";

            var result = new List<TreeviewItems>();
            var resultH = new TreeviewItems();

            ReportRepository rapportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "RapId='" + RapId + "'";
            logonInfo.Parameters.order = "Stadie";

            List<Models.ReportSQLItem> itemws = await rapportRepository.GetReportSQLListe(logonInfo);

            img = @Url.Content("~/images/database-filled.svg");
            resultH.id = "SQL";
            resultH.Name = "SQL";
            resultH.expanded = true;
            resultH.imageUrl = img;
            int Stadie = -1;
            string stadieTekst = "";

            foreach (ReportSQLItem i in itemws)
            {
                if (i.Stadie != Stadie)
                {
                    img = @Url.Content("~/images/folder.svg");
                    switch (i.Stadie)
                    {
                        case 0:
                            stadieTekst = "Pre";
                            break;

                        case 1:
                            stadieTekst = "Main";
                            break;

                        case 2:
                            stadieTekst = "Flette";
                            break;

                        case 3:
                            stadieTekst = "Block";
                            break;

                        case 4:
                            stadieTekst = "Post";
                            break;
                    }
                    result.Add(new TreeviewItems() { id = i.Stadie.ToString(), expanded = true, HasChildren = true, Name = stadieTekst, imageUrl = img, items = getSQLRecursiv(itemws, i.Stadie) });
                    Stadie = i.Stadie;
                }
            }

            resultH.items = result;

            return Json(resultH);
        }

        public List<TreeviewItems> getSQLRecursiv(List<ReportSQLItem> items, int Stadie)
        {
            var result = new List<TreeviewItems>();
            string img = "";

            foreach (ReportSQLItem i in items)
            {
                if (i.Stadie == Stadie)
                {
                    img = @Url.Content("~/images/script-filled.svg");
                    result.Add(new TreeviewItems() { id = i.ReportSQLGuid, expanded = false, HasChildren = true, Name = i.Kode, imageUrl = img });
                }
            }

            return result;
        }




        public async Task<ActionResult> GetRapportSQL(string RapSQLGuid)
        {
            ReportModel modell = new ReportModel();
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "ReportSQLGuid='" + RapSQLGuid + "'";

            ReportSQLItem items = await ReportRepository.GetReportSQL(logonInfo);

            modell.ReportSQL = items;

            return PartialView("_ReportSQL", modell);
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetReportSQL(ReportModel modell)
        {

            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReportSQLItem item = new();

            item = modell.ReportSQL;
            item.logonInfo = logonInfo;


            ReturnValueItem retur = await ReportRepository.SetReportSQL(item);

            return retur;
        }


        //public async Task SlettRapportSQL(string RapportSQLGuid)
        //{
        //    ReportRepository ReportRepository = new ReportRepository(Configuration);
        //    AccountLogOnInfoItem logonInfo = GetLogonInfo();

        //    await ReportRepository.removeRapportSQL(logonInfo, RapportSQLGuid);
        //}

        #endregion


        #region Spørmsål

        public ActionResult NewReportQuestion()
        {
            ReportModel modell = new ReportModel();
            return PartialView("_ReportQuestion", modell);
        }

        public async Task<ActionResult> GetReportQuestionList([DataSourceRequest] DataSourceRequest request, string RapId, bool hentVerdier)
        {
            ReportModel modell = new ReportModel();
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReportRepository ReportRepository = new ReportRepository(Configuration);

            logonInfo.Parameters.filter= "RapId='" + RapId + "'";
            logonInfo.Parameters.yesno = hentVerdier;

            List<Models.ReportQuestionItem> items = await ReportRepository.GetReportQuestionList(logonInfo);

            //modell.ReportVerdier.RapId = RapId;

            //foreach (var i in items)

            //{
            //    foreach (var v in i.Values)
            //    {
            //        ReportValueListItems item = new ReportValueListItems();
            //        item.Kode = v.Kode;
            //        item.Verdi = v.Verdi;
            //        modell.ReportVerdier.Verdier.Add(item);

            //    }

            //}

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetReportQuestion(ReportModel modell)
        {

            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.ReportQuestionItem item = new Models.ReportQuestionItem();

            item = modell.ReportQuestion;
            item.logonInfo = logonInfo;

            ReturnValueItem retur = await ReportRepository.SetReportQuestion(item);

            return retur;
        }

        public async Task<ActionResult> GetRapportSporsmal(string RapportSporsmalGuid)
        {
            ReportModel modell = new ReportModel();
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter= "RapportSporsmalGuid='" + RapportSporsmalGuid + "'";

            ReportQuestionItem item = await ReportRepository.GetReportQuestion(logonInfo);

            modell.ReportQuestion = item;

            return PartialView("_ReportQuestion", modell);
        }

        //public async Task SlettRapportSporsmal(string RapportSporsmalGuid)
        //{
        //    ReportRepository ReportRepository = new ReportRepository(Configuration);
        //    AccountLogOnInfoItem logonInfo = GetLogonInfo();

        //    await ReportRepository.removeRapportSporsmal(logonInfo, RapportSporsmalGuid);
        //}

        #endregion

        #region Formler

        //public ActionResult NyFormel()
        //{
        //    ReportModel modell = new ReportModel();
        //    return PartialView("_RapportFormler", modell);
        //}


        public async Task<ActionResult> getReportFormelListe([DataSourceRequest] DataSourceRequest request, string RapId, int programId)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.ReportFormelItem> items = await ReportRepository.GetReportFormelListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);

        }

        //public async Task<ActionResult> GetRapportFormel(string RapId)
        //{
        //    ReportModel modell = new ReportModel();
        //    ReportRepository ReportRepository = new ReportRepository(Configuration);
        //    AccountLogOnInfoItem logonInfo = GetLogonInfo();

        //    RapportFormelItem items = await ReportRepository.GetRapportFormel(logonInfo, RapId);

        //    modell.RapportFormel.Fellesraad = items.Fellesraad;
        //    modell.RapportFormel.RapId = items.RapId;
        //    modell.RapportFormel.FormelNavn = items.FormelNavn;
        //    modell.RapportFormel.FormelTekst = items.FormelTekst;
        //    modell.RapportFormel.FormelType = items.FormelType;
        //    modell.RapportFormel.OpprettetAv = items.OpprettetAv;
        //    modell.RapportFormel.OpprettetDate = items.OpprettetDate;
        //    modell.RapportFormel.EndretAv = items.EndretAv;
        //    modell.RapportFormel.EndretDato = items.EndretDato;
        //    modell.RapportFormel.SlettetAv = items.SlettetAv;
        //    modell.RapportFormel.SlettetDato = items.SlettetDato;
        //    modell.RapportFormel.Antall = items.Antall;
        //    modell.RapportFormel.Program = items.Program;
        //    modell.RapportFormel.FormelVerdiType = items.FormelVerdiType;
        //    modell.RapportFormel.RapportFormelGuid = items.RapportFormelGuid;

        //    return PartialView("_RapportFormler", modell);
        //}

        //[HttpPost]
        //public async Task<ReturnValueItem> LagreRapportFormel(ReportModel modell)
        //{

        //    ReportRepository ReportRepository = new ReportRepository(Configuration);
        //    AccountLogOnInfoItem logonInfo = GetLogonInfo();

        //    Models.RapportFormelItem item = new Models.RapportFormelItem();

        //    #region Setter verdier

        //    item.Fellesraad = modell.RapportFormel.Fellesraad;
        //    item.RapId = modell.RapportFormel.RapId;
        //    item.FormelNavn = modell.RapportFormel.FormelNavn;
        //    item.FormelTekst = modell.RapportFormel.FormelTekst;
        //    item.FormelType = modell.RapportFormel.FormelType;
        //    item.OpprettetAv = modell.RapportFormel.OpprettetAv;
        //    item.OpprettetDate = modell.RapportFormel.OpprettetDate;
        //    item.EndretAv = modell.RapportFormel.EndretAv;
        //    item.EndretDato = modell.RapportFormel.EndretDato;
        //    item.SlettetAv = modell.RapportFormel.SlettetAv;
        //    item.SlettetDato = modell.RapportFormel.SlettetDato;
        //    item.Antall = modell.RapportFormel.Antall;
        //    item.Program = modell.RapportFormel.Program;
        //    item.FormelVerdiType = modell.RapportFormel.FormelVerdiType;
        //    item.RapportFormelGuid = modell.RapportFormel.RapportFormelGuid;

        //    #endregion

        //    ReturnValueItem retur = await ReportRepository.SetRapportFormel(logonInfo, item);

        //    return retur;
        //}

        //public async Task SlettRapportFormel(string RapportFormelGuid)
        //{
        //    ReportRepository ReportRepository = new ReportRepository(Configuration);
        //    AccountLogOnInfoItem logonInfo = GetLogonInfo();

        //    await ReportRepository.removeRapportFormel(logonInfo, RapportFormelGuid);
        //}

        #endregion

        #region Documents and templates

        public async Task<ActionResult> GetReportScreens([DataSourceRequest] DataSourceRequest request)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "RapType=1";

            List<string> items = await ReportRepository.GetReportScreens(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetTemplateList([DataSourceRequest] DataSourceRequest request)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.yesno = true;
            logonInfo.Parameters.filter = "RapType=1";

            List<ReportListeItem> items = await ReportRepository.GetTemplateList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetInvestmentPlanYear([DataSourceRequest] DataSourceRequest request, string shipGuid, string field, string profilGuids)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.yesno = true;
            logonInfo.Parameters.filter = "RapType=1";

            List<ReportListeItem> items = await ReportRepository.GetTemplateList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<string> GetDocumentTemplate([DataSourceRequest] DataSourceRequest request, string RapId)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.field = RapId;

            string result = await ReportRepository.GetDocumentTemplate(logonInfo);

            return result;
        }

        public async Task<ReturnValueItem> SetDocumentTemplate([DataSourceRequest] DataSourceRequest request, string RapId, string base64Dokument)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.field = RapId;

            UploadReportFilerItem item = new();
            item.RapId = RapId;
            item.Base64String = base64Dokument;
            item.ErstattSiste = true;
            item.Ext = ".docx";
            item.logonInfo = logonInfo;


            ReturnValueItem result = await ReportRepository.uploadRapportDoc(item);

            return result;
        }

        public async Task<ActionResult> GetSQLInformasjon([DataSourceRequest] DataSourceRequest request, string RapId)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.field = RapId;

            List<SQLVerdierItem> items = new();

            if (RapId != null &&  RapId.Length > 0) 
                items = await ReportRepository.GetSQLInformasjon(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        [HttpPost]
        public async Task<ReportPreviewItem> CreateDocument(ReportModel modell)
        {


            ReportPreviewItem retur = new();
           
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.DocumentItems item = new Models.DocumentItems();

            item = modell.Document;
            item.logonInfo = logonInfo;

            DocumentValueListItem valueItem = new DocumentValueListItem();
            List<DocumentValueListItem> valueItems = new List<DocumentValueListItem>();


            string[] mn = item.MasterNavn.Split("|");
            string[] mv = item.MasterVerdier.Split("|");

            for (int i = 0; i < mv.Count(); i++)
            {
                DocumentValueListItem v = new DocumentValueListItem();
                v.Kode = mn[i];
                v.Verdi = mv[i];
                valueItems.Add(v);
                if (v.Kode == "ShipGuid")
                {
                    item.logonInfo.Parameters.fieldValue = v.Verdi;
                }

            }

            item.Verdier = valueItems;

            ReportRepository engrafoRepository = new ReportRepository(Configuration);
            retur = await engrafoRepository.CreateSpireDoc(item);

            HttpContext.Session.SetString("Base64String", retur.Base64String);
            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetImage(string profilGuid, string profile,  string tittel, string imageText)
        {
            ReportRepository reportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ReportImageItem item = new();
            item.id = "chartImage";
            item.ProfilGuid = profilGuid.Replace("'","");
            item.Profile = profile;
            item.Tittel = tittel;
            item.Image = imageText.Replace("data:image/png;base64,","");
            item.logonInfo = logonInfo;


            retur = await reportRepository.SetImage(item);

            return retur;
        }

        public async Task<ReturnValueItem> ClearImage()
        {
            ReportRepository reportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            retur = await reportRepository.ClearImage(logonInfo);

            return retur;
        }

        public async Task<ReturnValueItem> DuplicateReport(string rapId, string title)
        {
            ReportRepository reportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.field = rapId;
            logonInfo.Parameters.fieldValue = title;

            ReturnValueItem retur = new();

            retur = await reportRepository.DuplicateReport(logonInfo);

            return retur;
        }


        #endregion

        public async Task<ActionResult> getRapportKategorier([DataSourceRequest] DataSourceRequest request, string skjerm, string kategori)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<string> items = await ReportRepository.GetRapportKategorier(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> getRapportSkjerm([DataSourceRequest] DataSourceRequest request)
        {
            ReportRepository ReportRepository = new ReportRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<string> items = await ReportRepository.GetReportScreens(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReportPreviewItem> ShowTelerikReport(ReportModel modell)
        {
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            GetReportItem item = new();
            item.logonInfo=logonInfo;
            item.RapId = modell.ReportVerdier.RapId;

            ReportRepository ReportRepository = new ReportRepository(Configuration);
            ReportPreviewItem rapport = new();

            if (modell.ReportVerdier.MasterVerdier == null && modell.Report.KreverSelektering)
            {
                rapport.ErrorCode = 9;
                rapport.ErrorTekst = "Rapporten krever at du har valgt minst en registrering fra listen";
                HttpContext.Session.SetString("Base64String", "");
            }
            else
            {
                rapport = await ReportRepository.ShowTelerikReport(item);
                HttpContext.Session.SetString("Base64String", rapport.Base64String);
            }

            return rapport;
        }

        public async Task<bool> getRapportPreview(string Base64Dokumnet, string RapId)
        {
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReportPreview item = new();
            item.RapId = RapId;
            item.base64String = Base64Dokumnet;
            item.logonInfo = logonInfo;

            ReportRepository ReportRepository = new ReportRepository(Configuration);

            ReportPreviewItem doc = await ReportRepository.GetRapportPreview(item);


            HttpContext.Session.SetString("Base64String", doc.Base64String);

            return true;
        }


        [HttpGet]
        public FileStreamResult VisRapport(string rapId)
        {
            string base64string = HttpContext.Session.GetString("Base64String");

            Byte[] bytes = Convert.FromBase64String(base64string);

            Stream stream = new MemoryStream(bytes);

            HttpContext.Session.SetString("Base64String", "");

            return new FileStreamResult(stream, "application/pdf");
        }

        public async Task<bool> getWordDoc(string rapId, string parameter)
        {
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReportRepository ReportRepository = new ReportRepository(Configuration);
            ReturnValueItem report = new();

            report = await ReportRepository.exeVisDokument(logonInfo);

            HttpContext.Session.SetString("Base64String", report.Base64String);

            return true;
        }

        public string LoadDocument()
        {
            string base64;
            base64 = HttpContext.Session.GetString("Base64String");
            return base64;
        }

    }

}
