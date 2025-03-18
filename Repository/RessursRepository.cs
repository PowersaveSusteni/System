using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Susteni.Models.Ressurs;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class RessursRepository : Controller
    {

        private readonly IConfiguration Configuration;

        public RessursRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Import inbox

        //public async Task<List<Models.RessursInboxItem>> GetRessursInboxListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPFrivilligInboxListeWSResponse resp = new getKIPFrivilligInboxListeWSResponse();
        //    resp = await KipWSClient.getKIPFrivilligInboxListeWSAsync(logonInfo);

        //    List<Models.RessursInboxItem> items = new List<Models.RessursInboxItem>();
        //    SrcFrivilligInbox[] itemsWS;

        //    itemsWS = resp.Body.getKIPFrivilligInboxListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.RessursInboxItem item = new Models.RessursInboxItem();
        //        item.Mobil = i.Mobil;
        //        item.RegistrertDato = i.RegistrertDato;
        //        item.RessursInbox_GUID = i.RessursInbox_GUID;
        //        item.Slektsnavn = i.Slektsnavn;
        //        item.Postadresse = i.Postadresse;
        //        item.Postnummer = i.Postnummer;
        //        item.Poststed = i.Poststed;
        //        item.Foedselsdato = i.Foedselsdato;
        //        item.Merknad = i.Merknad;
        //        item.Epostadresse = i.Epostadresse;
        //        item.RessursFrivilligFunksjonSokn_GUID = i.RessursFrivilligFunksjonSokn_GUID;
        //        item.FulltNavn = i.FulltNavn;
        //        item.Fornavn = i.Fornavn;
        //        item.Mellomnavn = i.Mellomnavn;
        //        item.ImportertDato = i.ImportertDato;
        //        item.SlettBestillingDato = i.SlettBestillingDato;
        //        item.MMRessursGuid = i.MMRessursGuid;
        //        item.RegistrertRessursGuid = i.RegistrertRessursGuid;
        //        item.Tittel = i.Tittel;
        //        item.TelefonPrivat = i.TelefonPrivat;
        //        item.TelefonArbeid = i.TelefonArbeid;
        //        item.MobilArbeid = i.MobilArbeid;
        //        item.EpostadresseArbeid = i.EpostadresseArbeid;
        //        item.Mandag = i.Mandag;
        //        item.Tirsdag = i.Tirsdag;
        //        item.Onsdag = i.Onsdag;
        //        item.Torsdag = i.Torsdag;
        //        item.Fredag = i.Fredag;
        //        item.Lordag = i.Lordag;
        //        item.Sondag = i.Sondag;
        //        item.Formiddag = i.Formiddag;
        //        item.Ettermiddag = i.Ettermiddag;
        //        item.Kveld = i.Kveld;
        //        item.Natt = i.Natt;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        #endregion

    }
}
