using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class FakturaRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public FakturaRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Faktura

        //public async Task<Models.FakturaItem> getFaktura(SrcLogonInfo logonInfo, int faktNr, string kontoNr)
        //{
        //    getKIPFakturaWSResponse resp = new getKIPFakturaWSResponse();
        //    resp = await KipWSClient.getKIPFakturaWSAsync(logonInfo, faktNr, kontoNr);

        //    Models.FakturaItem item = new Models.FakturaItem();
        //    SrcFaktura i = resp.Body.getKIPFakturaWSResult;

        //    item.AvsPostNr = i.AvsPostNr;
        //    item.Fellesraad = i.Fellesraad;
        //    item.FaktNr = i.FaktNr;
        //    item.KontoNr = i.KontoNr;
        //    item.FaktType_GUID = i.FaktType_GUID;
        //    item.AvsNavn = i.AvsNavn;
        //    item.AvsAdresse1 = i.AvsAdresse1;
        //    item.AvsAdresse2 = i.AvsAdresse2;
        //    item.Kontakt_GUID = i.Kontakt_GUID;
        //    item.Kirkegard_GUID = i.Kirkegard_GUID;
        //    item.Stell_Guid = i.Stell_Guid;
        //    item.OrigFaktNr = i.OrigFaktNr;
        //    item.OppdragNr = i.OppdragNr;
        //    item.EkstFaktNr = i.EkstFaktNr;
        //    item.AvsPostSted = i.AvsPostSted;
        //    item.VaarRef = i.VaarRef;
        //    item.KundeNr = i.KundeNr;
        //    item.PersonNr = i.PersonNr;
        //    item.Navn = i.Navn;
        //    item.Adresse1 = i.Adresse1;
        //    item.Adresse2 = i.Adresse2;
        //    item.PostNr = i.PostNr;
        //    item.PostSted = i.PostSted;
        //    item.DeresRef = i.DeresRef;
        //    item.Info = i.Info;
        //    if (i.UtskDato.Ticks > 0) { item.UtskDato = i.UtskDato; }
        //    item.FaktDato = i.FaktDato;
        //    item.ForfDato = i.ForfDato;
        //    if (i.BetaltDato.Ticks > 0) { item.BetaltDato = i.BetaltDato; }
        //    if (i.KredittertDato.Ticks > 0) { item.KredittertDato = i.KredittertDato; }
        //    item.PrisUMVA = i.PrisUMVA;
        //    item.MVA = i.MVA;
        //    item.PrisMMVA = i.PrisMMVA;
        //    item.BChkSum = i.BChkSum;
        //    item.KID = i.KID;
        //    item.Betalt = i.Betalt;
        //    item.BlankettNr = i.BlankettNr;
        //    item.TekstType = i.TekstType;
        //    item.PaVent = i.PaVent;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.PeriodeFra = i.PeriodeFra;
        //    item.PeriodeTil = i.PeriodeTil;
        //    item.Tilbud = i.Tilbud;
        //    item.AxaptaKundeNr = i.AxaptaKundeNr;
        //    item.RegBetaltDato = i.RegBetaltDato;
        //    item.RegAv = i.RegAv;
        //    item.RegDato = i.RegDato;
        //    item.Bestilling_GUID = i.Bestilling_GUID;
        //    item.OppdrgNr = i.OppdrgNr;
        //    item.Kontakt_GUID_View = i.Kontakt_GUID_View;
        //    item.Kunde_GUID = i.Kunde_GUID;
        //    item.EksportDato = i.EksportDato;
        //    item.Kommentar = i.Kommentar;
        //    item.KredittertFordi = i.KredittertFordi;
        //    item.AutoGiro = i.AutoGiro;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.EksportNr = i.EksportNr;
        //    item.Last = i.Last;
        //    item.PostNrId = i.PostNrId;
        //    item.Sendtinkasso = i.Sendtinkasso;
        //    item.SistPurretDato = i.SistPurretDato;
        //    item.RapUtskNr = i.RapUtskNr;
        //    //item.CaseId = i.CaseId;
        //    return item;
        //}

        //public async Task<SrcReturnValue> SetFaktura(SrcLogonInfo logonInfo, Models.FakturaItem item)
        //{
        //    SrcFaktura items = new SrcFaktura();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.AvsPostNr = item.AvsPostNr;
        //    items.Fellesraad = item.Fellesraad;
        //    items.FaktNr = item.FaktNr;
        //    items.KontoNr = item.KontoNr;
        //    items.FaktType_GUID = item.FaktType_GUID;
        //    items.AvsNavn = item.AvsNavn;
        //    items.AvsAdresse1 = item.AvsAdresse1;
        //    items.AvsAdresse2 = item.AvsAdresse2;
        //    items.Kontakt_GUID = item.Kontakt_GUID;
        //    items.Kirkegard_GUID = item.Kirkegard_GUID;
        //    items.Stell_Guid = item.Stell_Guid;
        //    items.OrigFaktNr = item.OrigFaktNr;
        //    items.OppdragNr = item.OppdragNr;
        //    items.EkstFaktNr = item.EkstFaktNr;
        //    items.AvsPostSted = item.AvsPostSted;
        //    items.VaarRef = item.VaarRef;
        //    items.KundeNr = item.KundeNr;
        //    items.PersonNr = item.PersonNr;
        //    items.Navn = item.Navn;
        //    items.Adresse1 = item.Adresse1;
        //    items.Adresse2 = item.Adresse2;
        //    items.PostNr = item.PostNr;
        //    items.PostSted = item.PostSted;
        //    items.DeresRef = item.DeresRef;
        //    items.Info = item.Info;
        //    if (item.UtskDato != null) { items.UtskDato = (DateTime)item.UtskDato; }
        //    items.FaktDato = item.FaktDato;
        //    items.ForfDato = item.ForfDato;
        //    if (item.BetaltDato != null) { items.BetaltDato = (DateTime)item.BetaltDato; }
        //    if (item.KredittertDato != null) { items.KredittertDato = (DateTime)item.KredittertDato; }
        //    items.PrisUMVA = item.PrisUMVA;
        //    items.MVA = item.MVA;
        //    items.PrisMMVA = item.PrisMMVA;
        //    items.BChkSum = item.BChkSum;
        //    items.KID = item.KID;
        //    items.Betalt = item.Betalt;
        //    items.BlankettNr = item.BlankettNr;
        //    items.TekstType = item.TekstType;
        //    items.PaVent = item.PaVent;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.PeriodeFra = item.PeriodeFra;
        //    items.PeriodeTil = item.PeriodeTil;
        //    items.Tilbud = item.Tilbud;
        //    items.AxaptaKundeNr = item.AxaptaKundeNr;
        //    items.RegBetaltDato = item.RegBetaltDato;
        //    items.RegAv = item.RegAv;
        //    items.RegDato = item.RegDato;
        //    items.Bestilling_GUID = item.Bestilling_GUID;
        //    items.OppdrgNr = item.OppdrgNr;
        //    items.Kontakt_GUID_View = item.Kontakt_GUID_View;
        //    items.Kunde_GUID = item.Kunde_GUID;
        //    items.EksportDato = item.EksportDato;
        //    items.Kommentar = item.Kommentar;
        //    items.KredittertFordi = item.KredittertFordi;
        //    items.AutoGiro = item.AutoGiro;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.EksportNr = item.EksportNr;
        //    items.Last = item.Last;
        //    items.PostNrId = item.PostNrId;
        //    items.Sendtinkasso = item.Sendtinkasso;
        //    items.SistPurretDato = item.SistPurretDato;
        //    items.RapUtskNr = item.RapUtskNr;

        //    setKIPFakturaWSResponse resp = new setKIPFakturaWSResponse();
        //    resp = await KipWSClient.setKIPFakturaWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPFakturaWSResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> exeProduserFaktura(SrcLogonInfo logonInfo, Models.FaktureringItem item)
        //{
        //    SrcFakturering items = new SrcFakturering();

        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.KontoNr = item.KontoNr;
        //    items.FaktType_GUID = item.FaktType_GUID;
        //    items.FaktDato = item.FaktDato;
        //    items.ForfDato = item.ForfDato;
        //    items.kundeTekst = item.kundeTekst;
        //    items.KundeGuidListe = item.KundeGuidListe;

        //    List<SrcFakturaTjenester> itemsT = new();

        //    SrcFakturaTjenester itemT = new();

        //    itemT.TjenesteNr = item.TjenesteNr;
        //    itemT.VareTekst = item.Tekst;
        //    itemT.PrisUMVA = item.PrisUMVA;
        //    itemsT.Add(itemT);

        //    items.Tjenester = itemsT.ToArray();

        //    exeKIPFakturerWSResponse resp = new exeKIPFakturerWSResponse();
        //    resp = await KipWSClient.exeKIPFakturerWSAsync(logonInfo, items);
        //    retur = resp.Body.exeKIPFakturerWSResult;

        //    return retur;
        //}


        //public async Task<List<Models.FakturaLinjeItem>> GetFakturaLinjeListe(SrcLogonInfo logonInfo, int faktnr, string kontoNr)
        //{
        //    getKIPFakturaLinjeListeWSResponse resp = new getKIPFakturaLinjeListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaLinjeListeWSAsync(logonInfo, faktnr, kontoNr);

        //    List<Models.FakturaLinjeItem> items = new List<Models.FakturaLinjeItem>();
        //    SrcFakturaLinje[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaLinjeListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaLinjeItem item = new Models.FakturaLinjeItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.FaktNr = i.FaktNr;
        //        item.KontoNr = i.KontoNr;
        //        item.FakturaLinje_GUID = i.FakturaLinje_GUID;
        //        item.FaktType_GUID = i.FaktType_GUID;
        //        item.Kirkegard_GUID = i.Kirkegard_GUID;
        //        item.Grav_GUID = i.Grav_GUID;
        //        item.FesteFornying = i.FesteFornying;
        //        item.FornyTilAar = i.FornyTilAar;
        //        item.LopeNr = i.LopeNr;
        //        item.Sortering = i.Sortering;
        //        item.TjenesteNr = i.TjenesteNr;
        //        item.Enhet = i.Enhet;
        //        item.VareHedder = i.VareHedder;
        //        item.VareTekst = i.VareTekst;
        //        item.Antall = i.Antall;
        //        item.MomsKode = i.MomsKode;
        //        item.MVA = i.MVA;
        //        item.PrisUMVA = i.PrisUMVA;
        //        item.PrisMMVA = i.PrisMMVA;
        //        item.PrisPrUMVA = i.PrisPrUMVA;
        //        item.FaktLType = i.FaktLType;
        //        item.Dim1 = i.Dim1;
        //        item.Dim2 = i.Dim2;
        //        item.Dim3 = i.Dim3;
        //        item.Dim4 = i.Dim4;
        //        item.Dim5 = i.Dim5;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.Innskudd_GUID = i.Innskudd_GUID;
        //        item.FornyFraAar = i.FornyFraAar;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.Dim6 = i.Dim6;
        //        item.Rabatt = i.Rabatt;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.FakturaItem>> GetFakturaListe(SrcLogonInfo logonInfo, string filter, string sortering)
        //{
        //    getKIPFakturaListeWSResponse resp = new getKIPFakturaListeWSResponse();

        //    int Antall = 100;
        //    if (filter != null && filter.Length>0) { Antall = 1000; }
        //    resp = await KipWSClient.getKIPFakturaListeWSAsync(logonInfo, filter, sortering, Antall);

        //    List<Models.FakturaItem> items = new List<Models.FakturaItem>();
        //    SrcFaktura[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaItem item = new Models.FakturaItem();
        //        item.AvsPostNr = i.AvsPostNr;
        //        item.Fellesraad = i.Fellesraad;
        //        item.FaktNr = i.FaktNr;
        //        item.PaVent = i.PaVent;
        //        item.FakturaGuid = i.FakturaGuid;
        //        item.KontoNr = i.KontoNr;
        //        item.FaktType_GUID = i.FaktType_GUID;
        //        item.Kontakt_GUID = i.Kontakt_GUID;
        //        item.EkstFaktNr = i.EkstFaktNr;
        //        item.AvsPostSted = i.AvsPostSted;
        //        item.VaarRef = i.VaarRef;
        //        item.KundeNr = i.KundeNr;
        //        item.PersonNr = i.PersonNr;
        //        item.Navn = i.Navn;
        //        item.Adresse1 = i.Adresse1;
        //        item.Adresse2 = i.Adresse2;
        //        item.PostNr = i.PostNr;
        //        item.PostSted = i.PostSted;
        //        item.DeresRef = i.DeresRef;
        //        item.Info = i.Info;
        //        if (i.UtskDato.Ticks > 0) { item.UtskDato = i.UtskDato; }
        //        item.FaktDato = i.FaktDato;
        //        if (i.ForfDato.Ticks > 0) { item.ForfDato = i.ForfDato; }
        //        if (i.BetaltDato.Ticks > 0) { item.BetaltDato = i.BetaltDato; }
        //        if (i.KredittertDato.Ticks > 0) { item.KredittertDato = i.KredittertDato; }
        //        item.PrisUMVA = i.PrisUMVA;
        //        item.MVA = i.MVA;
        //        item.PrisMMVA = i.PrisMMVA;
        //        item.Betalt = i.Betalt;
        //        item.Restbelop = i.PrisMMVA - i.Betalt;
        //        item.Kunde_GUID = i.Kunde_GUID;
        //        item.Last = i.Last;
        //        item.KID = i.KID;

        //        if (i.BetaltDato.Ticks > 0)
        //        {
        //            item.Farge = "honeydew";
        //        }
        //        else if (i.ForfDato <= System.DateTime.Today && i.BetaltDato.Ticks == 0)
        //        {
        //            item.Farge = "mistyrose";
        //        }
        //        if (i.PaVent)
        //        {
        //            item.Status = 2;
        //            item.StatusFarge = "lightgray";
        //        }
        //        if (i.Status > 0)
        //        {
        //            item.Status = i.Status;
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.FakturaPurringItem>> GetFakturaPurreListe(SrcLogonInfo logonInfo, DateTime purreDato)
        //{
        //    getKIPFakturaPurringListeWSResponse resp = new getKIPFakturaPurringListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaPurringListeWSAsync(logonInfo, purreDato);

        //    List<Models.FakturaPurringItem> items = new List<Models.FakturaPurringItem>();
        //    SrcFakturaPurring[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaPurringListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaPurringItem item = new Models.FakturaPurringItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.FaktNr = i.FaktNr;
        //        item.KontoNr = i.KontoNr;
        //        item.PurreNr = i.PurreNr;
        //        item.PurreDato = i.PurreDato;
        //        if (i.UtskDato.Ticks > 0) { item.UtskDato = i.UtskDato; }
        //        if (i.ForfDato.Ticks > 0) { item.ForfDato = i.ForfDato; }
        //        item.TekstType = i.TekstType;
        //        item.Navn = i.Navn;
        //        item.FaktDato = i.FaktDato;
        //        item.FakturaPurringGuid = i.FakturaPurringGuid;
        //        items.Add(item);
        //    }
        //    return items;
        //}


        //public async Task<List<Models.FakturaPurredatoerItem>> GetFakturaPurredatoListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPFakturaPurringDatoListeWSResponse resp = new getKIPFakturaPurringDatoListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaPurringDatoListeWSAsync(logonInfo, DateTime.Today);

        //    List<Models.FakturaPurredatoerItem> items = new List<Models.FakturaPurredatoerItem>();
        //    SrcFakturaPurringDato[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaPurringDatoListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaPurredatoerItem item = new Models.FakturaPurredatoerItem();
        //        if (i.UtskDato.Ticks > 0) { item.UtskDato = i.UtskDato; }
        //        if (i.PurreDato.Ticks > 0) { item.PurreDato = i.PurreDato; }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.FakturaUtskdatoItem>> GetFakturaUtskDatoer(SrcLogonInfo logonInfo, int antall)
        //{
        //    getKIPFakturaUtskriftsdatoerWSResponse resp = new getKIPFakturaUtskriftsdatoerWSResponse();
        //    resp = await KipWSClient.getKIPFakturaUtskriftsdatoerWSAsync(logonInfo, antall);

        //    List<Models.FakturaUtskdatoItem> items = new List<Models.FakturaUtskdatoItem>();
        //    SrcFakturaUtskdatoer[]  itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaUtskriftsdatoerWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaUtskdatoItem item = new Models.FakturaUtskdatoItem();
        //        item.Utskdato = i.dato;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.FakturaLinjeItem> GetFakturaLinje(SrcLogonInfo logonInfo, string FakturaLinjeGuid)
        //{
        //    getKIPFakturaLinjeWSResponse resp = new getKIPFakturaLinjeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaLinjeWSAsync(logonInfo, FakturaLinjeGuid);

        //    Models.FakturaLinjeItem item = new Models.FakturaLinjeItem();
        //    SrcFakturaLinje i = resp.Body.getKIPFakturaLinjeWSResult;


        //    item.Fellesraad = i.Fellesraad;
        //    item.FaktNr = i.FaktNr;
        //    item.KontoNr = i.KontoNr;
        //    item.FakturaLinje_GUID = i.FakturaLinje_GUID;
        //    item.FaktType_GUID = i.FaktType_GUID;
        //    item.Kirkegard_GUID = i.Kirkegard_GUID;
        //    item.Grav_GUID = i.Grav_GUID;
        //    item.FesteFornying = i.FesteFornying;
        //    item.FornyTilAar = i.FornyTilAar;
        //    item.LopeNr = i.LopeNr;
        //    item.Sortering = i.Sortering;
        //    item.TjenesteNr = i.TjenesteNr;
        //    item.Enhet = i.Enhet;
        //    item.VareHedder = i.VareHedder;
        //    item.VareTekst = i.VareTekst;
        //    item.Antall = i.Antall;
        //    item.MomsKode = i.MomsKode;
        //    item.MVA = i.MVA;
        //    item.PrisUMVA = i.PrisUMVA;
        //    item.PrisMMVA = i.PrisMMVA;
        //    item.PrisPrUMVA = i.PrisPrUMVA;
        //    item.FaktLType = i.FaktLType;
        //    item.Dim1 = i.Dim1;
        //    item.Dim2 = i.Dim2;
        //    item.Dim3 = i.Dim3;
        //    item.Dim4 = i.Dim4;
        //    item.Dim5 = i.Dim5;
        //    item.Dim6 = i.Dim6;
        //    item.Rabatt = i.Rabatt;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.Innskudd_GUID = i.Innskudd_GUID;
        //    item.FornyFraAar = i.FornyFraAar;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    return item;
        //}

        //public async Task<SrcReturnValue> SetFakturaLinje(SrcLogonInfo logonInfo, Models.FakturaLinjeItem item)
        //{
        //    SrcFakturaLinje items = new SrcFakturaLinje();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Fellesraad = item.Fellesraad;
        //    items.FaktNr = item.FaktNr;
        //    items.KontoNr = item.KontoNr;
        //    items.FakturaLinje_GUID = item.FakturaLinje_GUID;
        //    items.FaktType_GUID = item.FaktType_GUID;
        //    items.Kirkegard_GUID = item.Kirkegard_GUID;
        //    items.Grav_GUID = item.Grav_GUID;
        //    items.FesteFornying = item.FesteFornying;
        //    items.FornyTilAar = item.FornyTilAar;
        //    items.LopeNr = item.LopeNr;
        //    items.Sortering = item.Sortering;
        //    items.TjenesteNr = item.TjenesteNr;
        //    items.Enhet = item.Enhet;
        //    items.VareHedder = item.VareHedder;
        //    items.VareTekst = item.VareTekst;
        //    items.Antall = item.Antall;
        //    items.MomsKode = item.MomsKode;
        //    items.MVA = item.MVA;
        //    items.PrisUMVA = item.PrisUMVA;
        //    items.PrisMMVA = item.PrisMMVA;
        //    items.PrisPrUMVA = item.PrisPrUMVA;
        //    items.FaktLType = item.FaktLType;
        //    items.Dim1 = item.Dim1;
        //    items.Dim2 = item.Dim2;
        //    items.Dim3 = item.Dim3;
        //    items.Dim4 = item.Dim4;
        //    items.Dim5 = item.Dim5;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.Innskudd_GUID = item.Innskudd_GUID;
        //    items.FornyFraAar = item.FornyFraAar;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.Dim6 = item.Dim6;
        //    items.Rabatt = item.Rabatt;

        //    setKIPFakturaLinjeWSResponse resp = new setKIPFakturaLinjeWSResponse();
        //    resp = await KipWSClient.setKIPFakturaLinjeWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPFakturaLinjeWSResult;

        //    return retur;

        //}


        //public async Task<SrcReturnValue> removeFakturaLinje(SrcLogonInfo logonInfo, string FakturaLinjeGuid)
        //{
        //    removeKIPFakturaLinjeWSResponse resp = new removeKIPFakturaLinjeWSResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.removeKIPFakturaLinjeWSAsync(logonInfo, FakturaLinjeGuid);
        //    rapPrev = resp.Body.removeKIPFakturaLinjeWSResult;

        //    return rapPrev;
        //}

        //public async Task<List<Models.FakturaInnbetalingItem>> GetFakturaInnbetalingListe(SrcLogonInfo logonInfo, int faktnr, string kontoNr)
        //{
        //    getKIPFakturaInnbetalingListeWSResponse resp = new getKIPFakturaInnbetalingListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaInnbetalingListeWSAsync(logonInfo, faktnr, kontoNr );

        //    List<Models.FakturaInnbetalingItem> items = new List<Models.FakturaInnbetalingItem>();
        //    SrcFakturaInnbetaling[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaInnbetalingListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaInnbetalingItem item = new Models.FakturaInnbetalingItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.FaktInnbetal_GUID = i.FaktInnbetal_GUID;
        //        item.FaktNr = i.FaktNr;
        //        item.KontoNr = i.KontoNr;
        //        item.IDato = i.IDato;
        //        item.Belop = i.Belop;
        //        item.Kommentar = i.Kommentar;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.LoggInfo = i.LoggInfo;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<SrcReturnValue> setFakturaLinjeListe(SrcLogonInfo logonInfo, int faktNr, string kontoNr, string tjenester)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    setKIPFakturaLinjeListeWSResponse resp = new setKIPFakturaLinjeListeWSResponse();
        //    resp = await KipWSClient.setKIPFakturaLinjeListeWSAsync(logonInfo, faktNr, kontoNr, tjenester);
        //    retur = resp.Body.setKIPFakturaLinjeListeWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> KrediterFaktura(SrcLogonInfo logonInfo, int FakturaNr, string KontoNr)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPKrediterFakturaWSResponse resp = new exeKIPKrediterFakturaWSResponse();
        //    resp = await KipWSClient.exeKIPKrediterFakturaWSAsync(logonInfo, FakturaNr, KontoNr, true);
        //    retur = resp.Body.exeKIPKrediterFakturaWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> KopierFaktura(SrcLogonInfo logonInfo, int FakturaNr, string KontoNr)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPKopierFakturaWSResponse resp = new exeKIPKopierFakturaWSResponse();
        //    resp = await KipWSClient.exeKIPKopierFakturaWSAsync(logonInfo, FakturaNr, KontoNr);
        //    retur = resp.Body.exeKIPKopierFakturaWSResult;

        //    return retur;
        //}

        //public async Task<SrcRapportPreview> SkrivUtFaktura(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPSkrivUtFakturaWSResponse resp = new exeKIPSkrivUtFakturaWSResponse();
        //    SrcRapportPreview rapPrev = new SrcRapportPreview();
        //    resp = await KipWSClient.exeKIPSkrivUtFakturaWSAsync(logonInfo, FakturaNrListe, true);
        //    rapPrev = resp.Body.exeKIPSkrivUtFakturaWSResult;

        //    return rapPrev;
        //}

        //public async Task<SrcReturnValue> eksportFaktura(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPOverforFakturaWSResponse resp = new exeKIPOverforFakturaWSResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPOverforFakturaWSAsync(logonInfo, FakturaNrListe);
        //    rapPrev = resp.Body.exeKIPOverforFakturaWSResult;

        //    return rapPrev;
        //}


        //public async Task<SrcReturnValue> FjernUtskriftsdato(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPFakturaFjernUtskriftsdatoResponse resp = new exeKIPFakturaFjernUtskriftsdatoResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPFakturaFjernUtskriftsdatoAsync(logonInfo, FakturaNrListe);
        //    rapPrev = resp.Body.exeKIPFakturaFjernUtskriftsdatoResult;

        //    return rapPrev;
        //}

        //public async Task<SrcReturnValue> FjernFraListe(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPFakturaSetSomUtskrevetResponse resp = new exeKIPFakturaSetSomUtskrevetResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPFakturaSetSomUtskrevetAsync(logonInfo, FakturaNrListe);
        //    rapPrev = resp.Body.exeKIPFakturaSetSomUtskrevetResult;

        //    return rapPrev;
        //}

        //public async Task<SrcReturnValue> FakturaSetVent(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPFakturaSetPaVentResponse resp = new exeKIPFakturaSetPaVentResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPFakturaSetPaVentAsync(logonInfo, FakturaNrListe);
        //    rapPrev = resp.Body.exeKIPFakturaSetPaVentResult;

        //    return rapPrev;
        //}

        //public async Task<SrcReturnValue> FakturaFraVent(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPFakturaHentFraVentResponse resp = new exeKIPFakturaHentFraVentResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPFakturaHentFraVentAsync(logonInfo, FakturaNrListe);
        //    rapPrev = resp.Body.exeKIPFakturaHentFraVentResult;

        //    return rapPrev;
        //}


        #endregion

        //#region Purringer

        //public async Task<SrcReturnValue> PurringFaktura(SrcLogonInfo logonInfo, string FakturaNrListe, DateTime PurreDato, DateTime ForfDato)
        //{
        //    ProduserPurringerResponse resp = new ProduserPurringerResponse();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    resp = await KipWSClient.ProduserPurringerAsync(logonInfo, FakturaNrListe, PurreDato, ForfDato);
        //    retur = resp.Body.ProduserPurringerResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> SlettPurring(SrcLogonInfo logonInfo, string FakturaNrListe, DateTime PurreDato)
        //{
        //    removeKIPFakturaPurringWSResponse resp = new removeKIPFakturaPurringWSResponse();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    resp = await KipWSClient.removeKIPFakturaPurringWSAsync(logonInfo, FakturaNrListe, PurreDato);
        //    retur = resp.Body.removeKIPFakturaPurringWSResult;

        //    return retur;
        //}

        //public async Task<SrcRapportPreview> SkrivUtPurringer(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPSkrivUtPurringerWSResponse resp = new exeKIPSkrivUtPurringerWSResponse();
        //    SrcRapportPreview rapPrev = new SrcRapportPreview();
        //    resp = await KipWSClient.exeKIPSkrivUtPurringerWSAsync(logonInfo, FakturaNrListe, true);
        //    rapPrev = resp.Body.exeKIPSkrivUtPurringerWSResult;

        //    return rapPrev;
        //}

        //#endregion

        //#region SvarUt


        //public async Task<SrcReturnValue> EkspederFakturaSvarUt(SrcLogonInfo logonInfo, string fakturaListe)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();


        //    exeKIPEkspederFakturaSvarUtWSResponse resp = new exeKIPEkspederFakturaSvarUtWSResponse();
        //    resp = await KipWSClient.exeKIPEkspederFakturaSvarUtWSAsync(logonInfo, fakturaListe);
        //    retur = resp.Body.exeKIPEkspederFakturaSvarUtWSResult;

        //    return retur;
        //}


        //#endregion

        //#region Innbetalinger

        //public async Task<List<Models.FakturaBBSItem>> GetFakturaBBSListe(SrcLogonInfo logonInfo, string strfilter, string sortering)
        //{
        //    getKIPFakturaBBSListeWSResponse resp = new getKIPFakturaBBSListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaBBSListeWSAsync(logonInfo, strfilter, sortering);

        //    List<Models.FakturaBBSItem> items = new List<Models.FakturaBBSItem>();
        //    SrcFakturaBBS[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaBBSListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaBBSItem item = new Models.FakturaBBSItem();
        //        item.BBSRes_GUID = i.BBSRes_GUID;
        //        item.Fellesraad = i.Fellesraad;
        //        item.BBSFiler_GUID = i.BBSFiler_GUID;
        //        item.OppdragNr = i.OppdragNr;
        //        item.BetBelop = i.BetBelop;
        //        item.Kid = i.Kid;
        //        item.ArkivRef = i.ArkivRef;
        //        item.OppdragsKonto = i.OppdragsKonto;
        //        item.DebKonto = i.DebKonto;
        //        item.OppdDato = i.OppdDato;
        //        item.Status = i.Status;
        //        switch (i.Status)
        //        {
        //            case 2:
        //                item.StatusTekst = "<";
        //                break;

        //            case 4:
        //                item.StatusTekst = ">";
        //                break;

        //            case 5:
        //                item.StatusTekst = "=";
        //                break;

        //            case 6:
        //                item.StatusTekst = "X";
        //                break;

        //            default:
        //                item.StatusTekst = "";
        //                break;

        //        }
        //        item.BetDato = i.BetDato;
        //        item.ForsNr = i.ForsNr;
        //        item.LopeNr = i.LopeNr;
        //        item.Fritekst = i.Fritekst;
        //        item.OppgjDato = i.OppgjDato;
        //        item.Ref = i.Ref;
        //        item.Utskrift = i.Utskrift;
        //        item.RegDato = i.RegDato;
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

        //public async Task<List<Models.FakturaBBSFilItem>> GetFakturaBBSFilListe(SrcLogonInfo logonInfo, string filter, string sortering)
        //{
        //    getKIPFakturaBBSFilListeWSResponse resp = new getKIPFakturaBBSFilListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaBBSFilListeWSAsync(logonInfo, filter, sortering);

        //    List<Models.FakturaBBSFilItem> items = new List<Models.FakturaBBSFilItem>();
        //    SrcFakturaBBSFil[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaBBSFilListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaBBSFilItem item = new Models.FakturaBBSFilItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.BBSFiler_GUID = i.BBSFiler_GUID;
        //        item.FilNavn = i.FilNavn;
        //        item.FilDato = i.FilDato;
        //        item.ForsNr = i.ForsNr;
        //        item.AntTrans = i.AntTrans;
        //        item.AntRec = i.AntRec;
        //        item.Sum = i.Sum;
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


        //public async Task<SrcReturnValue> ImportBBS(SrcLogonInfo logonInfo, string filnavn, string filinnhold)
        //{
        //    exeKIPBBSImportWSResponse resp = new exeKIPBBSImportWSResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPBBSImportWSAsync(logonInfo, filnavn, filinnhold);
        //    rapPrev = resp.Body.exeKIPBBSImportWSResult;

        //    return rapPrev;
        //}


        //public async Task<SrcReturnValue> KontrollerFaktura(SrcLogonInfo logonInfo, string FakturaNrListe)
        //{
        //    exeKIPKontrollerFakturaWSResponse resp = new exeKIPKontrollerFakturaWSResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPKontrollerFakturaWSAsync(logonInfo, FakturaNrListe);
        //    rapPrev = resp.Body.exeKIPKontrollerFakturaWSResult;

        //    return rapPrev;
        //}

        //public async Task<SrcProgress> Fremdrift(SrcLogonInfo logonInfo, string tittel, string progressGuid)
        //{
        //    exeKIPGetProgressResponse resp = new exeKIPGetProgressResponse();
        //    SrcProgress rapPrev = new SrcProgress();
        //    resp = await KipWSClient.exeKIPGetProgressAsync(logonInfo, progressGuid, tittel);
        //    rapPrev = resp.Body.exeKIPGetProgressResult;

        //    return rapPrev;
        //}

        //public async Task<SrcReturnValue> SetFakturaInnbetaling(SrcLogonInfo logonInfo, Models.FakturaInnbetalingItem item)
        //{
        //    SrcFakturaInnbetaling items = new SrcFakturaInnbetaling();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Fellesraad = item.Fellesraad;
        //    items.FaktInnbetal_GUID = item.FaktInnbetal_GUID;
        //    items.FaktNr = item.FaktNr;
        //    items.KontoNr = item.KontoNr;
        //    items.IDato = item.IDato;
        //    items.Belop = item.Belop;
        //    items.Kommentar = item.Kommentar;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.LoggInfo = item.LoggInfo;

        //    setKIPFakturaInnbetalingWSResponse resp = new setKIPFakturaInnbetalingWSResponse();
        //    resp = await KipWSClient.setKIPFakturaInnbetalingWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPFakturaInnbetalingWSResult;

        //    return retur;
        //}


        //public async Task<SrcReturnValue> KontrollerFakturaInnbetalinger(SrcLogonInfo logonInfo, string FakturaInformasjon)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPKontrollerInnbetalingerResponse resp = new exeKIPKontrollerInnbetalingerResponse();
        //    resp = await KipWSClient.exeKIPKontrollerInnbetalingerAsync(logonInfo, FakturaInformasjon);
        //    retur = resp.Body.exeKIPKontrollerInnbetalingerResult;

        //    return retur;
        //}



        //public async Task<SrcReturnValue> KontrollerFakturaInnbetaling(SrcLogonInfo logonInfo, int FaktNr, string Kontonr)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPKontrollerInnbetalingWSResponse resp = new exeKIPKontrollerInnbetalingWSResponse();
        //    resp = await KipWSClient.exeKIPKontrollerInnbetalingWSAsync(logonInfo, FaktNr, Kontonr);
        //    retur = resp.Body.exeKIPKontrollerInnbetalingWSResult;

        //    return retur;
        //}



        //#endregion

        //#region Festetilbud

        //public async Task<List<Models.FesteForfallItem>> GetFesteForfallListe(SrcLogonInfo logonInfo, string filter)
        //{
        //    getKIPFesteForfallListeWSResponse resp = new getKIPFesteForfallListeWSResponse();
        //    resp = await KipWSClient.getKIPFesteForfallListeWSAsync(logonInfo, filter);

        //    List<Models.FesteForfallItem> items = new List<Models.FesteForfallItem>();
        //    SrcFesteForfall[] itemsWS;

        //    itemsWS = resp.Body.getKIPFesteForfallListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FesteForfallItem item = new Models.FesteForfallItem();
        //        item.KirkegardNavn = i.KirkegardNavn;
        //        item.Fellesraad = i.Fellesraad;
        //        item.Grav_GUID = i.Grav_GUID;
        //        item.Kirkegard_GUID = i.Kirkegard_GUID;
        //        item.Gravsted_GUID = i.Gravsted_GUID;
        //        item.Type = i.Type;
        //        item.Laast = i.Laast;
        //        item.ForfallMnd = i.ForfallMnd;
        //        item.MappeId = i.MappeId;
        //        item.Mappe_GUID = i.Mappe_GUID;
        //        item.Historikk = i.Historikk;
        //        item.AntallGravlagte = i.AntallGravlagte;
        //        item.ForfallAar = i.ForfallAar;
        //        item.SistGravlagt = i.SistGravlagt;
        //        item.Plassering = i.Plassering;
        //        item.FDato = i.FDato;
        //        item.DDato = i.DDato;
        //        item.GDato = i.GDato;
        //        item.UrneRekke = i.UrneRekke;
        //        item.ErUrnefelt = i.ErUrnefelt;
        //        item.Areal = i.Areal;
        //        item.FulltNavn = i.FulltNavn;
        //        item.PersonNr = i.PersonNr;
        //        item.PostNr = i.PostNr;
        //        item.ErDod = i.ErDod;
        //        item.FakturaMottaker_GUID = i.FakturaMottaker_GUID;
        //        item.Faktureres = i.Faktureres;
        //        item.PeriodeFra = i.PeriodeFra;
        //        item.PeriodeTil = i.PeriodeTil;
        //        item.Tekst = i.Tekst;
        //        item.Antall = i.Antall;
        //        item.PrisPr = i.PrisPr;
        //        item.Pris = i.Pris;
        //        if (i.OpprettetDato.Ticks > 0) { item.OpprettetDato = i.OpprettetDato; }
        //        item.Status = i.Status;
        //        if (i.FakturaMottaker_GUID != null && (i.PostNr == null || i.PostNr == ""))
        //        {
        //            item.Status = 99;
        //        }
        //        item.FesteTilbud_GUID = i.FesteTilbud_GUID;
        //        item.Beskrivelse = i.Beskrivelse;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<SrcReturnValue> ProduserFestetilbud(SrcLogonInfo logonInfo, string filter, string GravstedGuid, int PeriodeFra, bool Forfalte)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPProduserFesteTilbudWSResponse resp = new exeKIPProduserFesteTilbudWSResponse();
        //    resp = await KipWSClient.exeKIPProduserFesteTilbudWSAsync(logonInfo, filter, GravstedGuid, PeriodeFra, Forfalte);
        //    retur = resp.Body.exeKIPProduserFesteTilbudWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> ProduserFesteFaktura(SrcLogonInfo logonInfo, string FestetilbudListeGuid)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPProduserFesteFakturaWSResponse resp = new exeKIPProduserFesteFakturaWSResponse();
        //    resp = await KipWSClient.exeKIPProduserFesteFakturaWSAsync(logonInfo, FestetilbudListeGuid);
        //    retur = resp.Body.exeKIPProduserFesteFakturaWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> SlettFestetilbud(SrcLogonInfo logonInfo, string FestetilbudListeGuid)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPSlettFestetilbudWSResponse resp = new exeKIPSlettFestetilbudWSResponse();
        //    resp = await KipWSClient.exeKIPSlettFestetilbudWSAsync(logonInfo, FestetilbudListeGuid);
        //    retur = resp.Body.exeKIPSlettFestetilbudWSResult;

        //    return retur;
        //}


        //public async Task<SrcRapportPreview> ProduserFesteBrev(SrcLogonInfo logonInfo, string filter, string FestetilbudListeGuid, string Dato, string Frist)
        //{
        //    SrcRapportPreview retur = new SrcRapportPreview();

        //    System.DateTime dtDato;
        //    System.DateTime dtFrist;

        //    dtDato = System.Convert.ToDateTime(Dato);
        //    dtFrist = System.Convert.ToDateTime(Frist);

        //    exeKIPProduserFesteBrevWSResponse resp = new exeKIPProduserFesteBrevWSResponse();
        //    resp = await KipWSClient.exeKIPProduserFesteBrevWSAsync(logonInfo, filter, FestetilbudListeGuid, dtDato, dtFrist);
        //    retur = resp.Body.exeKIPProduserFesteBrevWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> FestetilbudTilBrev(SrcLogonInfo logonInfo, string FestetilbudListeGuid)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPFestetilbudTilBrevWSResponse resp = new exeKIPFestetilbudTilBrevWSResponse();
        //    resp = await KipWSClient.exeKIPFestetilbudTilBrevWSAsync(logonInfo, FestetilbudListeGuid);
        //    retur = resp.Body.exeKIPFestetilbudTilBrevWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> FestetilbudTilFaktura(SrcLogonInfo logonInfo, string FestetilbudListeGuid)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPFestetilbudTilFakturaWSResponse resp = new exeKIPFestetilbudTilFakturaWSResponse();
        //    resp = await KipWSClient.exeKIPFestetilbudTilFakturaWSAsync(logonInfo, FestetilbudListeGuid);
        //    retur = resp.Body.exeKIPFestetilbudTilFakturaWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> FestetilbudTilForfall(SrcLogonInfo logonInfo, string FestetilbudListeGuid)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    exeKIPFestetilbudTilForfaltWSResponse resp = new exeKIPFestetilbudTilForfaltWSResponse();
        //    resp = await KipWSClient.exeKIPFestetilbudTilForfaltWSAsync(logonInfo, FestetilbudListeGuid);
        //    retur = resp.Body.exeKIPFestetilbudTilForfaltWSResult;

        //    return retur;
        //}
        //#endregion

        //#region Sky

        //public async Task<List<Models.FakturaSkyDatoItem>> GetFakturaSkyDatoListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPFakturaSkyDatoerWSResponse resp = new getKIPFakturaSkyDatoerWSResponse();
        //    resp = await KipWSClient.getKIPFakturaSkyDatoerWSAsync(logonInfo);

        //    List<Models.FakturaSkyDatoItem> items = new List<Models.FakturaSkyDatoItem>();
        //    SrcFakturaSkyDato[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaSkyDatoerWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaSkyDatoItem item = new Models.FakturaSkyDatoItem();
        //        item.EksportNr = i.EksportNr;
        //        if (i.Dato.Ticks==0)
        //        {
        //            item.Dato = "Nye";
        //        }
        //        else
        //        {
        //            item.Dato = i.Dato.ToString("dd.MM.yyyy");
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.FakturaSkyListeItem>> GetFakturaSkyListeListe(SrcLogonInfo logonInfo, int EksportNr)
        //{
        //    exeKIPFakturSkyHentWSResponse resp = new exeKIPFakturSkyHentWSResponse();
        //    resp = await KipWSClient.exeKIPFakturSkyHentWSAsync(logonInfo, EksportNr);

        //    List<Models.FakturaSkyListeItem> items = new List<Models.FakturaSkyListeItem>();
        //    SrcFakturaSkyListe[] itemsWS;

        //    itemsWS = resp.Body.exeKIPFakturSkyHentWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaSkyListeItem item = new Models.FakturaSkyListeItem();
        //        item.FaktNr = i.FaktNr;
        //        item.KundeNr = i.KundeNr;
        //        item.Navn = i.Navn;
        //        item.PostNr = i.PostNr;
        //        item.FaktDato = i.FaktDato;
        //        item.ForfDato = i.ForfDato;
        //        item.KredittertDato = i.KredittertDato;
        //        item.PrisMMVA = i.PrisMMVA;
        //        item.Fellesraad = i.Fellesraad;
        //        item.PaVent = i.PaVent;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.PersonNr = i.PersonNr;
        //        item.Antall = i.Antall;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.FakturaSkyFilItem>> GetFakturaSkyFilListe(SrcLogonInfo logonInfo)
        //{

        //    FTPGetFileListWSResponse resp = new FTPGetFileListWSResponse();
        //    resp = await KipWSClient.FTPGetFileListWSAsync(logonInfo, "","*");

        //    List<Models.FakturaSkyFilItem> items = new List<Models.FakturaSkyFilItem>();
        //    SrcFakturaSkyFile[] itemsWS;

        //    itemsWS = resp.Body.FTPGetFileListWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaSkyFilItem item = new Models.FakturaSkyFilItem();
        //        item.Filnavn = i.Filnavn;
        //        item.Dato = i.Dato;
        //        if (i.Filnavn.IndexOf(".old")>0)
        //        {
        //            item.Highlight = false;
        //        }
        //        else
        //        {
        //            item.Highlight = true;
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<bool> FakturaEksportSky(SrcLogonInfo logonInfo)
        //{
        //    exeKIPFakturaEksportSkyWSResponse resp = new exeKIPFakturaEksportSkyWSResponse();
        //    SrcReturnValue rapPrev = new SrcReturnValue();
        //    resp = await KipWSClient.exeKIPFakturaEksportSkyWSAsync(logonInfo);

        //    return true;
        //}

        //#endregion

        //#region Ordre

        //public async Task<List<Models.FakturaOrdreItem>> GetFakturaOrdreListe(SrcLogonInfo logonInfo, string Filter, string Sortering )
        //{
        //    getKIPFakturaOrdreListeWSResponse resp = new getKIPFakturaOrdreListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaOrdreListeWSAsync(logonInfo, Filter, Sortering);

        //    List<Models.FakturaOrdreItem> items = new List<Models.FakturaOrdreItem>();
        //    SrcFakturaOrdre[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaOrdreListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaOrdreItem item = new Models.FakturaOrdreItem();
        //        item.OrdreDato = i.OrdreDato;
        //        item.Fellesraad = i.Fellesraad;
        //        item.OrdreGuid = i.OrdreGuid;
        //        item.OrdreNr = i.OrdreNr;
        //        item.BildeGuid = i.BildeGuid;
        //        item.LinkGuid = i.LinkGuid;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.KontaktNavn = i.KontaktNavn;
        //        if (i.UtfInnenDato.Ticks > 0) { item.UtfInnenDato = i.UtfInnenDato; }
        //        item.Beskrivelse = i.Beskrivelse;
        //        if (i.UtfortDato.Ticks > 0) { item.UtfortDato = i.UtfortDato; }
        //        item.FaktNr = i.FaktNr;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.Modul = i.Modul;
        //        item.KontoNr = i.KontoNr;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.FakturaOrdreItem> GetFakturaOrdre(SrcLogonInfo logonInfo, string OrdreGuid )
        //{
        //    getKIPFakturaOrdreWSResponse resp = new getKIPFakturaOrdreWSResponse();
        //    resp = await KipWSClient.getKIPFakturaOrdreWSAsync(logonInfo, OrdreGuid);

        //    Models.FakturaOrdreItem item = new Models.FakturaOrdreItem();
        //    SrcFakturaOrdre i = resp.Body.getKIPFakturaOrdreWSResult;


        //    item.OrdreDato = i.OrdreDato;
        //    item.Fellesraad = i.Fellesraad;
        //    item.OrdreGuid = i.OrdreGuid;
        //    item.OrdreNr = i.OrdreNr;
        //    item.BildeGuid = i.BildeGuid;
        //    item.LinkGuid = i.LinkGuid;
        //    item.KontaktGuid = i.KontaktGuid;
        //    item.KontaktNavn = i.KontaktNavn;
        //    if (i.UtfInnenDato.Ticks > 0) { item.UtfInnenDato = i.UtfInnenDato; }
        //    item.Beskrivelse = i.Beskrivelse;
        //    if (i.UtfortDato.Ticks > 0) { item.UtfortDato = i.UtfortDato; }
        //    item.FaktNr = i.FaktNr;
        //    item.SlettetAv = i.SlettetAv;
        //    if (i.SlettetDato.Ticks > 0) { item.SlettetDato = i.SlettetDato; }
        //    item.OpprettetAv = i.OpprettetAv;
        //    if (i.OpprettetDate.Ticks > 0) { item.OpprettetDate = i.OpprettetDate; }
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.Modul = i.Modul;
        //    item.KontoNr = i.KontoNr;
        //    item.infoBestilling = i.infoBestilling;
        //    return item;
        //    }

        //public async Task<SrcReturnValue> SetFakturaOrdre(SrcLogonInfo logonInfo, Models.FakturaOrdreItem item)
        //{
        //    SrcFakturaOrdre items = new SrcFakturaOrdre();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.OrdreDato = item.OrdreDato;
        //    items.Fellesraad = item.Fellesraad;
        //    items.OrdreGuid = item.OrdreGuid;
        //    items.OrdreNr = item.OrdreNr;
        //    items.BildeGuid = item.BildeGuid;
        //    items.LinkGuid = item.LinkGuid;
        //    items.KontaktGuid = item.KontaktGuid;
        //    if (item.UtfInnenDato.HasValue) { items.UtfInnenDato = (System.DateTime)item.UtfInnenDato; }
        //    items.Beskrivelse = item.Beskrivelse;
        //    if (item.UtfortDato.HasValue) { items.UtfortDato = (System.DateTime)item.UtfortDato; }
        //    items.FaktNr = item.FaktNr;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.Modul = item.Modul;
        //    items.KontoNr = item.KontoNr;

        //    setKIPFakturaOrdreWSResponse resp = new setKIPFakturaOrdreWSResponse();
        //    resp = await KipWSClient.setKIPFakturaOrdreWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPFakturaOrdreWSResult;

        //    return retur;
        //}

        //public async Task<removeKIPFakturaOrdreWSResponse> removeFakturaOrdre(SrcLogonInfo logonInfo, string OrdreGuid)
        //{
        //    return await KipWSClient.removeKIPFakturaOrdreWSAsync(logonInfo, OrdreGuid);
        //}

        //public async Task<SrcReturnValue> FakturerOrdre(SrcLogonInfo logonInfo, string OrdreGuid)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();
        //    exeKIPFakturerOrdreWSResponse resp = new exeKIPFakturerOrdreWSResponse();
        //    resp = await KipWSClient.exeKIPFakturerOrdreWSAsync(logonInfo, OrdreGuid);
        //    retur = resp.Body.exeKIPFakturerOrdreWSResult;
        //    return retur;
        //}

        //public async Task<List<Models.FakturaOrdrelinjeItem>> GetFakturaOrdrelinjeListe(SrcLogonInfo logonInfo, string OrdreGuid)
        //{
        //    getKIPFakturaOrdreLinjeListeWSResponse resp = new getKIPFakturaOrdreLinjeListeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaOrdreLinjeListeWSAsync(logonInfo, OrdreGuid);

        //    List<Models.FakturaOrdrelinjeItem> items = new List<Models.FakturaOrdrelinjeItem>();
        //    SrcFakturaOrdrelinje[] itemsWS;

        //    itemsWS = resp.Body.getKIPFakturaOrdreLinjeListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.FakturaOrdrelinjeItem item = new Models.FakturaOrdrelinjeItem();
        //        item.MomsKode = i.MomsKode;
        //        item.Fellesraad = i.Fellesraad;
        //        item.OrdreLinjeGuid = i.OrdreLinjeGuid;
        //        item.OrdreGuid = i.OrdreGuid;
        //        item.TjenesteNr = i.TjenesteNr;
        //        item.Antall = i.Antall;
        //        item.PrisUMVA = i.PrisUMVA;
        //        item.PrisMMVA = i.PrisMMVA;
        //        item.Tekst = i.Tekst;
        //        item.MVA = i.MVA;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.PrisPr = i.PrisPr;
        //        item.Enhet = i.Enhet;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<SrcReturnValue> SetFakturaOrdrelinje(SrcLogonInfo logonInfo, Models.FakturaOrdrelinjeItem item)
        //{
        //    SrcFakturaOrdrelinje items = new SrcFakturaOrdrelinje();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.MomsKode = item.MomsKode;
        //    items.Fellesraad = item.Fellesraad;
        //    items.OrdreLinjeGuid = item.OrdreLinjeGuid;
        //    items.OrdreGuid = item.OrdreGuid;
        //    items.TjenesteNr = item.TjenesteNr;
        //    items.Antall = item.Antall;
        //    items.PrisUMVA = item.PrisUMVA;
        //    items.PrisMMVA = item.PrisMMVA;
        //    items.Tekst = item.Tekst;
        //    items.MVA = item.MVA;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.PrisPr = item.PrisPr;
        //    items.Enhet = item.Enhet;

        //    setKIPFakturaOrdreLinjeWSResponse resp = new setKIPFakturaOrdreLinjeWSResponse();
        //    resp = await KipWSClient.setKIPFakturaOrdreLinjeWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPFakturaOrdreLinjeWSResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> setFakturaOrdrelinjeListe(SrcLogonInfo logonInfo, string ordreGuid, string tjenester)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    setKIPFakturaOrdrelinjeListeWSResponse resp = new setKIPFakturaOrdrelinjeListeWSResponse();
        //    resp = await KipWSClient.setKIPFakturaOrdrelinjeListeWSAsync(logonInfo, ordreGuid, tjenester);
        //    retur = resp.Body.setKIPFakturaOrdrelinjeListeWSResult;

        //    return retur;
        //}

        //public async Task<Models.FakturaOrdrelinjeItem> GetFakturaOrdrelinje(SrcLogonInfo logonInfo, string Ordre_GUID)
        //{
        //    getKIPFakturaOrdreLinjeWSResponse resp = new getKIPFakturaOrdreLinjeWSResponse();
        //    resp = await KipWSClient.getKIPFakturaOrdreLinjeWSAsync(logonInfo, Ordre_GUID);

        //    Models.FakturaOrdrelinjeItem item = new Models.FakturaOrdrelinjeItem();
        //    SrcFakturaOrdrelinje i = resp.Body.getKIPFakturaOrdreLinjeWSResult;

        //    item.MomsKode = i.MomsKode;
        //    item.Fellesraad = i.Fellesraad;
        //    item.OrdreLinjeGuid = i.OrdreLinjeGuid;
        //    item.OrdreGuid = i.OrdreGuid;
        //    item.TjenesteNr = i.TjenesteNr;
        //    item.Antall = i.Antall;
        //    item.PrisUMVA = i.PrisUMVA;
        //    item.PrisMMVA = i.PrisMMVA;
        //    item.Tekst = i.Tekst;
        //    item.MVA = i.MVA;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.PrisPr = i.PrisPr;
        //    item.Enhet = i.Enhet;
        //    return item;

        //}

        //public async Task<removeKIPFakturaOrdreLinjeWSResponse> removeFakturaOrdrelinjeItemWs(SrcLogonInfo logonInfo, string Ordre_GUID)
        //{
        //    return await KipWSClient.removeKIPFakturaOrdreLinjeWSAsync(logonInfo, Ordre_GUID);
        //}

        //#endregion

        //#region Abonnement

        //public async Task<List<Models.AbonnementTyperItem>> GetAbonnementTyperListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPAbonnementTyperListeWSResponse resp = new getKIPAbonnementTyperListeWSResponse();
        //    resp = await KipWSClient.getKIPAbonnementTyperListeWSAsync(logonInfo, "");

        //    List<Models.AbonnementTyperItem> items = new List<Models.AbonnementTyperItem>();
        //    SrcAbonnementTyper[] itemsWS;

        //    itemsWS = resp.Body.getKIPAbonnementTyperListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.AbonnementTyperItem item = new Models.AbonnementTyperItem();
        //        item.Konto = i.Konto;
        //        item.Fellesraad = i.Fellesraad;
        //        item.AbbFaktType_GUID = i.AbbFaktType_GUID;
        //        item.Beskrivelse = i.Beskrivelse;
        //        item.IntervallType = i.IntervallType;
        //        item.Intervall = i.Intervall;
        //        item.NesteFaktDato = i.NesteFaktDato;
        //        item.Id = i.Id;
        //        item.MottakerNavn = i.MottakerNavn;
        //        item.Adresse1 = i.Adresse1;
        //        item.Adresse2 = i.Adresse2;
        //        item.PostNr = i.PostNr;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.PostNrId = i.PostNrId;
        //        item.Publiser = i.Publiser;
        //        item.Forklaring = i.Forklaring;
        //        item.Tjenestenummer = i.Tjenestenummer;
        //        item.Betingelser = i.Betingelser;
        //        item.AbonnementType = i.AbonnementType;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.AbonnementTyperItem> GetAbonnementType(SrcLogonInfo logonInfo, string AbbFaktType_GUID)
        //{
        //    getKIPAbonnementTyperWSResponse resp = new getKIPAbonnementTyperWSResponse();
        //    resp = await KipWSClient.getKIPAbonnementTyperWSAsync(logonInfo, AbbFaktType_GUID);

        //    Models.AbonnementTyperItem item = new Models.AbonnementTyperItem();
        //    SrcAbonnementTyper i = resp.Body.getKIPAbonnementTyperWSResult;


        //    item.Konto = i.Konto;
        //    item.Fellesraad = i.Fellesraad;
        //    item.AbbFaktType_GUID = i.AbbFaktType_GUID;
        //    item.Beskrivelse = i.Beskrivelse;
        //    item.IntervallType = i.IntervallType;
        //    item.Intervall = i.Intervall;
        //    item.NesteFaktDato = i.NesteFaktDato;
        //    item.Id = i.Id;
        //    item.MottakerNavn = i.MottakerNavn;
        //    item.Adresse1 = i.Adresse1;
        //    item.Adresse2 = i.Adresse2;
        //    item.PostNr = i.PostNr;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.PostNrId = i.PostNrId;
        //    item.Publiser = i.Publiser;
        //    item.Forklaring = i.Forklaring;
        //    item.Tjenestenummer = i.Tjenestenummer;
        //    item.Betingelser = i.Betingelser;
        //    item.AbonnementType = i.AbonnementType;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetAbonnementTyper(SrcLogonInfo logonInfo, Models.AbonnementTyperItem item)
        //{
        //    SrcAbonnementTyper items = new SrcAbonnementTyper();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Konto = item.Konto;
        //    items.Fellesraad = item.Fellesraad;
        //    items.AbbFaktType_GUID = item.AbbFaktType_GUID;
        //    items.Beskrivelse = item.Beskrivelse;
        //    items.IntervallType = item.IntervallType;
        //    items.Intervall = item.Intervall;
        //    items.NesteFaktDato = item.NesteFaktDato;
        //    items.Id = item.Id;
        //    items.MottakerNavn = item.MottakerNavn;
        //    items.Adresse1 = item.Adresse1;
        //    items.Adresse2 = item.Adresse2;
        //    items.PostNr = item.PostNr;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.PostNrId = item.PostNrId;
        //    items.Publiser = item.Publiser;
        //    items.Forklaring = item.Forklaring;
        //    items.Tjenestenummer = item.Tjenestenummer;
        //    items.Betingelser = item.Betingelser;
        //    items.AbonnementType = item.AbonnementType;

        //    setKIPAbonnementTyperWSResponse resp = new setKIPAbonnementTyperWSResponse();
        //    resp = await KipWSClient.setKIPAbonnementTyperWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPAbonnementTyperWSResult;

        //    return retur;
        //}

        //public async Task<List<Models.AbonnementItem>> GetAbonnementListe(SrcLogonInfo logonInfo, string abonnementGuid)
        //{
        //    getKIPAbonnementListeWSResponse resp = new getKIPAbonnementListeWSResponse();
        //    resp = await KipWSClient.getKIPAbonnementListeWSAsync(logonInfo, abonnementGuid, "", "");

        //    List<Models.AbonnementItem> items = new List<Models.AbonnementItem>();
        //    SrcAbonnement[] itemsWS;

        //    itemsWS = resp.Body.getKIPAbonnementListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.AbonnementItem item = new Models.AbonnementItem();
        //        item.Abbonement_GUID = i.Abbonement_GUID;
        //        item.FulltNavn = i.FulltNavn;
        //        item.Adresse = i.Adresse;
        //        item.PostNr = i.PostNr;
        //        item.Sted = i.Sted;
        //        item.Pris = i.Pris;
        //        item.MidlertidigStop = i.MidlertidigStop;
        //        item.Kontakt_GUID = i.Kontakt_GUID;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.AbonnementItem> GetAbonnement(SrcLogonInfo logonInfo, string Abbonement_GUID)
        //{
        //    getKIPAbonnementWSResponse resp = new getKIPAbonnementWSResponse();
        //    resp = await KipWSClient.getKIPAbonnementWSAsync(logonInfo, Abbonement_GUID);

        //    Models.AbonnementItem item = new Models.AbonnementItem();
        //    SrcAbonnement i = new SrcAbonnement();


        //    item.Abbonement_GUID = i.Abbonement_GUID;
        //    item.FulltNavn = i.FulltNavn;
        //    item.Adresse = i.Adresse;
        //    item.PostNr = i.PostNr;
        //    item.Sted = i.Sted;
        //    item.Pris = i.Pris;
        //    item.MidlertidigStop = i.MidlertidigStop;
        //    item.Kontakt_GUID = i.Kontakt_GUID;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetAbonnement(SrcLogonInfo logonInfo, Models.AbonnementItem item)
        //{
        //    SrcAbonnement items = new SrcAbonnement();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Abbonement_GUID = item.Abbonement_GUID;
        //    items.FulltNavn = item.FulltNavn;
        //    items.Adresse = item.Adresse;
        //    items.PostNr = item.PostNr;
        //    items.Sted = item.Sted;
        //    items.Pris = item.Pris;
        //    items.MidlertidigStop = item.MidlertidigStop;
        //    items.Kontakt_GUID = item.Kontakt_GUID;

        //    setKIPAbonnementWSResponse resp = new setKIPAbonnementWSResponse();
        //    resp = await KipWSClient.setKIPAbonnementWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPAbonnementWSResult;

        //    return retur;

        //}

        //public async Task<List<Models.AbonnementInnholdItem>> GetAbonnementInnholdListe(SrcLogonInfo logonInfo, string Abbonement_GUID)
        //{
        //    getKIPAbonnementInnholdListeWSResponse resp = new getKIPAbonnementInnholdListeWSResponse();
        //    resp = await KipWSClient.getKIPAbonnementInnholdListeWSAsync(logonInfo, Abbonement_GUID);

        //    List<Models.AbonnementInnholdItem> items = new List<Models.AbonnementInnholdItem>();
        //    SrcAbonnementInnhold[] itemsWS;

        //    itemsWS = resp.Body.getKIPAbonnementInnholdListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.AbonnementInnholdItem item = new Models.AbonnementInnholdItem();
        //        item.AbbonementInnhold_GUID = i.AbbonementInnhold_GUID;
        //        item.TjenesteNr = i.TjenesteNr;
        //        item.Antall = i.Antall;
        //        item.Fellesraad = i.Fellesraad;
        //        item.Abbonement_GUID = i.Abbonement_GUID;
        //        item.Rabatt = i.Rabatt;
        //        item.Pris = i.Pris;
        //        item.Info = i.Info;
        //        item.Tekst = i.Tekst;
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

        //public async Task<Models.AbonnementInnholdItem> GetAbonnementInnhold(SrcLogonInfo logonInfo, string AbbonementInnhold_GUID)
        //{
        //    getKIPAbonnementInnholdWSResponse resp = new getKIPAbonnementInnholdWSResponse();
        //    resp = await KipWSClient.getKIPAbonnementInnholdWSAsync(logonInfo, AbbonementInnhold_GUID);

        //    Models.AbonnementInnholdItem item = new Models.AbonnementInnholdItem();
        //    SrcAbonnementInnhold i = new SrcAbonnementInnhold();


        //    item.AbbonementInnhold_GUID = i.AbbonementInnhold_GUID;
        //    item.TjenesteNr = i.TjenesteNr;
        //    item.Antall = i.Antall;
        //    item.Fellesraad = i.Fellesraad;
        //    item.Abbonement_GUID = i.Abbonement_GUID;
        //    item.Rabatt = i.Rabatt;
        //    item.Pris = i.Pris;
        //    item.Info = i.Info;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetAbonnementInnhold(SrcLogonInfo logonInfo, Models.AbonnementInnholdItem item)
        //{
        //    SrcAbonnementInnhold items = new SrcAbonnementInnhold();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.AbbonementInnhold_GUID = item.AbbonementInnhold_GUID;
        //    items.TjenesteNr = item.TjenesteNr;
        //    items.Antall = item.Antall;
        //    items.Fellesraad = item.Fellesraad;
        //    items.Abbonement_GUID = item.Abbonement_GUID;
        //    items.Rabatt = item.Rabatt;
        //    items.Pris = item.Pris;
        //    items.Info = item.Info;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;

        //    setKIPAbonnementInnholdWSResponse resp = new setKIPAbonnementInnholdWSResponse();
        //    resp = await KipWSClient.setKIPAbonnementInnholdWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPAbonnementInnholdWSResult;

        //    return retur;

        //}

        //#endregion

        //#region Vipps

        //public async Task<string> VippsBetaling(string betalingGuid)
        //{
        //    string retur = "";


        //    executeVippsBetalingResponse resp = new executeVippsBetalingResponse();
        //    resp = await KipWSClient.executeVippsBetalingAsync("", betalingGuid, "https://office.kirkedata.no", "https://office.kirkedata.no");
        //    retur = resp.Body.executeVippsBetalingResult;

        //    return retur;
        //}

        //public async Task<string> VippsCapture(string betalingGuid)
        //{
        //    string retur = "";


        //    VippsCapturePaymentsWSResponse resp = new VippsCapturePaymentsWSResponse();
        //    resp = await KipWSClient.VippsCapturePaymentsWSAsync(betalingGuid);
        //    retur = resp.Body.VippsCapturePaymentsWSResult;

        //    return retur;
        //}

        //#endregion

    }

}
