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
using Susteni.Models.Kontakt;
using Microsoft.Extensions.Localization;

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Susteni.Models.Account;
using Susteni.Models.HelpDesk;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class RutinerController : Controller
    {

        private readonly IConfiguration Configuration;

        public RutinerController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            KontaktModel modell = new KontaktModel();
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
            HttpContext.Session.SetString("aktivTabKontakt", "tabKontaktinformasjon");
            HttpContext.Session.SetString("aktivTabBunnKontakt", "tabGraver");

            return View(modell);
        }

        public ActionResult DialogHistorikk()
        {
            return PartialView("_AdresseHistorikk");
        }


        public IActionResult Festere()
        {
            KontaktModel modell = new KontaktModel();
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
            HttpContext.Session.SetString("aktivTabKontakt", "tabKontaktinformasjon");
            HttpContext.Session.SetString("aktivTabBunnKontakt", "tabGraver");

            return View(modell);
        }

        public IActionResult HelpDesk()
        {
            HelpDeskModel modell = new HelpDeskModel();
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
            HttpContext.Session.SetString("aktivTabKontakt", "tabKontaktinformasjon");
            HttpContext.Session.SetString("aktivTabBunnKontakt", "tabGraver");

            return View(modell);
        }


        //public SrcLogonInfo GetLogonInfo()
        //{
        //    SrcLogonInfo logonInfo = new SrcLogonInfo();

        //    logonInfo.BrukerId = HttpContext.Session.GetString("BrukerId");
        //    logonInfo.Passord = HttpContext.Session.GetString("Passord");
        //    logonInfo.AktivFellesraad = HttpContext.Session.GetString("Fellesraad");
        //    logonInfo.AktivkWeb = HttpContext.Session.GetString("Fellesraad");
        //    logonInfo.Server = config.Value.WebserviceServer;
        //    logonInfo.Database = config.Value.WebserviceDatabase;
        //    if (Startup.StandardSprak == "de-DE")
        //    {
        //        logonInfo.Spraak = "D";
        //    }
        //    else if (Startup.StandardSprak == "nn-NO")
        //    {
        //        logonInfo.Spraak = "N";
        //    }
        //    else
        //    {
        //        logonInfo.Spraak = "B";
        //    }

        //    return logonInfo;
        //}

        public bool SetTab(string tab)
        {

            HttpContext.Session.SetString("aktivTabKontakt", tab);
            return true;
        }

        public bool SetTabBunn(string tab)
        {

            HttpContext.Session.SetString("aktivTabBunnKontakt", tab);
            return true;
        }


        //public async Task<ActionResult> GetKontaktListe([DataSourceRequest] DataSourceRequest request, int antall, string stringFilter, string sortering)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    if (antall == 0) { antall = 100; }
        //    if (stringFilter == null) { stringFilter = ""; }
        //    if (sortering == null) { sortering = ""; }

        //    stringFilter = stringFilter.Replace("AktivFellesraad", logonInfo.AktivFellesraad);

        //    List<Models.KontaktItem> items = await kontaktRepository.GetKontaktListe(logonInfo, antall, stringFilter, sortering);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetKontakt(string kontaktGuid, string viewString)
        //{
        //    KontaktModel modell = new KontaktModel();
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    string aktivTab = HttpContext.Session.GetString("aktivTabKontakt");
        //    string aktivTabBunn = HttpContext.Session.GetString("aktivTabBunnKontakt");

        //    if (viewString == null)
        //    {
        //        viewString = "_Kontakt";
        //    }

        //    KontaktItem items = await kontaktRepository.GetKontakt(logonInfo, kontaktGuid);

        //    if (aktivTab != null)
        //    {
        //        modell.Kontakt.aktivTab = aktivTab;
        //    }
        //    if (aktivTabBunn != null)
        //    {
        //        modell.Kontakt.aktivTabBunn = aktivTabBunn;
        //    }

        //    modell.Kontakt.Fellesraad = items.Fellesraad;
        //    modell.Kontakt.KontaktGuid = items.KontaktGuid;
        //    modell.Kontakt.ID = items.ID;
        //    modell.Kontakt.ErKontakt = items.ErKontakt;
        //    modell.Kontakt.FakturaEpost = items.FakturaEpost;
        //    modell.Kontakt.FakturaEpostAdresse = items.FakturaEpostAdresse;
        //    modell.Kontakt.Pub360RecNo = items.Pub360RecNo;
        //    modell.Kontakt.OpprettetAv = items.OpprettetAv;
        //    modell.Kontakt.OpprettetDate = items.OpprettetDate;
        //    modell.Kontakt.EndretAv = items.EndretAv;
        //    modell.Kontakt.EndretDato = items.EndretDato;
        //    modell.Kontakt.SlettetAv = items.SlettetAv;
        //    modell.Kontakt.SlettetDato = items.SlettetDato;
        //    modell.Kontakt.KundeNr = items.KundeNr;
        //    modell.Kontakt.PersonNr = items.PersonNr;
        //    modell.Kontakt.Fodt = items.Fodt;
        //    modell.Kontakt.FulltNavn = items.FulltNavn;
        //    modell.Kontakt.Fornavn = items.Fornavn;
        //    modell.Kontakt.Mellomnavn = items.Mellomnavn;
        //    modell.Kontakt.Etternavn = items.Etternavn;
        //    modell.Kontakt.Adresse = items.Adresse;
        //    modell.Kontakt.PostNr = items.PostNr;
        //    modell.Kontakt.Sted = items.Sted;
        //    modell.Kontakt.KommuneNr = items.KommuneNr;
        //    modell.Kontakt.Telefon = items.Telefon;
        //    modell.Kontakt.TlfArb = items.TlfArb;
        //    modell.Kontakt.Mobil = items.Mobil;
        //    modell.Kontakt.Fax = items.Fax;
        //    modell.Kontakt.EPost = items.EPost;
        //    modell.Kontakt.BostedAdresse = items.BostedAdresse;
        //    modell.Kontakt.BostedPostNr = items.BostedPostNr;
        //    modell.Kontakt.BostedSted = items.BostedSted;
        //    modell.Kontakt.TypeKunde = items.TypeKunde;
        //    modell.Kontakt.DagerForfall = items.DagerForfall;
        //    modell.Kontakt.ErDod = items.ErDod;
        //    modell.Kontakt.KortNavn = items.KortNavn;
        //    modell.Kontakt.Kommentar = items.Kommentar;
        //    modell.Kontakt.FodeSted = items.FodeSted;
        //    modell.Kontakt.ChkType = items.ChkType;
        //    modell.Kontakt.ChkDate = items.ChkDate;
        //    modell.Kontakt.SistEndretdato = items.SistEndretdato;
        //    modell.Kontakt.SistEndringType = items.SistEndringType;
        //    modell.Kontakt.IkkeSjekk = items.IkkeSjekk;
        //    modell.Kontakt.SlektsnavnUgift = items.SlektsnavnUgift;
        //    modell.Kontakt.SoknNr = items.SoknNr;
        //    modell.Kontakt.TypeKontakt = items.TypeKontakt;
        //    modell.Kontakt.Program = items.Program;
        //    modell.Kontakt.DapsDato = items.DapsDato;
        //    modell.Kontakt.MottaEpost = items.MottaEpost;
        //    modell.Kontakt.TrossamfunnGuid = items.TrossamfunnGuid;
        //    modell.Kontakt.DåpsSted = items.DåpsSted;
        //    modell.Kontakt.SivStatId = items.SivStatId;
        //    modell.Kontakt.Kjonn = items.Kjonn;
        //    modell.Kontakt.PostNrId = items.PostNrId;

        //    return PartialView(viewString, modell);
        //}

        //public async Task<ActionResult> FinnKontakt(string kontaktGuid, string personNr)
        //{
        //    KontaktModel modell = new KontaktModel();
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    KontaktItem items = await kontaktRepository.FindKontakt(logonInfo, personNr);

        //    modell.Kontakt.Fellesraad = items.Fellesraad;
        //    modell.Kontakt.KontaktGuid = items.KontaktGuid;
        //    modell.Kontakt.ID = items.ID;
        //    modell.Kontakt.ErKontakt = items.ErKontakt;
        //    modell.Kontakt.FakturaEpost = items.FakturaEpost;
        //    modell.Kontakt.FakturaEpostAdresse = items.FakturaEpostAdresse;
        //    modell.Kontakt.Pub360RecNo = items.Pub360RecNo;
        //    modell.Kontakt.OpprettetAv = items.OpprettetAv;
        //    modell.Kontakt.OpprettetDate = items.OpprettetDate;
        //    modell.Kontakt.EndretAv = items.EndretAv;
        //    modell.Kontakt.EndretDato = items.EndretDato;
        //    modell.Kontakt.SlettetAv = items.SlettetAv;
        //    modell.Kontakt.SlettetDato = items.SlettetDato;
        //    modell.Kontakt.KundeNr = items.KundeNr;
        //    modell.Kontakt.PersonNr = items.PersonNr;
        //    modell.Kontakt.Fodt = items.Fodt;
        //    modell.Kontakt.FulltNavn = items.FulltNavn;
        //    modell.Kontakt.Fornavn = items.Fornavn;
        //    modell.Kontakt.Mellomnavn = items.Mellomnavn;
        //    modell.Kontakt.Etternavn = items.Etternavn;
        //    modell.Kontakt.Adresse = items.Adresse;
        //    modell.Kontakt.PostNr = items.PostNr;
        //    modell.Kontakt.Sted = items.Sted;
        //    modell.Kontakt.KommuneNr = items.KommuneNr;
        //    modell.Kontakt.Telefon = items.Telefon;
        //    modell.Kontakt.TlfArb = items.TlfArb;
        //    modell.Kontakt.Mobil = items.Mobil;
        //    modell.Kontakt.Fax = items.Fax;
        //    modell.Kontakt.EPost = items.EPost;
        //    modell.Kontakt.BostedAdresse = items.BostedAdresse;
        //    modell.Kontakt.BostedPostNr = items.BostedPostNr;
        //    modell.Kontakt.BostedSted = items.BostedSted;
        //    modell.Kontakt.TypeKunde = items.TypeKunde;
        //    modell.Kontakt.DagerForfall = items.DagerForfall;
        //    modell.Kontakt.ErDod = items.ErDod;
        //    modell.Kontakt.KortNavn = items.KortNavn;
        //    modell.Kontakt.Kommentar = items.Kommentar;
        //    modell.Kontakt.FodeSted = items.FodeSted;
        //    modell.Kontakt.ChkType = items.ChkType;
        //    modell.Kontakt.ChkDate = items.ChkDate;
        //    modell.Kontakt.SistEndretdato = items.SistEndretdato;
        //    modell.Kontakt.SistEndringType = items.SistEndringType;
        //    modell.Kontakt.IkkeSjekk = items.IkkeSjekk;
        //    modell.Kontakt.SlektsnavnUgift = items.SlektsnavnUgift;
        //    modell.Kontakt.SoknNr = items.SoknNr;
        //    modell.Kontakt.TypeKontakt = items.TypeKontakt;
        //    modell.Kontakt.Program = items.Program;
        //    modell.Kontakt.DapsDato = items.DapsDato;
        //    modell.Kontakt.MottaEpost = items.MottaEpost;
        //    modell.Kontakt.TrossamfunnGuid = items.TrossamfunnGuid;
        //    modell.Kontakt.DåpsSted = items.DåpsSted;
        //    modell.Kontakt.SivStatId = items.SivStatId;
        //    modell.Kontakt.Kjonn = items.Kjonn;
        //    modell.Kontakt.PostNrId = items.PostNrId;

        //    return PartialView("_Kontakt", modell);
        //}


        //[HttpPost]
        //public async Task<SrcReturnValue> LagreKontakt(KontaktModel modell)
        //{

        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    Models.KontaktItem item = new Models.KontaktItem();
        //    #region Setter verdier

        //    item.Fellesraad = modell.Kontakt.Fellesraad;
        //    item.KontaktGuid = modell.Kontakt.KontaktGuid;
        //    item.ID = modell.Kontakt.ID;
        //    item.ErKontakt = modell.Kontakt.ErKontakt;
        //    item.FakturaEpost = modell.Kontakt.FakturaEpost;
        //    item.FakturaEpostAdresse = modell.Kontakt.FakturaEpostAdresse;
        //    item.Pub360RecNo = modell.Kontakt.Pub360RecNo;
        //    item.OpprettetAv = modell.Kontakt.OpprettetAv;
        //    item.OpprettetDate = modell.Kontakt.OpprettetDate;
        //    item.EndretAv = modell.Kontakt.EndretAv;
        //    item.EndretDato = modell.Kontakt.EndretDato;
        //    item.SlettetAv = modell.Kontakt.SlettetAv;
        //    item.SlettetDato = modell.Kontakt.SlettetDato;
        //    item.KundeNr = modell.Kontakt.KundeNr;
        //    item.PersonNr = modell.Kontakt.PersonNr;
        //    item.Fodt = modell.Kontakt.Fodt;
        //    item.FulltNavn = modell.Kontakt.FulltNavn;
        //    item.Fornavn = modell.Kontakt.Fornavn;
        //    item.Mellomnavn = modell.Kontakt.Mellomnavn;
        //    item.Etternavn = modell.Kontakt.Etternavn;
        //    item.Adresse = modell.Kontakt.Adresse;
        //    item.PostNr = modell.Kontakt.PostNr;
        //    item.KommuneNr = modell.Kontakt.KommuneNr;
        //    item.Telefon = modell.Kontakt.Telefon;
        //    item.TlfArb = modell.Kontakt.TlfArb;
        //    item.Mobil = modell.Kontakt.Mobil;
        //    item.Fax = modell.Kontakt.Fax;
        //    item.EPost = modell.Kontakt.EPost;
        //    item.BostedAdresse = modell.Kontakt.BostedAdresse;
        //    item.BostedPostNr = modell.Kontakt.BostedPostNr;
        //    item.TypeKunde = modell.Kontakt.TypeKunde;
        //    item.DagerForfall = modell.Kontakt.DagerForfall;
        //    item.ErDod = modell.Kontakt.ErDod;
        //    item.KortNavn = modell.Kontakt.KortNavn;
        //    item.Kommentar = modell.Kontakt.Kommentar;
        //    item.FodeSted = modell.Kontakt.FodeSted;
        //    item.ChkType = modell.Kontakt.ChkType;
        //    item.ChkDate = modell.Kontakt.ChkDate;
        //    item.SistEndretdato = modell.Kontakt.SistEndretdato;
        //    item.SistEndringType = modell.Kontakt.SistEndringType;
        //    item.IkkeSjekk = modell.Kontakt.IkkeSjekk;
        //    item.SlektsnavnUgift = modell.Kontakt.SlektsnavnUgift;
        //    item.SoknNr = modell.Kontakt.SoknNr;
        //    item.TypeKontakt = modell.Kontakt.TypeKontakt;
        //    item.Program = modell.Kontakt.Program;
        //    item.DapsDato = modell.Kontakt.DapsDato;
        //    item.MottaEpost = modell.Kontakt.MottaEpost;
        //    item.TrossamfunnGuid = modell.Kontakt.TrossamfunnGuid;
        //    item.DåpsSted = modell.Kontakt.DåpsSted;
        //    item.SivStatId = modell.Kontakt.SivStatId;
        //    item.Kjonn = modell.Kontakt.Kjonn;
        //    item.PostNrId = modell.Kontakt.PostNrId;

        //    #endregion

        //    retur = await kontaktRepository.SetKontakt(logonInfo, item);


        //    return retur;
        //}


        //public async Task<ActionResult> getKontaktForbindelseListe([DataSourceRequest] DataSourceRequest request, string forbindelse)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KontaktForbindelseItem> items = await kontaktRepository.GetKontaktForbindelseListe(logonInfo, forbindelse);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}



        //public async Task<ActionResult> GetKontaktAvtaleListe([DataSourceRequest] DataSourceRequest request, string kontaktGuid)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KontaktAvtaleItem> items = await kontaktRepository.GetKontaktAvtaleListe(logonInfo, kontaktGuid);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetKontaktStellListe([DataSourceRequest] DataSourceRequest request, string kontaktGuid)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    List<Models.KontaktStellItem> items = new List<Models.KontaktStellItem>();

        //    if (kontaktGuid != "" && kontaktGuid != null)
        //    {
        //        items = await kontaktRepository.GetKontaktStellListe(logonInfo, kontaktGuid);
        //    }

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetKontaktBestillingListe([DataSourceRequest] DataSourceRequest request, string kontaktGuid)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KontaktBestillingItem> items = await kontaktRepository.GetKontaktBestillingListe(logonInfo, kontaktGuid);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetKontaktOrdreListe([DataSourceRequest] DataSourceRequest request, string kontaktGuid)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KontaktOrdreItem> items = await kontaktRepository.GetKontaktOrdreListe(logonInfo, kontaktGuid);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetKontaktReskontroListe([DataSourceRequest] DataSourceRequest request, string kontaktGuid)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KontaktReskontroItem> items = await kontaktRepository.GetKontaktReskontroListe(logonInfo, kontaktGuid);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetKontaktAbonnementListe([DataSourceRequest] DataSourceRequest request, string kontaktGuid)
        //{
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KontaktAbonnementItem> items = await kontaktRepository.GetKontaktAbonnementListe(logonInfo, kontaktGuid);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}


        //public async Task<FunksjonerKontaktItem> GetKontaktEpost(string filter)
        //{
        //    FunksjonerKontaktItem item = new FunksjonerKontaktItem();
        //    KontaktRepository kontaktRepository = new KontaktRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    if (filter != null)
        //    {
        //        filter = "epost = '" + filter + "'";
        //        List<Models.FunksjonerKontaktItem> items = new List<Models.FunksjonerKontaktItem>();
        //        items = await kontaktRepository.GetShortKontaktListe(logonInfo, filter);

        //        item.KontaktGuid = items[0].KontaktGuid;
        //        item.FulltNavn = items[0].FulltNavn;
        //        item.Adresse = items[0].Adresse;
        //        item.PostNr = items[0].PostNr;
        //        item.Sted = items[0].Sted;
        //    }

        //    return item;
        //}



    }
}
