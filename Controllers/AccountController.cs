using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
//using static Susteni.Startup;
using Susteni.Models.Account;
using Susteni.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Http;
using Susteni.Models;
using Newtonsoft.Json;
using Susteni.Models.Admin;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class AccountController : Controller
    {

        private readonly IConfiguration Configuration;

        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IActionResult Index()
        {
            AccountModel modell = new AccountModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            return View(modell);
        }

        public IActionResult Kunder()
        {
            AccountModel modell = new AccountModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");

            return View(modell);
        }


        public IActionResult Eier()
        {
            AccountModel modell = new AccountModel();

            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");

            return View(modell);
        }


        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }

        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];
            logonInfo.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");

            return logonInfo;
        }


        #region Dialogbokser

        public ActionResult DialogFiksRessurs()
        {
            return PartialView("_BrukerRessurs");
        }

        public ActionResult DialogNewUser()
        {
            return PartialView("NewUser");
        }


        public ActionResult DialogKundeNy()
        {
            return PartialView("_NyKunde");
        }

        public ActionResult DialogBrukerImport()
        {
            return PartialView("_BrukerImport");
        }

        #endregion

        #region Kunde

        //public async Task<ActionResult> getSystemInfoListe([DataSourceRequest] DataSourceRequest request, string filterTekst, string sortering)
        //{
        //    AccountRepository accountRepository = new AccountRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    List<Models.SystemInfoListeItem> items = await accountRepository.GetSystemInfoListe(logonInfo, filterTekst, sortering);

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);
        //}


        #endregion


        #region Pålogging

        //public async Task<ActionResult> getAccounts([DataSourceRequest] DataSourceRequest request)
        //{
        //    AccountRepository accountRepository = new (Configuration);
        //    SrcLogonInfo LogonInfo = GetLogonInfo();

        //    List<Models.AccountsItem> items = await accountRepository.AccountsList(LogonInfo.BrukerId, LogonInfo.Passord, config.Value.WebserviceDatabase, "","");

        //    DataSourceResult result = items.ToDataSourceResult(request);

        //    return Json(result);

        //}

        //public async Task setAktivFellesraad(AccountModel modell, string fellesraad, string navn)
        //{
        //    AccountRepository accountsRepository = new(Configuration);
        //    SoknRepository soknRepository = new SoknRepository(Configuration);

        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    await accountsRepository.setBrukerAktivFellesraad(logonInfo, fellesraad);

        //    Models.AccountLogonItem item = await accountsRepository.Account(logonInfo.BrukerId, logonInfo.Passord);

        //    modell.LoginView.CustomId = item.CustomId;
        //    modell.LoginView.UserName = item.UserName;
        //    modell.LoginView.UserId = item.UserId;

        //}

        //public async Task<ActionResult> AccountLogon(AccountModel modell)
        //{
        //    AccountRepository accountRepository = new AccountRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    Models.AccountLogonItem items = await accountRepository.Account(logonInfo.BrukerId, logonInfo.Passord);

        //    modell.LoginView.CustomId = items.CustomId;
        //    modell.LoginView.UserId = items.UserId;
        //    modell.LoginView.UserName = items.UserName;
        //    modell.LoginView.Password = logonInfo.Passord;

        //    HttpContext.Session.SetString("UserId", items.CustomId);
        //    HttpContext.Session.SetString("Password", logonInfo.Passord);
        //    HttpContext.Session.SetString("CustomId", items.CustomId);
        //    HttpContext.Session.SetString("UserName", items.UserName);

        //    return View("Index", modell);
        //}


        #endregion

        #region OAuth

        //[HttpPost]
        //public async Task<bool> LagreoAuthInfo(AccountModel modell)
        //{

        //    AccountRepository oauthinfoRepository = new AccountRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    Models.oAuthInfoItem item = new Models.oAuthInfoItem();

        //    #region Setter verdier


        //    item.Fellesraad = modell.oAuthInfo.Fellesraad;
        //    item.oAuthGuid = modell.oAuthInfo.oAuthGuid;
        //    item.AppId = modell.oAuthInfo.AppId;
        //    item.SecretId = modell.oAuthInfo.SecretId;
        //    item.TenantId = modell.oAuthInfo.TenantId;
        //    item.Aktiv = modell.oAuthInfo.Aktiv;

        //    #endregion

        //    logonInfo.AktivFellesraad = item.Fellesraad;

        //    await oauthinfoRepository.SetoAuthInfo(logonInfo, item);

        //    return true;
        //}

        //public async Task<ActionResult> GetoAuthInfo(string fellesraad)
        //{
        //    AccountModel modell = new AccountModel();
        //    AccountRepository oauthinfoRepository = new AccountRepository(Configuration);
        //    SrcLogonInfo logonInfo = GetLogonInfo();

        //    logonInfo.AktivFellesraad = fellesraad;
        //    oAuthInfoItem items = await oauthinfoRepository.GetoAuthInfo(logonInfo);

        //    modell.oAuthInfo.oAuthGuid = items.oAuthGuid;
        //    modell.oAuthInfo.AppId = items.AppId;
        //    modell.oAuthInfo.SecretId = items.SecretId;
        //    modell.oAuthInfo.TenantId = items.TenantId;
        //    modell.oAuthInfo.Aktiv = items.Aktiv;

        //    return PartialView("_oAuth", modell);
        //}

        #endregion

        #region Brukere

        public async Task<ActionResult> GetUserCustomerList([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.CustomerUserItem> items = new();

            items = await accountRepository.GetUserCustomerList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        public async Task<ActionResult> GetAccountUser([DataSourceRequest] DataSourceRequest request, string UserId)
        {
            AccountModel modell = new AccountModel();
            AccountRepository shipRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "Userid = '" + UserId + "'";

            Models.AccountUserItem item = new();

            item = await shipRepository.GetUserAccount(logonInfo);

            modell.AccountUser = item;

            return PartialView("_UserInfo", modell);
        }


        public async Task<ReturnValueItem> SetAccountUser(AccountModel model)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            AccountUserItem item = new();

            item = model.AccountUser;
            item.logonInfo = logonInfo;


            retur = await accountRepository.SetAccountUser(item);

            return retur;
        }


        public async Task<ReturnValueItem> DropAccountUser([DataSourceRequest] DataSourceRequest request, string UserId)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);

            ReturnValueItem retur = new();

            Models.AccountUserItem item = new();
            item.UserId = UserId;

            retur = await accountRepository.DropUserAccount(item);

            return retur;
        }


        public async Task<ReturnValueItem> SetActiveCustomerUser(string CustomerGuid)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            CustomerItem item = new();
            item.CustomerGuid = CustomerGuid;
            item.logonInfo = logonInfo;

            retur = await accountRepository.SetActiveCustomerUser(item);

            if (retur.Status >= 0)
            {
                AccountSignedInItem itemAcc = await accountRepository.GetUserInfo(logonInfo);

                HttpContext.Session.SetString("CurrencyCode", itemAcc.CurrencyCode);
                HttpContext.Session.SetString("CustomerGuid", itemAcc.CustomId);
                HttpContext.Session.SetString("Logo", itemAcc.CustomLogo);
                ViewData["Logo"] = itemAcc.CustomLogo;
            }

            return retur;
        }


        public async Task<ReturnValueItem> SendSMS(AccountModel modell)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            AccountUserItem item = new();

            logonInfo.UserId = modell.LoginView.UserId;
            logonInfo.Password = modell.LoginView.Password;

            item.UserId = modell.LoginView.UserId;
            item.logonInfo = logonInfo;

            ReturnValueItem retur = new();

            retur = await accountRepository.sendSMS(item);

            return retur;
        }


        public async Task<ActionResult> VerifyKode(AccountModel modell)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            AccountUserItem item = new();

            item.SmsCode = modell.LoginView.SecretCode;
            item.UserId = modell.LoginView.UserId;
            item.logonInfo = logonInfo;

            ReturnValueItem resp = await accountRepository.verifySMSCode(item);

            if (resp.Status == 1)
            {

                logonInfo.Parameters.filter = "Userid = '" + item.UserId + "'";
                Models.AccountUserItem itemUserInfo = new();
                itemUserInfo = await accountRepository.GetUserAccount(logonInfo);
                modell.LoginView.oAuthUrl = itemUserInfo.oAuthUrl;
                modell.LoginView.AutLevel = 10;
            }

            return View("Login", modell);
        }



        public async Task<ActionResult> GetUserShipList([DataSourceRequest] DataSourceRequest request, string UserId)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            List<Models.UsersShipItem> items = new();

            if (UserId != null)
            {
                logonInfo.Parameters.filter = "UserId = '" + UserId + "'";
                items = await accountRepository.GetUserShipList(logonInfo);
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<IActionResult> UserShipItem(string UserShipGuid, string UserId)
        {

            AccountRepository accountRepository = new AccountRepository(Configuration);

            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            var result = new List<HierarchicalUsersShipItem>();

            if (UserId != null)
            {
                logonInfo.Parameters.filter = "UserId = '" + UserId + "'";
            }

            List<UsersShipItem> items = await accountRepository.GetUserShipsItems(logonInfo);

                result.Add(new HierarchicalUsersShipItem() { UserShipGuid = "Ships", parentId = null, hasChildren = true, expanded = true, Name = "Ships", imageUrl = Url.Content("~/images/vehicle-boat-cargo-filled.svg") });

                foreach (Models.UsersShipItem i in items)
                {
                    string img = Url.Content("~/images/vehicle-boat-cargo-filled.svg");
                    result.Add(new HierarchicalUsersShipItem() { UserShipGuid = i.ShipGuid, parentId = "Ships", hasChildren = false, expanded = false, Name = i.Name, @checked = i.active, imageUrl = img });
                }

                var result2 = result
                    .Where(x => !string.IsNullOrEmpty(UserShipGuid) ? x.parentId == UserShipGuid : x.parentId == null)
                    .Select(item => new
                    {
                        UserShipGuid = item.UserShipGuid,
                        Name = item.Name,
                        expanded = item.expanded,
                        imageUrl = item.imageUrl,
                        hasChildren = item.hasChildren,
                        @checked = item.@checked
                    });

            return Json(result2);
        }

        public string getCurrency()
        {
            return HttpContext.Session.GetString("CurrencyCode");
        }

        public async Task<ReturnValueItem> SetUserShipsList(string UserId, string ShipGuidList)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            UsersShipsItem item = new();

            item.UserId = UserId;
            item.ShipGuidList = ShipGuidList;
            item.CustomerGuid = logonInfo.CustomerGuid;
            item.logonInfo = logonInfo;

            retur = await accountRepository.SetUserShipsItems(item);

            return retur;
        }


        [HttpPost]
        public async Task<ReturnValueItem> CreateUser(AccountModel modell)
        {

            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.AccountUserItem item = new();

            item = modell.AccountUser;
            item.AktivCustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            item.logonInfo = logonInfo;

            ReturnValueItem retur = await accountRepository.CreateUser(item);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> ChangeUsersPassword(string UserId, string Password)
        {

            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.AccountPassordItem item = new();

            item.UserId = UserId;
            item.Password = Password;

            ReturnValueItem retur = await accountRepository.ChangeUsersPassword(item);

            return retur;
        }

        #endregion


    }

}
