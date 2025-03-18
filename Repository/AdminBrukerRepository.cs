using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ical.Net.Serialization.DataTypes;

namespace Susteni.Repository
{
    public class AdminBrukerRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public AdminBrukerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Bruker

        //public async Task<List<Models.BrukerItem>> GetBrukerListe(SrcLogonInfo logonInfo, int resType, string filter)
        //{
        //    getKIPBrukerListeWSResponse resp = new getKIPBrukerListeWSResponse();
        //    resp = await KipWSClient.getKIPBrukerListeWSAsync(logonInfo, resType, filter);

        //    List<Models.BrukerItem> items = new List<Models.BrukerItem>();
        //    SrcBruker[] itemsWS;

        //    itemsWS = resp.Body.getKIPBrukerListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.BrukerItem item = new Models.BrukerItem();
        //        item.BrukerId = i.BrukerId;
        //        item.BrukerGuid = i.BrukerGuid;
        //        item.Etternavn = i.Etternavn;
        //        item.Fornavn = i.Fornavn;
        //        item.FulltNavn = i.Fornavn + " " + item.Etternavn;
        //        item.nBrukerGuid = i.nBrukerGuid;
        //        item.RessursGuid = i.RessursGuid;
        //        item.Aktiv = i.Aktiv;
        //        if (i.Aktiv == false)
        //        {
        //            item.FargeNavn = "lightgray";
        //            item.visId = 4;
        //        }
        //        else
        //        {
        //            item.FargeNavn = "black";
        //            item.visId = 3;
        //        }
        //        if (i.RessursGuid == "")
        //        {
        //            item.FargeNavn = "red";
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.BrukerItem>> GetBrukerFellesraadListe(SrcLogonInfo logonInfo, string brukerId)
        //{
        //    getKIPBrukerFellesraadListeWSResponse resp = new getKIPBrukerFellesraadListeWSResponse();
        //    resp = await KipWSClient.getKIPBrukerFellesraadListeWSAsync(logonInfo, brukerId);

        //    List<Models.BrukerItem> items = new List<Models.BrukerItem>();
        //    SrcBruker[] itemsWS;

        //    itemsWS = resp.Body.getKIPBrukerFellesraadListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.BrukerItem item = new Models.BrukerItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.FulltNavn = i.EierFellesraad;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.BrukerItem> GetBruker(SrcLogonInfo logonInfo, string BrukerGuid)
        //{
        //    getKIPBrukerWSResponse resp = new getKIPBrukerWSResponse();
        //    resp = await KipWSClient.getKIPBrukerWSAsync(logonInfo, BrukerGuid);

        //    Models.BrukerItem item = new Models.BrukerItem();
        //    SrcBruker i = resp.Body.getKIPBrukerWSResult;

        //    item.BrukerId = i.BrukerId;
        //    if (i.FraDato.Ticks > 0) { item.FraDato = i.FraDato; }
        //    if (i.TilDato.Ticks > 0) { item.TilDato = i.TilDato; }
        //    item.ModulMedarbeider = i.ModulMedarbeider;
        //    item.ModulKH = i.ModulKH;
        //    item.ModulByra = i.ModulByra;
        //    item.ModulGravplass = i.ModulGravplass;
        //    item.ModulEngrafo = i.ModulEngrafo;
        //    item.ModulOkonomi = i.ModulOkonomi;
        //    item.ModulGrunnregister = i.ModulGrunnregister;
        //    item.ModulStatistikk = i.ModulStatistikk;
        //    item.ModulKisteskanning = i.ModulKisteskanning;
        //    item.ModulKrematorium = i.ModulKrematorium;
        //    item.ModulkWeb = i.ModulkWeb;
        //    item.ModulAdmin = i.ModulAdmin;
        //    item.Fellesraad = i.Fellesraad;
        //    item.BrukerGuid = i.BrukerGuid;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.Etternavn = i.Etternavn;
        //    item.Fornavn = i.Fornavn;
        //    item.Kontakt_GUID = i.Kontakt_GUID;
        //    item.BestilingVarsler = i.BestilingVarsler;
        //    item.AutoUpdate = i.AutoUpdate;
        //    item.SuperBruker = i.SuperBruker;
        //    item.SoknId = i.SoknId;
        //    item.NhGtj = i.NhGtj;
        //    item.NhDåp = i.NhDåp;
        //    item.NhKon = i.NhKon;
        //    item.NhVie = i.NhVie;
        //    item.NhGrf = i.NhGrf;
        //    item.NhAkt = i.NhAkt;
        //    item.NhFri = i.NhFri;
        //    item.NhBes = i.NhBes;
        //    item.NhKal = i.NhKal;
        //    item.NhGGen = i.NhGGen;
        //    item.NhGGfd = i.NhGGfd;
        //    item.NhGStl = i.NhGStl;
        //    item.NhGOko = i.NhGOko;
        //    item.NhGma = i.NhGma;
        //    item.AktivFakturaNrSerie = i.AktivFakturaNrSerie;
        //    item.HarEpost = i.HarEpost;
        //    item.DomainUser = i.DomainUser;
        //    item.DomainPassword = i.DomainPassword;
        //    item.EWSKalender = i.EWSKalender;
        //    item.Alfa = i.Alfa;
        //    item.Beta = i.Beta;
        //    item.SkjulInfo = i.SkjulInfo;
        //    item.EWSepost = i.EWSepost;
        //    item.AutNiva = i.AutNiva;
        //    item.AktivFellesraad = i.AktivFellesraad;
        //    item.AktivKonfirmantKull = i.AktivKonfirmantKull;
        //    item.url = i.url;
        //    return item;

