using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Susteni.Repository
{
    public class MailRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public MailRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Foldere

        //public async Task<List<Models.EpostFoldersItem>> GetFolderListe(SrcLogonInfo logonInfo)
        //{
        //    getKIPEpostFoldersWSResponse resp = new getKIPEpostFoldersWSResponse();
        //    resp = await KipWSClient.getKIPEpostFoldersWSAsync(logonInfo);

        //    List<Models.EpostFoldersItem> items = new List<Models.EpostFoldersItem>();
        //    SrcEpostFolders[] itemsWS;

        //    itemsWS = resp.Body.getKIPEpostFoldersWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.EpostFoldersItem item = new Models.EpostFoldersItem();
        //        item.FolderId = i.FolderId;
        //        item.Name = i.Name;
        //        item.ParentFolderid= i.ParentFolderid;
        //        item.AdmEnhEpostGuid = i.AdmEnhEpostGuid;
        //        item.RootNavn = i.RootNavn;
        //        item.ePostType = i.ePostType;
        //        items.Add(item);
        //    }
        //    return items;
        //}



        #endregion

        #region Mail

        //public async Task<List<Models.MailItem>> GetMailListe(SrcLogonInfo logonInfo, string folderId, string epostGuid, int epostType)
        //{
        //    getKIPEpostItemsWSResponse resp = new getKIPEpostItemsWSResponse();
        //    resp = await KipWSClient.getKIPEpostItemsWSAsync(logonInfo, folderId, epostGuid, epostType);

        //    List<Models.MailItem> items = new List<Models.MailItem>();
        //    SrcMailItems[] itemsWS;

        //    itemsWS = resp.Body.getKIPEpostItemsWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.MailItem item = new Models.MailItem();
        //        item.Id = i.Id;
        //        item.Subject = i.Subject;
        //        item.From= i.From;
        //        item.HasAttachments = i.HasAttachments;
        //        item.DateTimeReceived = i.DateTimeReceived;
        //        item.BodyText = i.Body;
        //        item.ePostType = epostType;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<List<Models.MailAttatchmentItem>> GetMailAttachment(SrcLogonInfo logonInfo, string mailId, string epostGuid, int ePostType)
        //{
        //    getKIPMailAttatechmentWSResponse resp = new getKIPMailAttatechmentWSResponse();
        //    resp = await KipWSClient.getKIPMailAttatechmentWSAsync(logonInfo, mailId, epostGuid, ePostType);

        //    List<Models.MailAttatchmentItem> items = new List<Models.MailAttatchmentItem>();
        //    SrcMailAttatchment[] itemsWS;

        //    itemsWS = resp.Body.getKIPMailAttatechmentWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.MailAttatchmentItem item = new Models.MailAttatchmentItem();
        //        item.Name = i.Name;
        //        item.Extension = i.Extension;
        //        items.Add(item);
        //    }
        //    return items;
        //}

        //public async Task<SrcReturnValue> ArkiverEpost(SrcLogonInfo logonInfo, Models.MailItem item)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();
        //    exeKIPArkiverEpostWSResponse resp = new exeKIPArkiverEpostWSResponse();
        //    SrcMailItems itemWS = new SrcMailItems();

        //    itemWS.Id = item.Id;
        //    itemWS.Subject = item.Subject;
        //    itemWS.Body = item.BodyText;    
        //    itemWS.PDF = item.PDF;
        //    itemWS.HasAttachments = item.HasAttachments;
        //    itemWS.MainAttachements = item.MainAttachements;
        //    itemWS.Attachements = item.Attachements;
        //    itemWS.IsNew = item.IsNew;
        //    itemWS.DateTimeReceived = item.DateTimeReceived;
        //    itemWS.From = item.From;
        //    itemWS.KontaktGuid = item.KontaktGuid;
        //    itemWS.Navn = item.Navn;
        //    itemWS.Adresse = item.Adresse;
        //    itemWS.Postnr = item.Postnr;
        //    itemWS.Sted = item.Sted;
        //    itemWS.JournalDato = item.JournalDato;
        //    itemWS.ArkivSom = item.ArkivSom;
        //    itemWS.TilgangsGruppe = item.TilgangsGruppe;
        //    itemWS.SkalIkkeBesvares = item.SkalIkkeBesvares;
        //    itemWS.mappeGuid = item.mappeGuid;
        //    itemWS.KunVedlegg = item.KunVedlegg;
        //    itemWS.DefaultvalueSet = item.DefaultvalueSet;
        //    itemWS.ePostGuid = item.ePostGuid;
        //    itemWS.ePostType = item.ePostType;

        //    resp = await KipWSClient.exeKIPArkiverEpostWSAsync(logonInfo, itemWS);
        //    retur = resp.Body.exeKIPArkiverEpostWSResult;

        //    return retur;
        //}

        //public async Task<SrcReturnValue> SendEpost(SrcLogonInfo logonInfo, Models.SendMailItems item)
        //{
        //    SrcReturnValue retur = new SrcReturnValue();
        //    SendEPostResponse resp = new SendEPostResponse();
        //    SrcSendMailItems itemWS = new SrcSendMailItems();

        //    itemWS.mailTo = item.mailTo;
        //    itemWS.mailCC = item.mailCC;
        //    itemWS.mailBC = item.mailBC;
        //    itemWS.replyAdress = item.replyAdress;
        //    itemWS.subject = item.subject;
        //    itemWS.body = item.body;
        //    itemWS.title = item.title;

        //    resp = await KipWSClient.SendEPostAsync(logonInfo, itemWS);
        //    retur = resp.Body.SendEPostResult;

        //    return retur;
        //}

        #endregion


    }
}
