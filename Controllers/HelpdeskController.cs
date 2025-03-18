using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Susteni.Models;
using Susteni.Models.HelpDesk;
using Susteni.Models.Ship;
using Susteni.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Susteni.Controllers
{
    public class HelpdeskController : Controller
    {

        private readonly IConfiguration Configuration;

        public HelpdeskController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HelpDesk()
        {
            HelpDeskModel model = new HelpDeskModel();

            return View(model);
        }

        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];
            logonInfo.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            logonInfo.Currency = HttpContext.Session.GetString("CurrencyCode");

            return logonInfo;
        }


        public ActionResult DialogSupport()
        {
            HelpDeskModel modell = new HelpDeskModel();

            modell.HelpDesk.BrukerId = HttpContext.Session.GetString("BrukerId");
            modell.HelpDesk.Fellesraad = HttpContext.Session.GetString("Fellesraad");

            return PartialView("Support", modell);
        }

        public async Task<ActionResult> DialogHelpDeskBilde(string bildeGuid)
        {

            HelpDeskModel modell = new HelpDeskModel();
            HelpdeskRepository helpdeskRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "HelpDeskBildeGuid='" + bildeGuid + "'";

            HelpDeskBildeItem items = await helpdeskRepository.GetHelpDeskBilde(logonInfo);

            modell.HelpDeskBilde.HelpDeskBildeGuid = items.HelpDeskBildeGuid;
            modell.HelpDeskBilde.HelpDeskGuid = items.HelpDeskGuid;
            modell.HelpDeskBilde.Bilde = items.Bilde;
            modell.HelpDeskBilde.Kommentar = items.Kommentar;

            return PartialView("_HelpDeskBildeFull", modell);
        }


        public async Task<ActionResult> DialogHelpDeskBildeInfo(string bildeGuid)
        {
            HelpDeskModel modell = new HelpDeskModel();
            HelpdeskRepository helpdeskRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "HelpDeskBildeGuid='" + bildeGuid + "'";

            HelpDeskBildeItem items = await helpdeskRepository.GetHelpDeskBilde(logonInfo);

            modell.HelpDeskBilde.HelpDeskBildeGuid = items.HelpDeskBildeGuid;
            modell.HelpDeskBilde.HelpDeskGuid = items.HelpDeskGuid;
            modell.HelpDeskBilde.Bilde = items.Bilde;
            modell.HelpDeskBilde.Kommentar = items.Kommentar;
            modell.HelpDeskBilde.TypeBilde = items.TypeBilde;

            return PartialView("_HelpDeskBildeInfo", modell);
        }

        [HttpPost]
        public async Task<ReturnValueItem> LagreHelpDeskBilde(HelpDeskModel modell)
        {

            HelpdeskRepository helpdeskRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.HelpDeskBildeItem item = new Models.HelpDeskBildeItem();
            item.logonInfo = logonInfo;

            #region Setter verdier

            item.HelpDeskBildeGuid = modell.HelpDeskBilde.HelpDeskBildeGuid;
            item.HelpDeskGuid = modell.HelpDeskBilde.HelpDeskGuid;
            item.Kommentar = modell.HelpDeskBilde.Kommentar;
            item.TypeBilde = modell.HelpDeskBilde.TypeBilde;
            item.Bilde = modell.HelpDeskBilde.Bilde;

            #endregion

            ReturnValueItem result = new ReturnValueItem();

            result = await helpdeskRepository.SetHelpDeskBilde(item);

            return result;
        }

        #region Helpdesk

        public async Task<ActionResult> GetHelpDeskListe([DataSourceRequest] DataSourceRequest request, string filterTekst, string sortering)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (filterTekst != null) { logonInfo.Parameters.filter = filterTekst; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.HelpDeskItem> items = new();

            if (filterTekst == null) { filterTekst = ""; }

            items = await helpRepository.GetHelpDeskListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public ActionResult NewTickets()
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            HelpDeskModel modell = new HelpDeskModel();

            return PartialView("_HelpDeskInfo", modell);
        }


        public async Task<ActionResult> GetHelpDesk(string helpdeskGuid)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            HelpDeskModel modell = new HelpDeskModel();
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (helpdeskGuid != null)
            {
                logonInfo.Parameters.filter = "helpdeskGuid='" + helpdeskGuid + "'";
            }

            HelpDeskItem items = await helpRepository.GetHelpDesk(logonInfo);

            modell.HelpDesk = items;

            return PartialView("_HelpDeskInfo", modell);
        }



        public async Task<ReturnValueItem> SetHelpDesk(HelpDeskModel model)
        {
            HelpdeskRepository shipRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            HelpDeskItem item = new();

            item = model.HelpDesk;

            item.logonInfo = logonInfo;

            retur = await shipRepository.SetHelpDesk(item);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveHelpDesk(string HelpDeskGuid)
        {
            HelpdeskRepository shipRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            HelpDeskItem item = new();

            item.HelpDeskGuid = HelpDeskGuid;

            item.logonInfo = logonInfo;

            retur = await shipRepository.RemoveHelpDesk(item);

            return retur;
        }
        #endregion


        #region Logg

        public async Task<ActionResult> GetHelpDeskLoggListe([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.HelpDeskLoggItem> items = new();

            if (strFilter == null) { strFilter = ""; }

            items = await helpRepository.GetHelpDeskLoggListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetHelpDeskLogg(string helpdeskGuid)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            HelpDeskModel modell = new HelpDeskModel();
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (helpdeskGuid != null)
            {
                logonInfo.Parameters.filter = "helpdeskGuid='" + helpdeskGuid + "'";
            }

            HelpDeskLoggItem items = await helpRepository.GetHelpDeskLogg(logonInfo);

            modell.HelpDeskLogg = items;

            return PartialView("_HelpDeskInfo", modell);
        }



        public async Task<ReturnValueItem> SetHelpDeskLogg(HelpDeskModel model)
        {
            HelpdeskRepository shipRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            HelpDeskLoggItem item = new();

            item = model.HelpDeskLogg;

            item.logonInfo = logonInfo;

            retur = await shipRepository.SetHelpDeskLogg(item);

            return retur;
        }
        #endregion



        #region Bilde

        public async Task<ActionResult> GetHelpDeskBildeListe([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.HelpDeskBildeItem> items = new();

            if (strFilter == null) { strFilter = ""; }

            items = await helpRepository.GetHelpDeskBildeListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetHelpDeskBilde(string helpdeskBildeGuid)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            HelpDeskModel modell = new HelpDeskModel();
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (helpdeskBildeGuid != null)
            {
                logonInfo.Parameters.filter = "helpdeskBildeGuid='" + helpdeskBildeGuid + "'";
            }

            HelpDeskBildeItem items = await helpRepository.GetHelpDeskBilde(logonInfo);

            modell.HelpDeskBilde = items;

            return PartialView("_HelpDeskBilde", modell);
        }

        public async Task<ReturnValueItem> SetHelpDeskBilde(HelpDeskModel model)
        {
            HelpdeskRepository shipRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            HelpDeskBildeItem item = new();

            item = model.HelpDeskBilde;

            item.logonInfo = logonInfo;

            retur = await shipRepository.SetHelpDeskBilde(item);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> LeggTilHelpDeskBilde(string HelpDeskGuid, string base64Image)
        {

            HelpdeskRepository helpdeskRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReturnValueItem retur = new ReturnValueItem();
            Models.HelpDeskBildeItem item = new Models.HelpDeskBildeItem();
            item.logonInfo = logonInfo;

            #region Setter verdier

            base64Image = base64Image.Replace("data:image/png;base64,", "");
            base64Image = base64Image.Replace("data:image/swg-;base64,", "");
            item.HelpDeskGuid = HelpDeskGuid;
            item.Bilde = base64Image;

            #endregion

            retur = await helpdeskRepository.SetHelpDeskBilde(item);

            return retur;
        }



        #endregion




        #region Typer

        public async Task<ActionResult> GetHelpDeskProgramListe([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.HelpDeskProgramItem> items = new();

            if (strFilter == null) { strFilter = ""; }

            items = await helpRepository.GetHelpDeskProgramListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetHelpDeskStatusListe([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.HelpDeskStatusItem> items = new();

            if (strFilter == null) { strFilter = ""; }

            items = await helpRepository.GetHelpDeskStatusListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetHelpDeskTypeListe([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            HelpdeskRepository helpRepository = new HelpdeskRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.HelpDeskTypeItem> items = new();

            if (strFilter == null) { strFilter = ""; }

            items = await helpRepository.GetHelpDeskTypeListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        #endregion


    }
}
