using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Susteni.Models;
using Susteni.Repository;
using Susteni.Models.Help;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public partial class HjelpController : Controller
    {
        private readonly IConfiguration Configuration;

        public HjelpController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            HjelpModel modell = new HjelpModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");

            return View(modell);
        }

        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];

            return logonInfo;
        }

        public ActionResult DialogHjelp()
        {
            HjelpModel modell = new HjelpModel();
            return PartialView("HelpSystem", modell);
        }


        public ActionResult NyHjelp()
        {
            HjelpModel modell = new HjelpModel();
            return PartialView("_HelpInfo", modell);
        }

        public async Task<ActionResult> getHelpSystemListe([DataSourceRequest] DataSourceRequest request, int Modul, string Skjerm, string Kategori, bool visAlle)
        {
            HelpRepository helpRepository = new HelpRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (Modul > 0)
            {
                logonInfo.Parameters.filter = "HelpSystem.Modul=" + Modul;
            }

            List<Models.HelpSystemItem> items = await helpRepository.GetHelpSystemListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetHelpSystem(HjelpModel modell)
        {
            HelpRepository helpRepository = new HelpRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            Models.HelpSystemItem item = new Models.HelpSystemItem();

            #region Setter verdier

            item.HelpGuid = modell.HelpSystem.HelpGuid;
            item.Modul = modell.HelpSystem.Modul;
            item.Screen = modell.HelpSystem.Screen;
            item.Title = modell.HelpSystem.Title;
            item.Info = modell.HelpSystem.Info;
            item.Kategori = modell.HelpSystem.Kategori;
            item.Active = modell.HelpSystem.Active;
            item.logonInfo = logonInfo;

            #endregion

            retur = await helpRepository.SetHelpSystem(item);

            return retur;
        }

        public async Task<ActionResult> GetHelpSystem(string HelpGuid)
        {
            HjelpModel modell = new HjelpModel();
            HelpRepository helpRepository = new HelpRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "HelpGuid='" + HelpGuid + "'";

            HelpSystemItem items = await helpRepository.GetHelpSystem(logonInfo);

            modell.HelpSystem.HelpGuid = items.HelpGuid;
            modell.HelpSystem.Modul = items.Modul;
            modell.HelpSystem.Screen = items.Screen;
            modell.HelpSystem.Title = items.Title;
            modell.HelpSystem.Info = items.Info;
            modell.HelpSystem.Kategori = items.Kategori;
            modell.HelpSystem.Active = items.Active;

            return PartialView("_HelpInfo", modell);
        }

        public async Task<string> GetHelpInfo(string HelpGuid)
        {
            HjelpModel modell = new HjelpModel();
            HelpRepository helpRepository = new HelpRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "HelpGuid='" + HelpGuid + "'";

            HelpSystemItem items = await helpRepository.GetHelpSystem(logonInfo);

            return items.Info;
        }

        public async Task<ReturnValueItem> RemoveHelpSystem(string HelpGuid)
        {
            HjelpModel modell = new HjelpModel();
            HelpRepository helpRepository = new HelpRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "HelpGuid='" + HelpGuid + "'";

            ReturnValueItem items = await helpRepository.RemoveHelpSystem(logonInfo);

            return items;
        }

    }
}