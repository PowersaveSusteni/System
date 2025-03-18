using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

using Susteni.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Telerik.SvgIcons;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class AccountRepository : Controller
    {

        private readonly IConfiguration Configuration;


        public AccountRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Kunder

        //public async Task<List<Models.SystemInfoListeItem>> GetSystemInfoListe(SrcLogonInfo logonInfo, string filter, string sortering)
        //{
        //    getKIPSystemInfoListeWSResponse resp = new getKIPSystemInfoListeWSResponse();
        //    resp = await KipWSClient.getKIPSystemInfoListeWSAsync(logonInfo, filter, sortering);

        //    List<Models.SystemInfoListeItem> items = new List<Models.SystemInfoListeItem>();
        //    SrcSystemInfo[] itemsWS;

        //    itemsWS = resp.Body.getKIPSystemInfoListeWSResult;

        //    foreach (var i in itemsWS)
        //    {
        //        Models.SystemInfoListeItem item = new Models.SystemInfoListeItem();
        //        item.Fellesraad = i.Fellesraad;
        //        item.Navn = i.Navn;
        //        items.Add(item);
        //    }
        //    return items;
        //}
                
        #endregion

        #region Pålogging og oversikt over alle fellesråd

        //[HttpPost]
        //public async Task<List<Models.AccountsItem>> AccountsList(string brukerId, string passord, string database, string token, string kode)
        //{
        //    getKIPAccountsWSResponse resp = new getKIPAccountsWSResponse();
        //    resp = await KipWSClient.getKIPAccountsWSAsync(brukerId, passord, database, token, kode);

        //    List<Models.AccountsItem> items = new List<Models.AccountsItem>();
        //    items = FromWsToAccountsItem(resp.Body.getKIPAccountsWSResult);

        //    return items;
        //}


        //private List<Models.AccountsItem> FromWsToAccountsItem(kip.kirkedata.webservices.SrcAccounts[] itemws)
        //{

        //    List<Models.AccountsItem> items = new List<Models.AccountsItem>();
        //    foreach (var i in itemws)
        //    {
        //        Models.AccountsItem item = new Models.AccountsItem();

        //        item.Fellesraad = i.Fellesraad;
        //        item.Navn = i.Navn;
        //        item.BrukerId = i.BrukerId;
        //        item.AktivFellesraad = i.AktivFellesraad;
        //        item.Fellesraad = i.Fellesraad;

        //        if (i.AktivFellesraad == null || i.AktivFellesraad.Length==0 )
        //        {
        //            item.AktivFellesraad = i.Fellesraad;
        //        }

        //        items.Add(item);
        //    }


        //    return items;
        //}


        #endregion

        #region Hente tilgangsrettigheter

        //[HttpPost]
        //public async Task<Models.AccountLogonItem> Account(string brukerId, string password)
        //{
        //    //SrcLogonInfo LogonInfo = new SrcLogonInfo();

        //    //LogonInfo.BrukerId = brukerId;
        //    //LogonInfo.Passord = password;
        //    //LogonInfo.Server = config.Value.WebserviceServer;
        //    //LogonInfo.Database = config.Value.WebserviceDatabase;

        //    getKIPAccountLogonWSResponse resp = new getKIPAccountLogonWSResponse();
        //    resp = await KipWSClient.getKIPAccountLogonWSAsync(LogonInfo);

        //    Models.AccountLogonItem item = new Models.AccountLogonItem();
        //    //SrcAccountLogon i = resp.Body.getKIPAccountLogonWSResult;

        //    //item.LogOnOk = 2;
        //    //item.CustomId = i.Fellesraad;
        //    //item.UserId = i.BrukerId;

        //    //item.UserId = brukerId;
        //    //item.Password = password;
        //    return item;
        //}
   
        #endregion

        #region  Sett aktiv fellesråd

        //public async Task<setKIPBrukerAktivFellesraadWSResponse> setBrukerAktivFellesraad(SrcLogonInfo LogonInfo, string fellesraad)
        //{
        //    return await KipWSClient.setKIPBrukerAktivFellesraadWSAsync(LogonInfo, fellesraad);
        //}

        #endregion

        #region logg på

        //public async Task<bool> sendSMS(AccountLogonItem LogonInfo, string brukerGuid)
        //{
        //    exeKIPSendSMSKodeWSResponse resp = new exeKIPSendSMSKodeWSResponse();
        //    resp = await KipWSClient.exeKIPSendSMSKodeWSAsync(LogonInfo, brukerGuid);

        //    return resp.Body.exeKIPSendSMSKodeWSResult;
        //}

        //public async Task<SrcVerifyBruker> verifySMSCode(SrcLogonInfo LogonInfo, string brukerId, string Code)
        //{
        //    exeKIPVerifySMSKodeWSResponse resp = new exeKIPVerifySMSKodeWSResponse();
        //    resp = await KipWSClient.exeKIPVerifySMSKodeWSAsync(LogonInfo, brukerId, Code);

        //    return resp.Body.exeKIPVerifySMSKodeWSResult;
        //}

        //public async Task<bool> verify2FaktorCode(SrcLogonInfo LogonInfo, string brukerId, string Code)
        //{
        //    exeKIPVerifyUserWSResponse resp = new exeKIPVerifyUserWSResponse();
        //    resp = await KipWSClient.exeKIPVerifyUserWSAsync(LogonInfo, brukerId, Code);

        //    return resp.Body.exeKIPVerifyUserWSResult;
        //}

        #endregion

        #region Token

        [HttpPost]
        public async Task<Models.AccountSignedInItem> GetToken(string brukerId, string passord)
        {
            Models.TokenItem item = new Models.TokenItem();
            AccountSignedInItem itemWS = new();

            itemWS.UserId = brukerId;
            itemWS.Password = passord;
            itemWS.logonInfo.UserId = brukerId;
            itemWS.logonInfo.Password = passord;
            itemWS.logonInfo.Server = Configuration["MySettings:Server"];
            itemWS.logonInfo.Database = Configuration["MySettings:Database"];
            string json = JsonConvert.SerializeObject(itemWS);

            string result = await SusteniExecuteJson("Account", "AccessToken", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.AccountSignedInItem>(result);

            return itemWS;
        }

        public async Task<ReturnValueItem> verify2FaktorCode(AccountUserItem item)
        {
            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "VerifyUser", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<Models.AccountSignedInItem> GetUserInfo(AccountLogOnInfoItem item)
        {
            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "GetUserInfo", json, "");

            AccountSignedInItem itemWS = JsonConvert.DeserializeObject<Models.AccountSignedInItem>(result);

            return itemWS;
        }

        //[HttpPost]
        //public async Task<Models.TokenItem> GetTokenAzure(string userId, string tennentId)
        //{
        //    getKIPAzureTokenWSResponse resp = new getKIPAzureTokenWSResponse();
        //    Models.TokenItem item = new Models.TokenItem();
        //    SrcToken itemWS = new();

        //    resp = await KipWSClient.getKIPAzureTokenWSAsync(userId, tennentId, config.Value.WebserviceDatabase, "99af6a7e-baff-4390-937e-05f95be9c73a");

        //    itemWS = resp.Body.getKIPAzureTokenWSResult;

        //    item.LogOnOk = itemWS.LogOnOk;
        //    item.AutNiva = itemWS.AutNiva;
        //    item.Mobil = itemWS.Mobil;
        //    item.AktivFellesraad = itemWS.AktivFellesraad;
        //    item.ErrorText = itemWS.ErrorText;
        //    item.ErrorNumber = itemWS.ErrorNumber;
        //    item.brukerId = itemWS.BrukerId;
        //    item.passord = itemWS.Passord;

        //    return item;
        //}

        #endregion

        #region Brukere


        [HttpPost]
        public async Task<List<Models.CustomerUserItem>> GetUserCustomerList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.CustomerUserItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Account", "GetCustomerUserList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.CustomerUserItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.AccountUserItem> GetUserAccount(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.AccountUserItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Account", "GetAccountUser", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.AccountUserItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<ReturnValueItem> SetAccountUser(Models.AccountUserItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "SetAccountUser", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> DropUserAccount(Models.AccountUserItem item)
        {
            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "DropUserAccount", json, "");

            ReturnValueItem retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<ReturnValueItem> CreateUser(Models.AccountUserItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "CreateUser", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> ChangeUsersPassword(Models.AccountPassordItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "ChangeUsersPassword", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetActiveCustomerUser(Models.CustomerItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "SetActiveCustomerUser", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> sendSMS(Models.AccountUserItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "SendSMS", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> verifySMSCode(Models.AccountUserItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "VerifySMSKode", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        public async Task<ReturnValueItem> VerifyUser(Models.AccountUserItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "VerifyUser", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }



        [HttpPost]
        public async Task<List<Models.UsersShipItem>> GetUserShipList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.UsersShipItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Account", "GetUserShipList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.UsersShipItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.UsersShipItem>> GetUserShipsItems(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.UsersShipItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Account", "GetUserShipsItems", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.UsersShipItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetUserShipsItems(UsersShipsItem item)
        {
            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Account", "SetUserShipsList", json, "");

            retur = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return retur;
        }

        #endregion

        public async Task<string> SusteniExecuteJson(string service, string funksjon, string json, string parameters)
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


        #region OAuth


        //public async Task<Models.oAuthInfoItem> GetoAuthInfo(SrcLogonInfo logonInfo)
        //{
        //    getKIPoAuthInfoWSResponse resp = new getKIPoAuthInfoWSResponse();
        //    resp = await KipWSClient.getKIPoAuthInfoWSAsync(logonInfo);

        //    Models.oAuthInfoItem item = new Models.oAuthInfoItem();
        //    SrcoAuthInfo i = resp.Body.getKIPoAuthInfoWSResult;


        //    item.Fellesraad = i.Fellesraad;
        //    item.oAuthGuid = i.oAuthGuid;
        //    item.AppId = i.AppId;
        //    item.SecretId = i.SecretId;
        //    item.TenantId = i.TenantId;
        //    item.Aktiv = i.Aktiv;
        //    return item;

        //}

        //public async Task<SrcReturnValue> SetoAuthInfo(SrcLogonInfo logonInfo, Models.oAuthInfoItem item)
        //{
        //    SrcoAuthInfo items = new SrcoAuthInfo();
        //    SrcReturnValue retur = new SrcReturnValue();
        //    items.Fellesraad = item.Fellesraad;
        //    items.oAuthGuid = item.oAuthGuid;
        //    items.AppId = item.AppId;
        //    items.SecretId = item.SecretId;
        //    items.TenantId = item.TenantId;
        //    items.Aktiv = item.Aktiv;

        //    setKIPoAuthInfoWSResponse resp = new setKIPoAuthInfoWSResponse();
        //    resp = await KipWSClient.setKIPoAuthInfoWSAsync(logonInfo, items);
        //    retur = resp.Body.setKIPoAuthInfoWSResult;

        //    return retur;

        //}



        #endregion
    }
}
