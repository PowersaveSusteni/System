using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Kendo.Mvc.UI;
using System.Diagnostics;
using System;
using System.Text;
using Susteni.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class FunctionsRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public FunctionsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        #region Oppgave kategorier

        //public async Task<List<Models.OppgaveKategoriItem>> GetOppgaveKategoriListe(SrcLogonInfo LogonInfo)
        //{
        //    getKIPOppgaveKategoriListeWSResponse resp = new getKIPOppgaveKategoriListeWSResponse();
        //    resp = await GetOppgaveKategoriListeWs(LogonInfo);

        //    List<Models.OppgaveKategoriItem> items = new List<Models.OppgaveKategoriItem>();
        //    items = FromWsToOppgaveKategoriItem(resp.Body.getKIPOppgaveKategoriListeWSResult);

        //    return items;

        //}

        //private async Task<getKIPOppgaveKategoriListeWSResponse> GetOppgaveKategoriListeWs(SrcLogonInfo LogonInfo)
        //{
        //    return await KipWSClient.getKIPOppgaveKategoriListeWSAsync(LogonInfo);
        //}

        //private List<Models.OppgaveKategoriItem> FromWsToOppgaveKategoriItem(kip.kirkedata.webservices.SrcOppgaveKategori[] itemws)
        //{
        //    List<Models.OppgaveKategoriItem> items = new List<Models.OppgaveKategoriItem>();
        //    foreach (var i in itemws)
        //    {
        //        Models.OppgaveKategoriItem item = new Models.OppgaveKategoriItem();

        //        item.Fellesraad = i.Fellesraad;
        //        item.FunkKategori_GUID = i.FunkKategori_GUID;
        //        item.Navn = i.Navn;
        //        item.Bilde_GUID = i.Bilde_GUID;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        #endregion

        #region Søk etter kontakter

        //public async Task<List<Models.MedlemssokItem>> GetMedlemssokListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPMedlemssokListeWSResponse resp = new getKIPMedlemssokListeWSResponse();
        //    resp = await KipWSClient.getKIPMedlemssokListeWSAsync(logonInfo);

        //    List<Models.MedlemssokItem> items = new List<Models.MedlemssokItem>();
        //    SrcMedlemssok[] itemsWS;

        //    itemsWS = resp.Body.getKIPMedlemssokListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.MedlemssokItem item = new Models.MedlemssokItem();
        //        item.SokGuid = i.SokGuid;
        //        item.Tittel = i.Tittel;
        //        item.Alder = i.Alder;
        //        item.Farge = i.Farge;
        //        item.Type = i.Type;
        //        item.Sortering = i.Sortering;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> CreateKontaktListe(SrcLogonInfo LogonInfo, SrcSokeInfo srcSokeInfo)
        //{
        //    createKIPKontaktListeWSResponse resp = new createKIPKontaktListeWSResponse();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();

        //    resp = await KipWSClient.createKIPKontaktListeWSAsync(LogonInfo, srcSokeInfo);
        //    retur = resp.Body.createKIPKontaktListeWSResult;
        //    return retur;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> CreateKontaktListeTrusoppAbb(SrcLogonInfo LogonInfo, SrcSokeInfo srcSokeInfo)
        //{
        //    finnTrosopplaringsabonnenterResponse resp = new finnTrosopplaringsabonnenterResponse();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();

        //    resp = await KipWSClient.finnTrosopplaringsabonnenterAsync(LogonInfo, srcSokeInfo);
        //    retur = resp.Body.finnTrosopplaringsabonnenterResult;
        //    return retur;
        //}

        //public async Task<Models.KontaktItem> HentPersonFraMedlemsregister(SrcLogonInfo LogonInfo, SrcSokeInfo srcSokeInfo)
        //{
        //    createKIPKontaktListeWSResponse resp = new createKIPKontaktListeWSResponse();
        //    Models.KontaktItem item = new Models.KontaktItem();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();

        //    resp = await KipWSClient.createKIPKontaktListeWSAsync(LogonInfo, srcSokeInfo);
        //    retur = resp.Body.createKIPKontaktListeWSResult; 

        //    if (retur.NewId > 0)
        //    {
        //        getKIPInfobankPersonWSResponse resp2 = new getKIPInfobankPersonWSResponse();
        //        resp2 = await KipWSClient.getKIPInfobankPersonWSAsync(LogonInfo, srcSokeInfo.PersonNr);

        //        SrcKontakt i = resp2.Body.getKIPInfobankPersonWSResult;

        //        item.Fellesraad = i.Fellesraad;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.Fodt = i.Fodt;
        //        item.PersonNr = i.PersonNr;
        //        item.Etternavn = i.Etternavn;
        //        item.Mellomnavn = i.Mellomnavn;
        //        item.Fornavn = i.Fornavn;
        //        item.Adresse = i.Adresse;
        //        item.FulltNavn = i.FulltNavn;
        //        item.PostNr = i.PostNr;
        //        item.Sted = i.Sted;
        //        item.KommuneNr = i.KommuneNr;
        //        item.ErDod = i.ErDod;
        //        item.Fodt = i.Fodt;
        //        item.DapsDato = i.DapsDato;
        //        item.SoknNr = i.SoknNr;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.PostNrId = i.PostNrId;
        //    }


        //    return item;
        //}

        //public async Task<Models.KontaktItem> HentPersonFraMedlemsregisterByraa(SrcLogonInfo LogonInfo, SrcSokeInfo srcSokeInfo)
        //{
        //    createKIPByraaKontaktListeWSResponse resp = new createKIPByraaKontaktListeWSResponse();
        //    Models.KontaktItem item = new Models.KontaktItem();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();

        //    resp = await KipWSClient.createKIPByraaKontaktListeWSAsync(LogonInfo, srcSokeInfo);
        //    retur = resp.Body.createKIPByraaKontaktListeWSResult;

        //    if (retur.NewId > 0)
        //    {
        //        getKIPInfobankPersonWSResponse resp2 = new getKIPInfobankPersonWSResponse();
        //        resp2 = await KipWSClient.getKIPInfobankPersonWSAsync(LogonInfo, srcSokeInfo.PersonNr);

        //        SrcKontakt i = resp2.Body.getKIPInfobankPersonWSResult;

        //        i.KontaktGuid = "";
        //        setKIPKontaktWSResponse respKontakt = new setKIPKontaktWSResponse();
        //        respKontakt = await KipWSClient.setKIPKontaktWSAsync(LogonInfo, i);
        //        retur = respKontakt.Body.setKIPKontaktWSResult;

        //        item.Fellesraad = i.Fellesraad;
        //        item.KontaktGuid = retur.NewGuid;
        //        item.Fodt = i.Fodt;
        //        item.PersonNr = i.PersonNr;
        //        item.Etternavn = i.Etternavn;
        //        item.Mellomnavn = i.Mellomnavn;
        //        item.Fornavn = i.Fornavn;
        //        item.Adresse = i.Adresse;
        //        item.FulltNavn = i.FulltNavn;
        //        item.PostNr = i.PostNr;
        //        item.Sted = i.Sted;
        //        item.KommuneNr = i.KommuneNr;
        //        item.ErDod = i.ErDod;
        //        item.Fodt = i.Fodt;
        //        item.DapsDato = i.DapsDato;
        //        item.SoknNr = i.SoknNr;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.PostNrId = i.PostNrId;
        //    }


        //    return item;
        //}

        //public async Task<List<Models.KontaktListeItem>> GetKontaktListe(SrcLogonInfo LogonInfo, int resultatId, bool visKunSiste, string sortering)
        //{         
        //    getKIPKontaktListeSokWSResponse resp = new getKIPKontaktListeSokWSResponse();
        //    resp = await KipWSClient.getKIPKontaktListeSokWSAsync(LogonInfo, resultatId, visKunSiste, sortering);

        //    List<Models.KontaktListeItem> items = new List<Models.KontaktListeItem>();
        //    SrcFinnKontakt[] itemws;

        //    itemws = resp.Body.getKIPKontaktListeSokWSResult;

        //    foreach (var i in itemws)
        //    {
        //        Models.KontaktListeItem item = new Models.KontaktListeItem();

        //        item.Fellesraad = i.Fellesraad;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.PersonNr = i.PersonNr;
        //        Debug.Print(i.Fulltnavn);
        //        if (i.Født.Ticks > 0) { item.Født = i.Født; }
        //        else if (i.PersonNr.Length == 11)
        //        {
        //            string fDate = i.PersonNr.Substring(0, 6);
        //            string fYear = "20";

        //            if (int.Parse(i.PersonNr.Substring(6)) < 50000)
        //            {
        //                fYear = "19";   
        //            }
        //            else if (int.Parse(i.PersonNr.Substring(6)) < 75000 )
        //            {
        //                fYear = "18";
        //            }

        //            fDate = fDate.Substring(0, 2) + "." + fDate.Substring(2, 2) + "." + fYear + fDate.Substring(4, 2);

        //            try
        //            {
        //                item.Født = (System.DateTime.Parse(fDate));
        //            }
        //            catch { }
        //        }
        //        item.StatKd = i.StatKd;
        //        item.Etternavn = i.Etternavn;
        //        item.Mellomnavn = i.Mellomnavn;
        //        item.Fornavn = i.Fornavn;
        //        item.Fulltnavn = i.Fulltnavn;
        //        if (i.Fulltnavn == "")
        //        {
        //            item.Fulltnavn = i.Fornavn;
        //            if (i.Mellomnavn != "") { item.Fulltnavn += " " + i.Mellomnavn; }
        //            item.Fulltnavn += " " + i.Etternavn;
        //        }
        //        item.Adresse = i.Adresse;
        //        item.PostNr = i.PostNr;
        //        item.Sted = i.Sted;
        //        item.Type = i.Type;
        //        item.SivilStatus = i.SivilStatus;
        //        item.ErDod = i.ErDod;
        //        item.Fra = i.Fra;
        //        item.MT = i.MT;
        //        item.parentFornavn = i.parentFornavn;
        //        item.parentMellomnavn = i.parentMellomnavn;
        //        item.parentEtternavn = i.parentEtternavn;
        //        item.PostnrId = i.PostnrId;
        //        item.KommuneNr = i.KommuneNr;
        //        if (i.StatusDato.Ticks > 0) { item.StatusDato = i.StatusDato; }
        //        item.Farge = "";
        //        item.BackgroundColor = "";
        //        if (i.Type == "F" || i.Type == "M")
        //        {
        //            item.BackgroundColor = "LightSalmon";
        //        }
        //        else if (i.Type == "B")
        //        {
        //            item.BackgroundColor = "LightCyan";
        //        }
        //        items.Add(item);
        //    }

        //    return items;
        //}


        //public async Task<List<Models.MedlemskapItem>> KontrollerMedlemskap(SrcLogonInfo LogonInfo, string personNrListe)
        //{

        //    getKIPFinnMedlemskapResponse resp = new getKIPFinnMedlemskapResponse();
        //    resp = await KipWSClient.getKIPFinnMedlemskapAsync(LogonInfo, personNrListe);

        //    List<Models.MedlemskapItem> items = new List<Models.MedlemskapItem>();
        //    SrcKontrollerMedlemsskap[] itemws;

        //    itemws = resp.Body.getKIPFinnMedlemskapResult;

        //    foreach (var i in itemws)
        //    {
        //        Models.MedlemskapItem item = new Models.MedlemskapItem();

        //        item.personNr = i.PersonNr;
        //        item.medlem = i.Medlem;

        //        items.Add(item);
        //    }

        //    return items;
        //}

        #endregion

        #region Kontakt register

        //public async Task<Models.FunksjonerKontaktItem> GetFunksjonerKontakt(SrcLogonInfo LogonInfo, string KontaktGuid)
        //{
        //    getKIPFunksjonerKontaktWSResponse resp = new getKIPFunksjonerKontaktWSResponse();
        //    resp = await KipWSClient.getKIPFunksjonerKontaktWSAsync(LogonInfo, KontaktGuid); 

        //    Models.FunksjonerKontaktItem item = new Models.FunksjonerKontaktItem();
        //    SrcFunksjonerKontakt i = new SrcFunksjonerKontakt();
        //    i = resp.Body.getKIPFunksjonerKontaktWSResult;

        //    item.ResultatId = i.ResultatId;
        //    item.KontaktGuid = i.KontaktGuid;
        //    item.Fellesraad = i.Fellesraad;
        //    item.SoknId = i.SoknId;
        //    item.Fra = i.Fra;
        //    item.Type = i.Type;
        //    item.TypeKunde = i.TypeKunde;
        //    item.ErDod = i.ErDod;
        //    item.Id = i.Id;
        //    item.PersonNr = i.PersonNr;
        //    item.Fornavn = i.Fornavn;
        //    item.Mellomnavn = i.Mellomnavn;
        //    item.Etternavn = i.Etternavn;
        //    item.FulltNavn = i.FulltNavn;
        //    item.Adresse = i.Adresse;
        //    item.PostNr = i.PostNr;
        //    item.Sted = i.Sted;
        //    item.Status = i.Status;
        //    item.StatusDato = i.StatusDato;
        //    item.Fodt = i.Fodt;
        //    item.Tlf = i.Tlf;
        //    item.Mob = i.Mob;
        //    item.EPost = i.EPost;
        //    item.SivilStatus = i.SivilStatus;
        //    item.Tittel = i.Tittel;
        //    item.BostedAdresse = i.BostedAdresse;
        //    item.BostedPostNr = i.BostedPostNr;
        //    item.IkkeSjekk = i.IkkeSjekk;
        //    item.Land = i.Land;
        //    item.SlektsnavnUgift = i.SlektsnavnUgift;
        //    item.DapsDato = i.DapsDato;
        //    item.DaapSted = i.DaapSted;
        //    item.FodeSted = i.FodeSted;
        //    item.SoknNr = i.SoknNr;
        //    return item;

        //}

        //public async Task<bool> SetFunksjonerKontakt(SrcLogonInfo LogonInfo, Models.FunksjonerKontaktItem item)
        //{

        //    SrcFunksjonerKontakt items = new SrcFunksjonerKontakt();
        //    items = ToWsFromFunksjonerKontaktItem(item);

        //    setKIPFunksjonerKontaktWSResponse resp = new setKIPFunksjonerKontaktWSResponse();
        //    resp = await KipWSClient.setKIPFunksjonerKontaktWSAsync(LogonInfo, items);

        //    return true;

        //}

        //private SrcFunksjonerKontakt ToWsFromFunksjonerKontaktItem(Models.FunksjonerKontaktItem item)
        //{
        //    SrcFunksjonerKontakt i = new SrcFunksjonerKontakt();

        //    i.ResultatId = item.ResultatId;
        //    i.KontaktGuid = item.KontaktGuid;
        //    i.Fellesraad = item.Fellesraad;
        //    i.Fra = item.Fra;
        //    i.Type = item.Type;
        //    i.TypeKunde = item.TypeKunde;
        //    i.ErDod = item.ErDod;
        //    i.Id = item.Id;
        //    i.PersonNr = item.PersonNr;
        //    i.Fornavn = item.Fornavn;
        //    i.Mellomnavn = item.Mellomnavn;
        //    i.Etternavn = item.Etternavn;
        //    i.FulltNavn = item.FulltNavn;
        //    i.Adresse = item.Adresse;
        //    i.PostNr = item.PostNr;
        //    i.Sted = item.Sted;
        //    i.Status = item.Status;
        //    i.StatusDato = item.StatusDato;
        //    i.Fodt = item.Fodt;
        //    i.Tlf = item.Tlf;
        //    i.Mob = item.Mob;
        //    i.EPost = item.EPost;
        //    i.SivilStatus = item.SivilStatus;
        //    i.Tittel = item.Tittel;
        //    i.BostedAdresse = item.BostedAdresse;
        //    i.BostedPostNr = item.BostedPostNr;
        //    i.IkkeSjekk = item.IkkeSjekk;
        //    i.Land = item.Land;
        //    i.SlektsnavnUgift = item.SlektsnavnUgift;
        //    i.DapsDato = item.DapsDato;
        //    i.DaapSted = item.DaapSted;
        //    i.FodeSted = item.FodeSted;
        //    i.SoknNr = item.SoknNr;

        //    return i;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> KopiKontaktFraResultat(SrcLogonInfo LogonInfo, string kontaktGuid)
        //{

        //    createKIPKontaktFromResultWSResponse resp = new createKIPKontaktFromResultWSResponse();
        //    resp = await KipWSClient.createKIPKontaktFromResultWSAsync(LogonInfo, kontaktGuid);
        //    kip.kirkedata.webservices.SrcReturnValue retur = resp.Body.createKIPKontaktFromResultWSResult;

        //    return retur;
        //}


        //public async Task<List<Models.FunksjonerKontaktItem>> GetFunksjonerKontaktListe(SrcLogonInfo logonInfo, string filterTekst)
        //{
        //    getKIPFunksjonerKontaktListeResponse resp = new getKIPFunksjonerKontaktListeResponse();
        //    resp = await KipWSClient.getKIPFunksjonerKontaktListeAsync(logonInfo, filterTekst);

        //    List<Models.FunksjonerKontaktItem> items = new List<Models.FunksjonerKontaktItem>();
        //    SrcFunksjonerKontakt[] itemsWS;

        //    itemsWS = resp.Body.getKIPFunksjonerKontaktListeResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FunksjonerKontaktItem item = new Models.FunksjonerKontaktItem();
        //        item.ResultatId = i.ResultatId;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.Fra = i.Fra;
        //        item.Type = i.Type;
        //        item.SoknId = i.SoknId;
        //        item.TypeKunde = i.TypeKunde;
        //        item.ErDod = i.ErDod;
        //        item.Id = i.Id;
        //        item.PersonNr = i.PersonNr;
        //        item.Fornavn = i.Fornavn;
        //        item.Mellomnavn = i.Mellomnavn;
        //        item.Etternavn = i.Etternavn;
        //        item.FulltNavn = i.FulltNavn;
        //        item.Adresse = i.Adresse;
        //        item.PostNr = i.PostNr;
        //        item.Sted = i.Sted;
        //        item.Status = i.Status;
        //        item.StatusDato = i.StatusDato;
        //        item.Fodt = i.Fodt;
        //        item.Tlf = i.Tlf;
        //        item.Mob = i.Mob;
        //        item.EPost = i.EPost;
        //        item.SivilStatus = i.SivilStatus;
        //        item.Tittel = i.Tittel;
        //        item.BostedAdresse = i.BostedAdresse;
        //        item.BostedPostNr = i.BostedPostNr;
        //        item.IkkeSjekk = i.IkkeSjekk;
        //        item.Land = i.Land;
        //        item.SlektsnavnUgift = i.SlektsnavnUgift;
        //        item.DapsDato = i.DapsDato;
        //        item.DaapSted = i.DaapSted;
        //        item.FodeSted = i.FodeSted;
        //        item.SoknNr = i.SoknNr;
        //        items.Add(item);
        //    }
        //    return items;
        //}



        #endregion

        //#region SMS

        //public async Task<List<Models.SMSflettekoderItem>> GetSMSflettekoderListe(SrcLogonInfo logonInfo, int Modul)
        //{
        //    getKIPSMSflettekoderListeWSResponse resp = new getKIPSMSflettekoderListeWSResponse();
        //    resp = await KipWSClient.getKIPSMSflettekoderListeWSAsync(logonInfo, Modul);

        //    List<Models.SMSflettekoderItem> items = new List<Models.SMSflettekoderItem>();
        //    SrcSMSflettekoder[] itemsWS;

        //    itemsWS = resp.Body.getKIPSMSflettekoderListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.SMSflettekoderItem item = new Models.SMSflettekoderItem();
        //        item.Modul = i.Modul;
        //        item.Kode = i.Kode;
        //        item.Sortering = i.Sortering;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.SmsItem>> GetSmsMalerListe(SrcLogonInfo logonInfo, int progModuler, string smsMalInfo)
        //{
        //    getKIPSMSMalerListeWSResponse resp = new getKIPSMSMalerListeWSResponse();
        //    resp = await KipWSClient.getKIPSMSMalerListeWSAsync(logonInfo, progModuler);

        //    List<Models.SmsItem> items = new List<Models.SmsItem>();
        //    SrcSMS[] itemsWS;

        //    if (smsMalInfo == null) { smsMalInfo = ""; }
        //    string[] arrMalInfo = smsMalInfo.Split(";");

        //    itemsWS = resp.Body.getKIPSMSMalerListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.SmsItem item = new Models.SmsItem();
        //        item.MalGuid = i.MalGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.SoknNr = i.SoknNr;
        //        item.MalType = i.MalType;
        //        item.Modul = i.Modul;
        //        item.Tittel = i.Tittel;
        //        item.Melding = i.Melding;
        //        item.EpostMelding = i.EpostMelding;
        //        item.Privat = i.Privat;
        //        item.BrukerId = i.BrukerId;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;

        //        if (smsMalInfo.Length > 0 ) { 
        //            foreach(string inf in arrMalInfo)
        //            {
        //                string[] info = inf.Split("|");
        //                item.Melding = item.Melding.Replace(info[0], info[1]);
        //            }
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}



        //public async Task<Models.SmsItem> GetSMSMal(SrcLogonInfo logonInfo, string MalGuid)
        //{
        //    getKIPSMSMalWSResponse resp = new getKIPSMSMalWSResponse();
        //    resp = await KipWSClient.getKIPSMSMalWSAsync(logonInfo, MalGuid);

        //    Models.SmsItem item = new Models.SmsItem();
        //    SrcSMS i = resp.Body.getKIPSMSMalWSResult;


        //    item.MalGuid = i.MalGuid;
        //    item.Fellesraad = i.Fellesraad;
        //    item.SoknNr = i.SoknNr;
        //    item.MalType = i.MalType;
        //    item.Modul = i.Modul;
        //    item.Tittel = i.Tittel;
        //    item.Melding = i.Melding;
        //    item.EpostMelding = i.EpostMelding;
        //    item.Privat = i.Privat;
        //    item.BrukerId = i.BrukerId;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    return item;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetSMSMal(SrcLogonInfo logonInfo, Models.SmsItem item)
        //{
        //    SrcSMS items = new SrcSMS();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.MalGuid = item.MalGuid;
        //    items.Fellesraad = item.Fellesraad;
        //    items.SoknNr = item.SoknNr;
        //    items.MalType = item.MalType;
        //    items.Modul = item.Modul;
        //    items.Tittel = item.Tittel;
        //    items.Melding = item.Melding;
        //    items.EpostMelding = item.EpostMelding;
        //    items.Privat = item.Privat;
        //    items.BrukerId = item.BrukerId;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;

        //    setSMSMalWSResponse resp = new setSMSMalWSResponse();
        //    resp = await KipWSClient.setSMSMalWSAsync(logonInfo, items);
        //    retur = resp.Body.setSMSMalWSResult;

        //    return retur;

        //}


        //public async Task<List<Models.SMSMottakereItem>> GetSMSMottakereListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPSMSMottakereListeWSResponse resp = new getKIPSMSMottakereListeWSResponse();
        //    resp = await KipWSClient.getKIPSMSMottakereListeWSAsync(logonInfo);

        //    List<Models.SMSMottakereItem> items = new List<Models.SMSMottakereItem>();
        //    SrcSMSMottakere[] itemsWS;

        //    itemsWS = resp.Body.getKIPSMSMottakereListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.SMSMottakereItem item = new Models.SMSMottakereItem();
        //        item.Key = i.Key;
        //        item.Epost = i.Epost;
        //        item.Foresatte = i.Foresatte;
        //        item.MobilNr = i.MobilNr;
        //        item.Navn = i.Navn;
        //        item.TillatEpost = i.TillatEpost;
        //        if (i.Epost.Length == 0 || i.TillatEpost == false)
        //        {
        //            item.EpostIkon = "mail-cancel";
        //        }
        //        else
        //        {
        //            item.EpostIkon = "mail";
        //        }
        //        item.TillatMobilNr = i.TillatMobilNr;
        //        if (i.HarApp)
        //        {
        //            item.AppIkon = "phone-application-ok";
        //        }
        //        else
        //        {
        //            item.AppIkon = "";
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetSMSMottakereListe(SrcLogonInfo logonInfo, string kontaktListe)
        //{
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    setKIPSMSMottakereListeWSResponse resp = new setKIPSMSMottakereListeWSResponse();

        //    resp = await KipWSClient.setKIPSMSMottakereListeWSAsync(logonInfo, kontaktListe);
        //    retur = resp.Body.setKIPSMSMottakereListeWSResult;
        //    return retur;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SendSMS(SrcLogonInfo logonInfo, Models.SMSmeldingItem SMSmelding)
        //{
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    exeKIPSendSMSWSResponse resp = new exeKIPSendSMSWSResponse();

        //    SrcSMSmelding sms = new SrcSMSmelding();
        //    List<SrcSMSMottakere> mottakere = new List<SrcSMSMottakere>();

        //    foreach(var i in SMSmelding.ListeMottakere)
        //    {
        //        SrcSMSMottakere smsMottakere = new SrcSMSMottakere();
        //        smsMottakere.Key = i.Key;
        //        smsMottakere.Navn = i.Navn;
        //        smsMottakere.MobilNr = i.MobilNr.Replace(" ","");
        //        smsMottakere.Epost = i.Epost;
        //        smsMottakere.Foresatte = i.Foresatte;
        //        smsMottakere.TillatEpost = i.TillatEpost;
        //        smsMottakere.TillatMobilNr = i.TillatMobilNr;
        //        smsMottakere.HarApp = i.HarApp;
        //        mottakere.Add(smsMottakere);
        //    }

        //    sms.BrukerGuid = SMSmelding.BrukerGuid;
        //    sms.BrukerNavn = SMSmelding.BrukerNavn;
        //    sms.EksternGuid = SMSmelding.EksternGuid;
        //    sms.Foreldre = SMSmelding.Foreldre;
        //    sms.ForeldreSendType = SMSmelding.ForeldreSendType;
        //    sms.InternTelefon = SMSmelding.InternTelefon;
        //    sms.Konfirmant = SMSmelding.Konfirmant;
        //    sms.KonfSendType = SMSmelding.KonfSendType;
        //    sms.Message = SMSmelding.Message;
        //    sms.ePostEmne = SMSmelding.EpostEmne;
        //    sms.ePostMessage = SMSmelding.EpostMessage;
        //    sms.Passord = SMSmelding.Passord;
        //    sms.SendDato = SMSmelding.SendDato;
        //    sms.SendType = SMSmelding.SendType;
        //    sms.SoknNavn = SMSmelding.SoknNavn;
        //    sms.SoknNr = SMSmelding.SoknNr;
        //    sms.Tidspunkt = SMSmelding.Tidspunkt;
        //    sms.Mottakere = mottakere.ToArray();

        //    resp = await KipWSClient.exeKIPSendSMSWSAsync(logonInfo, sms);
        //    retur = resp.Body.exeKIPSendSMSWSResult;
        //    return retur;
        //}

        //public async Task<List<Models.SMSbrukereItem>> GetSMSBrukereListe(SrcLogonInfo logonInfo, string aktiveSokn)
        //{
        //    getKIPSMSbrukereWSResponse resp = new getKIPSMSbrukereWSResponse();
        //    resp = await KipWSClient.getKIPSMSbrukereWSAsync(logonInfo, aktiveSokn);

        //    List<Models.SMSbrukereItem> items = new List<Models.SMSbrukereItem>();
        //    SrcSMSbrukere[] itemsWS;

        //    itemsWS = resp.Body.getKIPSMSbrukereWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.SMSbrukereItem item = new Models.SMSbrukereItem();
        //        item.BrukerGuid = i.BrukerGuid;
        //        item.BrukerNavn= i.BrukerNavn;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.SmsItem>> GetSmsMalerListeNy(SrcLogonInfo logonInfo, int progModuler)
        //{
        //    getKIPSMSMalerListeWSResponse resp = new getKIPSMSMalerListeWSResponse();
        //    resp = await KipWSClient.getKIPSMSMalerListeWSAsync(logonInfo, progModuler);

        //    List<Models.SmsItem> items = new List<Models.SmsItem>();
        //    SrcSMS[] itemsWS;

        //    itemsWS = resp.Body.getKIPSMSMalerListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.SmsItem item = new Models.SmsItem();
        //        item.MalGuid = i.MalGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.SoknNr = i.SoknNr;
        //        item.MalType = i.MalType;
        //        item.Modul = i.Modul;
        //        item.Tittel = i.Tittel;
        //        item.Melding = i.Melding;
        //        item.EpostMelding = i.EpostMelding;
        //        item.Privat = i.Privat;
        //        item.BrukerId = i.BrukerId;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        items.Add(item);
        //    }
        //    return items;
        //}
        //#endregion

        #region Henter rapport maler

        //public async Task<List<Models.RapporterItem>> GetRapport(SrcLogonInfo LogonInfo, string rapType, string skjerm, string kategori)
        //{
        //    getKIPRapportListeWSResponse resp = new getKIPRapportListeWSResponse();
        //    resp = await KipWSClient.getKIPRapportListeWSAsync(LogonInfo, rapType, skjerm, kategori, "0,1,2,3", "");

        //    List<Models.RapporterItem> items = new List<Models.RapporterItem>();
        //    items = FromWsToRapportItem(resp.Body.getKIPRapportListeWSResult);

        //    return items;

        //}


        //private List<Models.RapporterItem> FromWsToRapportItem(kip.kirkedata.webservices.SrcRapportListe[] itemws)
        //{
        //    List<Models.RapporterItem> items = new List<Models.RapporterItem>();
        //    foreach (var i in itemws)
        //    {
        //        Models.RapporterItem item = new Models.RapporterItem();

        //        item.FilNavn = i.FilNavn;
        //        item.RapId = i.RapId;
        //        item.Tittel = i.Tittel;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.Skjerm = i.Skjerm;
        //        item.Kategori = i.Kategori;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        #endregion

        #region Postnummer


        //public async Task<Models.PoststedItem> getPostSted(SrcLogonInfo logonInfo, string postNummer)
        //{
        //    getKIPPoststedWSResponse resp = new getKIPPoststedWSResponse();

        //    resp = await KipWSClient.getKIPPoststedWSAsync(logonInfo.Database, postNummer);

        //    SrcPoststed i = resp.Body.getKIPPoststedWSResult;
        //    Models.PoststedItem sted = new Models.PoststedItem();

        //    sted.Sted = i.Sted;
        //    sted.Fylkenavn = i.Fylkenavn;
        //    sted.Land = i.Land;
        //    sted.KommuneNr = i.KommuneNr;
        //    sted.KommuneNavn = i.KommuneNavn;
        //    if (i.KommuneNr != logonInfo.AktivFellesraad)
        //    {
        //        sted.Utenbys = true;
        //    }
        //    sted.InfoBestilling = i.InfoBestilling;

        //    return sted;
        //}

        //public async Task<List<Models.PoststedItem>> GetPoststedListe(SrcLogonInfo logonInfo, string filter)
        //{
        //    getKIPPoststedListeWSResponse resp = new getKIPPoststedListeWSResponse();
        //    resp = await KipWSClient.getKIPPoststedListeWSAsync(logonInfo, filter);

        //    List<Models.PoststedItem> items = new List<Models.PoststedItem>();
        //    SrcPoststed[] itemsWS;

        //    itemsWS = resp.Body.getKIPPoststedListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.PoststedItem item = new Models.PoststedItem();
        //        item.PostNr = i.PostNr;
        //        item.PostNrId = i.PostNrId;
        //        item.Sted = i.Sted;
        //        item.Aktiv = i.Aktiv;
        //        item.ProgramGuid = i.ProgramGuid;
        //        item.KommuneNr = i.KommuneNr;
        //        item.KommuneNavn = i.KommuneNavn;
        //        item.Landskode = i.Landskode;
        //        item.Land = i.Land;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetPoststed(SrcLogonInfo logonInfo, Models.PoststedItem item)
        //{
        //    SrcPoststed items = new SrcPoststed();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new kip.kirkedata.webservices.SrcReturnValue();
        //    items.PostNr = item.PostNr;
        //    items.PostNrId = item.PostNrId;
        //    items.Sted = item.Sted;
        //    items.Aktiv = item.Aktiv;
        //    items.ProgramGuid = item.ProgramGuid;
        //    items.KommuneNr = item.KommuneNr;
        //    items.Landskode = item.Landskode;

        //    setKIPPoststedWSResponse resp = new setKIPPoststedWSResponse();
        //    resp = await KipWSClient.setKIPPoststedWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPPoststedWSResult;

        //    return retur;

        //}


        //public async Task<List<Models.LandItem>> GetLandListe(SrcLogonInfo logonInfo, string filter, string sortering )
        //{
        //    getKIPLandListeWSResponse resp = new getKIPLandListeWSResponse();
        //    resp = await KipWSClient.getKIPLandListeWSAsync(logonInfo, filter, sortering);

        //    List<Models.LandItem> items = new List<Models.LandItem>();
        //    SrcLand[] itemsWS;

        //    itemsWS = resp.Body.getKIPLandListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.LandItem item = new Models.LandItem();
        //        item.Landskode = i.Landskode;
        //        item.Navn = i.Navn;
        //        item.Skjul = i.Skjul;
        //        item.ProgramGuid = i.ProgramGuid;
        //        item.KodeLang = i.KodeLang;
        //        item.Domene = i.Domene;
        //        item.TelefonKode = i.TelefonKode;
        //        item.NavnNorsk = i.NavnNorsk;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        #endregion

        #region Logg

        //public async Task<bool> SetLogg(SrcLogonInfo logonInfo, string program, string beskrivelse)
        //{
        //    bool retur;

        //    LoggWsResponse resp = new LoggWsResponse();
        //    resp = await KipWSClient.LoggWsAsync(program, logonInfo.BrukerId, beskrivelse);
        //    retur = resp.Body.LoggWsResult;

        //    return retur;

        //}


        #endregion

        #region Fido

        //public async Task<Models.FidoItem> GetNesteFido(SrcLogonInfo logonInfo)
        //{
        //    getKIPNesteFidoWSResponse resp = new getKIPNesteFidoWSResponse();
        //    resp = await KipWSClient.getKIPNesteFidoWSAsync(logonInfo);

        //    Models.FidoItem item = new Models.FidoItem();
        //    SrcFido i = resp.Body.getKIPNesteFidoWSResult;

        //    item.FidoGuid = i.FidoGuid;
        //    item.BrukerId = i.BrukerId;
        //    item.Tittel = i.Tittel;
        //    item.Melding = i.Melding;
        //    item.RegDato = i.RegDato;
        //    item.LestDato = i.LestDato;
        //    if (i.FidoBilde != null && i.FidoBilde != "")
        //    {
        //        item.FidoBilde = i.FidoBilde;
        //    }
        //    else
        //    {
        //        item.FidoBilde = "Fido-Leverer";
        //    }
        //    return item;
        //}

        //public async Task<removeKIPFidoWSResponse> removeFidoItemWs(SrcLogonInfo logonInfo, string FidoGuid)
        //{
        //    return await KipWSClient.removeKIPFidoWSAsync(logonInfo, FidoGuid);
        //}

        #endregion

        #region Task

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetTask(SrcLogonInfo logonInfo, Models.TaskItem item)
        //{
        //    SrcTask items = new SrcTask();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.TaskGuid = item.TaskGuid;
        //    items.Fellesraad = item.Fellesraad;
        //    items.BrukerId = item.BrukerId;
        //    items.Dato = item.Dato;
        //    items.Modul = item.Modul;
        //    items.Task = item.Task;
        //    items.Verider = item.Verdier;
        //    items.StartTidspunkt = item.StartTidspunkt;
        //    items.FerdigTidspunkt = item.FerdigTidspunkt;

        //    setKIPTaskWSResponse resp = new setKIPTaskWSResponse();
        //    resp = await KipWSClient.setKIPTaskWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPTaskWSResult;

        //    return retur;

        //}

        //public async Task<Models.TaskItem> GetTask(SrcLogonInfo logonInfo, string TaskGuid)
        //{
        //    getKIPTaskWSResponse resp = new getKIPTaskWSResponse();
        //    resp = await KipWSClient.getKIPTaskWSAsync(logonInfo, TaskGuid);

        //    Models.TaskItem item = new Models.TaskItem();
        //    SrcTask i = new SrcTask();


        //    item.TaskGuid = i.TaskGuid;
        //    item.Fellesraad = i.Fellesraad;
        //    item.BrukerId = i.BrukerId;
        //    item.Dato = i.Dato;
        //    item.Modul = i.Modul;
        //    item.Task = i.Task;
        //    item.StartTidspunkt = i.StartTidspunkt;
        //    item.FerdigTidspunkt = i.FerdigTidspunkt;
        //    return item;

        //}

        //public async Task<List<Models.TaskItem>> GetTaskListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPTaskListeWSResponse resp = new getKIPTaskListeWSResponse();
        //    resp = await KipWSClient.getKIPTaskListeWSAsync(logonInfo, "", "");

        //    List<Models.TaskItem> items = new List<Models.TaskItem>();
        //    SrcTask[] itemsWS;

        //    itemsWS = resp.Body.getKIPTaskListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.TaskItem item = new Models.TaskItem();
        //        item.TaskGuid = i.TaskGuid;
        //        item.Fellesraad = i.Fellesraad;
        //        item.BrukerId = i.BrukerId;
        //        item.Dato = i.Dato;
        //        item.Modul = i.Modul;
        //        item.Task = i.Task;
        //        item.StartTidspunkt = i.StartTidspunkt;
        //        item.FerdigTidspunkt = i.FerdigTidspunkt;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<exeKIPTaskFolkereigsterResponse> exeTaskKontrolerFolkeregisterWs(SrcLogonInfo logonInfo, string TaskGuid)
        //{
        //    return await KipWSClient.exeKIPTaskFolkereigsterAsync(logonInfo, TaskGuid);
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> exeVaksAdresse(SrcLogonInfo logonInfo, string KontaktGuid)
        //{
        //    kip.kirkedata.webservices.SrcReturnValue retur;
        //    exeKIPVaskAdresseResponse item = new exeKIPVaskAdresseResponse();  
        //    item = await KipWSClient.exeKIPVaskAdresseAsync(logonInfo, KontaktGuid);
        //    retur = item.Body.exeKIPVaskAdresseResult;

        //    return retur;
        //}

        #endregion

        #region Nyheter

        //public async Task<List<Models.NyhetItem>> GetNyhetListe(SrcLogonInfo logonInfo, string Fellesraad)
        //{
        //    getKIPNyhetListeWSResponse resp = new getKIPNyhetListeWSResponse();
        //    resp = await KipWSClient.getKIPNyhetListeWSAsync(logonInfo, Fellesraad);

        //    List<Models.NyhetItem> items = new List<Models.NyhetItem>();
        //    SrcNyhet[] itemsWS;

        //    itemsWS = resp.Body.getKIPNyhetListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.NyhetItem item = new Models.NyhetItem();
        //        item.KategoriId = i.KategoriId;
        //        item.Leverandor_GUID = i.Leverandor_GUID;
        //        item.Nyhet_GUID = i.Nyhet_GUID;
        //        item.Dato = i.Dato;
        //        item.Fellesraad = i.Fellesraad;
        //        item.Program = i.Program;
        //        item.Forfatter = i.Forfatter;
        //        item.Leverandor = i.Leverandor;
        //        item.Ingress = i.Ingress;
        //        item.TilDato = i.TilDato;
        //        item.Tittel = i.Tittel;
        //        item.Nyhet = i.Nyhet;
        //        item.YouTubeId = i.YouTubeId;
        //        item.LinkId = i.LinkId;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.NyhetItem> GetNyhet(SrcLogonInfo logonInfo, string Nyhet_GUID)
        //{
        //    getKIPNyhetWSResponse resp = new getKIPNyhetWSResponse();
        //    resp = await KipWSClient.getKIPNyhetWSAsync(logonInfo, Nyhet_GUID);

        //    Models.NyhetItem item = new Models.NyhetItem();
        //    SrcNyhet i = resp.Body.getKIPNyhetWSResult;


        //    item.KategoriId = i.KategoriId;
        //    item.Leverandor_GUID = i.Leverandor_GUID;
        //    item.Nyhet_GUID = i.Nyhet_GUID;
        //    item.Dato = i.Dato;
        //    item.Fellesraad = i.Fellesraad;
        //    item.Program = i.Program;
        //    item.Forfatter = i.Forfatter;
        //    item.Leverandor = i.Leverandor;
        //    item.Ingress = i.Ingress;
        //    item.TilDato = i.TilDato;
        //    item.Tittel = i.Tittel;
        //    item.Nyhet = i.Nyhet;
        //    item.YouTubeId = i.YouTubeId;
        //    item.LinkId = i.LinkId;
        //    item.Byte64Picture = i.Byte64Picture;
        //    item.Publiser = i.Publiser;
        //    return item;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetNyhet(SrcLogonInfo logonInfo, Models.NyhetItem item)
        //{
        //    SrcNyhet items = new SrcNyhet();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.KategoriId = item.KategoriId;
        //    items.Leverandor_GUID = item.Leverandor_GUID;
        //    items.Nyhet_GUID = item.Nyhet_GUID;
        //    items.Dato = item.Dato;
        //    items.Fellesraad = item.Fellesraad;
        //    items.Program = item.Program;
        //    items.Forfatter = item.Forfatter;
        //    items.Leverandor = item.Leverandor;
        //    items.Ingress = item.Ingress;
        //    items.TilDato = item.TilDato;
        //    items.Tittel = item.Tittel;
        //    items.Nyhet = item.Nyhet;
        //    items.YouTubeId = item.YouTubeId;
        //    items.LinkId = item.LinkId;
        //    items.Publiser = item.Publiser;

        //    setKIPNyhetWSResponse resp = new setKIPNyhetWSResponse();
        //    resp = await KipWSClient.setKIPNyhetWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPNyhetWSResult;

        //    return retur;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> removeNyhetItemWs(SrcLogonInfo logonInfo, string nyhetGuid)
        //{
        //    removeKIPNyhetWSResponse resp = new removeKIPNyhetWSResponse();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    resp = await KipWSClient.removeKIPNyhetWSAsync(logonInfo, nyhetGuid);
        //    retur.Result = resp.Body.removeKIPNyhetWSResult;
        //    return retur;
        //}

        //public async Task<List<Models.NyhetItem>> GetNyhetListeByra(SrcLogonInfo logonInfo)
        //{
        //    getKIPNyhetByraListeWSResponse resp = new getKIPNyhetByraListeWSResponse();
        //    resp = await KipWSClient.getKIPNyhetByraListeWSAsync(logonInfo, 199);

        //    List<Models.NyhetItem> items = new List<Models.NyhetItem>();
        //    SrcNyhet[] itemsWS;

        //    itemsWS = resp.Body.getKIPNyhetByraListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.NyhetItem item = new Models.NyhetItem();
        //        item.KategoriId = i.KategoriId;
        //        item.Leverandor_GUID = i.Leverandor_GUID;
        //        item.Nyhet_GUID = i.Nyhet_GUID;
        //        item.Dato = i.Dato;
        //        item.Fellesraad = i.Fellesraad;
        //        item.FellesraadNavn = i.FellesraadNavn;
        //        item.Program = i.Program;
        //        item.Forfatter = i.Forfatter;
        //        item.Leverandor = i.Leverandor;
        //        item.Ingress = i.Ingress;
        //        item.TilDato = i.TilDato;
        //        item.Tittel = i.Tittel;
        //        item.Nyhet = i.Nyhet;
        //        item.YouTubeId = i.YouTubeId;
        //        item.LinkId = i.LinkId;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.NyheterModulerItem>> GetNyheterModulerListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPNyheterModulerListeWSResponse resp = new getKIPNyheterModulerListeWSResponse();
        //    resp = await KipWSClient.getKIPNyheterModulerListeWSAsync(logonInfo);

        //    List<Models.NyheterModulerItem> items = new List<Models.NyheterModulerItem>();
        //    SrcNyheterModuler[] itemsWS;

        //    itemsWS = resp.Body.getKIPNyheterModulerListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.NyheterModulerItem item = new Models.NyheterModulerItem();
        //        item.ModulId = i.ModulId;
        //        item.Navn = i.Navn;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetNyhetBilde(SrcLogonInfo logonInfo, Models.NyhetItem item)
        //{
        //    SrcNyhet items = new SrcNyhet();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.Nyhet_GUID = item.Nyhet_GUID;
        //    items.Byte64Picture = item.Byte64Picture;

        //    setKIPNyhetBildeWSResponse resp = new setKIPNyhetBildeWSResponse();
        //    resp = await KipWSClient.setKIPNyhetBildeWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPNyhetBildeWSResult;

        //    return retur;

        //}

        #endregion

        #region InfoLogg

        //public async Task<List<Models.TimelineEventModel>> GetInfoLoggListe(SrcLogonInfo logonInfo, string RegistreringGuid)
        //{
        //    getKIPInfoLoggListeWSResponse resp = new getKIPInfoLoggListeWSResponse();
        //    resp = await KipWSClient.getKIPInfoLoggListeWSAsync(logonInfo, RegistreringGuid);

        //    List<Models.TimelineEventModel> items = new List<Models.TimelineEventModel>();
        //    SrcInfoLogg[] itemsWS;

        //    itemsWS = resp.Body.getKIPInfoLoggListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.TimelineEventModel item = new Models.TimelineEventModel();
        //        item.Title = i.Tittel;
        //        item.Subtitle = i.SubTittel;
        //        item.EventDate = i.Dato;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        #endregion

        #region Frie felt

        //public async Task<List<Models.FrieFeltItem>> GetFrieFeltListe(SrcLogonInfo logonInfo, string filter, string sortering, bool hentVerdier)
        //{
        //    getKIPFrieFeltListeWSResponse resp = new getKIPFrieFeltListeWSResponse();
        //    resp = await KipWSClient.getKIPFrieFeltListeWSAsync(logonInfo, filter, sortering, hentVerdier);

        //    List<Models.FrieFeltItem> items = new List<Models.FrieFeltItem>();
        //    SrcFrieFelt[] itemsWS;

        //    itemsWS = resp.Body.getKIPFrieFeltListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FrieFeltItem item = new Models.FrieFeltItem();
        //        item.FrieFeltGuid = i.FrieFeltGuid;
        //        item.Kull = i.Kull;
        //        item.TypeFelt = i.TypeFelt;
        //        item.Tekst = i.Tekst;
        //        item.Tittel = i.Tittel;
        //        item.FeltNavn = i.FeltNavn;
        //        item.FeltNr = i.FeltNr;
        //        item.WebFelt = i.WebFelt;
        //        item.Sortering = i.Sortering;
        //        item.WebId = i.WebId;
        //        item.FeltLengde = i.FeltLengde;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.Modul_ID = i.Modul_ID;
        //        item.TypeAktivitet = i.TypeAktivitet;
        //        item.GruppeTittel = i.GruppeTittel;
        //        item.Paakrevd = i.Paakrevd;
        //        item.PosX = i.PosX;
        //        item.PosY = i.PosY;
        //        item.Vidde = i.Vidde;
        //        item.Hoyde = i.Hoyde;
        //        item.Fond = i.Fond;
        //        item.Uthevert = i.Uthevert;
        //        item.Storresle = i.Storresle;
        //        item.Farge = i.Farge;
        //        item.StandardVerdi = i.StandardVerdi;
        //        item.Datasett = i.Datasett;
        //        item.Fellesraad = i.Fellesraad;
        //        item.SoknNr = i.SoknNr;
        //        item.SoknId = i.SoknId;

        //        if (i.Verdier != null)
        //        {
        //            List<Models.FrieFeltVerdiItem> itemVerdier = new List<Models.FrieFeltVerdiItem>();

        //            foreach (var j in i.Verdier)
        //            {
        //                Models.FrieFeltVerdiItem itemV = new Models.FrieFeltVerdiItem();
        //                itemV.Verdi = j.Verdi;
        //                itemVerdier.Add(itemV);
        //            }
        //            item.Verdier = itemVerdier;
        //        }

        //        items.Add(item);
        //    }
        //    return items;
        //}
        //public async Task<List<Models.FrieFeltItem>> GetAktiveFrieFeltListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPAktiveFrieFeltListeWSResponse resp = new getKIPAktiveFrieFeltListeWSResponse();
        //    resp = await KipWSClient.getKIPAktiveFrieFeltListeWSAsync(logonInfo);

        //    List<Models.FrieFeltItem> items = new List<Models.FrieFeltItem>();
        //    SrcFrieFelt[] itemsWS;

        //    itemsWS = resp.Body.getKIPAktiveFrieFeltListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FrieFeltItem item = new Models.FrieFeltItem();
        //        item.FrieFeltGuid = i.FrieFeltGuid;
        //        item.Kull = i.Kull;
        //        item.Tekst = i.Tekst;
        //        item.Tittel = i.Tittel;
        //        item.FeltNavn = i.FeltNavn;
        //        item.Fellesraad = i.Fellesraad;
        //        item.SoknNr = i.SoknNr;
        //        item.SoknId = i.SoknId;

        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.FrieFeltItem>> GetFrieFeltHistorikkListe(SrcLogonInfo logonInfo, string filter, string sortering, bool hentVerdier)
        //{
        //    getKIPFrieFeltHistorikkWSResponse resp = new getKIPFrieFeltHistorikkWSResponse();
        //    resp = await KipWSClient.getKIPFrieFeltHistorikkWSAsync(logonInfo, filter, sortering, hentVerdier);

        //    List<Models.FrieFeltItem> items = new List<Models.FrieFeltItem>();
        //    SrcFrieFelt[] itemsWS;

        //    itemsWS = resp.Body.getKIPFrieFeltHistorikkWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FrieFeltItem item = new Models.FrieFeltItem();
        //        item.FrieFeltGuid = i.FrieFeltGuid;
        //        item.TypeFelt = i.TypeFelt;
        //        item.Tekst = i.Tekst;
        //        item.Tittel = i.Tittel;
        //        item.GruppeTittel = i.GruppeTittel;

        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.FrieFeltItem> GetFrieFelt(SrcLogonInfo logonInfo, string FrieFeltGuid)
        //{
        //    getKIPFrieFeltWSResponse resp = new getKIPFrieFeltWSResponse();
        //    resp = await KipWSClient.getKIPFrieFeltWSAsync(logonInfo, FrieFeltGuid);

        //    Models.FrieFeltItem item = new Models.FrieFeltItem();
        //    SrcFrieFelt i = resp.Body.getKIPFrieFeltWSResult;

        //    item.FrieFeltGuid = i.FrieFeltGuid;
        //    item.Kull = i.Kull;
        //    item.TypeFelt = i.TypeFelt;
        //    item.Tekst = i.Tekst;
        //    item.Tittel = i.Tittel;
        //    item.FeltNavn = i.FeltNavn;
        //    item.FeltNr = i.FeltNr;
        //    item.WebFelt = i.WebFelt;
        //    item.Sortering = i.Sortering;
        //    item.WebId = i.WebId;
        //    item.FeltLengde = i.FeltLengde;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.Modul_ID = i.Modul_ID;
        //    item.TypeAktivitet = i.TypeAktivitet;
        //    item.GruppeTittel = i.GruppeTittel;
        //    item.Paakrevd = i.Paakrevd;
        //    item.PosX = i.PosX;
        //    item.PosY = i.PosY;
        //    item.Vidde = i.Vidde;
        //    item.Hoyde = i.Hoyde;
        //    item.Fond = i.Fond;
        //    item.Uthevert = i.Uthevert;
        //    item.Storresle = i.Storresle;
        //    item.Farge = i.Farge;
        //    item.StandardVerdi = i.StandardVerdi;
        //    item.Datasett = i.Datasett;
        //    item.Fellesraad = i.Fellesraad;
        //    item.SoknNr = i.SoknNr;
        //    item.SoknId = i.SoknId;
        //    return item;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetFrieFelt(SrcLogonInfo logonInfo, Models.FrieFeltItem item)
        //{
        //    SrcFrieFelt items = new SrcFrieFelt();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.FrieFeltGuid = item.FrieFeltGuid;
        //    items.Kull = item.Kull;
        //    items.TypeFelt = item.TypeFelt;
        //    items.Tekst = item.Tekst;
        //    items.Tittel = item.Tittel;
        //    items.FeltNavn = item.FeltNavn;
        //    items.FeltNr = item.FeltNr;
        //    items.WebFelt = item.WebFelt;
        //    items.Sortering = item.Sortering;
        //    items.WebId = item.WebId;
        //    items.FeltLengde = item.FeltLengde;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.Modul_ID = item.Modul_ID;
        //    items.TypeAktivitet = item.TypeAktivitet;
        //    items.GruppeTittel = item.GruppeTittel;
        //    items.Paakrevd = item.Paakrevd;
        //    items.PosX = item.PosX;
        //    items.PosY = item.PosY;
        //    items.Vidde = item.Vidde;
        //    items.Hoyde = item.Hoyde;
        //    items.Fond = item.Fond;
        //    items.Uthevert = item.Uthevert;
        //    items.Storresle = item.Storresle;
        //    items.Farge = item.Farge;
        //    items.StandardVerdi = item.StandardVerdi;
        //    items.Datasett = item.Datasett;
        //    items.Fellesraad = item.Fellesraad;
        //    items.SoknNr = item.SoknNr;
        //    items.SoknId = item.SoknId;

        //    setKIPFrieFeltWSResponse resp = new setKIPFrieFeltWSResponse();
        //    resp = await KipWSClient.setKIPFrieFeltWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPFrieFeltWSResult;

        //    return retur;
        //}

        //public async Task<removeKIPFrieFeltWSResponse> removeFrieFeltItemWs(SrcLogonInfo logonInfo, string FrieFeltGuid)
        //{
        //    return await KipWSClient.removeKIPFrieFeltWSAsync(logonInfo, FrieFeltGuid);
        //}

        //public async Task<exeKIPFrieFeltFlyttOppResponse> exeFrieFeltFlyttOpp(SrcLogonInfo logonInfo, string SoknNr, int Sortering, string kull)
        //{
        //    return await KipWSClient.exeKIPFrieFeltFlyttOppAsync(logonInfo, SoknNr, Sortering, kull);
        //}

        //public async Task<exeKIPFrieFeltFlyttNedResponse> exeFrieFeltFlyttNed(SrcLogonInfo logonInfo, string SoknNr, int Sortering, string kull)
        //{
        //    return await KipWSClient.exeKIPFrieFeltFlyttNedAsync(logonInfo, SoknNr, Sortering, kull);
        //}


        //public async Task<List<Models.FrieFeltVerdiItem>> GetFrieFeltVerdiListe(SrcLogonInfo logonInfo, string FrieFeltGuid, string sortering)
        //{
        //    getKIPFrieFeltVerdiListeWSResponse resp = new getKIPFrieFeltVerdiListeWSResponse();
        //    resp = await KipWSClient.getKIPFrieFeltVerdiListeWSAsync(logonInfo, FrieFeltGuid, sortering);

        //    List<Models.FrieFeltVerdiItem> items = new List<Models.FrieFeltVerdiItem>();
        //    SrcFrieFeltVerdi[] itemsWS;

        //    itemsWS = resp.Body.getKIPFrieFeltVerdiListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FrieFeltVerdiItem item = new Models.FrieFeltVerdiItem();
        //        item.FrieFeltVerdiGuid = i.FrieFeltVerdiGuid;
        //        item.FrieFeltGuid = i.FrieFeltGuid;
        //        item.Verdi = i.Verdi;
        //        item.Sortering = i.Sortering;
        //        item.WebId = i.WebId;
        //        item.FargeNavn = i.FargeNavn;
        //        item.MaksAntall = i.MaksAntall;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.FrieFeltVerdiItem> GetFrieFeltVerdi(SrcLogonInfo logonInfo, string FrieFeltVerdiGuid)
        //{
        //    getKIPFrieFeltVerdiWSResponse resp = new getKIPFrieFeltVerdiWSResponse();
        //    resp = await KipWSClient.getKIPFrieFeltVerdiWSAsync(logonInfo, FrieFeltVerdiGuid);

        //    Models.FrieFeltVerdiItem item = new Models.FrieFeltVerdiItem();
        //    SrcFrieFeltVerdi i = resp.Body.getKIPFrieFeltVerdiWSResult;


        //    item.FrieFeltVerdiGuid = i.FrieFeltVerdiGuid;
        //    item.FrieFeltGuid = i.FrieFeltGuid;
        //    item.Verdi = i.Verdi;
        //    item.Sortering = i.Sortering;
        //    item.WebId = i.WebId;
        //    item.FargeNavn = i.FargeNavn;
        //    item.MaksAntall = i.MaksAntall;
        //    return item;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetFrieFeltVerdi(SrcLogonInfo logonInfo, Models.FrieFeltVerdiItem item)
        //{
        //    SrcFrieFeltVerdi items = new SrcFrieFeltVerdi();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.FrieFeltVerdiGuid = item.FrieFeltVerdiGuid;
        //    items.FrieFeltGuid = item.FrieFeltGuid;
        //    items.Verdi = item.Verdi;
        //    items.Sortering = item.Sortering;
        //    items.WebId = item.WebId;
        //    items.FargeNavn = item.FargeNavn;
        //    items.MaksAntall = item.MaksAntall;

        //    setKIPFrieFeltVerdiWSResponse resp = new setKIPFrieFeltVerdiWSResponse();
        //    resp = await KipWSClient.setKIPFrieFeltVerdiWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPFrieFeltVerdiWSResult;

        //    return retur;

        //}

        //public async Task<removeKIPFrieFeltVerdiWSResponse> removeFrieFeltVerdiItemWs(SrcLogonInfo logonInfo, string FrieFeltVerdiGuid)
        //{
        //    return await KipWSClient.removeKIPFrieFeltVerdiWSAsync(logonInfo, FrieFeltVerdiGuid);
        //}

        //public async Task<exeKIPFrieFeltVerdiFlyttOppResponse> exeFrieFeltVerdiFlyttOpp(SrcLogonInfo logonInfo, string FrieFeltGuid, int Sortering)
        //{
        //    return await KipWSClient.exeKIPFrieFeltVerdiFlyttOppAsync(logonInfo, FrieFeltGuid, Sortering);
        //}

        //public async Task<exeKIPFrieFeltVerdiFlyttNedResponse> exeFrieFeltVerdiFlyttNed(SrcLogonInfo logonInfo, string FrieFeltGuid, int Sortering)
        //{
        //    return await KipWSClient.exeKIPFrieFeltVerdiFlyttNedAsync(logonInfo, FrieFeltGuid, Sortering);
        //}


        //public async Task<kip.kirkedata.webservices.SrcReturnValue> exeFrieFeltKopierKull(SrcLogonInfo logonInfo, string SoknNr, string fraKull, string tilKull)
        //{
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    getKIPFrieFeltKopierKullWSResponse resp = new getKIPFrieFeltKopierKullWSResponse();

        //    resp = await KipWSClient.getKIPFrieFeltKopierKullWSAsync(logonInfo, SoknNr, fraKull, tilKull);

        //    retur = resp.Body.getKIPFrieFeltKopierKullWSResult;
        //    return retur;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> exeFrieFeltKopierValgte(SrcLogonInfo logonInfo, string friefeltGuidListe,  string SoknNr,  string tilKull)
        //{
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    getKIPFrieFeltKopierValgteWSResponse resp = new getKIPFrieFeltKopierValgteWSResponse();

        //    resp = await KipWSClient.getKIPFrieFeltKopierValgteWSAsync(logonInfo, friefeltGuidListe, SoknNr, tilKull);

        //    retur = resp.Body.getKIPFrieFeltKopierValgteWSResult;
        //    return retur;
        //}

        #endregion

        #region Oppgaver
        //public async Task<List<Models.OppgaveListeItem>> GetOppgaveListe(SrcLogonInfo logonInfo, string filter, string sortering )
        //{
        //    getKIPOppgaveListeWSResponse resp = new getKIPOppgaveListeWSResponse();
        //    resp = await KipWSClient.getKIPOppgaveListeWSAsync(logonInfo, filter, sortering);

        //    List<Models.OppgaveListeItem> items = new List<Models.OppgaveListeItem>();
        //    SrcOppgaveListe[] itemsWS;

        //    itemsWS = resp.Body.getKIPOppgaveListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.OppgaveListeItem item = new Models.OppgaveListeItem();
        //        item.OppgaveGuid = i.OppgaveGuid;
        //        item.Tekst = i.Tekst;
        //        item.EksternLink = i.EksternLink;

        //        item.Dato = i.Dato;
        //        item.FraTid = i.FraTid;

        //        item.TilTid = i.TilTid;

        //        item.StartDato = i.StartDato;
        //        if (i.UtfortDato.Ticks > 0) { item.UtfortDato = i.UtfortDato; }
        //        item.OppfDato = i.OppfDato;
        //        if (i.ObsDato.Ticks > 0) { item.ObsDato = i.ObsDato; }
        //        if (i.FerdigDato.Ticks > 0) { item.FerdigDato = i.FerdigDato; }

        //        item.Fremdrift = i.Fremdrift;
        //        item.Status = i.Status;
        //        item.Prioritet = i.Prioritet;
        //        item.VisIKalender = i.VisIKalender;

        //        item.EskalerGuid = i.EskalerGuid;
        //        item.UtforesAvGuid = i.UtforesAvGuid;
        //        item.UtfortAv = i.UtfortAv;
        //        item.AnsvarligGuid = i.AnsvarligGuid;
        //        item.KalenderGuid = i.KalenderGuid;
        //        item.EskalerGuid = i.EskalerGuid;
        //        item.OppgaveEierGuid = i.OppgaveEierGuid;
        //        item.FunkKategoriGuid = i.FunkKategoriGuid;
        //        item.KompetanseGuid = i.KompetanseGuid;
        //        item.SynligMobil = i.SynligMobil;
        //        item.FunksjonGuid = i.FunksjonGuid;

        //        item.Privat = i.Privat;
        //        item.Flagg = i.Flagg;

        //        item.Modul = i.Modul;
        //        item.ModulId = i.ModulId;
        //        item.Ansvarlig = i.Ansvarlig;
        //        item.UtforesAv = i.UtforesAv;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.RegDato = i.RegDato;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.OppgaveItem> GetOppgave(SrcLogonInfo logonInfo, string OppgaveGuid)
        //{
        //    getKIPOppgaveWSResponse resp = new getKIPOppgaveWSResponse();
        //    resp = await KipWSClient.getKIPOppgaveWSAsync(logonInfo, OppgaveGuid);

        //    Models.OppgaveItem item = new Models.OppgaveItem();
        //    SrcOppgave i = resp.Body.getKIPOppgaveWSResult;


        //    item.Fellesraad = i.Fellesraad;
        //    item.OppgaveGuid = i.OppgaveGuid;
        //    //item.AktType = i.AktType;
        //    item.Dato = i.Dato;
        //    item.FraTid = i.FraTid;
        //    item.EksternLink = i.EksternLink;
        //    item.OppfDato = i.OppfDato;
        //    item.RegDato = i.RegDato;
        //    item.Tekst = i.Tekst;
        //    item.TilTid = i.TilTid;
        //    item.UtfortDato = i.UtfortDato;
        //    item.BrukerId = i.BrukerId;
        //    item.FormId = i.FormId;
        //    item.Privat = i.Privat;
        //    item.Flagg = i.Flagg;
        //    item.Beskrivelse = i.Beskrivelse;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.AnsvarligGuid = i.AnsvarligGuid;
        //    if (i.ObsDato.Ticks > 0) { item.ObsDato = i.ObsDato; }
        //    item.EskalerGuid = i.EskalerGuid;
        //    item.UtforesAvGuid = i.UtforesAvGuid;
        //    if (i.FerdigDato.Ticks > 0) { item.FerdigDato = i.FerdigDato; }
        //    item.StartDato = i.StartDato;
        //    item.Fremdrift = i.Fremdrift;
        //    item.Status = i.Status;
        //    item.Prioritet = i.Prioritet;
        //    item.VisIKalender = i.VisIKalender;
        //    item.HarBarn = i.HarBarn;
        //    item.KalenderGuid = i.KalenderGuid;
        //    item.OppgaveEierGuid = i.OppgaveEierGuid;
        //    item.FunkKategoriGuid = i.FunkKategoriGuid;
        //    item.KompetanseGuid = i.KompetanseGuid;
        //    item.SynligMobil = i.SynligMobil;
        //    item.Antall = i.Antall;
        //    item.Godtgjorsle = i.Godtgjorsle;
        //    item.SoknNr = i.SoknNr;
        //    item.FunksjonGuid = i.FunksjonGuid;
        //    return item;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetOppgave(SrcLogonInfo logonInfo, Models.OppgaveItem item)
        //{
        //    SrcOppgave items = new SrcOppgave();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.Fellesraad = item.Fellesraad;
        //    items.OppgaveGuid = item.OppgaveGuid;
        //    //items.AktType = item.AktType;
        //    items.Dato = item.Dato;
        //    items.FraTid = item.FraTid;
        //    items.EksternLink = item.EksternLink;
        //    items.OppfDato = item.OppfDato;
        //    items.RegDato = item.RegDato;
        //    items.Tekst = item.Tekst;
        //    items.TilTid = item.TilTid;
        //    if (item.UtfortDato != null) { items.UtfortDato = (System.DateTime)item.UtfortDato; }
        //    items.BrukerId = item.BrukerId;
        //    items.FormId = item.FormId;
        //    items.Privat = item.Privat;
        //    items.Flagg = item.Flagg;
        //    items.Beskrivelse = item.Beskrivelse;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.AnsvarligGuid = item.AnsvarligGuid;
        //    if (item.ObsDato != null) { items.ObsDato = (System.DateTime)item.ObsDato; }
        //    items.EskalerGuid = item.EskalerGuid;
        //    items.UtforesAvGuid = item.UtforesAvGuid;
        //    if (item.FerdigDato != null) { items.FerdigDato = (System.DateTime)item.FerdigDato; }
        //    items.StartDato = item.StartDato;
        //    items.Fremdrift = item.Fremdrift;
        //    items.Status = item.Status;
        //    items.Prioritet = item.Prioritet;
        //    items.VisIKalender = item.VisIKalender;
        //    items.HarBarn = item.HarBarn;
        //    items.KalenderGuid = item.KalenderGuid;
        //    items.OppgaveEierGuid = item.OppgaveEierGuid;
        //    items.FunkKategoriGuid = item.FunkKategoriGuid;
        //    items.KompetanseGuid = item.KompetanseGuid;
        //    items.SynligMobil = item.SynligMobil;
        //    items.Antall = item.Antall;
        //    items.Godtgjorsle = item.Godtgjorsle;
        //    items.SoknNr = item.SoknNr;
        //    items.FunksjonGuid = item.FunksjonGuid;

        //    setKIPOppgaveWSResponse resp = new setKIPOppgaveWSResponse();
        //    resp = await KipWSClient.setKIPOppgaveWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPOppgaveWSResult;

        //    return retur;

        //}

        //public async Task<setKIPOppgaveUtfortWSResponse> setOppgaveFremdrift(SrcLogonInfo logonInfo, string OppgaveGuid, int fremdrift)
        //{
        //    return await KipWSClient.setKIPOppgaveUtfortWSAsync(logonInfo, OppgaveGuid, fremdrift);
        //}

        //public async Task<removeKIPOppgaveWSResponse> removeOppgaveItemWs(SrcLogonInfo logonInfo, string OppgaveGuid)
        //{
        //    return await KipWSClient.removeKIPOppgaveWSAsync(logonInfo, OppgaveGuid);
        //}

        #endregion


        #region Obs

        //public async Task<List<Models.ObsItem>> GetObsListe(SrcLogonInfo logonInfo, string LinkGuid)
        //{
        //    getKIPObsListeWSResponse resp = new getKIPObsListeWSResponse();
        //    resp = await KipWSClient.getKIPObsListeWSAsync(logonInfo, LinkGuid);

        //    List<Models.ObsItem> items = new List<Models.ObsItem>();
        //    SrcObs[] itemsWS;

        //    itemsWS = resp.Body.getKIPObsListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.ObsItem item = new Models.ObsItem();
        //        item.ObsGuid = i.ObsGuid;
        //        item.LinkGuid = i.LinkGuid;
        //        item.ObsDato = i.ObsDato;
        //        item.Informasjon = i.Informasjon;
        //        item.Lest = i.Lest;
        //        item.Utfort = i.Utfort;
        //        item.BrukerId = i.BrukerId;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.ObsItem> GetObs(SrcLogonInfo logonInfo, string ObsGuid)
        //{
        //    getKIPObsWSResponse resp = new getKIPObsWSResponse();
        //    resp = await KipWSClient.getKIPObsWSAsync(logonInfo, ObsGuid);

        //    Models.ObsItem item = new Models.ObsItem();
        //    SrcObs i = new SrcObs();


        //    item.ObsGuid = i.ObsGuid;
        //    item.LinkGuid = i.LinkGuid;
        //    item.ObsDato = i.ObsDato;
        //    item.Informasjon = i.Informasjon;
        //    item.Lest = i.Lest;
        //    item.Utfort = i.Utfort;
        //    item.BrukerId = i.BrukerId;
        //    return item;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetObs(SrcLogonInfo logonInfo, Models.ObsItem item)
        //{
        //    SrcObs items = new SrcObs();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new kip.kirkedata.webservices.SrcReturnValue();
        //    items.ObsGuid = item.ObsGuid;
        //    items.LinkGuid = item.LinkGuid;
        //    items.ObsDato = item.ObsDato;
        //    items.Informasjon = item.Informasjon;
        //    items.Lest = item.Lest;
        //    items.Utfort = item.Utfort;
        //    items.BrukerId = item.BrukerId;

        //    setKIPObsWSResponse resp = new setKIPObsWSResponse();
        //    resp = await KipWSClient.setKIPObsWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPObsWSResult;

        //    return retur;

        //}


        #endregion

        #region Meny

        //public async Task<List<Models.HurtigmenyItem>> GetHurtigmenyListe(SrcLogonInfo logonInfo )
        //{
        //    getKIPHurtigmenyListeWSResponse resp = new getKIPHurtigmenyListeWSResponse();
        //    resp = await KipWSClient.getKIPHurtigmenyListeWSAsync(logonInfo);

        //    List<Models.HurtigmenyItem> items = new List<Models.HurtigmenyItem>();
        //    SrcHurtigmeny[] itemsWS;

        //    itemsWS = resp.Body.getKIPHurtigmenyListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.HurtigmenyItem item = new Models.HurtigmenyItem();
        //        item.Funksjon = i.Funksjon;
        //        item.Tittel = i.Tittel;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.URL = i.URL;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        public async Task<List<Models.MenuItem>> GetMenyListe(AccountLogOnInfoItem logonInfo, string filter)
        {

            List<Models.MenuItem> itemWS = new();

            if (filter  != null)
            {
                logonInfo.Parameters.filter = filter;
            }

            string json = JsonConvert.SerializeObject(logonInfo);

            string result = await ExecuteJson("Functions", "GetMenus", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.MenuItem>>(result);

            return itemWS;

        }

        //public async Task<List<Models.MenuFunksjonItem>> GetMenyFunksjonListe(SrcLogonInfo logonInfo, string filter)
        //{
        //    getKIPMenyFunksjonListeWSResponse resp = new getKIPMenyFunksjonListeWSResponse();
        //    resp = await KipWSClient.getKIPMenyFunksjonListeWSAsync(logonInfo, filter);

        //    List<Models.MenuFunksjonItem> items = new List<Models.MenuFunksjonItem>();
        //    SrcMenyFunksjon[] itemsWS;

        //    itemsWS = resp.Body.getKIPMenyFunksjonListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.MenuFunksjonItem item = new Models.MenuFunksjonItem();
        //        item.Funksjon = i.Funksjon;
        //        item.FunksjonGuid = i.FunksjonGuid;
        //        item.Hovedmeny = i.Hovedmeny;
        //        item.Tittel = i.Tittel;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.URL = i.URL;
        //        item.Ikon = i.Ikon;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.MenuFunksjonItem> GetMenyFunksjon(SrcLogonInfo logonInfo, string FunksjonGuid)
        //{
        //    getKIPMenyFunksjonWSResponse resp = new getKIPMenyFunksjonWSResponse();
        //    resp = await KipWSClient.getKIPMenyFunksjonWSAsync(logonInfo, FunksjonGuid);

        //    Models.MenuFunksjonItem item = new Models.MenuFunksjonItem();
        //    SrcMenyFunksjon i = resp.Body.getKIPMenyFunksjonWSResult;


        //    item.Funksjon = i.Funksjon;
        //    item.FunksjonGuid = i.FunksjonGuid;
        //    item.Hovedmeny = i.Hovedmeny;
        //    item.Tittel = i.Tittel;
        //    item.Beskrivelse = i.Beskrivelse;
        //    item.URL = i.URL;
        //    item.Ikon = i.Ikon;
        //    return item;

        //}

        //public async Task<List<string>> GetModulerListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPModulListeWSResponse resp = new getKIPModulListeWSResponse();
        //    resp = await KipWSClient.getKIPModulListeWSAsync(logonInfo);

        //    Models.MenuFunksjonItem item = new Models.MenuFunksjonItem();
        //    List<string> I = resp.Body.getKIPModulListeWSResult;


        //    return I;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetMenyFunksjon(SrcLogonInfo logonInfo, Models.MenuFunksjonItem item)
        //{
        //    SrcMenyFunksjon items = new SrcMenyFunksjon();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.Funksjon = item.Funksjon;
        //    items.FunksjonGuid = item.FunksjonGuid;
        //    items.Hovedmeny = item.Hovedmeny;
        //    items.Tittel = item.Tittel;
        //    items.Beskrivelse = item.Beskrivelse;
        //    items.URL = item.URL;
        //    items.Ikon = item.Ikon;

        //    setKIPMenyFunksjonWSResponse resp = new setKIPMenyFunksjonWSResponse();
        //    resp = await KipWSClient.setKIPMenyFunksjonWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPMenyFunksjonWSResult;

        //    return retur;

        //}

        //public async Task<removeKIPMenyFunksjonWSResponse> removeMenyFunksjon(SrcLogonInfo logonInfo, string FunksjonGuid)
        //{
        //    return await KipWSClient.removeKIPMenyFunksjonWSAsync(logonInfo, FunksjonGuid);
        //}

        //public async Task<List<Models.BrukerFunksjonItem>> GetBrukerFunksjonListe(SrcLogonInfo logonInfo, string BrukerId)
        //{
        //    getKIPBrukerFunksjonListeWSResponse resp = new getKIPBrukerFunksjonListeWSResponse();
        //    resp = await KipWSClient.getKIPBrukerFunksjonListeWSAsync(logonInfo, BrukerId);

        //    List<Models.BrukerFunksjonItem> items = new List<Models.BrukerFunksjonItem>();
        //    SrcBrukerFunksjon[] itemsWS;

        //    itemsWS = resp.Body.getKIPBrukerFunksjonListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.BrukerFunksjonItem item = new Models.BrukerFunksjonItem();
        //        item.BrukerFunksjonGuid = i.BrukerFunksjonGuid;
        //        item.BrukerId = i.BrukerId;
        //        item.Niva = i.Niva;
        //        item.Funksjon = i.Funksjon;
        //        item.Tilgang = i.Tilgang;
        //        item.Sortering = i.Sortering;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.BrukerFunksjonItem> GetBrukerFunksjon(SrcLogonInfo logonInfo, string BrukerFunksjonGuid)
        //{
        //    getKIPBrukerFunksjonWSResponse resp = new getKIPBrukerFunksjonWSResponse();
        //    resp = await KipWSClient.getKIPBrukerFunksjonWSAsync(logonInfo, BrukerFunksjonGuid);

        //    Models.BrukerFunksjonItem item = new Models.BrukerFunksjonItem();
        //    SrcBrukerFunksjon i = new SrcBrukerFunksjon();


        //    item.BrukerFunksjonGuid = i.BrukerFunksjonGuid;
        //    item.BrukerId = i.BrukerId;
        //    item.Niva = i.Niva;
        //    item.Funksjon = i.Funksjon;
        //    item.Tilgang = i.Tilgang;
        //    item.Sortering = i.Sortering;
        //    return item;

        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetBrukerFunksjon(SrcLogonInfo logonInfo, Models.BrukerFunksjonItem item)
        //{
        //    SrcBrukerFunksjon items = new SrcBrukerFunksjon();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.BrukerFunksjonGuid = item.BrukerFunksjonGuid;
        //    items.FunksjonGuid = item.FunksjonGuid;
        //    items.BrukerId = item.BrukerId;
        //    items.Niva = item.Niva;
        //    items.Funksjon = item.Funksjon;
        //    items.Tilgang = item.Tilgang;
        //    items.Sortering = item.Sortering;

        //    setKIPBrukerFunksjonWSResponse resp = new setKIPBrukerFunksjonWSResponse();
        //    resp = await KipWSClient.setKIPBrukerFunksjonWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPBrukerFunksjonWSResult;

        //    return retur;

        //}

        //public async Task<removeKIPBrukerFunksjonWSResponse> removeBrukerFunksjon(SrcLogonInfo logonInfo, string funksjonGuid, string brukerId)
        //{
        //    return await KipWSClient.removeKIPBrukerFunksjonWSAsync(logonInfo, funksjonGuid, brukerId);
        //}
        #endregion

        #region Rutenettmaler

        //public async Task<List<Models.RutenetmalItem>> GetRutenetmalListe(SrcLogonInfo logonInfo, int Modul)
        //{
        //    getKIPRutenettmalerListeResponse resp = new getKIPRutenettmalerListeResponse();
        //    resp = await KipWSClient.getKIPRutenettmalerListeAsync(logonInfo, Modul);

        //    List<Models.RutenetmalItem> items = new List<Models.RutenetmalItem>();
        //    SrcRutenettmal[] itemsWS;

        //    itemsWS = resp.Body.getKIPRutenettmalerListeResult;

        //    bool EierNavn = false;

        //    foreach (var i in itemsWS)
        //    {
        //        if (i.Navn == logonInfo.BrukerId)
        //        {
        //            EierNavn = true;
        //        }
        //    }

        //    foreach (var i in itemsWS)
        //    {
        //        Models.RutenetmalItem item = new Models.RutenetmalItem();
        //        item.GridmalGuid = i.GridmalGuid;
        //        item.Navn = i.Navn;
        //        item.Eier = i.Eier;
        //        item.Privat = i.Privat;
        //        if (!EierNavn && i.Navn.ToLower() =="standard")
        //        {
        //            item.Valgt = true;
        //        }
        //        else if (EierNavn && i.Navn.ToLower() == logonInfo.BrukerId.ToLower())
        //        {
        //            item.Valgt = true;
        //        }
        //        if (i.Eier.ToUpper() != logonInfo.BrukerId.ToUpper())
        //        {
        //            item.Farge = "gray";
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetRutenetmal(SrcLogonInfo logonInfo, Models.RutenetmalItem item)
        //{
        //    SrcRutenettmal items = new SrcRutenettmal();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();
        //    items.GridMal_GUID = item.GridMal_GUID;
        //    items.Navn = item.Navn;
        //    items.MODUL = item.MODUL;
        //    items.Privat = item.Privat;
        //    items.AutoUpdate = item.AutoUpdate;
        //    items.Eier = item.Eier;

        //    setKIPRutenettmalWSResponse resp = new setKIPRutenettmalWSResponse();
        //    resp = await KipWSClient.setKIPRutenettmalWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPRutenettmalWSResult;

        //    return retur;

        //}

        //public async Task<Models.RutenetmalItem> GetRutenettmal(SrcLogonInfo logonInfo, string GridMal_GUID)
        //{
        //    getKIPRutenettmalWSResponse resp = new getKIPRutenettmalWSResponse();
        //    resp = await KipWSClient.getKIPRutenettmalWSAsync(logonInfo, GridMal_GUID);

        //    Models.RutenetmalItem item = new Models.RutenetmalItem();
        //    SrcRutenettmal i = resp.Body.getKIPRutenettmalWSResult;


        //    item.Navn = i.Navn;
        //    item.MODUL = i.MODUL;
        //    item.SQL_TEKST = i.SQL_TEKST;
        //    item.Privat = i.Privat;
        //    item.AutoUpdate = i.AutoUpdate;
        //    item.Eier = i.Eier;
        //    item.GridMal_GUID = i.GridMal_GUID;
        //    item.SoknNr = i.SoknNr;
        //    item.Program_GUID = i.Program_GUID;
        //    item.Fellesraad = i.Fellesraad;
        //    return item;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> GetStandardRutenettmal(SrcLogonInfo logonInfo, int Modell)
        //{
        //    getKIPStandardRutenetmalWSResponse resp = new getKIPStandardRutenetmalWSResponse();
        //    resp = await KipWSClient.getKIPStandardRutenetmalWSAsync(logonInfo, Modell);

        //    kip.kirkedata.webservices.SrcReturnValue retur = resp.Body.getKIPStandardRutenetmalWSResult;

        //    return retur;

        //}

        //public async Task<List<Models.RutenetmalFeltItem>> GetRutenetmalFeltListe(SrcLogonInfo logonInfo, string GridmalGuid)
        //{
        //    getKIPRutenetmalFeltListeWSResponse resp = new getKIPRutenetmalFeltListeWSResponse();
        //    resp = await KipWSClient.getKIPRutenetmalFeltListeWSAsync(logonInfo, GridmalGuid);

        //    List<Models.RutenetmalFeltItem> items = new List<Models.RutenetmalFeltItem>();
        //    SrcRutenetmalFelt[] itemsWS;

        //    itemsWS = resp.Body.getKIPRutenetmalFeltListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.RutenetmalFeltItem item = new Models.RutenetmalFeltItem();
        //        item.GridmalGuid = i.GridmalGuid;
        //        item.TabellNavn = i.TabellNavn;
        //        item.OrigNavn = i.OrigNavn;
        //        item.Vis = i.Vis;
        //        item.Rekkefoelge = i.Rekkefoelge;
        //        item.Bredde = i.Bredde;
        //        item.NyttNavn = i.NyttNavn;
        //        item.Tittel = i.Tittel;
        //        item.Skrivebeskytt = i.Skrivebeskytt;
        //        item.OrigPinn = i.OrigPinn;
        //        item.SkjulTittel = i.SkjulTittel;
        //        item.Valgbar = i.Valgbar;
        //        item.DataType = i.DataType;
        //        item.Pinn = i.Pinn;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.RutenetmalFeltItem>> GetStandardRutenetmalFeltListe(SrcLogonInfo logonInfo, int Modul)
        //{
        //    getKIPStandardRutenetmalFeltListeWSResponse resp = new getKIPStandardRutenetmalFeltListeWSResponse();
        //    resp = await KipWSClient.getKIPStandardRutenetmalFeltListeWSAsync(logonInfo, Modul);

        //    List<Models.RutenetmalFeltItem> items = new List<Models.RutenetmalFeltItem>();
        //    SrcRutenetmalFelt[] itemsWS;

        //    itemsWS = resp.Body.getKIPStandardRutenetmalFeltListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.RutenetmalFeltItem item = new Models.RutenetmalFeltItem();
        //        item.GridmalGuid = i.GridmalGuid;
        //        item.TabellNavn = i.TabellNavn;
        //        item.OrigNavn = i.OrigNavn;
        //        item.Vis = i.Vis;
        //        item.Rekkefoelge = i.Rekkefoelge;
        //        item.Bredde = i.Bredde;
        //        item.NyttNavn = i.NyttNavn;
        //        item.Tittel = i.Tittel;
        //        item.Skrivebeskytt = i.Skrivebeskytt;
        //        item.OrigPinn = i.OrigPinn;
        //        item.SkjulTittel = i.SkjulTittel;
        //        item.Valgbar = i.Valgbar;
        //        item.DataType = i.DataType;
        //        item.Pinn = i.Pinn;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<kip.kirkedata.webservices.SrcReturnValue> SetRutenetmalFeltListe(SrcLogonInfo logonInfo, string GridmalGuid, string Kolonner)
        //{
        //    SrcRutenettmal items = new SrcRutenettmal();
        //    kip.kirkedata.webservices.SrcReturnValue retur = new();

        //    setKIPRutenetmalFeltListeWSResponse resp = new setKIPRutenetmalFeltListeWSResponse();
        //    resp = await KipWSClient.setKIPRutenetmalFeltListeWSAsync(logonInfo, GridmalGuid, Kolonner);
        //    retur = resp.Body.setKIPRutenetmalFeltListeWSResult;

        //    return retur;

        //}

        #endregion


        #region Endringslogg

        //public async Task<List<Models.EndrlingsloggItem>> GetEndrlingsloggListe(SrcLogonInfo logonInfo, string Post)
        //{
        //    getKIPEndrlingsloggListeWSResponse resp = new getKIPEndrlingsloggListeWSResponse();
        //    resp = await KipWSClient.getKIPEndrlingsloggListeWSAsync(logonInfo, Post);

        //    List<Models.EndrlingsloggItem> items = new List<Models.EndrlingsloggItem>();
        //    SrcEndrlingslogg[] itemsWS;

        //    itemsWS = resp.Body.getKIPEndrlingsloggListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.EndrlingsloggItem item = new Models.EndrlingsloggItem();
        //        item.Logg_GUID = i.Logg_GUID;
        //        item.BrukerId = i.BrukerId;
        //        item.Tidspunkt = i.Tidspunkt;
        //        item.Tabell = i.Tabell;
        //        item.Post = i.Post;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.Program = i.Program;
        //        item.Program_GUID = i.Program_GUID;
        //        item.Fellesraad = i.Fellesraad;
        //        items.Add(item);
        //    }
        //    return items;
        //}


        //public async Task<List<Models.EndrlingsloggInfoItem>> GetEndrlingsloggInfoListe(SrcLogonInfo logonInfo, string loggGuid)
        //{
        //    getKIPEndrlingsloggInfoListeWSResponse resp = new getKIPEndrlingsloggInfoListeWSResponse();
        //    resp = await KipWSClient.getKIPEndrlingsloggInfoListeWSAsync(logonInfo, loggGuid);

        //    List<Models.EndrlingsloggInfoItem> items = new List<Models.EndrlingsloggInfoItem>();
        //    SrcEndrlingsloggInfo[] itemsWS;

        //    itemsWS = resp.Body.getKIPEndrlingsloggInfoListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.EndrlingsloggInfoItem item = new Models.EndrlingsloggInfoItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.Logg_GUID = i.Logg_GUID;
        //        item.LoggInfo_GUID = i.LoggInfo_GUID;
        //        item.Felt = i.Felt;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.GammelVerdi = i.GammelVerdi;
        //        item.NyVerdi = i.NyVerdi;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.Program_GUID = i.Program_GUID;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        #endregion

        #region Type fuel

        [HttpPost]
        public async Task<List<Models.TypeFuelItem>> GetFuelTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.TypeFuelItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypeFuelList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.TypeFuelItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.TypeFuelItem> GetFuelType(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.TypeFuelItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypeFuel", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.TypeFuelItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetTypeFuel(Models.TypeFuelItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetTypeFuel", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveTypeFule(Models.AccountLogOnInfoItem logoninfo)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "RemoveTypeFuel", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        #region Type Power production

        [HttpPost]
        public async Task<Models.TypePowerProductionItem> GetPowerProductionType(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.TypePowerProductionItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypePowerProduction", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.TypePowerProductionItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetTypePowerProduction(Models.TypePowerProductionItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetTypePowerProduction", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<List<Models.TypePowerProductionItem>> GetPowerProductionTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.TypePowerProductionItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypePowerProductionList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.TypePowerProductionItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveTypePowerProduction(Models.AccountLogOnInfoItem logoninfo)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "RemoveTypePowerProduction", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        #endregion

        #region Type Equipment

        [HttpPost]
        public async Task<Models.TypeEquipmentItem> GetEquipmentType(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.TypeEquipmentItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypeEquipment", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.TypeEquipmentItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetTypeEquipment(Models.TypeEquipmentItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetTypeEquipment", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<List<Models.TypeEquipmentItem>> GetEquipmentTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.TypeEquipmentItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypeEquipmentList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.TypeEquipmentItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveTypeEquipment(Models.AccountLogOnInfoItem logoninfo)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "RemoveTypeEquipment", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        #region Type Ship

        [HttpPost]
        public async Task<Models.TypeShipItem> GetShipType(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.TypeShipItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypeShip", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.TypeShipItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetTypeShip(Models.TypeShipItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetTypeShip", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<List<Models.TypeShipItem>> GetShipTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.TypeShipItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetTypeShipList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.TypeShipItem>>(result);

            return itemWS;
        }



        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveTypeShip(Models.AccountLogOnInfoItem logoninfo)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "RemoveTypeShip", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }



        [HttpPost]
        public async Task<Models.ShipTypeGeneratorsItem> GetShipTypeGenerators(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipTypeGeneratorsItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetShipTypeGenerators", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipTypeGeneratorsItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetShipTypeGenerators(Models.ShipTypeGeneratorsItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetShipTypeGenerators", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<ReturnValueItem> RemoveShipTypeGenerators(AccountLogOnInfoItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "RemoveShipTypeGenerators", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<List<Models.ShipTypeGeneratorsItem>> GetShipTypeGeneratorsListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipTypeGeneratorsItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetShipTypeGeneratorsListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipTypeGeneratorsItem>>(result);

            return itemWS;
        }




        [HttpPost]
        public async Task<Models.ShipTypeOperationModesItem> GetShipTypeOperationModes(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipTypeOperationModesItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetShipTypeOperationModes", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipTypeOperationModesItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetShipTypeOperationModes(Models.ShipTypeOperationModesItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetShipTypeOperationModes", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<ReturnValueItem> RemoveShipTypeOperationModes(AccountLogOnInfoItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "RemoveShipTypeOperationModes", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<List<Models.ShipTypeOperationModesItem>> GetShipTypeOperationModesListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipTypeOperationModesItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetShipTypeOperationModesListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipTypeOperationModesItem>>(result);

            return itemWS;
        }


        #endregion

        #region Equipment library

        [HttpPost]
        public async Task<List<Models.EquipmentLibraryItem>> GetEquipmentLibraryList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.EquipmentLibraryItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetEquipmentLibraryListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.EquipmentLibraryItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.EquipmentLibraryItem> GetLibraryEquipment(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.EquipmentLibraryItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetEquipmentLibrary", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.EquipmentLibraryItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetEquipmentLibrary(Models.EquipmentLibraryItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetEquipmentLibrary", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        #region Vendor

        [HttpPost]
        public async Task<Models.GeneratorVendorItem> GetGeneratorVendor(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.GeneratorVendorItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetGeneratorVendor", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.GeneratorVendorItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetGeneratorVendor(Models.GeneratorVendorItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetGeneratorVendor", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<List<Models.GeneratorVendorItem>> GetGeneratorVendorList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.GeneratorVendorItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetGeneratorVendorList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.GeneratorVendorItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> RemoveGeneratorVendor(Models.GeneratorVendorItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "RemoveGeneratorVendor", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<List<Models.GeneratorVendorModelItem>> GetGeneratorVendorModelList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.GeneratorVendorModelItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetGeneratorVendorModelList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.GeneratorVendorModelItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> ImportFuelComsuption(Models.FuelComsuptionImportItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "ImportFuelComsuption", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        #endregion

        #region Model

        [HttpPost]
        public async Task<ReturnValueItem> SetGeneratorModel(Models.GeneratorModelItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "SetGeneratorModel", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> ImportGeneratorModel(GeneratorImportItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "ImportGeneratorModel", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<Models.GeneratorModelItem> GetGeneratorModel(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.GeneratorModelItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetGeneratorModel", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.GeneratorModelItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<List<Models.GeneratorModelItem>> GetGeneratorModelList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.GeneratorModelItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await ExecuteJson("Functions", "GetGeneratorModelList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.GeneratorModelItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> RemoveGeneratorModel(Models.GeneratorModelItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await ExecuteJson("Functions", "RemoveGeneratorModel", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        public async Task<string> ExecuteJson(string service, string funksjon, string json, string parameters)
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


