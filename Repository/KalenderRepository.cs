using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Susteni.Models;

namespace Susteni.Repository
{
    public class KalenderRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public KalenderRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //#region    Henter liste over alle avtalene

        //public async Task<List<Models.KalenderAvtalerItem>> GetKalenderAvtalerListe(SrcLogonInfo LogonInfo, string filter, string sortering)
        //{

        //    kip.kirkedata.webservices.getKIPKalenderAvtalerWSResponse resp = new kip.kirkedata.webservices.getKIPKalenderAvtalerWSResponse();
        //    resp = await KipWSClient.getKIPKalenderAvtalerWSAsync(LogonInfo, "", filter, sortering);

        //    SrcKalenderAvtaler[] itemWS;
        //    List<Models.KalenderAvtalerItem> items = new List<Models.KalenderAvtalerItem>();
        //    itemWS = resp.Body.getKIPKalenderAvtalerWSResult;

        //    foreach (var i in itemWS)
        //    {
        //        Models.KalenderAvtalerItem item = new Models.KalenderAvtalerItem();
        //        List<KalenderEtikettItem> itemEL = new();

        //        item.KalenderTiderGuid = i.KalenderTiderGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.Etiketter = i.Etikett;
        //        item.Lokasjon = i.Lokasjon;
        //        item.Plassering = i.Plassering;
        //        if (i.StatusId == 0 && (i.Modul == 40 || i.Modul == 0))
        //        {
        //            item.Emne = "Planlagt: " + i.Emne;
        //        }
        //        else
        //        {
        //            item.Emne = i.Emne;
        //        }
        //        item.Tekst = i.Tekst;
        //        item.Info = i.Info;
        //        item.Prioritet = i.Prioritet;
        //        item.Privat = i.Privat;
        //        item.Access = i.Access;
        //        if (i.Modul > 0) { item.Access = false; }
        //        item.Byraa = i.Byraa;
        //        item.Modul = i.Modul;
        //        item.EierGuid = i.EierGuid;
        //        item.UnngåHelligdag = i.UnngåHelligdag;
        //        item.Invitasjon = i.Invitasjon;
        //        item.Varsling = i.Varsling;
        //        item.RessursTekst = i.RessursTekst;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.SynkExchange = i.SynkExchange;
        //        item.SyncExchange = i.SyncExchange;
        //        item.PubliserWeb = i.PubliserWeb;
        //        item.Varmestyring = i.Varmestyring;
        //        item.StatusId = i.StatusId;
        //        item.SynkAv = i.SynkAv;
        //        item.IsCancelled = i.IsCancelled;
        //        item.Laast = i.Laast;
        //        item.KollisjonSjekk = i.KollisjonSjekk;
        //        item.StartDato = i.StartDato;
        //        item.StartTid = i.StartTid;
        //        item.SluttDato = i.SluttDato;
        //        item.SluttTid = i.SluttTid;
        //        item.PaaMin = i.PaaMin;
        //        item.PaaMinTid = i.PaaMinTid;
        //        item.Monster = i.Monster;
        //        item.Dager = i.Dager;
        //        item.DagInt = i.DagInt;
        //        item.UkeInt = i.UkeInt;
        //        item.UkeMan = i.UkeMan;
        //        item.UkeTir = i.UkeTir;
        //        item.UkeOns = i.UkeOns;
        //        item.UkeTor = i.UkeTor;
        //        item.UkeFre = i.UkeFre;
        //        item.UkeLor = i.UkeLor;
        //        item.UkeSon = i.UkeSon;
        //        item.MonsterStartDato = i.MonsterStartDato;
        //        item.MonsterStopDato = i.MonsterStopDato;
        //        item.UtenStopp = i.UtenStopp;
        //        item.AnsvarligRessursGuid = i.AnsvarligRessursGuid;
        //        item.KalenderTiderEier = i.KalenderTiderEier;
        //        item.IgnorerHelligdager = i.IgnorerHelligdager;
        //        item.AntallRepiteringer = i.AntallRepiteringer;
        //        item.MndPattern = i.MndPattern;
        //        item.MndDato = i.MndDato;
        //        item.MndDatoIntervall = i.MndDatoIntervall;
        //        item.MndUke = i.MndUke;
        //        item.MndDag = i.MndDag;
        //        item.MndDagIntervall = i.MndDagIntervall;
        //        item.AarInt = i.AarInt;
        //        item.AarDag = i.AarDag;
        //        item.AarMnd = i.AarMnd;
        //        item.PreTid = i.PreTid;
        //        item.PostTid = i.PostTid;
        //        item.StartTidspunkt = i.StartTidspunkt;
        //        item.SluttTidspunkt = i.SluttTidspunkt;
        //        item.RessursGuidTekst = i.RessursGuidTekst;
        //        item.RessursIdTekst = i.RessursIdTekst;
        //        item.KalenderUnntak = i.KalenderUnntak;
        //        item.Tilgang = i.Tilgang;

        //        if (i.AntallRepiteringer > 0)
        //        {
        //            item.SluttType = "1";
        //        }
        //        else if (i.MonsterStopDato.Ticks > 0)
        //        {
        //            item.SluttType = "2";
        //        }
        //        else
        //        {
        //            item.SluttType = "0";
        //        }

        //        if (i.EtikettListe != null)
        //        {
        //            foreach (var j in i.EtikettListe)
        //            {
        //                Models.KalenderEtikettItem itemE = new();
        //                itemE.base64string = j.base64string;
        //                itemEL.Add(itemE);
        //            }

        //        }

        //        item.Etikettliste = itemEL;

        //        items.Add(item);
        //    }

        //   return items;
        //}


        //public async Task<List<Models.KalenderAvtalerItem>> GetKalenderTekstAvtalerListe(SrcLogonInfo LogonInfo, string filter, string sortering)
        //{

        //    getKIPKalenderAvtalerListeWSResponse resp = new getKIPKalenderAvtalerListeWSResponse();
        //    resp = await KipWSClient.getKIPKalenderAvtalerListeWSAsync(LogonInfo, filter, sortering);

        //    SrcKalenderAvtaler[] itemWS;
        //    List<Models.KalenderAvtalerItem> items = new List<Models.KalenderAvtalerItem>();
        //    itemWS = resp.Body.getKIPKalenderAvtalerListeWSResult;

        //    foreach (var i in itemWS)
        //    {
        //        Models.KalenderAvtalerItem item = new Models.KalenderAvtalerItem();