        //}

        //public async Task<SrcReturnValue> exeBrukerSlett(SrcLogonInfo logonInfo, string BrukerId, string RessursGuid)
        //{
        //    exeKIPBrukerSlettWSResponse resp = new exeKIPBrukerSlettWSResponse();
        //    resp = await KipWSClient.exeKIPBrukerSlettWSAsync(logonInfo, BrukerId, RessursGuid);
        //    SrcReturnValue retur = new SrcReturnValue();

        //    retur = resp.Body.exeKIPBrukerSlettWSResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> exeBrukerFjern(SrcLogonInfo logonInfo, string BrukerId, string fellesraad)
        //{
        //    exeKIPFjernBrukerWSResponse resp = new exeKIPFjernBrukerWSResponse();
        //    resp = await KipWSClient.exeKIPFjernBrukerWSAsync(logonInfo, BrukerId, fellesraad);
        //    SrcReturnValue retur = new SrcReturnValue();

        //    retur = resp.Body.exeKIPFjernBrukerWSResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> SetBruker(SrcLogonInfo logonInfo, Models.BrukerItem item)
        //{
        //    SrcBruker items = new SrcBruker();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    #region Data
        //    items.BrukerId = item.BrukerId;
        //    if (item.FraDato != null) { items.FraDato = (DateTime)item.FraDato; }
        //    if (item.TilDato != null) { items.TilDato = (DateTime)item.TilDato; }
        //    items.ModulMedarbeider = item.ModulMedarbeider;
        //    items.ModulKH = item.ModulKH;
        //    items.ModulByra = item.ModulByra;
        //    items.ModulGravplass = item.ModulGravplass;
        //    items.ModulEngrafo = item.ModulEngrafo;
        //    items.ModulOkonomi = item.ModulOkonomi;
        //    items.ModulGrunnregister = item.ModulGrunnregister;
        //    items.ModulStatistikk = item.ModulStatistikk;
        //    items.ModulKisteskanning = item.ModulKisteskanning;
        //    items.ModulKrematorium = item.ModulKrematorium;
        //    items.ModulkWeb = item.ModulkWeb;
        //    items.ModulAdmin = item.ModulAdmin;
        //    items.Fellesraad = item.Fellesraad;
        //    items.BrukerGuid = item.BrukerGuid;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.Etternavn = item.Etternavn;
        //    items.Fornavn = item.Fornavn;
        //    items.Kontakt_GUID = item.Kontakt_GUID;
        //    items.BestilingVarsler = item.BestilingVarsler;
        //    items.AutoUpdate = item.AutoUpdate;
        //    items.SuperBruker = item.SuperBruker;
        //    items.SoknId = item.SoknId;
        //    items.NhGtj = item.NhGtj;
        //    items.NhDåp = item.NhDåp;
        //    items.NhKon = item.NhKon;
        //    items.NhVie = item.NhVie;
        //    items.NhGrf = item.NhGrf;
        //    items.NhAkt = item.NhAkt;
        //    items.NhFri = item.NhFri;
        //    items.NhBes = item.NhBes;
        //    items.NhKal = item.NhKal;
        //    items.NhGGen = item.NhGGen;
        //    items.NhGGfd = item.NhGGfd;
        //    items.NhGStl = item.NhGStl;
        //    items.NhGOko = item.NhGOko;
        //    items.NhGma = item.NhGma;
        //    items.AktivFakturaNrSerie = item.AktivFakturaNrSerie;
        //    items.HarEpost = item.HarEpost;
        //    items.DomainUser = item.DomainUser;
        //    items.DomainPassword = item.DomainPassword;
        //    items.EWSKalender = item.EWSKalender;
        //    items.Alfa = item.Alfa;
        //    items.Beta = item.Beta;
        //    items.SkjulInfo = item.SkjulInfo;
        //    items.EWSepost = item.EWSepost;
        //    items.AutNiva = item.AutNiva;
        //    items.AktivFellesraad = item.AktivFellesraad;
        //    items.AktivKonfirmantKull = item.AktivKonfirmantKull;
        //    #endregion

