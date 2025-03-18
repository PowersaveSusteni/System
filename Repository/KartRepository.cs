using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class KartRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public KartRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //#region Hovedfunksjoner

        //public async Task<List<Models.KartItem>> GetKartListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPKartListeWSResponse resp = new getKIPKartListeWSResponse();
        //    resp = await KipWSClient.getKIPKartListeWSAsync(logonInfo, false);

        //    List<Models.KartItem> items = new List<Models.KartItem>();
        //    SrcKart[] itemsWS;

        //    itemsWS = resp.Body.getKIPKartListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KartItem item = new Models.KartItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.KartGuid = i.KartGuid;
        //        item.KirkegardGuid = i.KirkegardGuid;
        //        item.Filnavn = i.Filnavn;
        //        item.WebFilNavn = i.WebFilNavn;
        //        item.Bruker = i.Bruker;
        //        item.BrukerId = i.BrukerId;
        //        item.Navn = i.Navn;
        //        item.Papir = i.Papir;
        //        item.SkalaTekst = i.SkalaTekst;
        //        item.Skala = i.Skala;
        //        item.X = i.X;
        //        item.Y = i.Y;
        //        item.EndretDato = i.EndretDato;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.Orientering = i.Orientering;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.KartItem> GetKart(SrcLogonInfo logonInfo, string KartGuid)
        //{
        //    getKIPKartWSResponse resp = new getKIPKartWSResponse();
        //    resp = await KipWSClient.getKIPKartWSAsync(logonInfo, KartGuid);

        //    Models.KartItem item = new Models.KartItem();
        //    SrcKart i = resp.Body.getKIPKartWSResult;

        //    item.Fellesraad = i.Fellesraad;
        //    item.KartGuid = i.KartGuid;
        //    item.KirkegardGuid = i.KirkegardGuid;
        //    item.Filnavn = i.Filnavn;
        //    item.Bruker = i.Bruker;
        //    item.BrukerId = i.BrukerId;
        //    item.Navn = i.Navn;
        //    item.WebFilNavn = i.WebFilNavn;
        //    item.Papir = i.Papir;
        //    item.SkalaTekst = i.SkalaTekst;
        //    item.Skala = i.Skala;
        //    item.X = i.X;
        //    item.Y = i.Y;
        //    item.EndretDato = i.EndretDato;
        //    item.Beskrivelse = i.Beskrivelse;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.Orientering = i.Orientering;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetKart(SrcLogonInfo logonInfo, Models.KartItem item)
        //{
        //    SrcKart items = new SrcKart();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Fellesraad = item.Fellesraad;
        //    items.KartGuid = item.KartGuid;
        //    items.KirkegardGuid = item.KirkegardGuid;
        //    items.Filnavn = item.Filnavn;
        //    items.Bruker = item.Bruker;
        //    items.BrukerId = item.BrukerId;
        //    items.Navn = item.Navn;
        //    items.WebFilNavn = item.WebFilNavn;
        //    items.Papir = item.Papir;
        //    items.SkalaTekst = item.SkalaTekst;
        //    items.Skala = item.Skala;
        //    items.X = item.X;
        //    items.Y = item.Y;
        //    items.EndretDato = item.EndretDato;
        //    items.Beskrivelse = item.Beskrivelse;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.Orientering = item.Orientering;

        //    setKIPKartWSResponse resp = new setKIPKartWSResponse();
        //    resp = await KipWSClient.setKIPKartWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPKartWSResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> Lagrekart(SrcLogonInfo logonInfo, string kartGuid, string kartData)
        //{
        //    setKIPKartFilWSResponse resp = new setKIPKartFilWSResponse();
        //    SrcReturnValue itemWS = new();
        //    resp = await KipWSClient.setKIPKartFilWSAsync(logonInfo, kartGuid, kartData);
        //    itemWS = resp.Body.setKIPKartFilWSResult;

        //    return itemWS;
        //}

        //public async Task<List<Models.KartEndredeGraverItem>> GetKartEndredeGraverListe(SrcLogonInfo logonInfo, string KirkegardGuid)
        //{
        //    getKIPKartEndredeGraverListeWSResponse resp = new getKIPKartEndredeGraverListeWSResponse();
        //    resp = await KipWSClient.getKIPKartEndredeGraverListeWSAsync(logonInfo, KirkegardGuid);

        //    List<Models.KartEndredeGraverItem> items = new List<Models.KartEndredeGraverItem>();
        //    SrcKartEndredeGraver[] itemsWS;

        //    itemsWS = resp.Body.getKIPKartEndredeGraverListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KartEndredeGraverItem item = new Models.KartEndredeGraverItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.KartGuid = i.KartGuid;
        //        item.GravEndretDato = i.GravEndretDato;
        //        item.WebKartDato = i.WebKartDato;
        //        item.Laast = i.Laast;
        //        item.LopeNr = i.LopeNr;
        //        item.GravlagtPos = i.GravlagtPos;
        //        item.Navn = i.Navn;
        //        item.FDato = i.FDato;
        //        item.DDato = i.DDato;
        //        item.GDato = i.GDato;
        //        item.GAar = i.GAar;
        //        item.ForfallAar = i.ForfallAar;
        //        item.Fredningstid = i.Fredningstid;
        //        item.GravFelles = i.GravFelles;
        //        item.Plassering = i.Plassering;
        //        item.KirkegardGuid = i.KirkegardGuid;
        //        item.KontaktGuid = i.KontaktGuid;
        //        if ( i.KontaktGuid != null && i.Navn == null)
        //        {
        //            item.Navn = "Reservert";
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.KartEndredeGraverItem>> GetKartGravListe(SrcLogonInfo logonInfo, string KirkegardGuid, string filterTekst)
        //{
        //    getKIPKartGravListeWSResponse resp = new getKIPKartGravListeWSResponse();
        //    resp = await KipWSClient.getKIPKartGravListeWSAsync(logonInfo, KirkegardGuid, filterTekst);

        //    List<Models.KartEndredeGraverItem> items = new List<Models.KartEndredeGraverItem>();
        //    SrcKartEndredeGraver[] itemsWS;

        //    itemsWS = resp.Body.getKIPKartGravListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KartEndredeGraverItem item = new Models.KartEndredeGraverItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.Laast = i.Laast;
        //        item.LopeNr = i.LopeNr;
        //        item.GravlagtPos = i.GravlagtPos;
        //        item.Navn = i.Navn;
        //        item.FDato = i.FDato;
        //        item.DDato = i.DDato;
        //        item.GDato = i.GDato;
        //        item.ForfallAar = i.ForfallAar;
        //        item.Fredningstid = i.Fredningstid;
        //        item.GravFelles = i.GravFelles;
        //        item.Plassering = i.Plassering;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<SrcReturnValue> SetKartEndredeGraver(SrcLogonInfo logonInfo, string Plasseringer)
        //{
        //    SrcKart items = new SrcKart();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    setKIPKartEndredeGraverWSResponse resp = new setKIPKartEndredeGraverWSResponse();
        //    resp = await KipWSClient.setKIPKartEndredeGraverWSAsync(logonInfo, Plasseringer);
        //    retur = resp.Body.setKIPKartEndredeGraverWSResult;

        //    return retur;
        //}


        //#endregion



    }
}
