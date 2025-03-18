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
using Susteni.Models.Ressurs;
using Microsoft.Extensions.Localization;

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; 
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Susteni.Models.Account;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public partial class RessursController : Controller
    {

        private readonly IConfiguration Configuration;

        public RessursController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            RessursModel modell = new RessursModel();
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
            modell.Ressurs.aktivTab = "tabGenerell";

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

        //public bool SetTab(string tab)
        //{

        //    HttpContext.Session.SetString("aktivTab", tab);
        //    return true;
        //}

        //public async Task<ActionResult> GetRessursNavn(string RessursGuid)
        //{
        //    RessursModel modell = new RessursModel();
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    RessursNavnItem items = await ressursRepository.GetRessurs(logonInfo, RessursGuid);

        //    modell.RessursNavn.Fellesraad = items.Fellesraad;
        //    modell.RessursNavn.RessursGuid = items.RessursGuid;
        //    modell.RessursNavn.KontaktGuid = items.KontaktGuid;
        //    modell.RessursNavn.RessId = items.RessId;
        //    modell.RessursNavn.BrukerId = items.BrukerId;
        //    modell.RessursNavn.ResType = items.ResType;
        //    modell.RessursNavn.Navn = items.Navn;
        //    modell.RessursNavn.Fornavn = items.Fornavn;
        //    modell.RessursNavn.Mellomnavn = items.Mellomnavn;
        //    modell.RessursNavn.Etternavn = items.Etternavn;
        //    modell.RessursNavn.Adresse = items.Adresse;
        //    modell.RessursNavn.PostNr = items.PostNr;
        //    modell.RessursNavn.Kjonn = items.Kjonn;
        //    modell.RessursNavn.Telefon = items.Telefon;
        //    modell.RessursNavn.Telefax = items.Telefax;
        //    modell.RessursNavn.Mobil = items.Mobil;
        //    modell.RessursNavn.Beskrivelse = items.Beskrivelse;
        //    modell.RessursNavn.KortNavn = items.KortNavn;
        //    modell.RessursNavn.Stilling = items.Stilling;
        //    modell.RessursNavn.PaaKal = items.PaaKal;
        //    modell.RessursNavn.Aktiv = items.Aktiv;
        //    modell.RessursNavn.DistriktGuid = items.DistriktGuid;
        //    modell.RessursNavn.Sortering = items.Sortering;
        //    modell.RessursNavn.Sortering2 = items.Sortering2;
        //    modell.RessursNavn.KardRess = items.KardRess;
        //    modell.RessursNavn.Type = items.Type;
        //    modell.RessursNavn.Farge = items.Farge;
        //    modell.RessursNavn.ReknKode = items.ReknKode;
        //    modell.RessursNavn.AntBegrPrDag = items.AntBegrPrDag;
        //    modell.RessursNavn.Monte = items.Monte;
        //    modell.RessursNavn.SoknNr = items.SoknNr;
        //    modell.RessursNavn.KardRessId = items.KardRessId;
        //    modell.RessursNavn.EPost = items.EPost;
        //    modell.RessursNavn.MottaSMS = items.MottaSMS;
        //    modell.RessursNavn.MottaEPost = items.MottaEPost;
        //    modell.RessursNavn.FargeNavn = items.FargeNavn;
        //    modell.RessursNavn.LabOraMRessGuid = items.LabOraMRessGuid;
        //    modell.RessursNavn.SorteringUt = items.SorteringUt;
        //    modell.RessursNavn.Sortering2Ut = items.Sortering2Ut;
        //    modell.RessursNavn.VisOppslag = items.VisOppslag;
        //    modell.RessursNavn.VisVisning = items.VisVisning;
        //    modell.RessursNavn.Liturg = items.Liturg;
        //    modell.RessursNavn.Predikant = items.Predikant;
        //    modell.RessursNavn.TekstLeser = items.TekstLeser;
        //    modell.RessursNavn.Organist = items.Organist;
        //    modell.RessursNavn.Klokker = items.Klokker;
        //    modell.RessursNavn.Kirketjener = items.Kirketjener;
        //    modell.RessursNavn.Kirkevert = items.Kirkevert;
        //    modell.RessursNavn.Saksbehandler = items.Saksbehandler;
        //    modell.RessursNavn.PersonNr = items.PersonNr;
        //    modell.RessursNavn.Nattverdsvert = items.Nattverdsvert;
        //    modell.RessursNavn.Daapsvert = items.Daapsvert;
        //    modell.RessursNavn.Hjelper1 = items.Hjelper1;
        //    modell.RessursNavn.Hjelper2 = items.Hjelper2;
        //    modell.RessursNavn.Hjelper3 = items.Hjelper3;
        //    modell.RessursNavn.Hjelper4 = items.Hjelper4;
        //    modell.RessursNavn.RessursEierGuid = items.RessursEierGuid;
        //    modell.RessursNavn.MinAntall = items.MinAntall;
        //    modell.RessursNavn.MaksAntall = items.MaksAntall;
        //    modell.RessursNavn.MaxAntall = items.MaxAntall;
        //    modell.RessursNavn.AnsvId = items.AnsvId;
        //    modell.RessursNavn.Fodt = items.Fodt;
        //    modell.RessursNavn.Gudstjeneste = items.Gudstjeneste;
        //    modell.RessursNavn.Stasjonskanning = items.Stasjonskanning;
        //    modell.RessursNavn.Gravferd = items.Gravferd;
        //    modell.RessursNavn.Mote = items.Mote;
        //    modell.RessursNavn.SyncExchange = items.SyncExchange;
        //    modell.RessursNavn.Gruppering = items.Gruppering;
        //    modell.RessursNavn.Hjelper5 = items.Hjelper5;
        //    modell.RessursNavn.Samtalerom = items.Samtalerom;
        //    modell.RessursNavn.Moeterom = items.Moeterom;
        //    modell.RessursNavn.Konserter = items.Konserter;
        //    modell.RessursNavn.Vielser = items.Vielser;
        //    modell.RessursNavn.Fagarbeider = items.Fagarbeider;
        //    modell.RessursNavn.SynkExchangeReadOnly = items.SynkExchangeReadOnly;
        //    modell.RessursNavn.LukketKalender = items.LukketKalender;
        //    modell.RessursNavn.StandardTilgang = items.StandardTilgang;
        //    modell.RessursNavn.GruppeType = items.GruppeType;
        //    modell.RessursNavn.OpprettetAv = items.OpprettetAv;
        //    modell.RessursNavn.OpprettetDate = items.OpprettetDate;
        //    modell.RessursNavn.EndretAv = items.EndretAv;
        //    modell.RessursNavn.EndretDato = items.EndretDato;
        //    modell.RessursNavn.SlettetAv = items.SlettetAv;
        //    modell.RessursNavn.SlettetDato = items.SlettetDato;
        //    modell.RessursNavn.Graver = items.Graver;
        //    modell.RessursNavn.Solist = items.Solist;
        //    modell.RessursNavn.Kor = items.Kor;
        //    modell.RessursNavn.SynkExchange2 = items.SynkExchange2;
        //    modell.RessursNavn.eKirkebok = items.eKirkebok;
        //    modell.RessursNavn.KirkeDbId = items.KirkeDbId;
        //    modell.RessursNavn.KalenderGruppe = items.KalenderGruppe;
        //    modell.RessursNavn.Medliturg = items.Medliturg;
        //    modell.RessursNavn.Aktiviet = items.Aktiviet;
        //    modell.RessursNavn.Aktivitet = items.Aktivitet;
        //    modell.RessursNavn.SynkFromDate = items.SynkFromDate;
        //    modell.RessursNavn.GPS = items.GPS;
        //    modell.RessursNavn.PassordWs = items.PassordWs;
        //    modell.RessursNavn.TilgjengeligWs = items.TilgjengeligWs;
        //    modell.RessursNavn.PostnrId = items.PostnrId;
        //    modell.RessursNavn.Besok = items.Besok;
        //    modell.RessursNavn.SynkExchange = items.SynkExchange;
        //    modell.RessursNavn.Varmestyring = items.Varmestyring;
        //    modell.RessursNavn.KjopsDato = items.KjopsDato;
        //    modell.RessursNavn.Produsent = items.Produsent;
        //    modell.RessursNavn.Verdi = items.Verdi;
        //    modell.RessursNavn.Lat = items.Lat;
        //    modell.RessursNavn.Long = items.Long;
        //    modell.RessursNavn.Kollekt = items.Kollekt;
        //    modell.RessursNavn.Forsanger = items.Forsanger;
        //    modell.RessursNavn.Andre = items.Andre;
        //    modell.RessursNavn.Tittel = items.Tittel;
        //    modell.RessursNavn.TypeRessurs = items.TypeRessurs;
        //    modell.RessursNavn.StandardBildeId = items.StandardBildeId;
        //    modell.RessursNavn.KirkebyggUrl = items.KirkebyggUrl;
        //    modell.RessursNavn.Region = items.Region;
        //    modell.RessursNavn.AktivMinMenighet = items.AktivMinMenighet;
        //    modell.RessursNavn.TilskrivesBrev = items.TilskrivesBrev;
        //    modell.RessursNavn.TilskrivesEPost = items.TilskrivesEPost;
        //    modell.RessursNavn.TilskrivesSMS = items.TilskrivesSMS;
        //    modell.RessursNavn.TilskrivesTelefon = items.TilskrivesTelefon;
        //    modell.RessursNavn.GDPRStatus = items.GDPRStatus;
        //    modell.RessursNavn.SistImpersonated = items.SistImpersonated;
        //    modell.RessursNavn.SistImpersonatedFeilet = items.SistImpersonatedFeilet;
        //    modell.RessursNavn.TilgangMinKirkeside = items.TilgangMinKirkeside;
        //    modell.RessursNavn.Timer = items.Timer;
        //    modell.RessursNavn.VisMobil = items.VisMobil;
        //    modell.RessursNavn.MobilNavn = items.MobilNavn;
        //    modell.RessursNavn.webuserId = items.webuserId;

        //    return PartialView("_RessursNavn", modell);
        //}

        //public async Task<ActionResult> GetRessurs(string RessursGuid)
        //{
        //    RessursModel modell = new RessursModel();
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    string aktivTab = HttpContext.Session.GetString("aktivTab");

        //    RessursNavnItem items = await ressursRepository.GetRessurs(logonInfo, RessursGuid);

        //    if (aktivTab != null)
        //    {
        //        modell.Ressurs.aktivTab = aktivTab;
        //    }
        //    else
        //    {
        //        modell.Ressurs.aktivTab = "tabGenerell";
        //    }
        //    modell.Ressurs.Fellesraad = items.Fellesraad;
        //    modell.Ressurs.RessursGuid = items.RessursGuid;
        //    modell.Ressurs.KontaktGuid = items.KontaktGuid;
        //    modell.Ressurs.RessId = items.RessId;
        //    modell.Ressurs.BrukerId = items.BrukerId;
        //    modell.Ressurs.ResType = items.ResType;
        //    modell.Ressurs.Navn = items.Navn;
        //    modell.Ressurs.Fornavn = items.Fornavn;
        //    modell.Ressurs.Mellomnavn = items.Mellomnavn;
        //    modell.Ressurs.Etternavn = items.Etternavn;
        //    modell.Ressurs.Adresse = items.Adresse;
        //    modell.Ressurs.PostNr = items.PostNr;
        //    modell.Ressurs.Kjonn = items.Kjonn;
        //    modell.Ressurs.Telefon = items.Telefon;
        //    modell.Ressurs.Telefax = items.Telefax;
        //    modell.Ressurs.Mobil = items.Mobil;
        //    modell.Ressurs.Beskrivelse = items.Beskrivelse;
        //    modell.Ressurs.KortNavn = items.KortNavn;
        //    modell.Ressurs.Stilling = items.Stilling;
        //    modell.Ressurs.PaaKal = items.PaaKal;
        //    modell.Ressurs.Aktiv = items.Aktiv;
        //    modell.Ressurs.DistriktGuid = items.DistriktGuid;
        //    modell.Ressurs.Sortering = items.Sortering;
        //    modell.Ressurs.Sortering2 = items.Sortering2;
        //    modell.Ressurs.KardRess = items.KardRess;
        //    modell.Ressurs.Type = items.Type;
        //    modell.Ressurs.Farge = items.Farge;
        //    modell.Ressurs.ReknKode = items.ReknKode;
        //    modell.Ressurs.AntBegrPrDag = items.AntBegrPrDag;
        //    modell.Ressurs.Monte = items.Monte;
        //    modell.Ressurs.SoknNr = items.SoknNr;
        //    modell.Ressurs.KardRessId = items.KardRessId;
        //    modell.Ressurs.EPost = items.EPost;
        //    modell.Ressurs.MottaSMS = items.MottaSMS;
        //    modell.Ressurs.MottaEPost = items.MottaEPost;
        //    modell.Ressurs.FargeNavn = items.FargeNavn;
        //    modell.Ressurs.LabOraMRessGuid = items.LabOraMRessGuid;
        //    modell.Ressurs.SorteringUt = items.SorteringUt;
        //    modell.Ressurs.Sortering2Ut = items.Sortering2Ut;
        //    modell.Ressurs.VisOppslag = items.VisOppslag;
        //    modell.Ressurs.VisVisning = items.VisVisning;
        //    modell.Ressurs.Liturg = items.Liturg;
        //    modell.Ressurs.Predikant = items.Predikant;
        //    modell.Ressurs.TekstLeser = items.TekstLeser;
        //    modell.Ressurs.Organist = items.Organist;
        //    modell.Ressurs.Klokker = items.Klokker;
        //    modell.Ressurs.Kirketjener = items.Kirketjener;
        //    modell.Ressurs.Kirkevert = items.Kirkevert;
        //    modell.Ressurs.Saksbehandler = items.Saksbehandler;
        //    modell.Ressurs.PersonNr = items.PersonNr;
        //    modell.Ressurs.Nattverdsvert = items.Nattverdsvert;
        //    modell.Ressurs.Daapsvert = items.Daapsvert;
        //    modell.Ressurs.Hjelper1 = items.Hjelper1;
        //    modell.Ressurs.Hjelper2 = items.Hjelper2;
        //    modell.Ressurs.Hjelper3 = items.Hjelper3;
        //    modell.Ressurs.Hjelper4 = items.Hjelper4;
        //    modell.Ressurs.RessursEierGuid = items.RessursEierGuid;
        //    modell.Ressurs.MinAntall = items.MinAntall;
        //    modell.Ressurs.MaksAntall = items.MaksAntall;
        //    modell.Ressurs.MaxAntall = items.MaxAntall;
        //    modell.Ressurs.AnsvId = items.AnsvId;
        //    modell.Ressurs.Fodt = items.Fodt;
        //    modell.Ressurs.Gudstjeneste = items.Gudstjeneste;
        //    modell.Ressurs.Stasjonskanning = items.Stasjonskanning;
        //    modell.Ressurs.Gravferd = items.Gravferd;
        //    modell.Ressurs.Mote = items.Mote;
        //    modell.Ressurs.SyncExchange = items.SyncExchange;
        //    modell.Ressurs.Gruppering = items.Gruppering;
        //    modell.Ressurs.Hjelper5 = items.Hjelper5;
        //    modell.Ressurs.Samtalerom = items.Samtalerom;
        //    modell.Ressurs.Moeterom = items.Moeterom;
        //    modell.Ressurs.Konserter = items.Konserter;
        //    modell.Ressurs.Vielser = items.Vielser;
        //    modell.Ressurs.Fagarbeider = items.Fagarbeider;
        //    modell.Ressurs.SynkExchangeReadOnly = items.SynkExchangeReadOnly;
        //    modell.Ressurs.LukketKalender = items.LukketKalender;
        //    modell.Ressurs.StandardTilgang = items.StandardTilgang;
        //    modell.Ressurs.GruppeType = items.GruppeType;
        //    modell.Ressurs.OpprettetAv = items.OpprettetAv;
        //    modell.Ressurs.OpprettetDate = items.OpprettetDate;
        //    modell.Ressurs.EndretAv = items.EndretAv;
        //    modell.Ressurs.EndretDato = items.EndretDato;
        //    modell.Ressurs.SlettetAv = items.SlettetAv;
        //    modell.Ressurs.SlettetDato = items.SlettetDato;
        //    modell.Ressurs.Graver = items.Graver;
        //    modell.Ressurs.Solist = items.Solist;
        //    modell.Ressurs.Kor = items.Kor;
        //    modell.Ressurs.SynkExchange2 = items.SynkExchange2;
        //    modell.Ressurs.eKirkebok = items.eKirkebok;
        //    modell.Ressurs.KirkeDbId = items.KirkeDbId;
        //    modell.Ressurs.KalenderGruppe = items.KalenderGruppe;
        //    modell.Ressurs.Medliturg = items.Medliturg;
        //    modell.Ressurs.Aktiviet = items.Aktiviet;
        //    modell.Ressurs.Aktivitet = items.Aktivitet;
        //    modell.Ressurs.SynkFromDate = items.SynkFromDate;
        //    modell.Ressurs.GPS = items.GPS;
        //    modell.Ressurs.PassordWs = items.PassordWs;
        //    modell.Ressurs.TilgjengeligWs = items.TilgjengeligWs;
        //    modell.Ressurs.PostNrId = items.PostnrId;
        //    modell.Ressurs.Besok = items.Besok;
        //    modell.Ressurs.SynkExchange = items.SynkExchange;
        //    modell.Ressurs.Varmestyring = items.Varmestyring;
        //    modell.Ressurs.KjopsDato = items.KjopsDato;
        //    modell.Ressurs.Produsent = items.Produsent;
        //    modell.Ressurs.Verdi = items.Verdi;
        //    modell.Ressurs.Lat = items.Lat;
        //    modell.Ressurs.Long = items.Long;
        //    modell.Ressurs.Kollekt = items.Kollekt;
        //    modell.Ressurs.Forsanger = items.Forsanger;
        //    modell.Ressurs.Andre = items.Andre;
        //    modell.Ressurs.Tittel = items.Tittel;
        //    modell.Ressurs.TypeRessurs = items.TypeRessurs;
        //    modell.Ressurs.StandardBildeGuid = items.StandardBildeId;
        //    modell.Ressurs.KirkebyggUrl = items.KirkebyggUrl;
        //    modell.Ressurs.Region = items.Region;
        //    modell.Ressurs.AktivMinMenighet = items.AktivMinMenighet;
        //    modell.Ressurs.TilskrivesBrev = items.TilskrivesBrev;
        //    modell.Ressurs.TilskrivesePost = items.TilskrivesEPost;
        //    modell.Ressurs.TilskrivesSMS = items.TilskrivesSMS;
        //    modell.Ressurs.TilskrivesTelefon = items.TilskrivesTelefon;
        //    modell.Ressurs.GDPRStatus = items.GDPRStatus;
        //    modell.Ressurs.SistImpersonated = items.SistImpersonated;
        //    modell.Ressurs.SistImpersonatedFeilet = items.SistImpersonatedFeilet;
        //    modell.Ressurs.TilgangMinKirkeside = items.TilgangMinKirkeside;
        //    modell.Ressurs.Timer = items.Timer;
        //    modell.Ressurs.VisMobil = items.VisMobil;
        //    modell.Ressurs.MobilNavn = items.MobilNavn;
        //    modell.Ressurs.webuserId = items.webuserId;

        //    return PartialView("_RessursNavn", modell);
        //}

        //[HttpPost]
        //public async Task<bool> LagreRessursNavn(RessursModel modell)
        //{

        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    Models.RessursNavnItem item = new Models.RessursNavnItem();

        //    #region Setter verdier


        //    item.Fellesraad = modell.RessursNavn.Fellesraad;
        //    item.RessursGuid = modell.RessursNavn.RessursGuid;
        //    item.KontaktGuid = modell.RessursNavn.KontaktGuid;
        //    item.RessId = modell.RessursNavn.RessId;
        //    item.BrukerId = modell.RessursNavn.BrukerId;
        //    if (modell.RessursNavn.ResType == 0)
        //    {
        //        item.ResType = (int)HttpContext.Session.GetInt32("ResType");
        //    }
        //    else
        //    {
        //        item.ResType = modell.RessursNavn.ResType;
        //    }
        //    item.Navn = modell.RessursNavn.Navn;
        //    item.Fornavn = modell.RessursNavn.Fornavn;
        //    item.Mellomnavn = modell.RessursNavn.Mellomnavn;
        //    item.Etternavn = modell.RessursNavn.Etternavn;
        //    item.Adresse = modell.RessursNavn.Adresse;
        //    item.PostNr = modell.RessursNavn.PostNr;
        //    item.Kjonn = modell.RessursNavn.Kjonn;
        //    item.Telefon = modell.RessursNavn.Telefon;
        //    item.Telefax = modell.RessursNavn.Telefax;
        //    item.Mobil = modell.RessursNavn.Mobil;
        //    item.Beskrivelse = modell.RessursNavn.Beskrivelse;
        //    item.KortNavn = modell.RessursNavn.KortNavn;
        //    item.Stilling = modell.RessursNavn.Stilling;
        //    item.PaaKal = modell.RessursNavn.PaaKal;
        //    item.Aktiv = modell.RessursNavn.Aktiv;
        //    item.DistriktGuid = modell.RessursNavn.DistriktGuid;
        //    item.Sortering = modell.RessursNavn.Sortering;
        //    item.Sortering2 = modell.RessursNavn.Sortering2;
        //    item.KardRess = modell.RessursNavn.KardRess;
        //    item.Type = modell.RessursNavn.Type;
        //    item.Farge = modell.RessursNavn.Farge;
        //    item.ReknKode = modell.RessursNavn.ReknKode;
        //    item.AntBegrPrDag = modell.RessursNavn.AntBegrPrDag;
        //    item.Monte = modell.RessursNavn.Monte;
        //    item.SoknNr = modell.RessursNavn.SoknNr;
        //    item.KardRessId = modell.RessursNavn.KardRessId;
        //    item.EPost = modell.RessursNavn.EPost;
        //    item.MottaSMS = modell.RessursNavn.MottaSMS;
        //    item.MottaEPost = modell.RessursNavn.MottaEPost;
        //    item.FargeNavn = modell.RessursNavn.FargeNavn;
        //    item.LabOraMRessGuid = modell.RessursNavn.LabOraMRessGuid;
        //    item.SorteringUt = modell.RessursNavn.SorteringUt;
        //    item.Sortering2Ut = modell.RessursNavn.Sortering2Ut;
        //    item.VisOppslag = modell.RessursNavn.VisOppslag;
        //    item.VisVisning = modell.RessursNavn.VisVisning;
        //    item.Liturg = modell.RessursNavn.Liturg;
        //    item.Predikant = modell.RessursNavn.Predikant;
        //    item.TekstLeser = modell.RessursNavn.TekstLeser;
        //    item.Organist = modell.RessursNavn.Organist;
        //    item.Klokker = modell.RessursNavn.Klokker;
        //    item.Kirketjener = modell.RessursNavn.Kirketjener;
        //    item.Kirkevert = modell.RessursNavn.Kirkevert;
        //    item.Saksbehandler = modell.RessursNavn.Saksbehandler;
        //    item.PersonNr = modell.RessursNavn.PersonNr;
        //    item.Nattverdsvert = modell.RessursNavn.Nattverdsvert;
        //    item.Daapsvert = modell.RessursNavn.Daapsvert;
        //    item.Hjelper1 = modell.RessursNavn.Hjelper1;
        //    item.Hjelper2 = modell.RessursNavn.Hjelper2;
        //    item.Hjelper3 = modell.RessursNavn.Hjelper3;
        //    item.Hjelper4 = modell.RessursNavn.Hjelper4;
        //    item.RessursEierGuid = modell.RessursNavn.RessursEierGuid;
        //    item.MinAntall = modell.RessursNavn.MinAntall;
        //    item.MaksAntall = modell.RessursNavn.MaksAntall;
        //    item.MaxAntall = modell.RessursNavn.MaxAntall;
        //    item.AnsvId = modell.RessursNavn.AnsvId;
        //    item.Fodt = modell.RessursNavn.Fodt;
        //    item.Gudstjeneste = modell.RessursNavn.Gudstjeneste;
        //    item.Stasjonskanning = modell.RessursNavn.Stasjonskanning;
        //    item.Gravferd = modell.RessursNavn.Gravferd;
        //    item.Mote = modell.RessursNavn.Mote;
        //    item.SyncExchange = modell.RessursNavn.SyncExchange;
        //    item.Gruppering = modell.RessursNavn.Gruppering;
        //    item.Hjelper5 = modell.RessursNavn.Hjelper5;
        //    item.Samtalerom = modell.RessursNavn.Samtalerom;
        //    item.Moeterom = modell.RessursNavn.Moeterom;
        //    item.Konserter = modell.RessursNavn.Konserter;
        //    item.Vielser = modell.RessursNavn.Vielser;
        //    item.Fagarbeider = modell.RessursNavn.Fagarbeider;
        //    item.SynkExchangeReadOnly = modell.RessursNavn.SynkExchangeReadOnly;
        //    item.LukketKalender = modell.RessursNavn.LukketKalender;
        //    item.StandardTilgang = modell.RessursNavn.StandardTilgang;
        //    item.GruppeType = modell.RessursNavn.GruppeType;
        //    item.OpprettetAv = modell.RessursNavn.OpprettetAv;
        //    item.OpprettetDate = modell.RessursNavn.OpprettetDate;
        //    item.EndretAv = modell.RessursNavn.EndretAv;
        //    item.EndretDato = modell.RessursNavn.EndretDato;
        //    item.SlettetAv = modell.RessursNavn.SlettetAv;
        //    item.SlettetDato = modell.RessursNavn.SlettetDato;
        //    item.Graver = modell.RessursNavn.Graver;
        //    item.Solist = modell.RessursNavn.Solist;
        //    item.Kor = modell.RessursNavn.Kor;
        //    item.SynkExchange2 = modell.RessursNavn.SynkExchange2;
        //    item.eKirkebok = modell.RessursNavn.eKirkebok;
        //    item.KirkeDbId = modell.RessursNavn.KirkeDbId;
        //    item.KalenderGruppe = modell.RessursNavn.KalenderGruppe;
        //    item.Medliturg = modell.RessursNavn.Medliturg;
        //    item.Aktiviet = modell.RessursNavn.Aktiviet;
        //    item.Aktivitet = modell.RessursNavn.Aktivitet;
        //    item.SynkFromDate = modell.RessursNavn.SynkFromDate;
        //    item.GPS = modell.RessursNavn.GPS;
        //    item.PassordWs = modell.RessursNavn.PassordWs;
        //    item.TilgjengeligWs = modell.RessursNavn.TilgjengeligWs;
        //    item.PostnrId = modell.RessursNavn.PostnrId;
        //    item.Besok = modell.RessursNavn.Besok;
        //    item.SynkExchange = modell.RessursNavn.SynkExchange;
        //    item.Varmestyring = modell.RessursNavn.Varmestyring;
        //    item.KjopsDato = modell.RessursNavn.KjopsDato;
        //    item.Produsent = modell.RessursNavn.Produsent;
        //    item.Verdi = modell.RessursNavn.Verdi;
        //    item.Lat = modell.RessursNavn.Lat;
        //    item.Long = modell.RessursNavn.Long;
        //    item.Kollekt = modell.RessursNavn.Kollekt;
        //    item.Forsanger = modell.RessursNavn.Forsanger;
        //    item.Andre = modell.RessursNavn.Andre;
        //    item.Tittel = modell.RessursNavn.Tittel;
        //    item.TypeRessurs = modell.RessursNavn.TypeRessurs;
        //    item.StandardBildeId = modell.RessursNavn.StandardBildeId;
        //    item.KirkebyggUrl = modell.RessursNavn.KirkebyggUrl;
        //    item.Region = modell.RessursNavn.Region;
        //    item.AktivMinMenighet = modell.RessursNavn.AktivMinMenighet;
        //    item.TilskrivesBrev = modell.RessursNavn.TilskrivesBrev;
        //    item.TilskrivesEPost = modell.RessursNavn.TilskrivesEPost;
        //    item.TilskrivesSMS = modell.RessursNavn.TilskrivesSMS;
        //    item.TilskrivesTelefon = modell.RessursNavn.TilskrivesTelefon;
        //    item.GDPRStatus = modell.RessursNavn.GDPRStatus;
        //    item.SistImpersonated = modell.RessursNavn.SistImpersonated;
        //    item.SistImpersonatedFeilet = modell.RessursNavn.SistImpersonatedFeilet;
        //    item.TilgangMinKirkeside = modell.RessursNavn.TilgangMinKirkeside;
        //    item.Timer = modell.RessursNavn.Timer;
        //    item.VisMobil = modell.RessursNavn.VisMobil;
        //    item.MobilNavn = modell.RessursNavn.MobilNavn;
        //    item.webuserId = modell.RessursNavn.webuserId;

        //    #endregion

        //    await ressursRepository.SetRessurs(logonInfo, item);

        //    return true;
        //}

        //[HttpPost]
        //public async Task<bool> LagreRessurs(RessursModel modell)
        //{

        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    Models.RessursNavnItem item = new Models.RessursNavnItem();

        //    #region Setter verdier


        //    item.Fellesraad = modell.Ressurs.Fellesraad;
        //    item.RessursGuid = modell.Ressurs.RessursGuid;
        //    item.KontaktGuid = modell.Ressurs.KontaktGuid;
        //    item.RessId = modell.Ressurs.RessId;
        //    item.BrukerId = modell.Ressurs.BrukerId;
        //    if (modell.Ressurs.ResType == 0)
        //    {
        //        item.ResType = (int)HttpContext.Session.GetInt32("RessursType");
        //    }
        //    else
        //    {
        //        item.ResType = modell.Ressurs.ResType;
        //    }
        //    item.Navn = modell.Ressurs.Navn;
        //    item.Fornavn = modell.Ressurs.Fornavn;
        //    item.Mellomnavn = modell.Ressurs.Mellomnavn;
        //    item.Etternavn = modell.Ressurs.Etternavn;
        //    item.Adresse = modell.Ressurs.Adresse;
        //    item.PostNr = modell.Ressurs.PostNr;
        //    item.Kjonn = modell.Ressurs.Kjonn;
        //    item.Telefon = modell.Ressurs.Telefon;
        //    item.Telefax = modell.Ressurs.Telefax;
        //    item.Mobil = modell.Ressurs.Mobil;
        //    item.Beskrivelse = modell.Ressurs.Beskrivelse;
        //    item.KortNavn = modell.Ressurs.KortNavn;
        //    item.Stilling = modell.Ressurs.Stilling;
        //    item.PaaKal = modell.Ressurs.PaaKal;
        //    item.Aktiv = modell.Ressurs.Aktiv;
        //    item.DistriktGuid = modell.Ressurs.DistriktGuid;
        //    item.Sortering = modell.Ressurs.Sortering;
        //    item.Sortering2 = modell.Ressurs.Sortering2;
        //    item.KardRess = modell.Ressurs.KardRess;
        //    item.Type = modell.Ressurs.Type;
        //    item.Farge = modell.Ressurs.Farge;
        //    item.ReknKode = modell.Ressurs.ReknKode;
        //    item.AntBegrPrDag = modell.Ressurs.AntBegrPrDag;
        //    item.Monte = modell.Ressurs.Monte;
        //    item.SoknNr = modell.Ressurs.SoknNr;
        //    item.KardRessId = modell.Ressurs.KardRessId;
        //    item.EPost = modell.Ressurs.EPost;
        //    item.MottaSMS = modell.Ressurs.MottaSMS;
        //    item.MottaEPost = modell.Ressurs.MottaEPost;
        //    item.FargeNavn = modell.Ressurs.FargeNavn;
        //    item.LabOraMRessGuid = modell.Ressurs.LabOraMRessGuid;
        //    item.SorteringUt = modell.Ressurs.SorteringUt;
        //    item.Sortering2Ut = modell.Ressurs.Sortering2Ut;
        //    item.VisOppslag = modell.Ressurs.VisOppslag;
        //    item.VisVisning = modell.Ressurs.VisVisning;
        //    item.Liturg = modell.Ressurs.Liturg;
        //    item.Predikant = modell.Ressurs.Predikant;
        //    item.TekstLeser = modell.Ressurs.TekstLeser;
        //    item.Organist = modell.Ressurs.Organist;
        //    item.Klokker = modell.Ressurs.Klokker;
        //    item.Kirketjener = modell.Ressurs.Kirketjener;
        //    item.Kirkevert = modell.Ressurs.Kirkevert;
        //    item.Saksbehandler = modell.Ressurs.Saksbehandler;
        //    item.PersonNr = modell.Ressurs.PersonNr;
        //    item.Nattverdsvert = modell.Ressurs.Nattverdsvert;
        //    item.Daapsvert = modell.Ressurs.Daapsvert;
        //    item.Hjelper1 = modell.Ressurs.Hjelper1;
        //    item.Hjelper2 = modell.Ressurs.Hjelper2;
        //    item.Hjelper3 = modell.Ressurs.Hjelper3;
        //    item.Hjelper4 = modell.Ressurs.Hjelper4;
        //    item.RessursEierGuid = modell.Ressurs.RessursEierGuid;
        //    item.MinAntall = modell.Ressurs.MinAntall;
        //    item.MaksAntall = modell.Ressurs.MaksAntall;
        //    item.MaxAntall = modell.Ressurs.MaxAntall;
        //    item.AnsvId = modell.Ressurs.AnsvId;
        //    item.Fodt = modell.Ressurs.Fodt;
        //    item.Gudstjeneste = modell.Ressurs.Gudstjeneste;
        //    item.Stasjonskanning = modell.Ressurs.Stasjonskanning;
        //    item.Gravferd = modell.Ressurs.Gravferd;
        //    item.Mote = modell.Ressurs.Mote;
        //    item.SyncExchange = modell.Ressurs.SyncExchange;
        //    item.Gruppering = modell.Ressurs.Gruppering;
        //    item.Hjelper5 = modell.Ressurs.Hjelper5;
        //    item.Samtalerom = modell.Ressurs.Samtalerom;
        //    item.Moeterom = modell.Ressurs.Moeterom;
        //    item.Konserter = modell.Ressurs.Konserter;
        //    item.Vielser = modell.Ressurs.Vielser;
        //    item.Fagarbeider = modell.Ressurs.Fagarbeider;
        //    item.SynkExchangeReadOnly = modell.Ressurs.SynkExchangeReadOnly;
        //    item.LukketKalender = modell.Ressurs.LukketKalender;
        //    item.StandardTilgang = modell.Ressurs.StandardTilgang;
        //    item.GruppeType = modell.Ressurs.GruppeType;
        //    item.OpprettetAv = modell.Ressurs.OpprettetAv;
        //    item.OpprettetDate = modell.Ressurs.OpprettetDate;
        //    item.EndretAv = modell.Ressurs.EndretAv;
        //    item.EndretDato = modell.Ressurs.EndretDato;
        //    item.SlettetAv = modell.Ressurs.SlettetAv;
        //    item.SlettetDato = modell.Ressurs.SlettetDato;
        //    item.Graver = modell.Ressurs.Graver;
        //    item.Solist = modell.Ressurs.Solist;
        //    item.Kor = modell.Ressurs.Kor;
        //    item.SynkExchange2 = modell.Ressurs.SynkExchange2;
        //    item.eKirkebok = modell.Ressurs.eKirkebok;
        //    item.KirkeDbId = modell.Ressurs.KirkeDbId;
        //    item.KalenderGruppe = modell.Ressurs.KalenderGruppe;
        //    item.Medliturg = modell.Ressurs.Medliturg;
        //    item.Aktiviet = modell.Ressurs.Aktiviet;
        //    item.Aktivitet = modell.Ressurs.Aktivitet;
        //    item.SynkFromDate = modell.Ressurs.SynkFromDate;
        //    item.GPS = modell.Ressurs.GPS;
        //    item.PassordWs = modell.Ressurs.PassordWs;
        //    item.TilgjengeligWs = modell.Ressurs.TilgjengeligWs;
        //    item.PostnrId = modell.Ressurs.PostNrId;
        //    item.Besok = modell.Ressurs.Besok;
        //    item.SynkExchange = modell.Ressurs.SynkExchange;
        //    item.Varmestyring = modell.Ressurs.Varmestyring;
        //    item.KjopsDato = modell.Ressurs.KjopsDato;
        //    item.Produsent = modell.Ressurs.Produsent;
        //    item.Verdi = modell.Ressurs.Verdi;
        //    item.Lat = modell.Ressurs.Lat;
        //    item.Long = modell.Ressurs.Long;
        //    item.Kollekt = modell.Ressurs.Kollekt;
        //    item.Forsanger = modell.Ressurs.Forsanger;
        //    item.Andre = modell.Ressurs.Andre;
        //    item.Tittel = modell.Ressurs.Tittel;
        //    item.TypeRessurs = modell.Ressurs.TypeRessurs;
        //    item.StandardBildeId = modell.Ressurs.StandardBildeGuid;
        //    item.KirkebyggUrl = modell.Ressurs.KirkebyggUrl;
        //    item.Region = modell.Ressurs.Region;
        //    item.AktivMinMenighet = modell.Ressurs.AktivMinMenighet;
        //    item.TilskrivesBrev = modell.Ressurs.TilskrivesBrev;
        //    item.TilskrivesEPost = modell.Ressurs.TilskrivesePost;
        //    item.TilskrivesSMS = modell.Ressurs.TilskrivesSMS;
        //    item.TilskrivesTelefon = modell.Ressurs.TilskrivesTelefon;
        //    item.GDPRStatus = modell.Ressurs.GDPRStatus;
        //    item.SistImpersonated = modell.Ressurs.SistImpersonated;
        //    item.SistImpersonatedFeilet = modell.Ressurs.SistImpersonatedFeilet;
        //    item.TilgangMinKirkeside = modell.Ressurs.TilgangMinKirkeside;
        //    item.Timer = modell.Ressurs.Timer;
        //    item.VisMobil = modell.Ressurs.VisMobil;
        //    item.MobilNavn = modell.Ressurs.MobilNavn;
        //    item.webuserId = modell.Ressurs.webuserId;
        //    item.KalenderByra = modell.Ressurs.KalenderByra;
        //    item.Bruksomrade = modell.Ressurs.Bruksomrade;
        //    if (item.Bruksomrade != null) {
        //        foreach (var omr in item.Bruksomrade)
        //        {
        //            switch (omr)
        //            {
        //                case "Møte":
        //                    item.Mote = true;
        //                    break;

        //                case "Konserter":
        //                    item.Konserter = true;
        //                    break;

        //                case "Aktiviteter":
        //                    item.Aktivitet = true;
        //                    break;

        //                case "Samtalerom":
        //                    item.Samtalerom = true;
        //                    break;

        //                case "Gudstjeneste":
        //                    item.Gudstjeneste = true;
        //                    break;

        //                case "Begravelse":
        //                    item.Gravferd = true;
        //                    break;

        //                case "Vielse":
        //                    item.Vielser = true;
        //                    break;

        //            }
        //        }
        //    }

        //    #endregion

        //    await ressursRepository.SetRessurs(logonInfo, item);

        //    return true;
        //}



        //[HttpPost]
        //public async Task<bool> OpprettVikar(string Navn, string resType, string soknId)
        //{

        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    SrcReturnValue retur = new();

        //    Models.RessursNavnItem item = new Models.RessursNavnItem();

        //    #region Setter verdier

        //    item.ResType = 99;
        //    item.Navn = Navn;
        //    //item.Fornavn = modell.Ressurs.Fornavn;
        //    //item.Mellomnavn = modell.Ressurs.Mellomnavn;
        //    //item.Etternavn = modell.Ressurs.Etternavn;
        //    switch (resType) {
        //        case "Liturg":
        //            item.Liturg = true;
        //        break;

        //        case "Organist":
        //            item.Organist = true;
        //            break;

        //        case "Predikant":
        //            item.Predikant = true;
        //            break;

        //        case "TekstLeser":
        //            item.TekstLeser = true;
        //            break;

        //        case "Klokker":
        //            item.Klokker = true;
        //            break;

        //        case "Kirketjener":
        //            item.Kirketjener = true;
        //            break;

        //        case "Kirkevert":
        //            item.Kirkevert = true;
        //            break;
        //    }

        //    #endregion

        //    retur = await ressursRepository.SetRessurs(logonInfo, item);

        //    await ressursRepository.SetRessursSokn(logonInfo, retur.NewGuid, soknId);

        //    return true;
        //}


        //public async Task<ActionResult> getRessursListe([DataSourceRequest] DataSourceRequest request, int ressursType)
        //{
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    HttpContext.Session.SetInt32("RessursType", ressursType);

        //    string aktivTab = HttpContext.Session.GetString("aktivTab");

        //    if (ressursType != 2 && aktivTab == "tabRom")
        //    {
        //        HttpContext.Session.SetString("aktivTab", "tabGenerell");
        //    }

        //    List<Models.RessursItem> items = await ressursRepository.GetRessursListe(logonInfo, ressursType, "", "");

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task<ActionResult> getKundeRessursListe([DataSourceRequest] DataSourceRequest request, string fellesraad, int ressursType, string filterText, string sortering)
        //{
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();
        //    HttpContext.Session.SetInt32("RessursType", ressursType);

        //    logonInfo.AktivFellesraad = fellesraad;

        //    List<Models.RessursItem> items = await ressursRepository.GetRessursListe(logonInfo, ressursType, filterText, sortering);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task<ActionResult> getRessursListeMulti([DataSourceRequest] DataSourceRequest request, string ressursType)
        //{
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.RessursItem> items = await ressursRepository.GetRessursListeMulti(logonInfo, ressursType);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task<ActionResult> getRessursFunksjoner([DataSourceRequest] DataSourceRequest request, int ressursType, string soknId, string funksjon)
        //{
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    if (soknId == null) { soknId = ""; }

        //    List<Models.RessursListeNavnItem> items = await ressursRepository.GetRessursFunksjonerListe(logonInfo, ressursType, soknId, funksjon);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task<ActionResult> getSeremonisteder([DataSourceRequest] DataSourceRequest request, string soknNr, string typeRom, string sermStedGuid)
        //{
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.RessursListeNavnItem> items = new List<Models.RessursListeNavnItem>();

        //    if (soknNr == null) { soknNr = ""; }

        //    if (soknNr != null) { 
        //        items = await ressursRepository.GetSeremonisteder(logonInfo, soknNr, typeRom, false, sermStedGuid);
        //    }

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task<ActionResult> getKrematorier([DataSourceRequest] DataSourceRequest request, string soknNr)
        //{
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.RessursListeNavnItem> items = new List<Models.RessursListeNavnItem>();

        //    items = await ressursRepository.GetKrematorier(logonInfo, soknNr);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task<ActionResult> getGravsteder([DataSourceRequest] DataSourceRequest request, string soknNr, string fellesraad)
        //{
        //    RessursRepository ressursRepository = new RessursRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    if (fellesraad != null)
        //    {
        //        logonInfo.AktivFellesraad = fellesraad;
        //    }

        //    List<Models.RessursListeNavnItem> items = new List<Models.RessursListeNavnItem>();

        //    items = await ressursRepository.GetGravplasser(logonInfo, soknNr);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

    }
}