        //        item.KalenderTiderGuid = i.KalenderTiderGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.Emne = i.Emne;
        //        item.Lokasjon = i.Lokasjon;
        //        item.Plassering = i.Plassering;
        //        item.Tekst = i.Tekst;
        //        item.Info = i.Info;
        //        item.Prioritet = i.Prioritet;
        //        item.Privat = i.Privat;
        //        item.Access = i.Access;
        //        item.Byraa = i.Byraa;
        //        item.Modul = i.Modul;
        //        item.EierGuid = i.EierGuid;
        //        item.UnngåHelligdag = i.UnngåHelligdag;
        //        item.Invitasjon = i.Invitasjon;
        //        item.Varsling = i.Varsling;
        //        item.RessursTekst = i.RessursTekst;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.SynkExchange = i.SynkExchange;
        //        item.SyncExchange = i.SyncExchange;
        //        item.PubliserWeb = i.PubliserWeb;
        //        item.Varmestyring = i.Varmestyring;
        //        item.StatusId = i.StatusId;
        //        item.SynkAv = i.SynkAv;
        //        item.IsCancelled = i.IsCancelled;
        //        item.Laast = i.Laast;
        //        item.KollisjonSjekk = i.KollisjonSjekk;
        //        item.StartDato = i.StartDato;
        //        item.StartTid = i.StartTid;
        //        item.SluttDato = i.SluttDato;
        //        item.SluttTid = i.SluttTid;
        //        item.AnsvarligRessursGuid = i.AnsvarligRessursGuid;
        //        item.KalenderTiderEier = i.KalenderTiderEier;
        //        item.IgnorerHelligdager = i.IgnorerHelligdager;
        //        item.AntallRepiteringer = i.AntallRepiteringer;
        //        item.PreTid = i.PreTid;
        //        item.PostTid = i.PostTid;
        //        item.StartTidspunkt = i.StartTidspunkt;
        //        item.SluttTidspunkt = i.SluttTidspunkt;
        //        item.RessursGuidTekst = i.RessursGuidTekst;
        //        item.RessursIdTekst = i.RessursIdTekst;
        //        item.KalenderUnntak = i.KalenderUnntak;
        //        item.Tilgang = i.Tilgang;

        //        if (i.AntallRepiteringer > 0)
        //        {
        //            item.SluttType = "1";
        //        }
        //        else if (i.MonsterStopDato.Ticks > 0)
        //        {
        //            item.SluttType = "2";
        //        }
        //        else
        //        {
        //            item.SluttType = "0";
        //        }

        //        items.Add(item);
        //    }
        //    return items;

        //}

        //public async Task<Models.KalenderAvtalerItem> GetKalenderAvtale(SrcLogonInfo LogonInfo, string kalenderGuid)
        //{

        //    getKIPKalenderAvtaleWSResponse resp = new getKIPKalenderAvtaleWSResponse();
        //    resp = await KipWSClient.getKIPKalenderAvtaleWSAsync(LogonInfo, kalenderGuid);

        //    Models.KalenderAvtalerItem item = new Models.KalenderAvtalerItem();
        //    SrcKalenderAvtaler i = resp.Body.getKIPKalenderAvtaleWSResult;

        //    item.KalenderTiderGuid = i.KalenderTiderGuid;
        //    item.Fellesraad = i.Fellesraad;
        //    item.KalenderGuid = i.KalenderGuid;
        //    item.Emne = i.Emne;
        //    item.Lokasjon = i.Lokasjon;
        //    item.Plassering = i.Plassering;
        //    item.StedRessursGuid = i.StedRessursGuid;
        //    item.Tekst = i.Tekst;
        //    item.Info = i.Info;
        //    item.Prioritet = i.Prioritet;
        //    item.Privat = i.Privat;
        //    item.Byraa = i.Byraa;
        //    item.Modul = i.Modul;
        //    item.EierGuid = i.EierGuid;
        //    item.UnngåHelligdag = i.UnngåHelligdag;
        //    item.Invitasjon = i.Invitasjon;
        //    item.Varsling = i.Varsling;
        //    item.RessursTekst = i.RessursTekst;
        //    item.KontaktGuid = i.KontaktGuid;
        //    item.SynkExchange = i.SynkExchange;
        //    item.SyncExchange = i.SyncExchange;
        //    item.PubliserWeb = i.PubliserWeb;
        //    item.Varmestyring = i.Varmestyring;
        //    item.StatusId = i.StatusId;
        //    item.SynkAv = i.SynkAv;
        //    item.IsCancelled = i.IsCancelled;
        //    item.Laast = i.Laast;
        //    item.KollisjonSjekk = i.KollisjonSjekk;
        //    item.StartDato = i.StartDato;
        //    item.StartTid = i.StartTid;
        //    item.SluttDato = i.SluttDato;
        //    item.SluttTid = i.SluttTid;
        //    item.PaaMin = i.PaaMin;
        //    item.PaaMinTid = i.PaaMinTid;
        //    item.Monster = i.Monster;
        //    item.Dager = i.Dager;
        //    item.DagInt = i.DagInt;
        //    item.UkeInt = i.UkeInt;
        //    item.UkeMan = i.UkeMan;
        //    item.UkeTir = i.UkeTir;
        //    item.UkeOns = i.UkeOns;
        //    item.UkeTor = i.UkeTor;
        //    item.UkeFre = i.UkeFre;
        //    item.UkeLor = i.UkeLor;
        //    item.UkeSon = i.UkeSon;
        //    item.MonsterStartDato = i.MonsterStartDato;
        //    item.MonsterStopDato = i.MonsterStopDato;
        //    item.UtenStopp = i.UtenStopp;
        //    item.AnsvarligRessursGuid = i.AnsvarligRessursGuid;
        //    item.KalenderTiderEier = i.KalenderTiderEier;
        //    item.IgnorerHelligdager = i.IgnorerHelligdager;
        //    item.AntallRepiteringer = i.AntallRepiteringer;
        //    item.MndPattern = i.MndPattern;
        //    item.MndDato = i.MndDato;
        //    item.MndDatoIntervall = i.MndDatoIntervall;
        //    item.MndUke = i.MndUke;
        //    item.MndDag = i.MndDag;
        //    item.MndDagIntervall = i.MndDagIntervall;
        //    item.AarInt = i.AarInt;
        //    item.AarDag = i.AarDag;
        //    item.AarMnd = i.AarMnd;
        //    item.PreTid = i.PreTid;
        //    item.PostTid = i.PostTid;
        //    item.StartTidspunkt = i.StartTidspunkt;
        //    item.SluttTidspunkt = i.SluttTidspunkt;
        //    item.RessursGuidTekst = i.RessursGuidTekst;
        //    item.RessursIdTekst = i.RessursIdTekst;
        //    item.KalenderUnntak = i.KalenderUnntak;
        //    item.Etiketter = i.Etiketter;
        //    if (item.Etiketter.IndexOf(";") == -1)
        //    {
        //        item.Etiketter = item.Etiketter.Replace("'", "");
        //    }
        //    item.LeierKontaktGuid = i.LeierKontaktGuid;

        //    if (i.AntallRepiteringer > 0)
        //    {
        //        item.SluttType = "1";
        //    }
        //    else if (i.MonsterStopDato.Ticks > 0)
        //    {
        //        item.SluttType = "2";
        //    }
        //    else
        //    {
        //        item.SluttType = "0";
        //    }

        //    if (i.LeierKontaktGuid != null)
        //    {
        //        getKIPKontaktWSResponse respK = new getKIPKontaktWSResponse();
        //        respK = await KipWSClient.getKIPKontaktWSAsync(LogonInfo, i.LeierKontaktGuid);

        //        SrcKontakt iK = respK.Body.getKIPKontaktWSResult;

        //        item.Fornavn = iK.Fornavn;
        //        item.Mellomnavn = iK.Mellomnavn;
        //        item.Etternavn = iK.Etternavn;
        //        item.Adresse = iK.Adresse;
        //        item.PostNr = iK.PostNr;
        //        item.Sted = iK.Sted;
        //    }

        //    return item;

        //}