        //    setKIPBrukerWSResponse resp = new setKIPBrukerWSResponse();
        //    resp = await KipWSClient.setKIPBrukerWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPBrukerWSResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> SetProfilBruker(SrcLogonInfo logonInfo, Models.BrukerItem item)
        //{
        //    SrcBruker items = new SrcBruker();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    #region Data
        //    items.BrukerGuid = item.BrukerGuid;
        //    items.Etternavn = item.Etternavn;
        //    items.Fornavn = item.Fornavn;
        //    items.NhGtj = item.NhGtj;
        //    items.NhDåp = item.NhDåp;
        //    items.NhKon = item.NhKon;
        //    items.NhVie = item.NhVie;
        //    items.NhGrf = item.NhGrf;
        //    items.NhAkt = item.NhAkt;
        //    items.NhFri = item.NhFri;
        //    items.NhBes = item.NhBes;
        //    items.NhKal = item.NhKal;
        //    items.NhGGen = item.NhGGen;
        //    items.NhGGfd = item.NhGGfd;
        //    items.NhGStl = item.NhGStl;
        //    items.NhGOko = item.NhGOko;
        //    items.NhGma = item.NhGma;
        //    #endregion

        //    setKIPProfilBrukerWSResponse resp = new setKIPProfilBrukerWSResponse();
        //    resp = await KipWSClient.setKIPProfilBrukerWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPProfilBrukerWSResult;

        //    return retur;

        //}


        //public async Task<SrcReturnValue> OpprettBruker(SrcLogonInfo logonInfo, Models.BrukerItem item)
        //{
        //    SrcBruker items = new SrcBruker();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    #region Data
        //    items.BrukerId = item.BrukerId;
        //    items.Passord = item.Passord;
        //    items.ModulMedarbeider = item.ModulMedarbeider;
        //    items.ModulKH = item.ModulKH;
        //    items.ModulByra = item.ModulByra;
        //    items.ModulGravplass = item.ModulGravplass;
        //    items.ModulEngrafo = item.ModulEngrafo;
        //    items.ModulOkonomi = item.ModulOkonomi;
        //    items.ModulGrunnregister = item.ModulGrunnregister;
        //    items.ModulStatistikk = item.ModulStatistikk;
        //    items.ModulKisteskanning = item.ModulKisteskanning;
        //    items.ModulkWeb = item.ModulkWeb;
        //    items.ModulAdmin = item.ModulAdmin;
        //    items.Fellesraad = item.Fellesraad;
        //    items.BrukerGuid = item.BrukerGuid;
        //    items.Etternavn = item.Etternavn;
        //    items.Fornavn = item.Fornavn;
        //    items.Kontakt_GUID = item.Kontakt_GUID;
        //    items.BestilingVarsler = item.BestilingVarsler;
        //    items.AutoUpdate = item.AutoUpdate;
        //    items.SuperBruker = item.SuperBruker;
        //    items.SoknId = item.SoknId;
        //    items.NhGtj = item.NhGtj;
        //    items.NhDåp = item.NhDåp;
        //    items.NhKon = item.NhKon;
        //    items.NhVie = item.NhVie;
        //    items.NhGrf = item.NhGrf;
        //    items.NhAkt = item.NhAkt;
        //    items.NhFri = item.NhFri;
        //    items.NhBes = item.NhBes;
        //    items.NhKal = item.NhKal;
        //    items.NhGGen = item.NhGGen;
        //    items.NhGGfd = item.NhGGfd;
        //    items.NhGStl = item.NhGStl;
        //    items.NhGOko = item.NhGOko;
        //    items.NhGma = item.NhGma;
        //    items.AktivFakturaNrSerie = item.AktivFakturaNrSerie;
        //    items.HarEpost = item.HarEpost;
        //    items.DomainUser = item.DomainUser;
        //    items.DomainPassword = item.DomainPassword;
        //    items.EWSKalender = item.EWSKalender;
        //    items.Alfa = item.Alfa;
        //    items.Beta = item.Beta;
        //    items.SkjulInfo = item.SkjulInfo;
        //    items.EWSepost = item.EWSepost;
        //    items.AutNiva = item.AutNiva;
        //    items.AktivFellesraad = item.AktivFellesraad;
        //    items.AktivKonfirmantKull = item.AktivKonfirmantKull;
        //    #endregion

