using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Susteni.Models;
using Susteni.Repository;
using Susteni.Models.Funksjoner;
using Susteni.Models.Account;
using Susteni.Models.HelpDesk;
using Susteni.Models.Ressurs;
using Microsoft.VisualBasic;
using System.Net.Mail;
using Microsoft.IdentityModel.Abstractions;
using Kendo.Mvc.Infrastructure.Implementation;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class FunctionsController : Controller
    {
        private readonly IConfiguration Configuration;

        public FunctionsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }

        public IActionResult Nyheter()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }

        public IActionResult TypeFuel()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }

        public IActionResult TypeEquipment()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }


        public IActionResult TypeShip()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }

        public IActionResult TypePowerProduction()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }


        public IActionResult SMSmaler()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }

        public IActionResult Vendor()
        {
            FunctionsModel modell = new FunctionsModel();
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");

            return View(modell);
        }

        [HttpGet]
        public async Task<ActionResult> ShipTypeOM(string ShipTypeOMGuid, string ShipTypeGuid)
        {
            FunctionsModel modell = new FunctionsModel();
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            Models.ShipTypeOperationModesItem item = new();

            if (ShipTypeOMGuid != null)
            {
                logonInfo.Parameters.filter = "OperationModeGuid='" + ShipTypeOMGuid + "'";
                item = await functionRepository.GetShipTypeOperationModes(logonInfo);
            }
            else
            {
                item.ShipTypeGuid = ShipTypeGuid;
            }

            modell.ShipTypeOperationModes = item;

            return PartialView("_OMType", modell);
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


        #region Meny

        public async Task<string> getMeny(string filterTekst)
        {
            string meny = "";
            string hovedmeny = HttpContext.Session.GetString("Menu");

            if (hovedmeny != null)
            {

                meny = HttpContext.Session.GetString("Menu" + hovedmeny);

                if (meny == null)
                {
                    FunctionsRepository funksjonerRepository = new FunctionsRepository(Configuration);
                    AccountLogOnInfoItem logonInfo = GetLogonInfo();
                    logonInfo.Parameters.filter = "MainMenu='" + hovedmeny + "'";

                    List<Models.MenuItem> items = await funksjonerRepository.GetMenyListe(logonInfo, filterTekst);


                    meny = "<ul>";

                    foreach (var i in items)
                    {
                        meny += "<li data-role='drawer-item' title='" + i.Function + "' id='" + i.URL + "'><span><img src='/images/" + i.Icon + ".svg' alt='" + i.Function + "' width='32' height='32'></span><span class='k-item-text'>" + i.Function + "</span></li>";
                    }

                    meny += "</ul>";

                    HttpContext.Session.SetString("Menu" + hovedmeny, meny);
                }
            }



                return meny;
            }

        #endregion

        #region Type fuel

        public async Task<ActionResult> GetFuelTypeList([DataSourceRequest] DataSourceRequest request)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.TypeFuelItem> items = new();

            items = await functionsRepository.GetFuelTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetTypeFuel([DataSourceRequest] DataSourceRequest request, string FuelTypeGuid)
        {
            FunctionsModel modell = new FunctionsModel();
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "FuelTypeGuid='" + FuelTypeGuid + "'";

            Models.TypeFuelItem item = new();

            item = await functionsRepository.GetFuelType(logonInfo);

            item.Metan2 = item.Metan;
            item.DensityMGO2 = item.DensityMGO;
            item.CarbonContent2 = item.CarbonContent;
            item.Cf2 = item.Cf;
            item.Lystgass2 = item.Lystgass;
            item.NOx2 = item.NOx;
            item.SOx2 = item.SOx;

            modell.TypeFuel = item;

            return PartialView("_TypeFuel", modell);
        }

        public async Task<ReturnValueItem> SetTypeFuel(FunctionsModel model)
        {
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            TypeFuelItem item = new();

            item = model.TypeFuel;


            item.Metan = item.Metan2;
            item.DensityMGO = item.DensityMGO2;
            item.CarbonContent = item.CarbonContent2;
            item.Cf = item.Cf2;
            item.Lystgass = item.Lystgass2;
            item.NOx = item.NOx2;
            item.SOx = item.SOx2;

            item.logonInfo = logonInfo;

            retur = await functionRepository.SetTypeFuel(item);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveTypeFuel(string fuelTypeGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "FuelTypeGuid='" + fuelTypeGuid + "'";

            Models.ReturnValueItem item = new();

            item = await functionsRepository.RemoveTypeFule(logonInfo);

            return item;
        }

        #endregion

        #region Type Equipment

        public async Task<ActionResult> GetEquipmentType(string EquipmentTypesGuid)
        {
            FunctionsModel modell = new FunctionsModel();
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "EquipmentTypesGuid='" + EquipmentTypesGuid + "'";

            Models.TypeEquipmentItem item = new();

            item = await functionRepository.GetEquipmentType(logonInfo);

            modell.TypeEquipment = item;

            return PartialView("_TypeEquipment", modell);
        }

        public async Task<ActionResult> GetTypeEquipmentList([DataSourceRequest] DataSourceRequest request)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.TypeEquipmentItem> items = new();

            items = await functionsRepository.GetEquipmentTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReturnValueItem> SetTypeEquipment(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            TypeEquipmentItem item = new();

            item = model.TypeEquipment;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.SetTypeEquipment(item);

            return retur;
        }



        public async Task<ReturnValueItem> RemoveTypeEquipment(string equipmentTypesGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "EquipmentTypesGuid='" + equipmentTypesGuid + "'";

            Models.ReturnValueItem item = new();

            item = await functionsRepository.RemoveTypeEquipment(logonInfo);

            return item;
        }

        #endregion

        #region Type Ship

        public async Task<ActionResult> GetTypeShip(string ShipTypeGuid)
        {
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            FunctionsModel modell = new FunctionsModel();

            logonInfo.Parameters.filter = "ShipTypeGuid='" + ShipTypeGuid + "'";

            Models.TypeShipItem item = new();

            item = await functionRepository.GetShipType(logonInfo);

            modell.TypeShip = item;

            return PartialView("_TypeShip", modell);
        }

        public async Task<ReturnValueItem> SetTypeShip(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            TypeShipItem item = new();
            item = model.TypeShip;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.SetTypeShip(item);

            return retur;
        }

        public async Task<ActionResult> GetTypeShipList([DataSourceRequest] DataSourceRequest request)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.TypeShipItem> items = new();

            items = await functionsRepository.GetShipTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReturnValueItem> RemoveTypeShip(string shipTypeGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "ShipTypeGuid='" + shipTypeGuid + "'";

            Models.ReturnValueItem item = new();

            item = await functionsRepository.RemoveTypeShip(logonInfo);

            return item;
        }



        public async Task<ActionResult> GetShipTypeGenerators(string GeneratorGuid, string ShipTypeGuid)
        {
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            FunctionsModel modell = new FunctionsModel();
            Models.ShipTypeGeneratorsItem item = new();

            if (GeneratorGuid != null)
            {
                logonInfo.Parameters.filter = "GeneratorGuid='" + GeneratorGuid + "'";
                item = await functionRepository.GetShipTypeGenerators(logonInfo);
            }
            else
            {
                item.ShipTypeGuid = ShipTypeGuid;
            }

            modell.ShipTypeGenerators = item;

            return PartialView("_ShipTypeGenerator", modell);
        }

        public async Task<ReturnValueItem> SetShipTypeGenerators(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipTypeGeneratorsItem item = new();
            item = model.ShipTypeGenerators;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.SetShipTypeGenerators(item);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveShipTypeGenerators(string shipTypeGeneratorGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = shipTypeGeneratorGuid;
            ReturnValueItem retur = new();

            retur = await functionsRepository.RemoveShipTypeGenerators(logonInfo);

            return retur;
        }

        public async Task<ActionResult> GetShipTypeGeneratorsListe([DataSourceRequest] DataSourceRequest request, string ShipTypeGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "ShipTypeGuid='" + ShipTypeGuid + "'";
            logonInfo.Parameters.order = "[Order]";

            List<Models.ShipTypeGeneratorsItem> items = new();

            items = await functionsRepository.GetShipTypeGeneratorsListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        public async Task<ActionResult> GetShipTypeOM(string GeneratorGuid, string ShipTypeGuid)
        {
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            FunctionsModel modell = new FunctionsModel();
            Models.ShipTypeOperationModesItem item = new();

            if (GeneratorGuid != null) { 
                logonInfo.Parameters.filter = "OperationModeGuid='" + GeneratorGuid + "'";
                item = await functionRepository.GetShipTypeOperationModes(logonInfo);
            }

            modell.ShipTypeOperationModes = item;

            return PartialView("_ShipTypeOM", modell);


        }

        public async Task<ReturnValueItem> SetShipTypeOperationModes(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipTypeOperationModesItem item = new();
            item = model.ShipTypeOperationModes;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.SetShipTypeOperationModes(item);

            return retur;
        }

 

        public async Task<ReturnValueItem> RemoveShipTypeOperationModes(string shipTypeOperationGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = shipTypeOperationGuid;
            ReturnValueItem retur = new();

            retur = await functionsRepository.RemoveShipTypeOperationModes(logonInfo);

            return retur;
        }

        public async Task<ActionResult> GetShipTypeOperationModesListe([DataSourceRequest] DataSourceRequest request, string ShipTypeGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "ShipTypeGuid='" + ShipTypeGuid + "'";
            logonInfo.Parameters.order = "[Order]";

            List<Models.ShipTypeOperationModesItem> items = new();

            items = await functionsRepository.GetShipTypeOperationModesListe(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        #endregion

        #region Type Powerproduction

        public async Task<ActionResult> GetTypePowerProduction(string TypeGuid)
        {
            FunctionsModel modell = new FunctionsModel();
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.TypePowerProductionItem item = new();


            if (TypeGuid != null)
            {
                logonInfo.Parameters.filter = "TypeGuid='" + TypeGuid + "'";

                item = await functionRepository.GetPowerProductionType(logonInfo);
            }

            modell.TypePowerProduction = item;

            return PartialView("_TypePowerProduction", modell);
        }

        public async Task<ActionResult> GetTypePowerProductionList([DataSourceRequest] DataSourceRequest request)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.TypePowerProductionItem> items = new();

            items = await functionsRepository.GetPowerProductionTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReturnValueItem> SetTypePowerProduction(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            TypePowerProductionItem item = new();

            item = model.TypePowerProduction;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.SetTypePowerProduction(item);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveTypePowerProduction(string TypeGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "TypeGuid='" + TypeGuid + "'";

            Models.ReturnValueItem item = new();

            item = await functionsRepository.RemoveTypePowerProduction(logonInfo);

            return item;
        }

        #endregion

        #region Equipment types

        public async Task<ActionResult> GetEquipmentLibraryList([DataSourceRequest] DataSourceRequest request)
        {
            FunctionsRepository FunctionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.EquipmentLibraryItem> items = new();

            items = await FunctionsRepository.GetEquipmentLibraryList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetEquipmentLibrary([DataSourceRequest] DataSourceRequest request, string LibraryGuid)
        {
            FunctionsModel modell = new FunctionsModel();
            FunctionsRepository functionRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "";

            EquipmentLibraryItem item = new();

            item = await functionRepository.GetLibraryEquipment(logonInfo);

            modell.EquipmentLibrary = item;

            return PartialView("_EquipmentLibraryInfo", modell);
        }


        public async Task<ReturnValueItem> SetEquipmentLibrary(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            EquipmentLibraryItem item = new();

            retur = await functionsRepository.SetEquipmentLibrary(item);

            return retur;
        }
        #endregion

        #region Vendor

        public async Task<ReturnValueItem> SetGeneratorVendor(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            GeneratorVendorItem item = model.GeneratorVendor;
            item.logonInfo = logonInfo;


            retur = await functionsRepository.SetGeneratorVendor(item);

            return retur;
        }

        public async Task<ActionResult> GetGeneratorVendor([DataSourceRequest] DataSourceRequest request, string GeneratorVendorGuid)
        {
            FunctionsModel modell = new FunctionsModel();
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "GeneratorVendorGuid='" + GeneratorVendorGuid + "'";

            Models.GeneratorVendorItem item = new();

            item = await functionsRepository.GetGeneratorVendor(logonInfo);

            modell.GeneratorVendor = item;

            return PartialView("_VendorInfo", modell);
        }

        public async Task<ActionResult> GetGeneratorVendorList([DataSourceRequest] DataSourceRequest request)
        {
            FunctionsRepository FunctionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.GeneratorVendorItem> items = new();

            items = await FunctionsRepository.GetGeneratorVendorList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReturnValueItem> RemoveGeneratorVendor(string GeneratorVendorGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            GeneratorVendorItem item = new();
            item.GeneratorVendorGuid = GeneratorVendorGuid;
            item.logonInfo = logonInfo;


            retur = await functionsRepository.RemoveGeneratorVendor(item);

            return retur;
        }

        public async Task<ReturnValueItem> ImportFuelComsuption(string GeneratorGuid, string FromGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            FuelComsuptionImportItem item = new();
            item.GeneratorGuid = GeneratorGuid;
            item.FromGuid = FromGuid;
            item.logonInfo = logonInfo;


            retur = await functionsRepository.ImportFuelComsuption(item);

            return retur;
        }

        public async Task<IActionResult> getVendorTreeview(string id, string menuName)
        {
            string img = "";

            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<GeneratorVendorModelItem> itemWS = new List<GeneratorVendorModelItem>();
            
            var result = new List<HierarchicalVendorItem>();

            img = @Url.Content("~/images/control-tree-filled.svg");

            result.Add(new HierarchicalVendorItem() { id = "Vendors", expanded = true, HasChildren = true, Name = "Vendoers", imageUrl = img });

            string oldId = "";

            itemWS = await functionsRepository.GetGeneratorVendorModelList(logonInfo);

            if (itemWS != null)
            {
                foreach (GeneratorVendorModelItem i in itemWS)
                {
                    if (i.GeneratorVendorGuid != oldId)
                    {
                        oldId = i.GeneratorVendorGuid;
                        img = @Url.Content("~/images/building-factory-1.svg");
                        result.Add(new HierarchicalVendorItem() { id = i.GeneratorVendorGuid, Eier = "Vendors",  HasChildren = true, Name = i.Vendor, expanded = false, niva = 1, imageUrl = img });
                    }
                }

                foreach (GeneratorVendorModelItem i in itemWS)
                {
                    img = @Url.Content("~/images/turbine-2-filled.svg");
                    result.Add(new HierarchicalVendorItem() { id = i.GeneratorModelGuid.ToString(), Eier = i.GeneratorVendorGuid, HasChildren = true, Name = i.Model, niva = 2, imageUrl = img });
                }
            }


            var result2 = result
                .Where(x => !string.IsNullOrEmpty(id) ? x.Eier == id : x.Eier == null)
                .Select(item => new
                {
                    id = item.id,
                    Text = item.Name,
                    expanded = item.expanded,
                    imageUrl = item.imageUrl,
                    hasChildren = item.HasChildren
                });

            return Json(result2);
        }

        public List<HierarchicalVendorItem> getSubMenus(List<GeneratorVendorModelItem> items, string VendorGuid)
        {
            var result = new List<HierarchicalVendorItem>();
            string img = "";
            foreach (GeneratorVendorModelItem i in items)
            {
                if (i.GeneratorVendorGuid == VendorGuid)
                {
                    img = @Url.Content("~/images/turbine-2-filled.svg");
                    result.Add(new HierarchicalVendorItem() { id = i.GeneratorModelGuid.ToString(), Eier = VendorGuid, HasChildren = true, Name = i.Model, niva = 2, imageUrl = img });
                }
            }

            return result;
        }


        #endregion

        #region Models

        public async Task<ActionResult> GetGeneratorModel(string GeneratorModelGuid, string GeneratorVendorGuid)
        {
            FunctionsModel modell = new FunctionsModel();
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            Models.GeneratorModelItem item = new();

            if (GeneratorModelGuid != null && GeneratorModelGuid != "")
            {
                logonInfo.Parameters.filter = "GeneratorModelGuid = '" + GeneratorModelGuid + "'";
                item = await functionsRepository.GetGeneratorModel(logonInfo);
                modell.GeneratorModel = item;
            }
            else
            {
                modell.GeneratorModel.GeneratorVendorGuid = GeneratorVendorGuid;

            }

            return PartialView("_ModelInfo", modell);
        }


        public async Task<ReturnValueItem> SetGeneratorModel(FunctionsModel model)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            GeneratorModelItem item = new();
            item = model.GeneratorModel;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.SetGeneratorModel(item);

            return retur;
        }


        public async Task<ReturnValueItem> ImportGeneratorModel(string shipGuid, string generatorModelGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            GeneratorImportItem item = new();
            item.ShipGuid = shipGuid;
            item.GeneratorModelGuid = generatorModelGuid;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.ImportGeneratorModel(item);

            return retur;
        }

        public async Task<ActionResult> GetGeneratorModelList([DataSourceRequest] DataSourceRequest request, string GeneratorVendorGuid)
        {
            FunctionsRepository FunctionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "GeneratorVendorGuid = '" + GeneratorVendorGuid + "'";
            List<Models.GeneratorModelItem> items = new();

            items = await FunctionsRepository.GetGeneratorModelList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        public async Task<ReturnValueItem> RemoveGeneratorModel(string GeneratorModelGuid)
        {
            FunctionsRepository functionsRepository = new FunctionsRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            GeneratorModelItem item = new();
            item.GeneratorModelGuid = GeneratorModelGuid;
            item.logonInfo = logonInfo;

            retur = await functionsRepository.RemoveGeneratorModel(item);

            return retur;
        }
        #endregion

    }


}