        //private List<Models.KalenderAvtalerItem> FromWsToKalenderAvtalerItem(kip.kirkedata.webservices.SrcKalenderAvtaler[] itemws)
        //{
        //    List<Models.KalenderAvtalerItem> items = new List<Models.KalenderAvtalerItem>();
        //    foreach (var i in itemws)
        //    {
        //        Models.KalenderAvtalerItem item = new Models.KalenderAvtalerItem();
        //        List<KalenderEtikettItem> itemEL = new();

        //        item.KalenderTiderGuid = i.KalenderTiderGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.Etiketter = i.Etikett;
        //        item.Lokasjon = i.Lokasjon;
        //        item.Plassering = i.Plassering;
        //        if (i.StatusId == 0 && (i.Modul== 40 || i.Modul == 0))
        //        {
        //            item.Emne = "Planlagt: " + i.Emne;
        //        }
        //        else
        //        {
        //            item.Emne = i.Emne;
        //        }
        //        item.Tekst = i.Tekst;
        //        item.Info = i.Info;
        //        item.Prioritet = i.Prioritet;
        //        item.Privat = i.Privat;
        //        item.Access = i.Access;
        //        if (i.Modul > 0) { item.Access = false; }
        //        item.Byraa = i.Byraa;
        //        item.Modul = i.Modul;
        //        item.EierGuid = i.EierGuid;
        //        item.UnngåHelligdag = i.UnngåHelligdag;
        //        item.Invitasjon = i.Invitasjon;
        //        item.Varsling = i.Varsling;
        //        item.RessursTekst = i.RessursTekst;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.SynkExchange = i.SynkExchange;
        //        item.SyncExchange = i.SyncExchange;
        //        item.PubliserWeb = i.PubliserWeb;
        //        item.Varmestyring = i.Varmestyring;
        //        item.StatusId = i.StatusId;
        //        item.SynkAv = i.SynkAv;
        //        item.IsCancelled = i.IsCancelled;
        //        item.Laast = i.Laast;
        //        item.KollisjonSjekk = i.KollisjonSjekk;
        //        item.StartDato = i.StartDato;
        //        item.StartTid = i.StartTid;
        //        item.SluttDato = i.SluttDato;
        //        item.SluttTid = i.SluttTid;
        //        item.PaaMin = i.PaaMin;
        //        item.PaaMinTid = i.PaaMinTid;
        //        item.Monster = i.Monster;
        //        item.Dager = i.Dager;
        //        item.DagInt = i.DagInt;
        //        item.UkeInt = i.UkeInt;
        //        item.UkeMan = i.UkeMan;
        //        item.UkeTir = i.UkeTir;
        //        item.UkeOns = i.UkeOns;
        //        item.UkeTor = i.UkeTor;
        //        item.UkeFre = i.UkeFre;
        //        item.UkeLor = i.UkeLor;
        //        item.UkeSon = i.UkeSon;
        //        item.MonsterStartDato = i.MonsterStartDato;
        //        item.MonsterStopDato = i.MonsterStopDato;
        //        item.UtenStopp = i.UtenStopp;
        //        item.AnsvarligRessursGuid = i.AnsvarligRessursGuid;
        //        item.KalenderTiderEier = i.KalenderTiderEier;
        //        item.IgnorerHelligdager = i.IgnorerHelligdager;
        //        item.AntallRepiteringer = i.AntallRepiteringer;
        //        item.MndPattern = i.MndPattern;
        //        item.MndDato = i.MndDato;
        //        item.MndDatoIntervall = i.MndDatoIntervall;
        //        item.MndUke = i.MndUke;
        //        item.MndDag = i.MndDag;
        //        item.MndDagIntervall = i.MndDagIntervall;
        //        item.AarInt = i.AarInt;
        //        item.AarDag = i.AarDag;
        //        item.AarMnd = i.AarMnd;
        //        item.PreTid = i.PreTid;
        //        item.PostTid = i.PostTid;
        //        item.StartTidspunkt = i.StartTidspunkt;
        //        item.SluttTidspunkt = i.SluttTidspunkt;
        //        item.RessursGuidTekst = i.RessursGuidTekst;
        //        item.RessursIdTekst = i.RessursIdTekst;
        //        item.KalenderUnntak = i.KalenderUnntak;
        //        item.Tilgang = i.Tilgang;

        //        if (i.AntallRepiteringer>0)
        //        {
        //            item.SluttType = "1";
        //        }                        
        //        else if (i.MonsterStopDato.Ticks>0)
        //        {
        //            item.SluttType = "2";
        //        }
        //        else
        //        {
        //            item.SluttType = "0";
        //        }

        //        if (i.EtikettListe != null)
        //        {
        //            foreach (var j in i.EtikettListe)
        //            {
        //                Models.KalenderEtikettItem itemE = new();
        //                itemE.base64string = j.base64string;
        //                itemEL.Add(itemE);
        //            }

        //        }

        //        item.Etikettliste = itemEL;

        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<SrcReturnValue> getRegistreringKalenderavtale(SrcLogonInfo logonInfo, int modul, string kalenderGuid)
        //{
        //    SrcKalenderGruppe items = new SrcKalenderGruppe();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    getKIPFinnRegistreringKalenderAvtalerWSResponse resp = new getKIPFinnRegistreringKalenderAvtalerWSResponse();
        //    resp = await KipWSClient.getKIPFinnRegistreringKalenderAvtalerWSAsync(logonInfo, modul, kalenderGuid);
        //    retur = resp.Body.getKIPFinnRegistreringKalenderAvtalerWSResult;

        //    return retur;

        //}


        //#endregion

        //#region Lagrer og sletter kalender avtale

        //public async Task<SrcReturnValue> SetAvtaler(SrcLogonInfo LogonInfo, Models.KalenderAvtalerItem item)
        //{
        //    SrcKalenderAvtaler itemWS = new SrcKalenderAvtaler();

