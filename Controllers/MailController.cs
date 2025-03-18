using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Susteni.Models;
using Newtonsoft.Json.Serialization;
using Susteni.Repository;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Susteni.Models.Account;
using Susteni.Models.Mail;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class MailController : Controller
    {
        private readonly IConfiguration Configuration;

        public MailController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            MailModel modell = new MailModel();

            ViewData["Menu"] = "GP";
            ViewData["Message"] = "Din side for kirkelige handlinger.";
            ViewData["LogOnOk"] = "2";

            return View(modell);
        }

        //public SrcLogonInfo GetLogonInfo()
        //{
        //    SrcLogonInfo logonInfo = new SrcLogonInfo();

        //    logonInfo.BrukerId = HttpContext.Session.GetString("BrukerId");
        //    logonInfo.Passord = HttpContext.Session.GetString("Passord");
        //    logonInfo.EPostAdresse = HttpContext.Session.GetString("Epost");
        //    logonInfo.OrgNr = HttpContext.Session.GetString("OrgNr");
        //    logonInfo.AktivFellesraad = HttpContext.Session.GetString("Fellesraad");
        //    logonInfo.AktivkWeb = HttpContext.Session.GetString("Fellesraad");
        //    logonInfo.Bruker_GUID = HttpContext.Session.GetString("BrukerGuid");
        //    logonInfo.ArkivType = (int)HttpContext.Session.GetInt32("ArkivType");
        //    logonInfo.ArkivdelGuid = HttpContext.Session.GetString("ArkivdelGuid");
        //    logonInfo.ArkivGuid = HttpContext.Session.GetString("ArkivGuid");
        //    logonInfo.AdmEnhetGuid = HttpContext.Session.GetString("AdmEnhetGuid");
        //    logonInfo.Server = config.Value.WebserviceServer;
        //    logonInfo.Database = config.Value.WebserviceDatabase;

        //    return logonInfo;
        //}


        #region Dialogbosker

        public ActionResult DialogEpost()
        {
            return PartialView("_Mail");
        }

        public ActionResult DialogSendEpost()
        {
            return PartialView("SendEpost");
        }

        #endregion

        #region Mail

        //public async Task<List<EpostFoldersItem>> GetHierarchicaFolders()
        //{
        //    MailRepository mailRepository = new MailRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    List<EpostFoldersItem> items = await mailRepository.GetFolderListe(logonInfo);

        //    return items;
        //}



        //public async Task<ActionResult> getMailListe([DataSourceRequest] DataSourceRequest request, string folderId, string epostGuid, int epostType)
        //{
        //    MailRepository mailRepository = new MailRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.MailItem> items = new List<Models.MailItem>();

        //    if (folderId != null) {
        //        items = await mailRepository.GetMailListe(logonInfo, folderId, epostGuid, epostType);
        //        }

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //    }

        //public async Task<ActionResult> getMailAttatchments([DataSourceRequest] DataSourceRequest request, string mailId, string epostGuid, int epostType)
        //{
        //    MailRepository mailRepository = new MailRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.MailAttatchmentItem> items = await mailRepository.GetMailAttachment(logonInfo, mailId, epostGuid, epostType);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //    }

        //public async Task<SrcReturnValue> ArkiverEpost(MailModel modell)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();
        //    MailItem itemWS = new MailItem();
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    MailRepository mailRepository = new MailRepository(Configuration);

        //    #region Sett verdier

        //    itemWS.Id = modell.Mail.Id;
        //    itemWS.Subject = modell.Mail.Subject;
        //    itemWS.BodyText = modell.Mail.BodyText;
        //    itemWS.PDF = modell.Mail.PDF;
        //    itemWS.HasAttachments = modell.Mail.HasAttachments;
        //    itemWS.MainAttachements = modell.Mail.MainAttachements;
        //    itemWS.Attachements = modell.Mail.Attachements;
        //    itemWS.IsNew = modell.Mail.IsNew;
        //    itemWS.DateTimeReceived = modell.Mail.DateTimeReceived;
        //    itemWS.From = modell.Mail.From;
        //    itemWS.KontaktGuid = modell.Mail.KontaktGuid;
        //    itemWS.Navn = modell.Mail.Navn;
        //    itemWS.Adresse = modell.Mail.Adresse;
        //    itemWS.Postnr = modell.Mail.Postnr;
        //    itemWS.Sted = modell.Mail.Sted;
        //    itemWS.JournalDato = modell.Mail.JournalDato;
        //    itemWS.ArkivSom = modell.Mail.ArkivSom;
        //    itemWS.TilgangsGruppe = modell.Mail.TilgangsGruppe;
        //    itemWS.SkalIkkeBesvares = modell.Mail.SkalIkkeBesvares;
        //    itemWS.mappeGuid = modell.Mail.mappeGuid;
        //    itemWS.KunVedlegg = modell.Mail.KunVedlegg;
        //    itemWS.DefaultvalueSet = modell.Mail.DefaultvalueSet;
        //    itemWS.ePostGuid = modell.Mail.ePostGuid;
        //    itemWS.ePostType = modell.Mail.ePostType;

        //    #endregion

        //    retur = await mailRepository.ArkiverEpost(logonInfo, itemWS);

        //    return retur;
        //    }

        #endregion

    }
}
