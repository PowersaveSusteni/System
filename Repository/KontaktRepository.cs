using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class KontaktRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public KontaktRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //#region Hovedfunksjoner kontakt

        //public async Task<List<Models.KontaktItem>> GetKontaktListe(SrcLogonInfo logonInfo, int antall, string filter, string sortering  )
        //{
        //    getKIPKontaktListeWSResponse resp = new getKIPKontaktListeWSResponse();
        //    resp = await KipWSClient.getKIPKontaktListeWSAsync(logonInfo, antall, filter, sortering );

        //    List<Models.KontaktItem> items = new List<Models.KontaktItem>();
        //    SrcKontakt[] itemsWS;

        //    itemsWS = resp.Body.getKIPKontaktListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.KontaktItem item = new Models.KontaktItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.KontaktGuid = i.KontaktGuid;
        //        item.ID = i.ID;
        //        item.ErKontakt = i.ErKontakt;
        //        item.FakturaEpost = i.FakturaEpost;
        //        item.FakturaEpostAdresse = i.FakturaEpostAdresse;
        //        item.Pub360RecNo = i.Pub360RecNo;
        //        item.OpprettetAv = i.OpprettetAv;
        //        item.OpprettetDate = i.OpprettetDate;
        //        item.EndretAv = i.EndretAv;
        //        item.EndretDato = i.EndretDato;
        //        item.SlettetAv = i.SlettetAv;
        //        item.SlettetDato = i.SlettetDato;
        //        item.KundeNr = i.KundeNr;
        //        item.PersonNr = i.PersonNr;
        //        item.Fodt = i.Fodt;
        //        item.FulltNavn = i.FulltNavn;
        //        item.Fornavn = i.Fornavn;
        //        item.Mellomnavn = i.Mellomnavn;
        //        item.Etternavn = i.Etternavn;
        //        item.Adresse = i.Adresse;
        //        item.PostNr = i.PostNr;
        //        item.Sted = i.Sted;
        //        item.KommuneNr = i.KommuneNr;
        //        item.Telefon = i.Telefon;
        //        item.TlfArb = i.TlfArb;
        //        item.Mobil = i.Mobil;
        //        item.Fax = i.Fax;
        //        item.EPost = i.EPost;
        //        item.BostedAdresse = i.BostedAdresse;
        //        item.BostedPostNr = i.BostedPostNr;
        //        item.BostedSted = i.BostedSted;
        //        item.TypeKunde = i.TypeKunde;
        //        item.DagerForfall = i.DagerForfall;
        //        item.ErDod = i.ErDod;
        //        item.KortNavn = i.KortNavn;
        //        item.Kommentar = i.Kommentar;
        //        item.FodeSted = i.FodeSted;
        //        item.ChkType = i.ChkType;
        //        item.ChkDate = i.ChkDate;
        //        item.SistEndretdato = i.SistEndretdato;
        //        item.SistEndringType = i.SistEndringType;
        //        item.IkkeSjekk = i.IkkeSjekk;
        //        item.SlektsnavnUgift = i.SlektsnavnUgift;
        //        item.SoknNr = i.SoknNr;
        //        item.TypeKontakt = i.TypeKontakt;
        //        item.Program = i.Program;
        //        item.DapsDato = i.DapsDato;
        //        item.MottaEpost = i.MottaEpost;
        //        item.TrossamfunnGuid = i.TrossamfunnGuid;
        //        item.DåpsSted = i.DåpsSted;
        //        item.SivStatId = i.SivStatId;
        //        item.Kjonn = i.Kjonn;
        //        item.PostNrId = i.PostNrId;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<Models.KontaktItem> GetKontakt(SrcLogonInfo LogonInfo, string kontaktGuid)
        //{

        //    getKIPKontaktWSResponse resp = new getKIPKontaktWSResponse();
        //    resp = await KipWSClient.getKIPKontaktWSAsync(LogonInfo, kontaktGuid);

        //    Models.KontaktItem item = new Models.KontaktItem();
        //    SrcKontakt i = resp.Body.getKIPKontaktWSResult;

        //    item.Fellesraad = i.Fellesraad;
        //    item.KontaktGuid = i.KontaktGuid;
        //    item.ID = i.ID;
        //    item.ErKontakt = i.ErKontakt;
        //    item.FakturaEpost = i.FakturaEpost;
        //    item.FakturaEpostAdresse = i.FakturaEpostAdresse;
        //    item.Pub360RecNo = i.Pub360RecNo;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.KundeNr = i.KundeNr;
        //    item.PersonNr = i.PersonNr;
        //    item.Fodt = i.Fodt;
        //    item.FulltNavn = i.FulltNavn;
        //    item.Fornavn = i.Fornavn;
        //    item.Mellomnavn = i.Mellomnavn;
        //    item.Etternavn = i.Etternavn;
        //    item.Adresse = i.Adresse;
        //    item.PostNr = i.PostNr;
        //    item.Sted = i.Sted;
        //    item.KommuneNr = i.KommuneNr;
        //    item.KommuneNavn = i.KommuneNavn;
        //    item.Telefon = i.Telefon;
        //    item.TlfArb = i.TlfArb;
        //    item.Mobil = i.Mobil;
        //    item.Fax = i.Fax;
        //    item.EPost = i.EPost;
        //    item.BostedAdresse = i.BostedAdresse;
        //    item.BostedPostNr = i.BostedPostNr;
        //    item.BostedSted = i.BostedSted;
        //    item.TypeKunde = i.TypeKunde;
        //    item.DagerForfall = i.DagerForfall;
        //    item.ErDod = i.ErDod;
        //    item.KortNavn = i.KortNavn;
        //    item.Kommentar = i.Kommentar;
        //    item.FodeSted = i.FodeSted;
        //    item.ChkType = i.ChkType;
        //    item.ChkDate = i.ChkDate;
        //    item.SistEndretdato = i.SistEndretdato;
        //    item.SistEndringType = i.SistEndringType;
        //    item.IkkeSjekk = i.IkkeSjekk;
        //    item.SlektsnavnUgift = i.SlektsnavnUgift;
        //    item.SoknNr = i.SoknNr;
        //    item.TypeKontakt = i.TypeKontakt;
        //    item.Program = i.Program;
        //    item.DapsDato = i.DapsDato;
        //    item.MottaEpost = i.MottaEpost;
        //    item.TrossamfunnGuid = i.TrossamfunnGuid;
        //    item.DåpsSted = i.DåpsSted;
        //    item.SivStatId = i.SivStatId;
        //    item.Kjonn = i.Kjonn;
        //    item.PostNrId = i.PostNrId;
        //    return item;

        //}

        //public async Task<Models.KontaktItem> FindKontakt(SrcLogonInfo LogonInfo, string personNr)
        //{
        //    findKIPKontaktWSResponse resp = new findKIPKontaktWSResponse();
        //    resp = await KipWSClient.findKIPKontaktWSAsync(LogonInfo, personNr);

        //    Models.KontaktItem item = new Models.KontaktItem();
        //    SrcKontakt i = resp.Body.findKIPKontaktWSResult;

        //    item.Fellesraad = i.Fellesraad;
        //    item.KontaktGuid = i.KontaktGuid;
        //    item.ID = i.ID;
        //    item.ErKontakt = i.ErKontakt;
        //    item.FakturaEpost = i.FakturaEpost;
        //    item.FakturaEpostAdresse = i.FakturaEpostAdresse;
        //    item.Pub360RecNo = i.Pub360RecNo;
        //    item.OpprettetAv = i.OpprettetAv;
        //    item.OpprettetDate = i.OpprettetDate;
        //    item.EndretAv = i.EndretAv;
        //    item.EndretDato = i.EndretDato;
        //    item.SlettetAv = i.SlettetAv;
        //    item.SlettetDato = i.SlettetDato;
        //    item.KundeNr = i.KundeNr;
        //    item.PersonNr = i.PersonNr;
        //    item.Fodt = i.Fodt;
        //    item.FulltNavn = i.FulltNavn;
        //    item.Fornavn = i.Fornavn;
        //    item.Mellomnavn = i.Mellomnavn;
        //    item.Etternavn = i.Etternavn;
        //    item.Adresse = i.Adresse;
        //    item.PostNr = i.PostNr;
        //    item.Sted = i.Sted;
        //    item.KommuneNr = i.KommuneNr;
        //    item.KommuneNavn = i.KommuneNavn;
        //    item.Telefon = i.Telefon;
        //    item.TlfArb = i.TlfArb;
        //    item.Mobil = i.Mobil;
        //    item.Fax = i.Fax;
        //    item.EPost = i.EPost;
        //    item.BostedAdresse = i.BostedAdresse;
        //    item.BostedPostNr = i.BostedPostNr;
        //    item.BostedSted = i.BostedSted;
        //    item.TypeKunde = i.TypeKunde;
        //    item.DagerForfall = i.DagerForfall;
        //    item.ErDod = i.ErDod;
        //    item.KortNavn = i.KortNavn;
        //    item.Kommentar = i.Kommentar;
        //    item.FodeSted = i.FodeSted;
        //    item.ChkType = i.ChkType;
        //    item.ChkDate = i.ChkDate;
        //    item.SistEndretdato = i.SistEndretdato;
        //    item.SistEndringType = i.SistEndringType;
        //    item.IkkeSjekk = i.IkkeSjekk;
        //    item.SlektsnavnUgift = i.SlektsnavnUgift;
        //    item.SoknNr = i.SoknNr;
        //    item.TypeKontakt = i.TypeKontakt;
        //    item.Program = i.Program;
        //    item.DapsDato = i.DapsDato;
        //    item.MottaEpost = i.MottaEpost;
        //    item.TrossamfunnGuid = i.TrossamfunnGuid;
        //    item.DåpsSted = i.DåpsSted;
        //    item.SivStatId = i.SivStatId;
        //    item.Kjonn = i.Kjonn;
        //    item.PostNrId = i.PostNrId;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetKontakt(SrcLogonInfo LogonInfo, Models.KontaktItem item)
        //{
        //    SrcKontakt items = new SrcKontakt();
        //    SrcReturnValue retur = new SrcReturnValue();

        //    items.Fellesraad = item.Fellesraad;
        //    items.KontaktGuid = item.KontaktGuid;
        //    items.ID = item.ID;
        //    items.ErKontakt = item.ErKontakt;
        //    items.FakturaEpost = item.FakturaEpost;
        //    items.FakturaEpostAdresse = item.FakturaEpostAdresse;
        //    items.Pub360RecNo = item.Pub360RecNo;
        //    items.OpprettetAv = item.OpprettetAv;
        //    items.OpprettetDate = item.OpprettetDate;
        //    items.EndretAv = item.EndretAv;
        //    items.EndretDato = item.EndretDato;
        //    items.SlettetAv = item.SlettetAv;
        //    items.SlettetDato = item.SlettetDato;
        //    items.KundeNr = item.KundeNr;
        //    items.PersonNr = item.PersonNr;
        //    items.Fodt = item.Fodt;
        //    items.FulltNavn = item.FulltNavn;
        //    items.Fornavn = item.Fornavn;
        //    items.Mellomnavn = item.Mellomnavn;
        //    items.Etternavn = item.Etternavn;
        //    items.Adresse = item.Adresse;
        //    items.PostNr = item.PostNr;
        //    items.KommuneNr = item.KommuneNr;
        //    items.Telefon = item.Telefon;
        //    items.TlfArb = item.TlfArb;
        //    items.Mobil = item.Mobil;
        //    items.Fax = item.Fax;
        //    items.EPost = item.EPost;
        //    items.BostedAdresse = item.BostedAdresse;
        //    items.BostedPostNr = item.BostedPostNr;
        //    items.TypeKunde = item.TypeKunde;
        //    items.DagerForfall = item.DagerForfall;
        //    items.ErDod = item.ErDod;
        //    items.KortNavn = item.KortNavn;
        //    items.Kommentar = item.Kommentar;
        //    items.FodeSted = item.FodeSted;
        //    items.ChkType = item.ChkType;
        //    items.ChkDate = item.ChkDate;
        //    items.SistEndretdato = item.SistEndretdato;
        //    items.SistEndringType = item.SistEndringType;
        //    items.IkkeSjekk = item.IkkeSjekk;
        //    items.SlektsnavnUgift = item.SlektsnavnUgift;
        //    items.SoknNr = item.SoknNr;
        //    items.TypeKontakt = item.TypeKontakt;
        //    items.Program = item.Program;
        //    items.DapsDato = item.DapsDato;
        //    items.MottaEpost = item.MottaEpost;
        //    items.TrossamfunnGuid = item.TrossamfunnGuid;
        //    items.DåpsSted = item.DåpsSted;
        //    items.SivStatId = item.SivStatId;
        //    items.Kjonn = item.Kjonn;
        //    items.PostNrId = item.PostNrId;

        //    setKIPKontaktWSResponse resp = new setKIPKontaktWSResponse();
        //    resp = await KipWSClient.setKIPKontaktWSAsync(LogonInfo, items);
        //    retur = resp.Body.setKIPKontaktWSResult;

        //    return retur;

        //}

        //public async Task<SrcReturnValue> SetKontaktPersonNr(SrcLogonInfo LogonInfo, string kontaktGuid, string personNr)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();

        //    setKIPKontaktPersonnrWSResponse resp = new setKIPKontaktPersonnrWSResponse();
        //    resp = await KipWSClient.setKIPKontaktPersonnrWSAsync(LogonInfo, kontaktGuid, personNr);
        //    retur = resp.Body.setKIPKontaktPersonnrWSResult;

        //    return retur;
        //}

        //#endregion


    }
}