        //    #region data
        //    itemWS.KalenderTiderGuid = item.KalenderTiderGuid;
        //    itemWS.Fellesraad = item.Fellesraad;
        //    itemWS.KalenderGuid = item.KalenderGuid;
        //    itemWS.Emne = item.Emne;
        //    itemWS.Lokasjon = item.Lokasjon;
        //    itemWS.Plassering = item.Plassering;
        //    itemWS.Tekst = item.Tekst;
        //    itemWS.Info = item.Info;
        //    itemWS.Prioritet = item.Prioritet;
        //    itemWS.Privat = item.Privat;
        //    itemWS.Byraa = item.Byraa;
        //    itemWS.Modul = item.Modul;
        //    itemWS.EierGuid = item.EierGuid;
        //    itemWS.UnngåHelligdag = item.UnngåHelligdag;
        //    itemWS.Invitasjon = item.Invitasjon;
        //    itemWS.Varsling = item.Varsling;
        //    itemWS.RessursTekst = item.RessursTekst;
        //    itemWS.KontaktGuid = item.KontaktGuid;
        //    itemWS.SynkExchange = item.SynkExchange;
        //    itemWS.SyncExchange = item.SyncExchange;
        //    itemWS.PubliserWeb = item.PubliserWeb;
        //    itemWS.Varmestyring = item.Varmestyring;
        //    itemWS.StatusId = item.StatusId;
        //    itemWS.SynkAv = item.SynkAv;
        //    itemWS.IsCancelled = item.IsCancelled;
        //    itemWS.Laast = item.Laast;
        //    itemWS.KollisjonSjekk = item.KollisjonSjekk;
        //    itemWS.StartDato = item.StartDato;
        //    itemWS.StartTid = item.StartTid;
        //    itemWS.SluttDato = item.SluttDato;
        //    itemWS.SluttTid = item.SluttTid;
        //    itemWS.PaaMin = item.PaaMin;
        //    itemWS.PaaMinTid = item.PaaMinTid;
        //    itemWS.Monster = item.Monster;
        //    itemWS.Dager = item.Dager;
        //    itemWS.DagInt = item.DagInt;
        //    itemWS.UkeInt = item.UkeInt;
        //    itemWS.UkeMan = item.UkeMan;
        //    itemWS.UkeTir = item.UkeTir;
        //    itemWS.UkeOns = item.UkeOns;
        //    itemWS.UkeTor = item.UkeTor;
        //    itemWS.UkeFre = item.UkeFre;
        //    itemWS.UkeLor = item.UkeLor;
        //    itemWS.UkeSon = item.UkeSon;
        //    itemWS.MonsterStartDato = item.MonsterStartDato;
        //    itemWS.MonsterStopDato = item.MonsterStopDato;
        //    itemWS.UtenStopp = item.UtenStopp;
        //    itemWS.AnsvarligRessursGuid = item.AnsvarligRessursGuid;
        //    itemWS.StedRessursGuid = item.StedRessursGuid;
        //    itemWS.KalenderTiderEier = item.KalenderTiderEier;
        //    itemWS.IgnorerHelligdager = item.IgnorerHelligdager;
        //    itemWS.AntallRepiteringer = item.AntallRepiteringer;
        //    itemWS.MndPattern = item.MndPattern;
        //    itemWS.MndDato = item.MndDato;
        //    itemWS.MndDatoIntervall = item.MndDatoIntervall;
        //    itemWS.MndUke = item.MndUke;
        //    itemWS.MndDag = item.MndDag;
        //    itemWS.MndDagIntervall = item.MndDagIntervall;
        //    itemWS.AarInt = item.AarInt;
        //    itemWS.AarDag = item.AarDag;
        //    itemWS.AarMnd = item.AarMnd;
        //    itemWS.PreTid = item.PreTid;
        //    itemWS.PostTid = item.PostTid;
        //    itemWS.StartTidspunkt = item.StartTidspunkt;
        //    itemWS.SluttTidspunkt = item.SluttTidspunkt;
        //    itemWS.RessursGuidTekst = item.RessursGuidTekst;
        //    itemWS.RessursIdTekst = item.RessursIdTekst;
        //    itemWS.Etiketter = item.Etiketter;
        //    itemWS.LeierKontaktGuid = item.LeierKontaktGuid;
        //    itemWS.SkjerIKirken = item.SkjerIKirken;
        //    itemWS.LinkGuid = item.LinkGuid;
        //    #endregion

        //    setKalenderAvtalerWSResponse resp = new setKalenderAvtalerWSResponse();
        //    resp = await KipWSClient.setKalenderAvtalerWSAsync(LogonInfo, itemWS);

        //    return resp.Body.setKalenderAvtalerWSResult;
        //}

        //public async Task<removeKIPKalenderAvtaleWSResponse> removeKalenderAvtaleItemWs(SrcLogonInfo LogonInfo, string kalenderGuid, bool permanent)
        //{
        //    return await KipWSClient.removeKIPKalenderAvtaleWSAsync(LogonInfo, kalenderGuid, permanent);
        //}

        //public async Task<setKIPKalenderRessursWSResponse> SetKalenderRessurs(SrcLogonInfo LogonInfo, string kalenderGuid, string ressursGuid, string linkGuid, string typeRegistrering)
        //{

        //    return await KipWSClient.setKIPKalenderRessursWSAsync(LogonInfo, kalenderGuid, ressursGuid, linkGuid, typeRegistrering, 0);
        //}

        //public async Task<setKIPGudstjenesteRessurserWSResponse> SetGudstjenesteRessurser(SrcLogonInfo LogonInfo, string gudstjenesteGuid, string kalenderGuid)
        //{

        //    return await KipWSClient.setKIPGudstjenesteRessurserWSAsync(LogonInfo, gudstjenesteGuid, kalenderGuid);
        //}

        //public async Task<string> OppdaterAvtale(SrcLogonInfo logonInfo, Models.KalenderAvtalerItem item)
        //{
        //    SrcKalenderAvtaler itemWS = new SrcKalenderAvtaler();

        //    #region data
        //    itemWS.KalenderTiderGuid = item.KalenderTiderGuid;
        //    itemWS.Fellesraad = item.Fellesraad;
        //    itemWS.KalenderGuid = item.KalenderGuid;
        //    itemWS.Emne = item.Emne;
        //    itemWS.Lokasjon = item.Lokasjon;
        //    itemWS.Plassering = item.Plassering;
        //    itemWS.Tekst = item.Tekst;
        //    itemWS.Info = item.Info;
        //    itemWS.Prioritet = item.Prioritet;
        //    itemWS.Privat = item.Privat;
        //    itemWS.Byraa = item.Byraa;
        //    itemWS.Modul = item.Modul;
        //    itemWS.EierGuid = item.EierGuid;
        //    itemWS.UnngåHelligdag = item.UnngåHelligdag;
        //    itemWS.Invitasjon = item.Invitasjon;
        //    itemWS.Varsling = item.Varsling;
        //    itemWS.RessursTekst = item.RessursTekst;
        //    itemWS.KontaktGuid = item.KontaktGuid;
        //    itemWS.SynkExchange = item.SynkExchange;
        //    itemWS.SyncExchange = item.SyncExchange;
        //    itemWS.PubliserWeb = item.PubliserWeb;
        //    itemWS.Varmestyring = item.Varmestyring;
        //    itemWS.StatusId = item.StatusId;
        //    itemWS.SynkAv = item.SynkAv;
        //    itemWS.IsCancelled = item.IsCancelled;
        //    itemWS.Laast = item.Laast;
        //    itemWS.KollisjonSjekk = item.KollisjonSjekk;
        //    itemWS.StartDato = item.StartDato;
        //    itemWS.StartTid = item.StartTid;
        //    itemWS.SluttDato = item.SluttDato;
        //    itemWS.SluttTid = item.SluttTid;
        //    itemWS.PaaMin = item.PaaMin;
        //    itemWS.PaaMinTid = item.PaaMinTid;
        //    itemWS.Monster = item.Monster;
        //    itemWS.Dager = item.Dager;
        //    itemWS.DagInt = item.DagInt;
        //    itemWS.UkeInt = item.UkeInt;
        //    itemWS.UkeMan = item.UkeMan;
        //    itemWS.UkeTir = item.UkeTir;
        //    itemWS.UkeOns = item.UkeOns;
        //    itemWS.UkeTor = item.UkeTor;
        //    itemWS.UkeFre = item.UkeFre;
        //    itemWS.UkeLor = item.UkeLor;
        //    itemWS.UkeSon = item.UkeSon;
        //    itemWS.MonsterStartDato = item.MonsterStartDato;
        //    itemWS.MonsterStopDato = item.MonsterStopDato;
        //    itemWS.UtenStopp = item.UtenStopp;
        //    itemWS.AnsvarligRessursGuid = item.AnsvarligRessursGuid;
        //    itemWS.KalenderTiderEier = item.KalenderTiderEier;
        //    itemWS.IgnorerHelligdager = item.IgnorerHelligdager;
        //    itemWS.AntallRepiteringer = item.AntallRepiteringer;
        //    itemWS.MndPattern = item.MndPattern;
        //    itemWS.MndDato = item.MndDato;
        //    itemWS.MndDatoIntervall = item.MndDatoIntervall;
        //    itemWS.MndUke = item.MndUke;
        //    itemWS.MndDag = item.MndDag;
        //    itemWS.MndDagIntervall = item.MndDagIntervall;
        //    itemWS.AarInt = item.AarInt;
        //    itemWS.AarDag = item.AarDag;
        //    itemWS.AarMnd = item.AarMnd;
        //    itemWS.PreTid = item.PreTid;
        //    itemWS.PostTid = item.PostTid;
        //    itemWS.StartTidspunkt = item.StartTidspunkt;
        //    itemWS.SluttTidspunkt = item.SluttTidspunkt;
        //    itemWS.RessursGuidTekst = item.RessursGuidTekst;
        //    itemWS.RessursIdTekst = item.RessursIdTekst;
        //    #endregion


