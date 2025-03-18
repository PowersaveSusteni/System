using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Susteni.Models;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class ReportRepository : Controller
    {
        private readonly IConfiguration Configuration;


        public ReportRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Rapport

        public async Task<ReturnValueItem> SetReport(Models.ReportItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "SetReport", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;

        }

        public async Task<ReportItem> GetReport(AccountLogOnInfoItem logonInfo)
        {
            ReportItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReport", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReportItem>(result);

            return retur;

        }

        public async Task<ReturnValueItem> SetRapportMal(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> SetRapportMalDokument(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveReport(ReportItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "RemoveReport", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReportItems> GetReportList(GetReportItems item)
        {
            ReportItems retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "GetReportList", json, "");

            retur = JsonConvert.DeserializeObject<ReportItems>(result);

            return retur;
        }

        public async Task<List<DocumentListeItem>> GetReportDocumentList(GetReportItems item)
        {
            List<DocumentListeItem> retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "GetReportDocumentList", json, "");

            retur = JsonConvert.DeserializeObject<List<DocumentListeItem>>(result);

            return retur;
        }

        public async Task<string> GetReportDocument(AccountLogOnInfoItem item)
        {

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "GetReportDocument", json, "");

            return result;
        }

        public async Task<List<ReportItem>> GetRapporterListeFilter(AccountLogOnInfoItem logonInfo)
        {
            List<ReportItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<List<ReportItem>> (result);

            return retur;
        }

        #endregion

        #region Rapport filer

        public async Task<ReturnValueItem> SetRapportDoc(AccountLogOnInfoItem logonInfo, Models.UploadReportFilerItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> uploadRapportDoc(UploadReportFilerItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "uploadReportFile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> uploadRapportPreview(UploadReportFilerItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "uploadReportPreview", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> GetRapportDoc(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<string> GetReportFileImagePreview(AccountLogOnInfoItem logonInfo)
        {
            string retur = "";

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReportFileImagePreview", json, "");

            //retur = JsonConvert.DeserializeObject<string>(result);

            return result;
        }


        public async Task<List<ReportFilesItem>> GetReportFilesList(AccountLogOnInfoItem logonInfo)
        {
            List<ReportFilesItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReportFilesList", json, "");

            retur = JsonConvert.DeserializeObject<List<ReportFilesItem>>(result);

            return retur;
        }

        public async Task<ReturnValueItem> removeReportFilerItemWs(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        #region RapportSQL

        public async Task<List<Models.ReportSQLItem>> GetReportSQLListe(AccountLogOnInfoItem logonInfo)
        {
            List<Models.ReportSQLItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReportSQLListe", json, "");

            retur = JsonConvert.DeserializeObject<List<Models.ReportSQLItem>>(result);

            return retur;
        }

        public async Task<Models.ReportSQLItem> GetReportSQL(AccountLogOnInfoItem logonInfo)
        {
            ReportSQLItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReportSQL", json, "");

            retur = JsonConvert.DeserializeObject<ReportSQLItem>(result);

            return retur;

        }


        public async Task<ReturnValueItem> SetReportSQL(ReportSQLItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "SetReportSQL", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;

        }

        public async Task<ReturnValueItem> removeRapportSQL(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        #region Rapport spørsmål


        public async Task<List<ReportQuestionItem>> GetRapportSporsmalListe(AccountLogOnInfoItem logonInfo)
        {
            List<ReportQuestionItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<List<ReportQuestionItem>>(result);

            return retur;
        }

        public async Task<ReportQuestionItem> GetRapportSporsmaal(AccountLogOnInfoItem logonInfo)
        {
            ReportQuestionItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<ReportQuestionItem>(result);

            return retur;

        }

        public async Task<ReturnValueItem> SetRapportSporsmaal(ReportQuestionItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;

        }

        public async Task<ReturnValueItem> removeRapportSporsmal(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion


        #region SQL Formler

        public async Task<List<ReportFormelItem>> GetReportFormelListe(AccountLogOnInfoItem logonInfo)
        {
            List<ReportFormelItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<List<ReportFormelItem>>(result);

            return retur;
        }

        public async Task<Models.ReportFormelItem> GetRapportFormel(AccountLogOnInfoItem logonInfo)
        {
            Models.ReportFormelItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReportFormelItem>(result);

            return retur;

        }

        public async Task<ReturnValueItem> SetRapportFormel(ReportFormelItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> removeRapportFormel(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion


        #region Document and templates


        public async Task<List<string>> GetReportScreens(AccountLogOnInfoItem logonInfo)
        {
            List<string> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReportScreens", json, "");

            retur = JsonConvert.DeserializeObject<List<string>>(result);

            return retur;
        }


        public async Task<List<ReportListeItem>> GetTemplateList(AccountLogOnInfoItem logonInfo)
        {
            List<ReportListeItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetTemplateList", json, "");

            retur = JsonConvert.DeserializeObject<List<ReportListeItem>>(result);

            return retur;
        }

        public async Task<string> GetDocumentTemplate(AccountLogOnInfoItem logonInfo)
        {
            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetDocumentTemplate", json, "");

            return result;
        }

        public async Task<ReportPreviewItem> GetRapportPreview(ReportPreview item)
        {
            ReportPreviewItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "CreateSpireDocPreview", json, "");

            retur = JsonConvert.DeserializeObject<ReportPreviewItem>(result);

            return retur;
        }


        public async Task<List<SQLVerdierItem>> GetSQLInformasjon(AccountLogOnInfoItem logonInfo)
        {
            List<SQLVerdierItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetSQLInformasjon", json, "");

            retur = JsonConvert.DeserializeObject<List<SQLVerdierItem>>(result);

            return retur;
        }

        #endregion

        public async Task<List<string>> GetRapportKategorier(AccountLogOnInfoItem logonInfo)
        {
            List<string> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<List<string>>(result);

            return retur;
        }


        public async Task<ReportItems> GetRapportListe(GetReportItems item)
        {
            ReportItems retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "GetReportList", json, "");

            retur = JsonConvert.DeserializeObject<ReportItems>(result);

            return retur;
        }



        public async Task<ReportQuestionItem> GetReportQuestion(AccountLogOnInfoItem logonInfo)
        {
            ReportQuestionItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReportQuestion", json, "");

            retur = JsonConvert.DeserializeObject<ReportQuestionItem>(result);

            return retur;
        }


        public async Task<ReturnValueItem> SetReportQuestion(ReportQuestionItem item)
        {
            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "SetReportQuestion", json, "");

            retur = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return retur;
        }

        public async Task<List<ReportQuestionItem>> GetReportQuestionList(AccountLogOnInfoItem logonInfo)
        {
            List<ReportQuestionItem> retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "GetReportQuestionList", json, "");

            retur = JsonConvert.DeserializeObject<List<ReportQuestionItem>>(result);

            return retur;
        }

        public async Task<ReturnValueItem> GetRapportPreview(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReportPreviewItem> ShowTelerikReport(GetReportItem item)
        {

            Models.ReportPreviewItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "ShowTelerikReport", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReportPreviewItem>(result);

            return retur;
        }

        public async Task<ReportPreviewItem> CreateSpireDoc(DocumentItems item)
        {

            Models.ReportPreviewItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "CreateSpireDoc", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReportPreviewItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> exeVisDokument(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> DuplicateReport(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "DuplicateReport", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        public async Task<ReturnValueItem> SetImage(ReportImageItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Report", "SetImage", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> ClearImage(AccountLogOnInfoItem logonInfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await SusteniExecuteJson("Report", "ClearImage", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        public async Task<string> SusteniExecuteJson(string service, string funksjon, string json, string parameters)
        {
            WebHeaderCollection wHeader = new WebHeaderCollection();
            string myText = "";
            string sUrl = "";
            string paramter = json.ToString();
            wHeader.Clear();

            sUrl = Configuration["MySettings:WebserviceUrl"];

            if (sUrl != null && sUrl.Length > 0)
            {
                try
                {
                    if (parameters != null && parameters.Length > 0)
                        sUrl += service + "/" + funksjon + "?" + parameters;
                    else
                        sUrl += service + "/" + funksjon;

                    var client = new HttpClient();
                    client.BaseAddress = new Uri(sUrl);

                    var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(sUrl, content).Result;
                    return await result.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    myText = ex.Message;
                }
            }

            return myText;
        }

    }

}
