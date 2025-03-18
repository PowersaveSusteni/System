using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using Susteni.Models;
using Susteni.Models.Account;
using Susteni.Models.Home;
using Susteni.Models.Funksjoner;

using Susteni.Repository;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration Configuration;

        public HomeController(IConfiguration configuration, IStringLocalizerFactory factory)
        {
            Configuration = configuration;
        }


        public IActionResult Index()
        {
            string meny = HttpContext.Session.GetString("Menu");
            if (string.IsNullOrEmpty(meny))
            {
                ViewData["Menu"] = "Hjem";
            }
            else
            {
                ViewData["Menu"] = meny;
            }

            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["Hjem"] = HttpContext.Session.GetString("Hjem");

            //var authorizedTenants = dbContext.AuthorizedTenants.Where(x => x.TenantId != null && x.AuthorizedOn != null).ToList();
            return View();
        }

        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];

            return logonInfo;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult DialogSendSMS(string kontaktListe)
        {
            if (kontaktListe != null)
            {
                HttpContext.Session.SetString("kontaktListe", kontaktListe);
            }
            else
            {
                HttpContext.Session.SetString("kontaktListe", "");
            }
            return PartialView("Utsending");
        }

        public ActionResult DialogRapporter()
        {
            return PartialView("Rapporter");
        }

    
        public IActionResult Login()
        {
            AccountModel modell = new AccountModel();

            ViewData["Message"] = "Your contact page xxx.";

            return View(modell);
        }

        public IActionResult Hjem()
        {
            ViewData["Menu"] = "Hjem";
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["Logo"] = HttpContext.Session.GetString("Logo");

            ViewData["ChangeCustomer"] = HttpContext.Session.GetInt32("ChangeCustomer");


            HttpContext.Session.SetString("Menu", "Hjem");
            HttpContext.Session.SetString("Meny", "Hjem");
            return View();
        }

        public ActionResult newHandy(AccountModel modell)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);


            modell.LoginView.AutLevel = 9;

            return View("Login", modell);
        }

        public IActionResult Grunnregister()
        {
            ViewData["Menu"] = "Grunnregister";
            ViewData["Message"] = "Din side for kirkelige handlinger.";
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["ByttFellesraad"] = HttpContext.Session.GetInt32("ByttFellesraad");
            HttpContext.Session.SetString("Menu", "Admin");
            HttpContext.Session.SetString("Meny", "Grunnregister");
            return View();
        }

        public IActionResult Admin()
        {
            ViewData["Menu"] = "Admin";
            ViewData["Message"] = "Din side for kirkelige handlinger.";
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            ViewData["ByttFellesraad"] = HttpContext.Session.GetInt32("ByttFellesraad");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            HttpContext.Session.SetString("Meny", "Administrasjon");
            HttpContext.Session.SetString("Menu", "Admin");
            return View();
        }

        public async Task<ActionResult> AccountSigIn(AccountModel modell)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);

            int logonOk = 1;


            if (HttpContext.Session.GetInt32("AutNiva") > 0)
            {
                AccountLogOnInfoItem logonInfo = GetLogonInfo();
                AccountUserItem userItem = new AccountUserItem();

                logonInfo.UserId = modell.LoginView.UserId;
                logonInfo.Password = modell.LoginView.Password;

                userItem.UserId = modell.LoginView.UserId;
                userItem.Password = modell.LoginView.Password;
                userItem.SmsCode = modell.LoginView.SecretCode;
                userItem.logonInfo = logonInfo;

                ReturnValueItem retur = await accountRepository.verify2FaktorCode(userItem);
                if (retur.Status == 1) { logonOk = 2; } else { logonOk = -1; }
            }

            if (logonOk > 0)
            {
                AccountSignedInItem itmAcc = await accountRepository.GetToken(modell.LoginView.Email, modell.LoginView.Password);

                modell.LoginView.CustomId = itmAcc.CustomId;
                modell.LoginView.UserId = itmAcc.UserId;
                modell.LoginView.UserName = itmAcc.UserName;
                modell.LoginView.Password = modell.LoginView.Password;

                HttpContext.Session.SetString("UserId", itmAcc.CustomId);
                HttpContext.Session.SetString("Password", modell.LoginView.Password);
                HttpContext.Session.SetString("CustomerGuid", itmAcc.CustomId);
                HttpContext.Session.SetString("UserName", itmAcc.UserName);

                if (itmAcc.LogOnOk == 2 || logonOk == 2)
                {
                    ViewData["Menu"] = "Home";
                    ViewData["LogOnOk"] = "2";

                    HttpContext.Session.SetString("Menu", "Hjem");

                    AccountLogOnInfoItem logonInfo = new();
                    logonInfo.UserId = itmAcc.UserId;
                    logonInfo.Password = itmAcc.Password;
                    logonInfo.Server = Configuration["MySettings:Server"];
                    logonInfo.Database = Configuration["MySettings:Database"];
                    AccountSignedInItem item = await accountRepository.GetUserInfo(logonInfo);

                    modell.LoginView.CustomId = item.CustomId;
                    modell.LoginView.UserId = item.UserId;
                    modell.LoginView.UserName = item.UserName;
                    modell.LoginView.Password = modell.LoginView.Password;
                    modell.LoginView.SuperBruker = item.SuperBruker;
                    modell.LoginView.SuperAdmin = item.SuperAdmin;

                    HttpContext.Session.SetString("UserId", item.UserId);
                    HttpContext.Session.SetString("Password", modell.LoginView.Password);
                    HttpContext.Session.SetString("CustomerGuid", item.CustomId);
                    HttpContext.Session.SetString("CurrencyCode", item.CurrencyCode);
                    HttpContext.Session.SetString("UserName", item.UserName);
                    HttpContext.Session.SetString("Logo", item.CustomLogo);
                    HttpContext.Session.SetInt32("SuperAdmin", item.SuperAdmin);
                    HttpContext.Session.SetInt32("SuperBruker", item.SuperBruker);
                    HttpContext.Session.SetInt32("ChangeCustomer", item.SuperAdmin);

                    ViewData["Logo"] = item.CustomLogo;
                    ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
                    ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");


                    return View("Hjem", modell);
                }
                else
                {
                    modell.LoginView.AutLevel = itmAcc.AutLevel;
                    modell.LoginView.Mobil = itmAcc.Mobil;
                    return View("Login", modell);
                }
            }
            else
            {
                modell.LoginView.ErrorText = "Du har angitt ugyldig engangskode";
                modell.LoginView.ErrorTextHjelp = "";

                return View("LoginError", modell);
            }
        }

        public async Task<ActionResult> VerifyKode(AccountModel modell)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            AccountUserItem item = new();

            logonInfo.UserId = modell.LoginView.UserId;
            logonInfo.Password = modell.LoginView.Password;

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

        public async Task<ActionResult> NewHendy(AccountModel modell)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);
            //SrcLogonInfo logonInfo = GetLogonInfo();
            AccountSignedInItem itmAcc = new();
            itmAcc = await accountRepository.GetToken(modell.LoginView.Email, modell.LoginView.Password);

            //modell.LoginView.AutNiva = 9;

            return View("Login", modell);
        }

        public async Task<ActionResult> GetToken(AccountModel modell)
        {
            AccountRepository accountRepository = new AccountRepository(Configuration);

            AccountSignedInItem itmAcc = new();

            itmAcc = await accountRepository.GetToken(modell.LoginView.Email, modell.LoginView.Password);

            if (itmAcc != null)
            {


            HttpContext.Session.SetInt32("AutNiva", itmAcc.AutLevel);

            if (itmAcc.LogOnOk > 0 && itmAcc.AutLevel == 0)
            {
                ViewData["Menu"] = "Home";
                ViewData["LogOnOk"] = "2";

                HttpContext.Session.SetString("Menu", "Hjem");

                AccountLogOnInfoItem logonInfo = new();
                logonInfo.UserId = itmAcc.UserId;
                logonInfo.Password = itmAcc.Password;
                logonInfo.Server = Configuration["MySettings:Server"];
                logonInfo.Database = Configuration["MySettings:Database"];
                AccountSignedInItem item = await accountRepository.GetUserInfo(logonInfo);

                modell.LoginView.CustomId = item.CustomId;
                modell.LoginView.UserId = item.UserId;
                modell.LoginView.UserName = item.UserName;
                modell.LoginView.Password = modell.LoginView.Password;

                HttpContext.Session.SetString("UserId", item.UserId);
                HttpContext.Session.SetString("Password", modell.LoginView.Password);
                HttpContext.Session.SetString("CustomerGuid", item.CustomId);
                HttpContext.Session.SetString("CurrencyCode", item.CurrencyCode);
                HttpContext.Session.SetString("UserName", item.UserName);
                HttpContext.Session.SetString("Logo", item.CustomLogo);
                HttpContext.Session.SetInt32("SuperAdmin", item.SuperAdmin);
                HttpContext.Session.SetInt32("SuperBruker", item.SuperBruker);
                HttpContext.Session.SetInt32("RunVersion", item.RunVersion);

                HttpContext.Session.SetInt32("ChangeCustomer", item.SuperAdmin);
                ViewData["ChangeCustomer"] = HttpContext.Session.GetInt32("SuperBruker");
                ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
                ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");

                ViewData["Logo"] = item.CustomLogo;
            }
            else if (itmAcc.LogOnOk > 0)
            {
                modell.LoginView.CustomId = itmAcc.CustomId;
                modell.LoginView.UserId = itmAcc.UserId;
                modell.LoginView.UserName = itmAcc.UserName;
                modell.LoginView.AutLevel = itmAcc.AutLevel;
                return View("Login", modell);
            }
            else if (itmAcc.ErrorText.Length > 0)
            {
                if (itmAcc.ErrorText != null)
                {
                    modell.LoginView.ErrorText = itmAcc.ErrorText;
                }
                else
                {
                    modell.LoginView.ErrorText = "Du har oppgitt feil brukernavn eller passord.";
                    modell.LoginView.ErrorTextHjelp = "Sjekk at der ikke er mellomrom før eller etter brukernavnet/passordet";
                }
                
                return View("LoginError", modell);
            }

            return View("Hjem", modell);
            }
            else
            {
                modell.LoginView.ErrorText = "Du har oppgitt feil brukernavn eller passord.";
                modell.LoginView.ErrorTextHjelp = "Sjekk at der ikke er mellomrom før eller etter brukernavnet/passordet";

                return View("LoginError", modell);
            }

        }

       
        public string GetUserName()
        {

            string userId = "";
            string userName = "";
            string tennentId = "";

            if (User.Identity.IsAuthenticated)
            {
                userId = User.Identity.Name;
                ClaimsPrincipal currentUser = User;
                foreach (var c in currentUser.Claims)
                {
                    Debug.Print(c.Type);
                    Debug.Print(c.Value);
                    if (c.Type == "name")
                    {
                        userName = c.Value;
                    }
                }

            }
            return userName;
        }

        public IActionResult Logout()
        {
            AccountModel modell = new AccountModel();

            ViewData["Menu"] = "";
            ViewData["LogOnOk"] = "0";

            HttpContext.Session.Clear();

            ViewData["Bruker"] = "";
            ViewData["AccMedarbieder"] = 0;
            ViewData["AccKH"] = 0;
            ViewData["AccByra"] = 0;
            ViewData["AccGravplass"] = 0;
            ViewData["AccEngrafo"] = 0;
            ViewData["AccOkonomi"] = 0;
            ViewData["AccStatistikk"] = 0;
            ViewData["AccGrunnregister"] = 0;
            ViewData["AccKisteskanning"] = 0;
            ViewData["AcckWeb"] = 0;
            ViewData["SuperBruker"] = 0;
            ViewData["Brukernavn"] = "";
            ViewData["SuperAdmin"] = 0;

            return View(modell);
        }


        #region Statistikk

        [HttpGet]
        public async Task<string> GetListOfShips()
        {
            HomeModel modell = new HomeModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            string htmlCode = "";

            var ver = HttpContext.Session.GetInt32("RunVersion");

            htmlCode = "<div class='cards-container'>";

            List<ShipItem> items = await shipRepository.getShipListWithPicture(logonInfo);

            foreach (var i in items)
            {
                htmlCode += "<div class='k-card'>";
                htmlCode += "<div class='k-card-header'>";
                htmlCode += "<h5 class='k-card-title'>" + i.Name + "</h5>";
                htmlCode += "</div>";
                if (i.byte64Picture != null && i.byte64Picture.Length>0) { 
                    htmlCode += "<img class='k-card-image' alt='Ships' src='data:image/jpeg;base64," + i.byte64Picture + "' style='width: 100%'/>";
                }

                htmlCode += "<div class='k-actions k-card-actions k-actions-vertical'>";
                if (ver == 1)
                {
                    htmlCode += "<span class='k-card-action'><button type='button' class='commandMain' onclick='generators(¤" + i.ShipGuid + "¤,¤" + i.Name + "¤,¤" + i.ProfilGuid + "¤,¤" + i.ProfilName + "¤)'><img src='/images/court-filled.svg' style='width: 24px; height: 24px; margin-right: 5px;' />Energy optimizing</button></span>";
                }
                else
                {
                    htmlCode += "<span class='k-card-action'><button type='button' class='commandMain' onclick='powerProd(¤" + i.ShipGuid + "¤,¤" + i.Name + "¤,¤" + i.ProfilGuid + "¤,¤" + i.ProfilName + "¤)'><img src='/images/court-filled.svg' style='width: 24px; height: 24px; margin-right: 5px;' />Energy optimizing</button></span>";
                }

                htmlCode += "</div>";

                htmlCode += "</div>";

            }

            htmlCode += "</div>";

            return htmlCode;
        }

        #endregion


        [HttpGet]
        public string VisVelkommenInfo()
        {

            string htmlCode;

            htmlCode = System.IO.File.ReadAllText("wwwroot/html/proginfo.html");
            htmlCode = htmlCode.Replace("\r\n", "<br/>");


            return htmlCode;
        }


        #region Menyer

        public string MenyEngrafo()
        {

            string meny;

            meny = "<ul><li data-role='drawer-item'><span><img src='/images/Avtale.png' width = '32' height = '32' ></ span >< span class='k-item-text'>Bestillingliste</span></li>                <li data-role='drawer-item'><span><img src = '/images/Kalender.png' width='32' height='32'></span><span class='k-item-text'>Kalender bestilling</span></li>                <li data-role= 'drawer-item' >< span >< img src= '/images/Stell.png' width= '32' height= '32' ></ span >< span class='k-item-text'>Stellavtaler</span></li>                <li data-role='drawer-separator' class='separator'></li>                <li data-role='drawer-item'><span><img src = '/images/Church.png' width='32' height='32'></span><span class='k-item-text'>Gravplass</span></li></ul>";

            return meny;
        }

        #endregion

    }

}