        //    exeKIPOppdaterAvtaleWSResponse resp = new exeKIPOppdaterAvtaleWSResponse();
        //    resp = await KipWSClient.exeKIPOppdaterAvtaleWSAsync(logonInfo, itemWS);

        //    return resp.Body.exeKIPOppdaterAvtaleWSResult;
        //}

        //public async Task<List<Models.KalenderDatoerItem>> GetKalenderDatoer(SrcLogonInfo logonInfo, string filter)
        //{
        //    getKIPKalenderDatoerWSResponse resp = new getKIPKalenderDatoerWSResponse();
        //    resp = await KipWSClient.getKIPKalenderDatoerWSAsync(logonInfo, filter);

        //    List<Models.KalenderDatoerItem> items = new List<Models.KalenderDatoerItem>();
        //    SrcKalenderDatoer[] itemsWS;

        //    itemsWS = resp.Body.getKIPKalenderDatoerWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KalenderDatoerItem item = new Models.KalenderDatoerItem();
        //        item.StartDate = i.StartDato;
        //        items.Add(item);
        //    }
        //    return items;
        //}


        //public async Task<string> SlettSkjeriKirken(SrcLogonInfo LogonInfo, string kalenderGuid, string modul, string LinkGuid)
        //{
        //    PubliserSkjerikirkenResponse resp = new PubliserSkjerikirkenResponse();
        //    resp = await KipWSClient.PubliserSkjerikirkenAsync(LogonInfo, kalenderGuid, 3, modul, LinkGuid, DateTime.Now);

        //    return resp.Body.PubliserSkjerikirkenResult;
        //}

        //#endregion


        //#region Liste over ressurser knytt til en bestemt avtale


        //public async Task<List<Models.KalenderRessurserItem>> GetKalenderRessurserListe(SrcLogonInfo LogonInfo, string kalenderGuid)
        //{

        //    getKIPKalenderRessurserListeWSResponse resp = new getKIPKalenderRessurserListeWSResponse();
        //    resp = await KipWSClient.getKIPKalenderRessurserListeWSAsync(LogonInfo, kalenderGuid);

        //    List<Models.KalenderRessurserItem> items = new List<Models.KalenderRessurserItem>();
        //    items = FromWsToKalenderRessurserItem(resp.Body.getKIPKalenderRessurserListeWSResult);

        //    return items;
        //}

        //private List<Models.KalenderRessurserItem> FromWsToKalenderRessurserItem(SrcKalenderRessurser[] itemws)
        //{
        //    List<Models.KalenderRessurserItem> items = new List<Models.KalenderRessurserItem>();
        //    foreach (var i in itemws)
        //    {
        //        Models.KalenderRessurserItem item = new Models.KalenderRessurserItem();

        //        item.Fellesraad = i.Fellesraad;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.RessursGuid = i.RessursGuid;
        //        item.ResType = i.ResType;
        //        item.Navn = i.Navn;
        //        item.Stilling = i.Stilling;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<bool> RemoveKalenderRessurs(SrcLogonInfo LogonInfo, string KalenderRessursGuid)
        //{
        //    exeKIPKalenderRessursRemoveResponse resp = new exeKIPKalenderRessursRemoveResponse();
        //    resp = await KipWSClient.exeKIPKalenderRessursRemoveAsync(LogonInfo, KalenderRessursGuid);

        //    return resp.Body.exeKIPKalenderRessursRemoveResult;
        //}

        //public async Task<bool> SetKalenderRessursType(SrcLogonInfo LogonInfo, string KalenderRessursGuid, string Type)
        //{
        //    setKalenderRessursTypeResponse resp = new setKalenderRessursTypeResponse();
        //    resp = await KipWSClient.setKalenderRessursTypeAsync(LogonInfo, KalenderRessursGuid, Type);

        //    return resp.Body.setKalenderRessursTypeResult;
        //}

        //#endregion

        //#region Gammel kode

        //public List<Models.KalenderRessursItem> FromWsToKalenderRessursItem(SrcKalenderRessurs[] itemws)
        //{
        //    List<Models.KalenderRessursItem> items = new List<Models.KalenderRessursItem>();
        //    int j=0;

        //    foreach (var i in itemws)
        //    {
        //        Models.KalenderRessursItem item = new Models.KalenderRessursItem();
        //        item.Navn = i.Navn;
        //        item.EierNavn = i.EierNavn;
        //        item.ResType = i.ResType;
        //        item.RessursGuid = i.RessursGuid;
        //        item.RessursId = i.RessursId;
        //        item.GruppeNavn = i.GruppeNavn;
        //        item.Sortering = i.Sortering;
        //        item.RessursEierGuid = i.RessursEierGuid;
        //        item.Checked = i.Checked;
        //        item.HarBarn = i.HarBarn;
        //        if (i.FargeNavn.IndexOf(";")>0)
        //        {
        //            string[] arrFarge = i.FargeNavn.Split(";");
        //            string hex = string.Format("{0}{1}{2}", Convert.ToInt32(arrFarge[0]).ToString("X"), Convert.ToInt32(arrFarge[1]).ToString("X"), Convert.ToInt32(arrFarge[2]).ToString("X")) ;
        //            item.FargeNavn = "#" + hex;
        //        }
        //        else if (i.FargeNavn.Length>0) {
        //            item.FargeNavn = i.FargeNavn;
        //        }
        //        else
        //        {
        //            j++;
        //            switch (j)
        //            {
        //                case 0:
        //                    item.FargeNavn = "Coral";
        //                    break;

        //                case 1:
        //                    item.FargeNavn = "CornflowerBlue";
        //                    break;

        //                case 2:
        //                    item.FargeNavn = "DarkKhaki";
        //                    break;

        //                case 3:
        //                    item.FargeNavn = "DarkOrange";
        //                    break;

        //                case 4:
        //                    item.FargeNavn = "DarkTurquoise";
        //                    break;

        //                case 5:
        //                    item.FargeNavn = "Goldenrod";
        //                    break;

        //                case 6:
        //                    item.FargeNavn = "LightCoral";
        //                    break;

        //                case 7:
        //                    item.FargeNavn = "LightSeaGreen";
        //                    break;

        //                case 8:
        //                    item.FargeNavn = "LightSteelBlue";
        //                    break;

        //                case 9:
        //                    item.FargeNavn = "LimeGreen";
        //                    break;