        //    exeKIPCreateUserResponse resp = new exeKIPCreateUserResponse();
        //    resp = await KipWSClient.exeKIPCreateUserAsync(logonInfo, items);
        //    retur = resp.Body.exeKIPCreateUserResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> OpprettBrukereFellesraad(SrcLogonInfo logonInfo, string fellesraad, string brukerGuidListe)
        //{
        //    SrcBruker items = new SrcBruker();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    setKIPBrukereFellesraadWSResponse resp = new setKIPBrukereFellesraadWSResponse();
        //    resp = await KipWSClient.setKIPBrukereFellesraadWSAsync(logonInfo, brukerGuidListe, fellesraad);
        //    retur = resp.Body.setKIPBrukereFellesraadWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> OpprettBrukerFellesraad(SrcLogonInfo logonInfo, string fellesraad, string brukerId)
        //{
        //    SrcBruker items = new SrcBruker();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    items.BrukerId = brukerId;
        //    items.Fellesraad = fellesraad;

        //    setKIPBrukerFellesraadWSResponse resp = new setKIPBrukerFellesraadWSResponse();
        //    resp = await KipWSClient.setKIPBrukerFellesraadWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPBrukerFellesraadWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> ByttPassord(SrcLogonInfo LogonInfo, Models.BrukerItem item)
        //{
        //    SrcBruker items = new SrcBruker();
        //    items.BrukerId = item.BrukerId;
        //    items.Passord = item.Passord;
        //    SrcReturnValue retur = new();

        //    exeKIPChangePasswordResponse resp = new();

        //    resp = await KipWSClient.exeKIPChangePasswordAsync(LogonInfo, items);
        //    retur = resp.Body.exeKIPChangePasswordResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> SendNyttPassord(SrcLogonInfo LogonInfo, string ePostAdresse, string BrukerId, string Passord)
        //{
        //    exeKIPSendNyttPassordWSResponse item = new();
        //    SrcReturnValue retur = new();
        //    item = await KipWSClient.exeKIPSendNyttPassordWSAsync(LogonInfo, ePostAdresse, BrukerId, Passord);
        //    retur = item.Body.exeKIPSendNyttPassordWSResult;

        //    return retur;
        //}

        #endregion

        #region Tilganger

        //public async Task<List<Models.SoknRessursItem>> GetBrukerRolleSokn(SrcLogonInfo LogonInfo, string brukerId)
        //{
        //    getKIPBrukerTilgangSoknWSResponse resp = new getKIPBrukerTilgangSoknWSResponse();
        //    resp = await KipWSClient.getKIPBrukerTilgangSoknWSAsync(LogonInfo, brukerId);

        //    List<Models.SoknRessursItem> items = new List<Models.SoknRessursItem>();
        //    SrcRessursSokn[] itemws = resp.Body.getKIPBrukerTilgangSoknWSResult;

        //    foreach (var i in itemws)
        //    {
        //        Models.SoknRessursItem item = new Models.SoknRessursItem();
        //        item.PROSTI_ID = i.ProstiId;
        //        item.SoknNavn = i.SoknNavn;
        //        item.SoknId = i.SoknId;
        //        item.ProstiNavn = i.ProstiNavn;
        //        item.SoknNr = i.SoknNr;
        //        item.Aktiv = i.Aktiv;
        //        items.Add(item);
        //    }
        //    return items;

        //}

        //public async Task<List<Models.SoknRessursItem>> GetBrukerSokn(SrcLogonInfo LogonInfo, string brukerId)
        //{
        //    getKIPBrukerSoknListeWSResponse resp = new getKIPBrukerSoknListeWSResponse();
        //    resp = await KipWSClient.getKIPBrukerSoknListeWSAsync(LogonInfo, brukerId);

        //    List<Models.SoknRessursItem> items = new List<Models.SoknRessursItem>();
        //    SrcRessursSokn[] itemws = resp.Body.getKIPBrukerSoknListeWSResult;

