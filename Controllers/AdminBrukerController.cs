using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Susteni.Models;
using Susteni.Models.Admin;
using Susteni.Repository;
using Susteni.Models.Account;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class AdminBrukerController : Controller
    {
        private readonly IConfiguration Configuration;

        public AdminBrukerController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            AdminModel modell = new AdminModel();
            ViewData["LogOnOk"] = "2";
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

        public IActionResult Bruker()
        {
            AdminModel modell = new AdminModel();
            ViewData["LogOnOk"] = "2";
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

        //public SrcLogonInfo GetLogonInfo()
        //{
        //    SrcLogonInfo logonInfo = new SrcLogonInfo();

        //    logonInfo.BrukerId = HttpContext.Session.GetString("BrukerId");
        //    logonInfo.Passord = HttpContext.Session.GetString("Passord");
        //    logonInfo.EPostAdresse = HttpContext.Session.GetString("Epost");
        //    logonInfo.AktivFellesraad = HttpContext.Session.GetString("Fellesraad");
        //    logonInfo.AktivkWeb = HttpContext.Session.GetString("Fellesraad");
        //    logonInfo.RessursGuid = HttpContext.Session.GetString("RessursGuid");
        //    logonInfo.Navn = HttpContext.Session.GetString("Brukernavn");
        //    logonInfo.RapEier = HttpContext.Session.GetString("Navn");
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

        //public ActionResult DialogBrukerNy()
        //{
        //    return PartialView("NyBruker");
        //}

        //public ActionResult DialogNyttPassord()
        //{
        //    return PartialView("_NyttPassord");
        //}

        #region  Bruker

        //public async Task<ActionResult> getBrukerListe([DataSourceRequest] DataSourceRequest request, int resType, string filterText)
        //{
        //   AdminBrukerRepository brukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    List<BrukerItem> items = new List<BrukerItem>();

        //    if (logonInfo.BrukerId != null && logonInfo.BrukerId != "")
        //    {
        //        items = await brukerRepository.GetBrukerListe(logonInfo, resType, filterText);
        //    }

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> getBrukerFellesraadListe([DataSourceRequest] DataSourceRequest request, string brukerId)
        //{
        //    AdminBrukerRepository brukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    List<BrukerItem> items = new List<BrukerItem>();

        //    if (logonInfo.BrukerId != null && logonInfo.BrukerId != "")
        //    {
        //        items = await brukerRepository.GetBrukerFellesraadListe(logonInfo, brukerId);
        //    }

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetBruker(string BrukerGuid, string RessursGuid)
        //{
        //    AdminModel modell = new AdminModel();
        //    AdminBrukerRepository adminbrukerRepository = new AdminBrukerRepository(Configuration);
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    string aktivTab = HttpContext.Session.GetString("aktivTab");

        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    BrukerItem items = new BrukerItem();

        //    if (BrukerGuid != "")
        //    {
        //        items = await adminbrukerRepository.GetBruker(logonInfo, BrukerGuid);
        //    }

        //    #region Data bruker

        //    if (aktivTab != null)
        //    {
        //        modell.Bruker.aktivTab = aktivTab;
        //    }

        //    modell.Bruker.BrukerId = items.BrukerId;
        //    modell.Bruker.FraDato = items.FraDato;
        //    modell.Bruker.TilDato = items.TilDato;
        //    modell.Bruker.ModulMedarbeider = items.ModulMedarbeider;
        //    modell.Bruker.ModulKH = items.ModulKH;
        //    modell.Bruker.ModulByra = items.ModulByra;
        //    modell.Bruker.ModulGravplass = items.ModulGravplass;
        //    modell.Bruker.ModulEngrafo = items.ModulEngrafo;
        //    modell.Bruker.ModulOkonomi = items.ModulOkonomi;
        //    modell.Bruker.ModulGrunnregister = items.ModulGrunnregister;
        //    modell.Bruker.ModulStatistikk = items.ModulStatistikk;
        //    modell.Bruker.ModulKisteskanning = items.ModulKisteskanning;
        //    modell.Bruker.ModulKrematorium = items.ModulKrematorium;
        //    modell.Bruker.ModulkWeb = items.ModulkWeb;
        //    modell.Bruker.ModulAdmin = items.ModulAdmin;
        //    modell.Bruker.Fellesraad = items.Fellesraad;
        //    modell.Bruker.BrukerGuid = items.BrukerGuid;
        //    modell.Bruker.OpprettetAv = items.OpprettetAv;
        //    modell.Bruker.OpprettetDate = items.OpprettetDate;
        //    modell.Bruker.EndretAv = items.EndretAv;
        //    modell.Bruker.EndretDato = items.EndretDato;
        //    modell.Bruker.SlettetAv = items.SlettetAv;
        //    modell.Bruker.SlettetDato = items.SlettetDato;
        //    modell.Bruker.Etternavn = items.Etternavn;
        //    modell.Bruker.Fornavn = items.Fornavn;
        //    modell.Bruker.Kontakt_GUID = items.Kontakt_GUID;
        //    modell.Bruker.BestilingVarsler = items.BestilingVarsler;
        //    modell.Bruker.AutoUpdate = items.AutoUpdate;
        //    modell.Bruker.SuperBruker = items.SuperBruker;
        //    modell.Bruker.SoknId = items.SoknId;
        //    modell.Bruker.NhGtj = items.NhGtj;
        //    modell.Bruker.NhDåp = items.NhDåp;
        //    modell.Bruker.NhKon = items.NhKon;
        //    modell.Bruker.NhVie = items.NhVie;
        //    modell.Bruker.NhGrf = items.NhGrf;
        //    modell.Bruker.NhAkt = items.NhAkt;
        //    modell.Bruker.NhFri = items.NhFri;
        //    modell.Bruker.NhBes = items.NhBes;
        //    modell.Bruker.NhKal = items.NhKal;
        //    modell.Bruker.NhGGen = items.NhGGen;
        //    modell.Bruker.NhGGfd = items.NhGGfd;
        //    modell.Bruker.NhGStl = items.NhGStl;
        //    modell.Bruker.NhGOko = items.NhGOko;
        //    modell.Bruker.NhGma = items.NhGma;
        //    modell.Bruker.AktivFakturaNrSerie = items.AktivFakturaNrSerie;
        //    modell.Bruker.HarEpost = items.HarEpost;
        //    modell.Bruker.DomainUser = items.DomainUser;
        //    modell.Bruker.DomainPassword = items.DomainPassword;
        //    modell.Bruker.EWSKalender = items.EWSKalender;
        //    modell.Bruker.Alfa = items.Alfa;
        //    modell.Bruker.Beta = items.Beta;
        //    modell.Bruker.SkjulInfo = items.SkjulInfo;
        //    modell.Bruker.EWSepost = items.EWSepost;
        //    modell.Bruker.AutNiva = items.AutNiva;
        //    modell.Bruker.AktivFellesraad = items.AktivFellesraad;
        //    modell.Bruker.AktivKonfirmantKull = items.AktivKonfirmantKull;
        //    modell.Bruker.url = items.url;
        //    #endregion


        //    RessursNavnItem itemR = new RessursNavnItem();

        //    if (RessursGuid != "")
        //    {
        //        itemR = await ressursRepository.GetRessurs(logonInfo, RessursGuid);
        //    }

        //    #region Data ressurs
        //    modell.Ressurs.Fellesraad = itemR.Fellesraad;
        //    modell.Ressurs.RessursGuid = itemR.RessursGuid;
        //    modell.Ressurs.KontaktGuid = itemR.KontaktGuid;
        //    modell.Ressurs.RessId = itemR.RessId;
        //    modell.Ressurs.BrukerId = itemR.BrukerId;
        //    modell.Ressurs.ResType = itemR.ResType;
        //    modell.Ressurs.Navn = itemR.Navn;
        //    modell.Ressurs.Fornavn = itemR.Fornavn;
        //    modell.Ressurs.Mellomnavn = itemR.Mellomnavn;
        //    modell.Ressurs.Etternavn = itemR.Etternavn;
        //    modell.Ressurs.Adresse = itemR.Adresse;
        //    modell.Ressurs.PostNr = itemR.PostNr;
        //    modell.Ressurs.Kjonn = itemR.Kjonn;
        //    modell.Ressurs.Telefon = itemR.Telefon;
        //    modell.Ressurs.Telefax = itemR.Telefax;
        //    modell.Ressurs.Mobil = itemR.Mobil;
        //    modell.Ressurs.Beskrivelse = itemR.Beskrivelse;
        //    modell.Ressurs.KortNavn = itemR.KortNavn;
        //    modell.Ressurs.Stilling = itemR.Stilling;
        //    modell.Ressurs.PaaKal = itemR.PaaKal;
        //    modell.Ressurs.Aktiv = itemR.Aktiv;
        //    modell.Ressurs.DistriktGuid = itemR.DistriktGuid;
        //    modell.Ressurs.Sortering = itemR.Sortering;
        //    modell.Ressurs.Sortering2 = itemR.Sortering2;
        //    modell.Ressurs.KardRess = itemR.KardRess;
        //    modell.Ressurs.Type = itemR.Type;
        //    modell.Ressurs.Farge = itemR.Farge;
        //    modell.Ressurs.ReknKode = itemR.ReknKode;
        //    modell.Ressurs.AntBegrPrDag = itemR.AntBegrPrDag;
        //    modell.Ressurs.Monte = itemR.Monte;
        //    modell.Ressurs.SoknNr = itemR.SoknNr;
        //    modell.Ressurs.KardRessId = itemR.KardRessId;
        //    modell.Ressurs.EPost = itemR.EPost;
        //    modell.Ressurs.MottaSMS = itemR.MottaSMS;
        //    modell.Ressurs.MottaEPost = itemR.MottaEPost;
        //    modell.Ressurs.FargeNavn = itemR.FargeNavn;
        //    modell.Ressurs.LabOraMRessGuid = itemR.LabOraMRessGuid;
        //    modell.Ressurs.SorteringUt = itemR.SorteringUt;
        //    modell.Ressurs.Sortering2Ut = itemR.Sortering2Ut;
        //    modell.Ressurs.VisOppslag = itemR.VisOppslag;
        //    modell.Ressurs.VisVisning = itemR.VisVisning;
        //    modell.Ressurs.Liturg = itemR.Liturg;
        //    modell.Ressurs.Predikant = itemR.Predikant;
        //    modell.Ressurs.TekstLeser = itemR.TekstLeser;
        //    modell.Ressurs.Organist = itemR.Organist;
        //    modell.Ressurs.Klokker = itemR.Klokker;
        //    modell.Ressurs.Kirketjener = itemR.Kirketjener;
        //    modell.Ressurs.Kirkevert = itemR.Kirkevert;
        //    modell.Ressurs.Saksbehandler = itemR.Saksbehandler;
        //    modell.Ressurs.PersonNr = itemR.PersonNr;
        //    modell.Ressurs.Nattverdsvert = itemR.Nattverdsvert;
        //    modell.Ressurs.Daapsvert = itemR.Daapsvert;
        //    modell.Ressurs.Hjelper1 = itemR.Hjelper1;
        //    modell.Ressurs.Hjelper2 = itemR.Hjelper2;
        //    modell.Ressurs.Hjelper3 = itemR.Hjelper3;
        //    modell.Ressurs.Hjelper4 = itemR.Hjelper4;
        //    modell.Ressurs.RessursEierGuid = itemR.RessursEierGuid;
        //    modell.Ressurs.MinAntall = itemR.MinAntall;
        //    modell.Ressurs.MaksAntall = itemR.MaksAntall;
        //    modell.Ressurs.MaxAntall = itemR.MaxAntall;
        //    modell.Ressurs.AnsvId = itemR.AnsvId;
        //    modell.Ressurs.Fodt = itemR.Fodt;
        //    modell.Ressurs.Gudstjeneste = itemR.Gudstjeneste;
        //    modell.Ressurs.Gravferd = itemR.Gravferd;
        //    modell.Ressurs.Mote = itemR.Mote;
        //    modell.Ressurs.SyncExchange = itemR.SyncExchange;
        //    modell.Ressurs.Gruppering = itemR.Gruppering;
        //    modell.Ressurs.Hjelper5 = itemR.Hjelper5;
        //    modell.Ressurs.Samtalerom = itemR.Samtalerom;
        //    modell.Ressurs.Moeterom = itemR.Moeterom;
        //    modell.Ressurs.Konserter = itemR.Konserter;
        //    modell.Ressurs.Vielser = itemR.Vielser;
        //    modell.Ressurs.Fagarbeider = itemR.Fagarbeider;
        //    modell.Ressurs.SynkExchangeReadOnly = itemR.SynkExchangeReadOnly;
        //    modell.Ressurs.LukketKalender = itemR.LukketKalender;
        //    modell.Ressurs.StandardTilgang = itemR.StandardTilgang;
        //    modell.Ressurs.GruppeType = itemR.GruppeType;
        //    modell.Ressurs.OpprettetAv = itemR.OpprettetAv;
        //    modell.Ressurs.OpprettetDate = itemR.OpprettetDate;
        //    modell.Ressurs.EndretAv = itemR.EndretAv;
        //    modell.Ressurs.EndretDato = itemR.EndretDato;
        //    modell.Ressurs.SlettetAv = itemR.SlettetAv;
        //    modell.Ressurs.SlettetDato = itemR.SlettetDato;
        //    modell.Ressurs.Graver = itemR.Graver;
        //    modell.Ressurs.Solist = itemR.Solist;
        //    modell.Ressurs.Kor = itemR.Kor;
        //    modell.Ressurs.SynkExchange2 = itemR.SynkExchange2;
        //    modell.Ressurs.eKirkebok = itemR.eKirkebok;
        //    modell.Ressurs.KirkeDbId = itemR.KirkeDbId;
        //    modell.Ressurs.KalenderGruppe = itemR.KalenderGruppe;
        //    modell.Ressurs.Medliturg = itemR.Medliturg;
        //    modell.Ressurs.Aktiviet = itemR.Aktiviet;
        //    modell.Ressurs.Aktivitet = itemR.Aktivitet;
        //    modell.Ressurs.SynkFromDate = itemR.SynkFromDate;
        //    modell.Ressurs.GPS = itemR.GPS;
        //    modell.Ressurs.PassordWs = itemR.PassordWs;
        //    modell.Ressurs.TilgjengeligWs = itemR.TilgjengeligWs;
        //    modell.Ressurs.PostnrId = itemR.PostnrId;
        //    modell.Ressurs.Besok = itemR.Besok;
        //    modell.Ressurs.SynkExchange = itemR.SynkExchange;
        //    modell.Ressurs.Varmestyring = itemR.Varmestyring;
        //    modell.Ressurs.KjopsDato = itemR.KjopsDato;
        //    modell.Ressurs.Produsent = itemR.Produsent;
        //    modell.Ressurs.Verdi = itemR.Verdi;
        //    modell.Ressurs.Lat = itemR.Lat;
        //    modell.Ressurs.Long = itemR.Long;
        //    modell.Ressurs.Kollekt = itemR.Kollekt;
        //    modell.Ressurs.Forsanger = itemR.Forsanger;
        //    modell.Ressurs.Andre = itemR.Andre;
        //    modell.Ressurs.Tittel = itemR.Tittel;
        //    modell.Ressurs.TypeRessurs = itemR.TypeRessurs;
        //    modell.Ressurs.StandardBildeId = itemR.StandardBildeId;
        //    modell.Ressurs.KirkebyggUrl = itemR.KirkebyggUrl;
        //    modell.Ressurs.Region = itemR.Region;
        //    modell.Ressurs.AktivMinMenighet = itemR.AktivMinMenighet;
        //    modell.Ressurs.TilskrivesBrev = itemR.TilskrivesBrev;
        //    modell.Ressurs.TilskrivesEPost = itemR.TilskrivesEPost;
        //    modell.Ressurs.TilskrivesSMS = itemR.TilskrivesSMS;
        //    modell.Ressurs.TilskrivesTelefon = itemR.TilskrivesTelefon;
        //    modell.Ressurs.GDPRStatus = itemR.GDPRStatus;
        //    modell.Ressurs.SistImpersonated = itemR.SistImpersonated;
        //    modell.Ressurs.SistImpersonatedFeilet = itemR.SistImpersonatedFeilet;
        //    modell.Ressurs.TilgangMinKirkeside = itemR.TilgangMinKirkeside;
        //    modell.Ressurs.Timer = itemR.Timer;
        //    modell.Ressurs.VisMobil = itemR.VisMobil;
        //    modell.Ressurs.MobilNavn = itemR.MobilNavn;
        //    modell.Ressurs.webuserId = itemR.webuserId;
        //    #endregion

        //    ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");

        //    return PartialView("_Brukere", modell);
        //}

        //public async Task<SrcReturnValue> RemoveBruker(string BrukerId, string RessursGuid)
        //{
        //    AdminBrukerRepository adminbrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcReturnValue retur = new SrcReturnValue();
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    retur = await adminbrukerRepository.exeBrukerSlett(logonInfo, BrukerId, RessursGuid);

        //    return retur;
        //}


        //public async Task<SrcReturnValue> FjernBruker(string BrukerId, string fellesraad)
        //{
        //    AdminBrukerRepository adminbrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcReturnValue retur = new SrcReturnValue();
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    retur = await adminbrukerRepository.exeBrukerFjern(logonInfo, BrukerId, fellesraad);

        //    return retur;
        //}


        public string OpprettNyttPassord()
        {
            Random rand = new Random();
            string charbase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            return new string(Enumerable.Range(0, 6)
                   .Select(_ => charbase[rand.Next(charbase.Length)])
                   .ToArray());
        }

        public string OpprettNyBrukerId(string fornavn, string etternavn)
        {
            string brukerId = "";
            string tall = "";
            brukerId = fornavn.Substring(0, 1);
            brukerId += etternavn.Substring(0, 1);

            Random rand = new Random();
            tall = rand.Next(100, 999).ToString();
            brukerId += tall;

            return brukerId;
        }

              

        #endregion

        #region Kalender tilganger

        //public async Task<ActionResult> GetKalenderTilgangTypeListe([DataSourceRequest] DataSourceRequest request)
        //{
        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KalenderTilgangTypeItem> items = await adminBrukerRepository.GetKalenderTilgangTypeListe(logonInfo);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetKalenderTilgangerListe([DataSourceRequest] DataSourceRequest request)
        //{
        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.KalenderTilgangerItem> items = await adminBrukerRepository.GetKalenderTilgangerListe(logonInfo);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task SetKalenderTilgangKontroll(bool lukket)
        //{
        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    await adminBrukerRepository.SetKalenderTilgangKontroll(logonInfo, lukket);
        //}

        //public async Task SetKalenderTilgang(string ressursGUID, int Tilgang)
        //{
        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    await adminBrukerRepository.SetKalenderTilgang(logonInfo, ressursGUID, Tilgang);
        //}

        //public async Task UpdateKalenderTilgang(string ressursGUID, int Tilgang)
        //{
        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    await adminBrukerRepository.UpdateKalenderTilgang(logonInfo, ressursGUID, Tilgang);
        //}

        //public async Task FjernKalenderTilgang(string ressursGUID)
        //{
        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    await adminBrukerRepository.FjernKalenderTilgang(logonInfo, ressursGUID);
        //}

        #endregion

        #region Tilganger

        //public async Task<IActionResult> BrukerSoknTreeView(string id, string brukerId, string soknId)
        //{

        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<SoknRessursItem> items = await adminBrukerRepository.GetBrukerRolleSokn(logonInfo, brukerId);

        //    string OldSokn_ID = "";

        //    //DataSourceResult result = itemws.ToDataSourceResult(request);
        //    var result = new List<HierarchicalSoknRessursItem>();

        //    foreach (SoknRessursItem i in items)
        //    {
        //        if (OldSokn_ID != i.PROSTI_ID)
        //        {
        //            OldSokn_ID = i.PROSTI_ID;
        //            bool exp = true;
        //            if (items.Count > 2) { exp = false; }
        //            foreach (Models.SoknRessursItem test in items)
        //            {
        //                if (test.PROSTI_ID == OldSokn_ID && test.Aktiv)
        //                {
        //                    exp = true;
        //                }
        //            }
        //            result.Add(new HierarchicalSoknRessursItem() { id = i.PROSTI_ID, ParentID = null, HasChildren = true, expanded = exp, Name = i.ProstiNavn, imageUrl = Url.Content("~/images/gemeinde.png") });
        //        }
        //    }

        //    foreach (Models.SoknRessursItem i in items)
        //    {
        //        string img = Url.Content("~/images/gemeinde.png");

        //        result.Add(new HierarchicalSoknRessursItem() { id = i.SoknId, ParentID = i.PROSTI_ID, HasChildren = false, Name = i.SoknNavn, @checked = i.Aktiv, imageUrl = img });
        //    }

        //    var result2 = result
        //        .Where(x => !string.IsNullOrEmpty(id) ? x.ParentID == id : x.ParentID == null)
        //        .Select(item => new
        //        {
        //            id = item.id,
        //            Name = item.Name,
        //            expanded = item.expanded,
        //            imageUrl = item.imageUrl,
        //            hasChildren = item.HasChildren,
        //            @checked = item.@checked
        //        });

        //    return Json(result2);
        //}

        //public async Task<IActionResult> BrukerRollerTreeView(string brukerId, string soknId)
        //{
        //    AdminBrukerRepository adminBrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<BrukerRolleItem> itemws = await adminBrukerRepository.GetBrukerRolleTilgang(logonInfo, brukerId, soknId);

        //    var result = new List<HierarchicalSoknRessursItem>();

        //    foreach (BrukerRolleItem i in itemws)
        //    {
        //        result.Add(new HierarchicalSoknRessursItem { id = i.RolleGuid, HasChildren = false, Name = i.RolleNavn, @checked = i.Aktiv });
        //    }

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetBrukerSokn([DataSourceRequest] DataSourceRequest request, string brukerId)
        //{
        //    AdminBrukerRepository brukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.SoknRessursItem> items = new List<Models.SoknRessursItem>();


        //    items = await brukerRepository.GetBrukerSokn(logonInfo, brukerId);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<ActionResult> GetBrukerRolleListe([DataSourceRequest] DataSourceRequest request, string brukerId, string soknId)
        //{
        //    AdminBrukerRepository brukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.BrukerRolleItem> items = await brukerRepository.GetBrukerRolleListe(logonInfo, brukerId, soknId);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}

        //public async Task<bool> setBrukerSokn(string soknId, string brukerId)
        //{
        //    AdminBrukerRepository adminbrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    await adminbrukerRepository.setBrukerSokn(logonInfo, brukerId, soknId);

        //    return true;
        //}

        //public async Task<bool> setBrukerRoller(string rollerGuid, string brukerId, string soknId)
        //{

        //    AdminBrukerRepository adminbrukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    await adminbrukerRepository.setBrukerRoller(logonInfo, rollerGuid, brukerId, soknId);

        //    return true;
        //}

        //public async Task<ActionResult> GetBrukerTilgang(string SoknNr, string BrukerId)
        //{
        //    AdminModel modell = new AdminModel();
        //    AdminBrukerRepository brukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    BrukerTilgangItem items = await brukerRepository.GetBrukerTilgang(logonInfo, SoknNr, BrukerId);

        //    modell.BrukerTilgang.Fellesraad = items.Fellesraad;
        //    modell.BrukerTilgang.SoknNr = items.SoknNr;
        //    modell.BrukerTilgang.BrukerId = items.BrukerId;
        //    modell.BrukerTilgang.SoknId = items.SoknId;
        //    modell.BrukerTilgang.ADM = items.ADM;
        //    modell.BrukerTilgang.AKTIVITETER_R = items.AKTIVITETER_R;
        //    modell.BrukerTilgang.AKTIVITETER_W = items.AKTIVITETER_W;
        //    modell.BrukerTilgang.ANSATTREG_R = items.ANSATTREG_R;
        //    modell.BrukerTilgang.ANSATTREG_W = items.ANSATTREG_W;
        //    modell.BrukerTilgang.BIBLIOTEK = items.BIBLIOTEK;
        //    modell.BrukerTilgang.DOED_R = items.DOED_R;
        //    modell.BrukerTilgang.DOED_W = items.DOED_W;
        //    modell.BrukerTilgang.DAAP_R = items.DAAP_R;
        //    modell.BrukerTilgang.DAAP_W = items.DAAP_W;
        //    modell.BrukerTilgang.GUDSTJENESTE_R = items.GUDSTJENESTE_R;
        //    modell.BrukerTilgang.GUDSTJENESTE_W = items.GUDSTJENESTE_W;
        //    modell.BrukerTilgang.INNUTMELDING_R = items.INNUTMELDING_R;
        //    modell.BrukerTilgang.INNUTMELDING_W = items.INNUTMELDING_W;
        //    modell.BrukerTilgang.KONFIRMASJON_R = items.KONFIRMASJON_R;
        //    modell.BrukerTilgang.KONFIRMASJON_W = items.KONFIRMASJON_W;
        //    modell.BrukerTilgang.ARKIV_DOK_R = items.ARKIV_DOK_R;
        //    modell.BrukerTilgang.ARKIV_DOK_W = items.ARKIV_DOK_W;
        //    modell.BrukerTilgang.ARKIV_SAK_R = items.ARKIV_SAK_R;
        //    modell.BrukerTilgang.ARKIV_SAK_W = items.ARKIV_SAK_W;
        //    modell.BrukerTilgang.ARKIV_MOTE_R = items.ARKIV_MOTE_R;
        //    modell.BrukerTilgang.ARKIV_MOTE_W = items.ARKIV_MOTE_W;
        //    modell.BrukerTilgang.TIDSPLAN_ROM_R = items.TIDSPLAN_ROM_R;
        //    modell.BrukerTilgang.TIDSPLAN_ROM_W = items.TIDSPLAN_ROM_W;
        //    modell.BrukerTilgang.TIDSPLAN_PERS_R = items.TIDSPLAN_PERS_R;
        //    modell.BrukerTilgang.TIDSPLAN_PERS_W = items.TIDSPLAN_PERS_W;
        //    modell.BrukerTilgang.TIDSPLAN_GUDSTJENESTE = items.TIDSPLAN_GUDSTJENESTE;
        //    modell.BrukerTilgang.VIELSE_R = items.VIELSE_R;
        //    modell.BrukerTilgang.VIELSE_W = items.VIELSE_W;
        //    modell.BrukerTilgang.FASTE_DATA_R = items.FASTE_DATA_R;
        //    modell.BrukerTilgang.FASTE_DATA_W = items.FASTE_DATA_W;
        //    modell.BrukerTilgang.AVHOLDT = items.AVHOLDT;
        //    modell.BrukerTilgang.MEDLEMSREG = items.MEDLEMSREG;
        //    modell.BrukerTilgang.TIDSPLAN_GUDSTJENESTE_W = items.TIDSPLAN_GUDSTJENESTE_W;
        //    modell.BrukerTilgang.STANDARD_KLIENT = items.STANDARD_KLIENT;
        //    modell.BrukerTilgang.FRIVILLIGREG_R = items.FRIVILLIGREG_R;
        //    modell.BrukerTilgang.FRIVILLIGREG_W = items.FRIVILLIGREG_W;
        //    modell.BrukerTilgang.SMS = items.SMS;
        //    modell.BrukerTilgang.Sentralbord = items.Sentralbord;
        //    modell.BrukerTilgang.RaadUtvalg = items.RaadUtvalg;
        //    modell.BrukerTilgang.GudstjenesteAdm = items.GudstjenesteAdm;
        //    modell.BrukerTilgang.Adresering = items.Adresering;
        //    modell.BrukerTilgang.Folkeregister = items.Folkeregister;
        //    modell.BrukerTilgang.Ressurs_GUID = items.Ressurs_GUID;
        //    modell.BrukerTilgang.DB_PASSORD = items.DB_PASSORD;
        //    modell.BrukerTilgang.DB_BRUKERNAVN = items.DB_BRUKERNAVN;
        //    modell.BrukerTilgang.ADRESSE_INFO = items.ADRESSE_INFO;
        //    modell.BrukerTilgang.SPRAAK = items.SPRAAK;
        //    modell.BrukerTilgang.PRESTEGJELD_ID = items.PRESTEGJELD_ID;
        //    modell.BrukerTilgang.KLIENT_NAVN = items.KLIENT_NAVN;
        //    modell.BrukerTilgang.OpprettetAv = items.OpprettetAv;
        //    modell.BrukerTilgang.OpprettetDate = items.OpprettetDate;
        //    modell.BrukerTilgang.EndretAv = items.EndretAv;
        //    modell.BrukerTilgang.EndretDato = items.EndretDato;
        //    modell.BrukerTilgang.SlettetAv = items.SlettetAv;
        //    modell.BrukerTilgang.SlettetDato = items.SlettetDato;
        //    modell.BrukerTilgang.Konfirmasjon_S = items.Konfirmasjon_S;
        //    modell.BrukerTilgang.Frivilligreg_S = items.Frivilligreg_S;
        //    modell.BrukerTilgang.Aktiviteter_U = items.Aktiviteter_U;
        //    modell.BrukerTilgang.Aktiviteter_A = items.Aktiviteter_A;
        //    modell.BrukerTilgang.BesokTj_L = items.BesokTj_L;
        //    modell.BrukerTilgang.BesokTj_S = items.BesokTj_S;
        //    modell.BrukerTilgang.BesokTj_U = items.BesokTj_U;
        //    modell.BrukerTilgang.Innutmelding_A = items.Innutmelding_A;
        //    modell.BrukerTilgang.Daap_A = items.Daap_A;
        //    modell.BrukerTilgang.Konfirmasjon_A = items.Konfirmasjon_A;
        //    modell.BrukerTilgang.GDPRansvarlig = items.GDPRansvarlig;
        //    modell.BrukerTilgang.Bank = items.Bank;
        //    modell.BrukerTilgang.BesokTjeneste = items.BesokTjeneste;
        //    modell.BrukerTilgang.Program_GUID = items.Program_GUID;
        //    modell.BrukerTilgang.BrukerTilgangGuid = items.BrukerTilgangGuid;

        //    return PartialView("_BrukerTilgang", modell);
        //}

        //[HttpPost]
        //public async Task<bool> LagreBrukerTilgang(AdminModel modell)
        //{

        //    AdminBrukerRepository brukerRepository = new AdminBrukerRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    Models.BrukerTilgangItem item = new Models.BrukerTilgangItem();

        //    #region Setter verdier


        //    item.Fellesraad = modell.BrukerTilgang.Fellesraad;
        //    item.SoknNr = modell.BrukerTilgang.SoknNr;
        //    item.BrukerId = modell.BrukerTilgang.BrukerId;
        //    item.SoknId = modell.BrukerTilgang.SoknId;
        //    item.ADM = modell.BrukerTilgang.ADM;
        //    item.AKTIVITETER_R = modell.BrukerTilgang.AKTIVITETER_R;
        //    item.AKTIVITETER_W = modell.BrukerTilgang.AKTIVITETER_W;
        //    item.ANSATTREG_R = modell.BrukerTilgang.ANSATTREG_R;
        //    item.ANSATTREG_W = modell.BrukerTilgang.ANSATTREG_W;
        //    item.BIBLIOTEK = modell.BrukerTilgang.BIBLIOTEK;
        //    item.DOED_R = modell.BrukerTilgang.DOED_R;
        //    item.DOED_W = modell.BrukerTilgang.DOED_W;
        //    item.DAAP_R = modell.BrukerTilgang.DAAP_R;
        //    item.DAAP_W = modell.BrukerTilgang.DAAP_W;
        //    item.GUDSTJENESTE_R = modell.BrukerTilgang.GUDSTJENESTE_R;
        //    item.GUDSTJENESTE_W = modell.BrukerTilgang.GUDSTJENESTE_W;
        //    item.INNUTMELDING_R = modell.BrukerTilgang.INNUTMELDING_R;
        //    item.INNUTMELDING_W = modell.BrukerTilgang.INNUTMELDING_W;
        //    item.KONFIRMASJON_R = modell.BrukerTilgang.KONFIRMASJON_R;
        //    item.KONFIRMASJON_W = modell.BrukerTilgang.KONFIRMASJON_W;
        //    item.ARKIV_DOK_R = modell.BrukerTilgang.ARKIV_DOK_R;
        //    item.ARKIV_DOK_W = modell.BrukerTilgang.ARKIV_DOK_W;
        //    item.ARKIV_SAK_R = modell.BrukerTilgang.ARKIV_SAK_R;
        //    item.ARKIV_SAK_W = modell.BrukerTilgang.ARKIV_SAK_W;
        //    item.ARKIV_MOTE_R = modell.BrukerTilgang.ARKIV_MOTE_R;
        //    item.ARKIV_MOTE_W = modell.BrukerTilgang.ARKIV_MOTE_W;
        //    item.TIDSPLAN_ROM_R = modell.BrukerTilgang.TIDSPLAN_ROM_R;
        //    item.TIDSPLAN_ROM_W = modell.BrukerTilgang.TIDSPLAN_ROM_W;
        //    item.TIDSPLAN_PERS_R = modell.BrukerTilgang.TIDSPLAN_PERS_R;
        //    item.TIDSPLAN_PERS_W = modell.BrukerTilgang.TIDSPLAN_PERS_W;
        //    item.TIDSPLAN_GUDSTJENESTE = modell.BrukerTilgang.TIDSPLAN_GUDSTJENESTE;
        //    item.VIELSE_R = modell.BrukerTilgang.VIELSE_R;
        //    item.VIELSE_W = modell.BrukerTilgang.VIELSE_W;
        //    item.FASTE_DATA_R = modell.BrukerTilgang.FASTE_DATA_R;
        //    item.FASTE_DATA_W = modell.BrukerTilgang.FASTE_DATA_W;
        //    item.AVHOLDT = modell.BrukerTilgang.AVHOLDT;
        //    item.MEDLEMSREG = modell.BrukerTilgang.MEDLEMSREG;
        //    item.TIDSPLAN_GUDSTJENESTE_W = modell.BrukerTilgang.TIDSPLAN_GUDSTJENESTE_W;
        //    item.STANDARD_KLIENT = modell.BrukerTilgang.STANDARD_KLIENT;
        //    item.FRIVILLIGREG_R = modell.BrukerTilgang.FRIVILLIGREG_R;
        //    item.FRIVILLIGREG_W = modell.BrukerTilgang.FRIVILLIGREG_W;
        //    item.SMS = modell.BrukerTilgang.SMS;
        //    item.Sentralbord = modell.BrukerTilgang.Sentralbord;
        //    item.RaadUtvalg = modell.BrukerTilgang.RaadUtvalg;
        //    item.GudstjenesteAdm = modell.BrukerTilgang.GudstjenesteAdm;
        //    item.Adresering = modell.BrukerTilgang.Adresering;
        //    item.Folkeregister = modell.BrukerTilgang.Folkeregister;
        //    item.Ressurs_GUID = modell.BrukerTilgang.Ressurs_GUID;
        //    item.DB_PASSORD = modell.BrukerTilgang.DB_PASSORD;
        //    item.DB_BRUKERNAVN = modell.BrukerTilgang.DB_BRUKERNAVN;
        //    item.ADRESSE_INFO = modell.BrukerTilgang.ADRESSE_INFO;
        //    item.SPRAAK = modell.BrukerTilgang.SPRAAK;
        //    item.PRESTEGJELD_ID = modell.BrukerTilgang.PRESTEGJELD_ID;
        //    item.KLIENT_NAVN = modell.BrukerTilgang.KLIENT_NAVN;
        //    item.OpprettetAv = modell.BrukerTilgang.OpprettetAv;
        //    item.OpprettetDate = modell.BrukerTilgang.OpprettetDate;
        //    item.EndretAv = modell.BrukerTilgang.EndretAv;
        //    item.EndretDato = modell.BrukerTilgang.EndretDato;
        //    item.SlettetAv = modell.BrukerTilgang.SlettetAv;
        //    item.SlettetDato = modell.BrukerTilgang.SlettetDato;
        //    item.Konfirmasjon_S = modell.BrukerTilgang.Konfirmasjon_S;
        //    item.Frivilligreg_S = modell.BrukerTilgang.Frivilligreg_S;
        //    item.Aktiviteter_U = modell.BrukerTilgang.Aktiviteter_U;
        //    item.Aktiviteter_A = modell.BrukerTilgang.Aktiviteter_A;
        //    item.BesokTj_L = modell.BrukerTilgang.BesokTj_L;
        //    item.BesokTj_S = modell.BrukerTilgang.BesokTj_S;
        //    item.BesokTj_U = modell.BrukerTilgang.BesokTj_U;
        //    item.Innutmelding_A = modell.BrukerTilgang.Innutmelding_A;
        //    item.Daap_A = modell.BrukerTilgang.Daap_A;
        //    item.Konfirmasjon_A = modell.BrukerTilgang.Konfirmasjon_A;
        //    item.GDPRansvarlig = modell.BrukerTilgang.GDPRansvarlig;
        //    item.Bank = modell.BrukerTilgang.Bank;
        //    item.BesokTjeneste = modell.BrukerTilgang.BesokTjeneste;
        //    item.Program_GUID = modell.BrukerTilgang.Program_GUID;
        //    item.BrukerTilgangGuid = modell.BrukerTilgang.BrukerTilgangGuid;

        //    #endregion

        //    await brukerRepository.SetBrukerTilgang(logonInfo, item);

        //    return true;
        //}

        #endregion

    }
}