        //                case 10:
        //                    item.FargeNavn = "MediumAquamarine";
        //                    break;

        //                case 11:
        //                    item.FargeNavn = "MediumTurquoise";
        //                    break;

        //                case 12:
        //                    item.FargeNavn = "OliveDrab";
        //                    break;

        //                case 13:
        //                    item.FargeNavn = "OrangeRed";
        //                    break;

        //                case 14:
        //                    item.FargeNavn = "PaleVioletRed";
        //                    break;

        //                case 15:
        //                    item.FargeNavn = "Plum";
        //                    break;

        //                case 16:
        //                    item.FargeNavn = "Purple";
        //                    break;

        //                case 17:
        //                    item.FargeNavn = "Salmon";
        //                    break;

        //                case 18:
        //                    item.FargeNavn = "SeaGreen";
        //                    break;

        //                case 19:
        //                    item.FargeNavn = "SlateBlue";
        //                    break;

        //                case 20:
        //                    item.FargeNavn = "Teal";
        //                    break;

        //                case 21:
        //                    item.FargeNavn = "Tomato";
        //                    break;

        //                case 22:
        //                    item.FargeNavn = "Violet";
        //                    break;

        //                case 23:
        //                    item.FargeNavn = "MediumVioletRed";
        //                    break;

        //                case 24:
        //                    item.FargeNavn = "MediumBlue";
        //                    break;

        //                case 25:
        //                    item.FargeNavn = "Maroon";
        //                    break;

        //                case 26:
        //                    item.FargeNavn = "IndianRed";
        //                    break;

        //                case 27:
        //                    item.FargeNavn = "HotPink";
        //                    break;

        //                case 28:
        //                    item.FargeNavn = "Green";
        //                    break;

        //                case 29:
        //                    item.FargeNavn = "DeepSkyBlue";
        //                    break;

        //                case 30:
        //                    item.FargeNavn = "DarkSlateBlue";
        //                    break;
        //            }
        //        }
        //         items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.KalenderRessursItem>> GetKalenderRessursListe(SrcLogonInfo LogonInfo, string filter, string sortering)
        //{

        //    getKIPKalenderRessurserWSResponse resp = new getKIPKalenderRessurserWSResponse();
        //    resp = await KipWSClient.getKIPKalenderRessurserWSAsync(LogonInfo, filter, sortering);

        //    List<Models.KalenderRessursItem> items = new List<Models.KalenderRessursItem>();
        //    items = FromWsToKalenderRessursItem(resp.Body.getKIPKalenderRessurserWSResult);

        //    return items;
        //}

        //#endregion

        //#region Helligdager

        //public async Task<List<Models.HelligdagerItem>> GetHelligdagerListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPHelligdagerWSResponse resp = new getKIPHelligdagerWSResponse();
        //    resp = await KipWSClient.getKIPHelligdagerWSAsync(logonInfo);

        //    List<Models.HelligdagerItem> items = new List<Models.HelligdagerItem>();
        //    SrcDag[] itemsWS;

        //    itemsWS = resp.Body.getKIPHelligdagerWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.HelligdagerItem item = new Models.HelligdagerItem();
        //        item.Dato = i.Dato;
        //        item.Farge = i.Farge;
        //        item.Hoytidsdag = i.Hoytidsdag;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //#endregion

        //#region Kalener Gruppe

        //public async Task<SrcReturnValue> SetKalenderGruppe(SrcLogonInfo logonInfo, Models.KalenderGruppeItem item)
        //{
        //    SrcKalenderGruppe items = new SrcKalenderGruppe();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.SoknNr = item.SoknNr;
        //    items.RessursGruppeGuid = item.RessursGruppeGuid;
        //    items.Navn = item.Navn;
        //    items.Aktiv = item.Aktiv;
        //    items.Eier = item.Eier;
        //    items.Privat = item.Privat;
        //    items.Type = item.Type;

        //    setKIPKalenderGruppeWSResponse resp = new setKIPKalenderGruppeWSResponse();
        //    resp = await KipWSClient.setKIPKalenderGruppeWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPKalenderGruppeWSResult;

        //    return retur;

        //}

        //public async Task<List<Models.KalenderGruppeItem>> GetKalenderGruppeListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPRessursGruppeListeWSResponse resp = new getKIPRessursGruppeListeWSResponse();
        //    resp = await KipWSClient.getKIPRessursGruppeListeWSAsync(logonInfo);

        //    List<Models.KalenderGruppeItem> items = new List<Models.KalenderGruppeItem>();
        //    SrcKalenderGruppe[] itemsWS;

        //    itemsWS = resp.Body.getKIPRessursGruppeListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KalenderGruppeItem item = new Models.KalenderGruppeItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.SoknNr = i.SoknNr;
        //        item.RessursGruppeGuid = i.RessursGruppeGuid;
        //        item.Navn = i.Navn;
        //        item.Aktiv = i.Aktiv;
        //        item.Eier = i.Eier;
        //        item.Privat = i.Privat;
        //        item.Type = i.Type;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        if (i.Eier != logonInfo.BrukerId)
        //        {
        //            item.Aktiv = false;
        //        }
        //        else
        //        {
        //            item.Aktiv = true;
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<bool> removeKalenderItemWs(SrcLogonInfo logonInfo, string RessursGruppeGuid)
        //{
        //    bool retur;
        //    removeKIPKalenderGruppeWSResponse resp = new removeKIPKalenderGruppeWSResponse();
        //    resp = await KipWSClient.removeKIPKalenderGruppeWSAsync(logonInfo, RessursGruppeGuid);
        //    retur = resp.Body.removeKIPKalenderGruppeWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> setKalenderGruppeAktiv(SrcLogonInfo logonInfo, string kalenderGruppeGuid)
        //{
        //    SrcReturnValue retur;
        //    setKIPKalenderGruppeAktivWSResponse resp = new setKIPKalenderGruppeAktivWSResponse();
        //    resp = await KipWSClient.setKIPKalenderGruppeAktivWSAsync(logonInfo, kalenderGruppeGuid);
        //    retur = resp.Body.setKIPKalenderGruppeAktivWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> setKalenderGruppeMedlemmer(SrcLogonInfo logonInfo, string kalenderGruppeGuid)
        //{
        //    SrcReturnValue retur;
        //    setKIPKalenderGruppeMedlemWSResponse resp = new setKIPKalenderGruppeMedlemWSResponse();
        //    resp = await KipWSClient.setKIPKalenderGruppeMedlemWSAsync(logonInfo, kalenderGruppeGuid);
        //    retur = resp.Body.setKIPKalenderGruppeMedlemWSResult;

        //    return retur;
        //}

        //public async Task<bool> removeKalenderGruppe(SrcLogonInfo logonInfo, string kalenderGruppeGuid)
        //{
        //    bool retur;
        //    removeKIPKalenderGruppeWSResponse resp = new removeKIPKalenderGruppeWSResponse();
        //    resp = await KipWSClient.removeKIPKalenderGruppeWSAsync(logonInfo, kalenderGruppeGuid);
        //    retur = resp.Body.removeKIPKalenderGruppeWSResult;

        //    return retur;
        //}


        //#endregion

        //#region Kalender ressurser

        //public async Task<List<Models.KalenderRessursItem>> GetKalenderAktiveRessursListe(SrcLogonInfo LogonInfo)
        //{