        //    foreach (var i in itemws)
        //    {
        //        Models.SoknRessursItem item = new Models.SoknRessursItem();
        //        item.PROSTI_ID = i.ProstiId;
        //        item.SoknNavn = i.SoknNavn;
        //        item.SoknId = i.SoknId;
        //        item.ProstiNavn = i.ProstiNavn;
        //        item.SoknNr = i.SoknNr;
        //        item.Aktiv = i.Aktiv;
        //        items.Add(item);
        //    }
        //    return items;

        //}

        //public async Task<List<Models.BrukerRolleItem>> GetBrukerRolleListe(SrcLogonInfo logonInfo, string brukerId, string soknId)
        //{
        //    getKIPBrukerRolleListeWSResponse resp = new getKIPBrukerRolleListeWSResponse();
        //    resp = await KipWSClient.getKIPBrukerRolleListeWSAsync(logonInfo, brukerId, soknId);

        //    List<Models.BrukerRolleItem> items = new List<Models.BrukerRolleItem>();
        //    SrcBrukerRolle[] itemsWS;
        //    itemsWS = resp.Body.getKIPBrukerRolleListeWSResult;


        //    foreach (var i in itemsWS)
        //    {
        //        Models.BrukerRolleItem item = new Models.BrukerRolleItem();
        //        item.RolleGuid = i.RolleGuid;
        //        item.Navn = i.Navn;
        //        item.SoknId = i.SoknId;
        //        item.BrukerId = i.BrukerId;
        //        item.RolleNavn = i.RolleNavn;
        //        item.RolleType = i.RolleType;
        //        switch ( i.RolleType)
        //        {
        //            case 0:                        
        //                if (Startup.StandardSprak == "de-DE")
        //                {
        //                    item.RolleTypeNavn = "KIP-Gemeinde";
        //                }
        //                else
        //                {
        //                    item.RolleTypeNavn = "Gravlund/Kardinal";
        //                }
        //                break;

        //            case 1:
        //                item.RolleTypeNavn = "kWeb";
        //                break;

        //            case 2:
        //                item.RolleTypeNavn = "Engrafo";
        //                break;
        //        }


        //        item.Aktiv = i.Aktiv;
        //        item.FraDato = i.FraDato;
        //        if (i.TilDato.Ticks > 0) { item.TilDato = i.TilDato; }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.BrukerRolleItem>> GetBrukerRolleTilgang(SrcLogonInfo logonInfo, string brukerId, string soknId)
        //{
        //    getKIPBrukerRolleTilgangWSResponse resp = new getKIPBrukerRolleTilgangWSResponse();
        //    resp = await KipWSClient.getKIPBrukerRolleTilgangWSAsync(logonInfo, brukerId, soknId);

        //    List<Models.BrukerRolleItem> items = new List<Models.BrukerRolleItem>();
        //    SrcBrukerRolle[] itemsWS;
        //    itemsWS = resp.Body.getKIPBrukerRolleTilgangWSResult;


        //    foreach (var i in itemsWS)
        //    {
        //        Models.BrukerRolleItem item = new Models.BrukerRolleItem();
        //        item.RolleGuid = i.RolleGuid;
        //        item.RolleNavn = i.RolleNavn;
        //        item.RolleType = i.RolleType;
        //        item.Aktiv = i.Aktiv;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<setKIPBrukerSoknWSResponse> setBrukerSokn(SrcLogonInfo LogonInfo, string ressursGuid, string soknId)
        //{
        //    return await KipWSClient.setKIPBrukerSoknWSAsync(LogonInfo, ressursGuid, soknId);
        //}

        //public async Task<setKIPBrukerRollerWSResponse> setBrukerRoller(SrcLogonInfo LogonInfo, string rollerGuid, string brukerId, string soknId)
        //{
        //    return await KipWSClient.setKIPBrukerRollerWSAsync(LogonInfo, brukerId, rollerGuid, soknId);
        //}

        //public async Task<Models.BrukerTilgangItem> GetBrukerTilgang(SrcLogonInfo logonInfo, string SoknNr, string BrukerId)
        //{
        //    getKIPBrukerTilgangWSResponse resp = new getKIPBrukerTilgangWSResponse();
        //    resp = await KipWSClient.getKIPBrukerTilgangWSAsync(logonInfo, BrukerId, SoknNr);

        //    Models.BrukerTilgangItem item = new Models.BrukerTilgangItem();
        //    SrcBrukerTilgang i = resp.Body.getKIPBrukerTilgangWSResult;


        //    item.Fellesraad = i.Fellesraad;
        //    item.SoknNr = i.SoknNr;
        //    item.BrukerId = i.BrukerId;
        //    item.SoknId = i.SoknId;
        //    item.ADM = i.ADM;
        //    item.AKTIVITETER_R = i.AKTIVITETER_R;
        //    item.AKTIVITETER_W = i.AKTIVITETER_W;
        //    item.ANSATTREG_R = i.ANSATTREG_R;
        //    item.ANSATTREG_W = i.ANSATTREG_W;
        //    item.BIBLIOTEK = i.BIBLIOTEK;
        //    item.DOED_R = i.DOED_R;
        //    item.DOED_W = i.DOED_W;
        //    item.DAAP_R = i.DAAP_R;
        //    item.DAAP_W = i.DAAP_W;
        //    item.GUDSTJENESTE_R = i.GUDSTJENESTE_R;
        //    item.GUDSTJENESTE_W = i.GUDSTJENESTE_W;
        //    item.INNUTMELDING_R = i.INNUTMELDING_R;
        //    item.INNUTMELDING_W = i.INNUTMELDING_W;
        //    item.KONFIRMASJON_R = i.KONFIRMASJON_R;
        //    item.KONFIRMASJON_W = i.KONFIRMASJON_W;
        //    item.ARKIV_DOK_R = i.ARKIV_DOK_R;
        //    item.ARKIV_DOK_W = i.ARKIV_DOK_W;
        //    item.ARKIV_SAK_R = i.ARKIV_SAK_R;
        //    item.ARKIV_SAK_W = i.ARKIV_SAK_W;
        //    item.ARKIV_MOTE_R = i.ARKIV_MOTE_R;
        //    item.ARKIV_MOTE_W = i.ARKIV_MOTE_W;
        //    item.TIDSPLAN_ROM_R = i.TIDSPLAN_ROM_R;
        //    item.TIDSPLAN_ROM_W = i.TIDSPLAN_ROM_W;
        //    item.TIDSPLAN_PERS_R = i.TIDSPLAN_PERS_R;
        //    item.TIDSPLAN_PERS_W = i.TIDSPLAN_PERS_W;
        //    item.TIDSPLAN_GUDSTJENESTE = i.TIDSPLAN_GUDSTJENESTE;
        //    item.VIELSE_R = i.VIELSE_R;
        //    item.VIELSE_W = i.VIELSE_W;
        //    item.FASTE_DATA_R = i.FASTE_DATA_R;
        //    item.FASTE_DATA_W = i.FASTE_DATA_W;
        //    item.AVHOLDT = i.AVHOLDT;
        //    item.MEDLEMSREG = i.MEDLEMSREG;
        //    item.TIDSPLAN_GUDSTJENESTE_W = i.TIDSPLAN_GUDSTJENESTE_W;
        //    item.STANDARD_KLIENT = i.STANDARD_KLIENT;
        //    item.FRIVILLIGREG_R = i.FRIVILLIGREG_R;
        //    item.FRIVILLIGREG_W = i.FRIVILLIGREG_W;
        //    item.SMS = i.SMS;
        //    item.Sentralbord = i.Sentralbord;
        //    item.RaadUtvalg = i.RaadUtvalg;
        //    item.GudstjenesteAdm = i.GudstjenesteAdm;
        //    item.Adresering = i.Adresering;
        //    item.Folkeregister = i.Folkeregister;
        //    item.Ressurs_GUID = i.Ressurs_GUID;
        //    item.DB_PASSORD = i.DB_PASSORD;
        //    item.DB_BRUKERNAVN = i.DB_BRUKERNAVN;
        //    item.ADRESSE_INFO = i.ADRESSE_INFO;
        //    item.SPRAAK = i.SPRAAK;
        //    item.PRESTEGJELD_ID = i.PRESTEGJELD_ID;
        //    item.KLIENT_NAVN = i.KLIENT_NAVN;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.Konfirmasjon_S = i.Konfirmasjon_S;
        //    item.Frivilligreg_S = i.Frivilligreg_S;
        //    item.Aktiviteter_U = i.Aktiviteter_U;
        //    item.Aktiviteter_A = i.Aktiviteter_A;
        //    item.BesokTj_L = i.BesokTj_L;
        //    item.BesokTj_S = i.BesokTj_S;
        //    item.BesokTj_U = i.BesokTj_U;
        //    item.Innutmelding_A = i.Innutmelding_A;
        //    item.Daap_A = i.Daap_A;
        //    item.Konfirmasjon_A = i.Konfirmasjon_A;
        //    item.GDPRansvarlig = i.GDPRansvarlig;
        //    item.Bank = i.Bank;
        //    item.BesokTjeneste = i.BesokTjeneste;
        //    item.Program_GUID = i.Program_GUID;
        //    item.BrukerTilgangGuid = i.BrukerTilgangGuid;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetBrukerTilgang(SrcLogonInfo logonInfo, Models.BrukerTilgangItem item)
        //{
        //    SrcBrukerTilgang items = new SrcBrukerTilgang();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Fellesraad = item.Fellesraad;
        //    items.SoknNr = item.SoknNr;
        //    items.BrukerId = item.BrukerId;
        //    items.SoknId = item.SoknId;
        //    items.ADM = item.ADM;
        //    items.AKTIVITETER_R = item.AKTIVITETER_R;
        //    items.AKTIVITETER_W = item.AKTIVITETER_W;
        //    items.ANSATTREG_R = item.ANSATTREG_R;
        //    items.ANSATTREG_W = item.ANSATTREG_W;
        //    items.BIBLIOTEK = item.BIBLIOTEK;
        //    items.DOED_R = item.DOED_R;
        //    items.DOED_W = item.DOED_W;
        //    items.DAAP_R = item.DAAP_R;
        //    items.DAAP_W = item.DAAP_W;
        //    items.GUDSTJENESTE_R = item.GUDSTJENESTE_R;
        //    items.GUDSTJENESTE_W = item.GUDSTJENESTE_W;
        //    items.INNUTMELDING_R = item.INNUTMELDING_R;
        //    items.INNUTMELDING_W = item.INNUTMELDING_W;
        //    items.KONFIRMASJON_R = item.KONFIRMASJON_R;
        //    items.KONFIRMASJON_W = item.KONFIRMASJON_W;
        //    items.ARKIV_DOK_R = item.ARKIV_DOK_R;
        //    items.ARKIV_DOK_W = item.ARKIV_DOK_W;
        //    items.ARKIV_SAK_R = item.ARKIV_SAK_R;
        //    items.ARKIV_SAK_W = item.ARKIV_SAK_W;
        //    items.ARKIV_MOTE_R = item.ARKIV_MOTE_R;
        //    items.ARKIV_MOTE_W = item.ARKIV_MOTE_W;
        //    items.TIDSPLAN_ROM_R = item.TIDSPLAN_ROM_R;
        //    items.TIDSPLAN_ROM_W = item.TIDSPLAN_ROM_W;
        //    items.TIDSPLAN_PERS_R = item.TIDSPLAN_PERS_R;
        //    items.TIDSPLAN_PERS_W = item.TIDSPLAN_PERS_W;
        //    items.TIDSPLAN_GUDSTJENESTE = item.TIDSPLAN_GUDSTJENESTE;
        //    items.VIELSE_R = item.VIELSE_R;
        //    items.VIELSE_W = item.VIELSE_W;
        //    items.FASTE_DATA_R = item.FASTE_DATA_R;
        //    items.FASTE_DATA_W = item.FASTE_DATA_W;
        //    items.AVHOLDT = item.AVHOLDT;
        //    items.MEDLEMSREG = item.MEDLEMSREG;
        //    items.TIDSPLAN_GUDSTJENESTE_W = item.TIDSPLAN_GUDSTJENESTE_W;
        //    items.STANDARD_KLIENT = item.STANDARD_KLIENT;
        //    items.FRIVILLIGREG_R = item.FRIVILLIGREG_R;
        //    items.FRIVILLIGREG_W = item.FRIVILLIGREG_W;
        //    items.SMS = item.SMS;
        //    items.Sentralbord = item.Sentralbord;
        //    items.RaadUtvalg = item.RaadUtvalg;
        //    items.GudstjenesteAdm = item.GudstjenesteAdm;
        //    items.Adresering = item.Adresering;
        //    items.Folkeregister = item.Folkeregister;
        //    items.Ressurs_GUID = item.Ressurs_GUID;
        //    items.DB_PASSORD = item.DB_PASSORD;
        //    items.DB_BRUKERNAVN = item.DB_BRUKERNAVN;
        //    items.ADRESSE_INFO = item.ADRESSE_INFO;
        //    items.SPRAAK = item.SPRAAK;
        //    items.PRESTEGJELD_ID = item.PRESTEGJELD_ID;
        //    items.KLIENT_NAVN = item.KLIENT_NAVN;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.Konfirmasjon_S = item.Konfirmasjon_S;
        //    items.Frivilligreg_S = item.Frivilligreg_S;
        //    items.Aktiviteter_U = item.Aktiviteter_U;
        //    items.Aktiviteter_A = item.Aktiviteter_A;
        //    items.BesokTj_L = item.BesokTj_L;
        //    items.BesokTj_S = item.BesokTj_S;
        //    items.BesokTj_U = item.BesokTj_U;
        //    items.Innutmelding_A = item.Innutmelding_A;
        //    items.Daap_A = item.Daap_A;
        //    items.Konfirmasjon_A = item.Konfirmasjon_A;
        //    items.GDPRansvarlig = item.GDPRansvarlig;
        //    items.Bank = item.Bank;
        //    items.BesokTjeneste = item.BesokTjeneste;
        //    items.Program_GUID = item.Program_GUID;
        //    items.BrukerTilgangGuid = item.BrukerTilgangGuid;