        //    getKIPKalenderAktiveRessurserWSResponse resp = new getKIPKalenderAktiveRessurserWSResponse();
        //    resp = await KipWSClient.getKIPKalenderAktiveRessurserWSAsync(LogonInfo);

        //    List<Models.KalenderRessursItem> items = new List<Models.KalenderRessursItem>();
        //    items = FromWsToKalenderRessursItem(resp.Body.getKIPKalenderAktiveRessurserWSResult);

        //    return items;
        //}

        //public async Task<setKIPKalenderAktivRessursWSResponse> SetKalenderAktivRessursWS(SrcLogonInfo LogonInfo, string ressursGuid)
        //{
        //    return await KipWSClient.setKIPKalenderAktivRessursWSAsync(LogonInfo, ressursGuid);
        //}

        //public async Task<setKIPKalenderUnregRessursWSResponse> SetKalenderUnregRessursWS(SrcLogonInfo LogonInfo, string KalenderGuid, string TypeRessurs, string navn)
        //{
        //    return await KipWSClient.setKIPKalenderUnregRessursWSAsync(LogonInfo, KalenderGuid, TypeRessurs, navn);
        //}

        //#endregion

        //#region Kalender ressursliste 
        //public async Task<List<Models.RessursItem>> GetRessurserFunksjonsliste(SrcLogonInfo LogonInfo, int ressursType, string Funksjon, string SoknId)
        //{

        //    getKIPRessursFunksjonListeWSResponse resp = new getKIPRessursFunksjonListeWSResponse();
        //    resp = await KipWSClient.getKIPRessursFunksjonListeWSAsync(LogonInfo, ressursType, Funksjon, SoknId);

        //    List<Models.RessursItem> items = new List<Models.RessursItem>();
        //    SrcRessursListeNavn[] itemsWS;

        //    itemsWS = resp.Body.getKIPRessursFunksjonListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.RessursItem item = new Models.RessursItem();
        //        item.RessursGuid = i.RessursGuid;
        //        item.ResType = i.ResType;
        //        item.SoknNr = i.SoknId;
        //        item.Navn = i.Navn;
        //        items.Add(item);
        //    }

        //    return items;
        //}

        //public async Task<List<Models.KalenderRessurserItem>> getKalenderAktiveRessurserAlle(SrcLogonInfo LogonInfo, string ResType, string KalenderGuid)
        //{

        //    getKIPKalenderAktiveRessurserAlleWSResponse resp = new getKIPKalenderAktiveRessurserAlleWSResponse();
        //    resp = await KipWSClient.getKIPKalenderAktiveRessurserAlleWSAsync(LogonInfo, ResType, KalenderGuid);

        //    List<Models.KalenderRessurserItem> items = new List<Models.KalenderRessurserItem>();
        //    SrcKalenderRessurs[] itemsWS;

        //    itemsWS = resp.Body.getKIPKalenderAktiveRessurserAlleWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KalenderRessurserItem item = new Models.KalenderRessurserItem();
        //        item.RessursGuid = i.RessursGuid;
        //        item.ResType = i.ResType;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.Navn = i.Navn;
        //        items.Add(item);
        //    }

        //    return items;
        //}

        //public async Task<List<Models.KalenderRessurserListeItem>> GetKalenderRessurserListe2(SrcLogonInfo LogonInfo, string kalenderGuid, string filterTekst)
        //{

        //    getKIPKalenderRessurserListeNyWSResponse resp = new getKIPKalenderRessurserListeNyWSResponse();
        //    resp = await KipWSClient.getKIPKalenderRessurserListeNyWSAsync(LogonInfo, kalenderGuid, filterTekst);

        //    List<Models.KalenderRessurserListeItem> items = new List<Models.KalenderRessurserListeItem>();
        //    items = FromWsToKalenderRessurserListeItem(resp.Body.getKIPKalenderRessurserListeNyWSResult);

        //    return items;
        //}

        //private List<Models.KalenderRessurserListeItem> FromWsToKalenderRessurserListeItem(SrcKalenderRessurserListe[] itemws)
        //{
        //    List<Models.KalenderRessurserListeItem> items = new List<Models.KalenderRessurserListeItem>();
        //    foreach (var i in itemws)
        //    {
        //        Models.KalenderRessurserListeItem item = new Models.KalenderRessurserListeItem();

        //        item.Fellesraad = i.Fellesraad;
        //        item.KalenderRessursGuid = i.KalenderRessursGuid;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.ResType = i.ResType;
        //        item.Type = i.Type;
        //        if (Startup.StandardSprak == "de-DE")
        //        {
        //            switch (i.Type)
        //            {
        //                case "Seremoni":
        //                    item.Type = "Zeremonie";
        //                    break;

        //                case "Organist":
        //                    item.Type = "Organist/in";
        //                    break;

        //                case "Liturg":
        //                    item.Type = "Liturg/in";
        //                    break;

        //                case "Kirketjener":
        //                    item.Type = "Küster/in";
        //                    break;

        //                case "Tekstleser":
        //                    item.Type = "Lesedienst";
        //                    break;
        //            }
        //        }
        //        item.Sortering = i.Sortering;
        //        item.Navn = i.Navn;
        //        item.RessursGuid = i.RessursGuid;
        //        item.EPost = i.Epost;
        //        item.Mobil = i.Mobil;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //#endregion

        //#region  Etiketter

        //public async Task<List<Models.EtikettItem>> GetEtikettListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPEtikettListeWSResponse resp = new getKIPEtikettListeWSResponse();
        //    resp = await KipWSClient.getKIPEtikettListeWSAsync(logonInfo);

        //    List<Models.EtikettItem> items = new List<Models.EtikettItem>();
        //    SrcEtikett[] itemsWS;

        //    itemsWS = resp.Body.getKIPEtikettListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.EtikettItem item = new Models.EtikettItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.EtikettGuid = i.EtikettGuid;
        //        item.Navn = i.Navn;
        //        item.Farge = i.Farge;
        //        item.Modul = i.Modul;
        //        item.Varighet = i.Varighet;
        //        item.base64string = i.base64string;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.EtikettItem> GetEtikett(SrcLogonInfo logonInfo, string EtikettGuid)
        //{
        //    getKIPEtikettWSResponse resp = new getKIPEtikettWSResponse();
        //    resp = await KipWSClient.getKIPEtikettWSAsync(logonInfo, EtikettGuid);

        //    Models.EtikettItem item = new Models.EtikettItem();
        //    SrcEtikett i = resp.Body.getKIPEtikettWSResult;


        //    item.Fellesraad = i.Fellesraad;
        //    item.EtikettGuid = i.EtikettGuid;
        //    item.Navn = i.Navn;
        //    item.Farge = i.Farge;
        //    item.Kollisjonssjekk = i.Kollisjonssjekk;
        //    item.Prefiks = i.Prefiks;
        //    item.PreTid = i.PreTid;
        //    item.PostTid = i.PostTid;
        //    item.MedarbeiderEtikettGuid = i.MedarbeiderEtikettGuid;
        //    item.Modul = i.Modul;
        //    item.Varighet = i.Varighet;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.Fri = i.Fri;
        //    item.System = i.System;
        //    item.Tjenesteuke = i.Tjenesteuke;
        //    item.LabEtikettColor = i.LabEtikettColor;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetEtikett(SrcLogonInfo logonInfo, Models.EtikettItem item)
        //{
        //    SrcEtikett items = new SrcEtikett();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Fellesraad = item.Fellesraad;
        //    items.EtikettGuid = item.EtikettGuid;
        //    items.Navn = item.Navn;
        //    items.Farge = item.Farge;
        //    items.Kollisjonssjekk = item.Kollisjonssjekk;
        //    items.Prefiks = item.Prefiks;
        //    items.PreTid = item.PreTid;
        //    items.PostTid = item.PostTid;
        //    items.MedarbeiderEtikettGuid = item.MedarbeiderEtikettGuid;
        //    items.Modul = item.Modul;
        //    items.Varighet = item.Varighet;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.Fri = item.Fri;
        //    items.System = item.System;
        //    items.Tjenesteuke = item.Tjenesteuke;
        //    items.LabEtikettColor = item.LabEtikettColor;

        //    setKIPEtikettWSResponse resp = new setKIPEtikettWSResponse();
        //    resp = await KipWSClient.setKIPEtikettWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPEtikettWSResult;

        //    return retur;

        //}

        //public async Task<List<Models.KalenderEtikettItem>> GetKalenderEtikettListe(SrcLogonInfo logonInfo, string KalenderGuid)
        //{
        //    getKIPKalenderEtikettListeWSResponse resp = new getKIPKalenderEtikettListeWSResponse();
        //    resp = await KipWSClient.getKIPKalenderEtikettListeWSAsync(logonInfo, KalenderGuid);

        //    List<Models.KalenderEtikettItem> items = new List<Models.KalenderEtikettItem>();
        //    SrcKalenderEtikett[] itemsWS;

        //    itemsWS = resp.Body.getKIPKalenderEtikettListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KalenderEtikettItem item = new Models.KalenderEtikettItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.EtikettGuid = i.EtikettGuid;
        //        item.Navn = i.Navn;
        //        item.Farge = i.Farge;
        //        item.Kollisjonssjekk = i.Kollisjonssjekk;
        //        item.Prefiks = i.Prefiks;
        //        item.PreTid = i.PreTid;
        //        item.PostTid = i.PostTid;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.base64string = i.base64string;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //#endregion

        //#region Stenging

        //public async Task<List<Models.KalenderAvtalerItem>> GetKalenderStengeListe(SrcLogonInfo LogonInfo, string filter, string sortering)
        //{

        //    getKIPKalenderStengingerWSResponse resp = new getKIPKalenderStengingerWSResponse();
        //    resp = await KipWSClient.getKIPKalenderStengingerWSAsync(LogonInfo, filter, sortering);

        //    SrcKalenderAvtaler[] itemWS;
        //    List<Models.KalenderAvtalerItem> items = new List<Models.KalenderAvtalerItem>();
        //    itemWS = resp.Body.getKIPKalenderStengingerWSResult;

        //    foreach (var i in itemWS)
        //    {
        //        Models.KalenderAvtalerItem item = new Models.KalenderAvtalerItem();

        //        item.KalenderTiderGuid = i.KalenderTiderGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.Emne = i.Emne;
        //        item.Lokasjon = i.Lokasjon;
        //        item.Plassering = i.Plassering;
        //        item.Tekst = i.Tekst;
        //        item.Info = i.Info;
        //        item.Prioritet = i.Prioritet;
        //        item.Privat = i.Privat;
        //        item.Access = i.Access;
        //        item.Byraa = i.Byraa;
        //        item.Modul = i.Modul;
        //        if (i.Modul == 777)
        //        {
        //            item.StengHva = "Urnekalender";
        //        }
        //        else if (i.Modul == 888)
        //        {
        //            item.StengHva = "Bestilling kalender";
        //        }
        //        else if (i.Modul == 999)
        //        {
        //            item.StengHva = "Begge";
        //        }
        //        item.EierGuid = i.EierGuid;
        //        item.UnngåHelligdag = i.UnngåHelligdag;
        //        item.Invitasjon = i.Invitasjon;
        //        item.Varsling = i.Varsling;
        //        item.RessursTekst = i.RessursTekst;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.SynkExchange = i.SynkExchange;
        //        item.SyncExchange = i.SyncExchange;
        //        item.PubliserWeb = i.PubliserWeb;
        //        item.Varmestyring = i.Varmestyring;
        //        item.StatusId = i.StatusId;
        //        item.SynkAv = i.SynkAv;
        //        item.IsCancelled = i.IsCancelled;
        //        item.Laast = i.Laast;
        //        item.KollisjonSjekk = i.KollisjonSjekk;
        //        item.StartDato = i.StartDato;
        //        item.StartTid = i.StartTid;
        //        item.SluttDato = i.SluttDato;
        //        item.SluttTid = i.SluttTid;
        //        item.AnsvarligRessursGuid = i.AnsvarligRessursGuid;
        //        item.KalenderTiderEier = i.KalenderTiderEier;
        //        item.IgnorerHelligdager = i.IgnorerHelligdager;
        //        item.AntallRepiteringer = i.AntallRepiteringer;
        //        item.PreTid = i.PreTid;
        //        item.PostTid = i.PostTid;
        //        item.StartTidspunkt = i.StartTidspunkt;
        //        item.SluttTidspunkt = i.SluttTidspunkt;
        //        item.RessursGuidTekst = i.RessursGuidTekst;
        //        item.RessursIdTekst = i.RessursIdTekst;
        //        item.KalenderUnntak = i.KalenderUnntak;
        //        item.Tilgang = i.Tilgang;

        //        if (i.AntallRepiteringer > 0)
        //        {
        //            item.SluttType = "1";
        //        }
        //        else if (i.MonsterStopDato.Ticks > 0)
        //        {
        //            item.SluttType = "2";
        //        }
        //        else
        //        {
        //            item.SluttType = "0";
        //        }

        //        items.Add(item);
        //    }
        //    return items;

        //}

        //#endregion

        //#region Generelle funksjoner

        //public async Task<SrcReturnValue> getKIPKalenderKonflikt(SrcLogonInfo LogonInfo, string RessursListe, DateTime? Dato, string KlokkeslettFra, string KlokkeslettTil, string KalenderGuid, int Modul, bool AllowDuplet)
        //{

        //    SrcReturnValue retur = new();
        //    SrcKalenderKonflikt item = new();
        //    getKIPKalenderKonfliktResponse resp = new getKIPKalenderKonfliktResponse();

        //    if (Dato != null)
        //    {
        //        item.KalenderGuid = KalenderGuid;
        //        item.Dato = (DateTime)Dato;
        //        item.KlokkeslettFra = KlokkeslettFra;
        //        item.KlokkeslettTil = KlokkeslettTil;
        //        item.RessursListe = RessursListe;
        //        item.Modul = Modul;
        //        item.AllowDuplet = AllowDuplet;

        //        if (item.Dato>DateTime.Now)
        //        {
        //            try
        //            {
        //                resp = await KipWSClient.getKIPKalenderKonfliktAsync(LogonInfo, item);
        //                retur = resp.Body.getKIPKalenderKonfliktResult;
        //            }
        //            catch (Exception ex)
        //            {
        //                retur.ErrorText = ex.Message;
        //                retur.Result = false;
        //            }

        //        }
        //        else
        //        {
        //            retur.Result = true;
        //        }

        //    }
        //    else 
        //    { 
        //        retur.Result = true; 
        //    }

        //    return retur;
        //}


        //#endregion


    }

}