        //    setKIPBrukerTilgangWSResponse resp = new setKIPBrukerTilgangWSResponse();
        //    resp = await KipWSClient.setKIPBrukerTilgangWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPBrukerTilgangWSResult;

        //    return retur;

        //}

        #endregion

        #region Kalender tilganger

        //public async Task<List<Models.KalenderTilgangTypeItem>> GetKalenderTilgangTypeListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPKalenderTilgangTypeListeWSResponse resp = new getKIPKalenderTilgangTypeListeWSResponse();
        //    resp = await KipWSClient.getKIPKalenderTilgangTypeListeWSAsync(logonInfo);

        //    List<Models.KalenderTilgangTypeItem> items = new List<Models.KalenderTilgangTypeItem>();
        //    SrcKalenderTilgangType[] itemsWS;

        //    itemsWS = resp.Body.getKIPKalenderTilgangTypeListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KalenderTilgangTypeItem item = new Models.KalenderTilgangTypeItem();
        //        item.Tilgang = i.Tilgang;
        //        item.Navn = i.Navn;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<exeKIPKalenderTilgangskontrollWSResponse> SetKalenderTilgangKontroll(SrcLogonInfo logonInfo, bool lukket)
        //{
        //    return await KipWSClient.exeKIPKalenderTilgangskontrollWSAsync(logonInfo, lukket);
        //}

        //public async Task<exeKIPGiKalenderTilgangWSResponse> SetKalenderTilgang(SrcLogonInfo logonInfo, string ressursGUID, int Tilgang)
        //{
        //    return await KipWSClient.exeKIPGiKalenderTilgangWSAsync(logonInfo, ressursGUID, Tilgang );
        //}

        //public async Task<exeKIPUpdateKalenderTilgangWSResponse> UpdateKalenderTilgang(SrcLogonInfo logonInfo, string ressursGUID, int Tilgang)
        //{
        //    return await KipWSClient.exeKIPUpdateKalenderTilgangWSAsync(logonInfo, ressursGUID, Tilgang);
        //}

        //public async Task<exeKIPFjernKalenderTilgangWSResponse> FjernKalenderTilgang(SrcLogonInfo logonInfo, string ressursGUID)
        //{
        //    return await KipWSClient.exeKIPFjernKalenderTilgangWSAsync(logonInfo, ressursGUID);
        //}

        //public async Task<List<Models.KalenderTilgangerItem>> GetKalenderTilgangerListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPKalenderTilgangerListeWSResponse resp = new getKIPKalenderTilgangerListeWSResponse();
        //    resp = await KipWSClient.getKIPKalenderTilgangerListeWSAsync(logonInfo);

        //    List<Models.KalenderTilgangerItem> items = new List<Models.KalenderTilgangerItem>();
        //    SrcKalenderTilganger[] itemsWS;

        //    itemsWS = resp.Body.getKIPKalenderTilgangerListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KalenderTilgangerItem item = new Models.KalenderTilgangerItem();
        //        item.RessursGuid = i.RessursGuid;
        //        item.Navn = i.Navn;
        //        item.Tilgang = i.Tilgang;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        #endregion


        #region KipCode

        //public async Task<setLisensKipResponse> SetLisensKipCode(SrcLogonInfo LogonInfo, string BrukerGuid, string BrukerId, string Identifikator)
        //{
        //    return await KipWSLicens.setLisensKipAsync(BrukerGuid, BrukerId, "Notification", Identifikator, "Epost","","",DateTime.Today,DateTime.Today.AddYears(20),"333301");
        //}

        #endregion
    }
}
