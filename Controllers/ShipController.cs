using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Kendo.Mvc.UI;
using Susteni.Repository;
using Susteni.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Susteni.Models.Ship;
using Microsoft.AspNetCore.Http;
using Susteni.Models.Customer;
using System;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Abstractions;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using System.Threading;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Susteni.Models.Home;
using Telerik.Windows.Documents.Fixed.Model.Actions;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class ShipController : Controller
    {
        private readonly IConfiguration Configuration;

        public ShipController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            return View();
        }

        public IActionResult Ships()
        {
            ShipModel model = new ShipModel();

            model.Ship.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            ViewData["RunVersion"] = HttpContext.Session.GetInt32("RunVersion");

            return View(model);
        }


        public IActionResult NewShip()
        {
            ShipModel model = new ShipModel();

            model.Ship.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");

            return PartialView("_ShipInfo", model);
        }

        public IActionResult NewShipDialog()
        {
            ShipModel model = new ShipModel();

            model.Ship.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");

            return PartialView("_NewShip", model);
        }

        public IActionResult DialogGeneratorImport()
        {
            ShipModel model = new ShipModel();

            model.Ship.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");

            return PartialView("_GeneratorImport", model);
        }

        public async Task<IActionResult> FuelSavings(string shipGuid, string Name, string ProfilGuid, string ProfilName)
        {
            ShipModel model = new ShipModel();
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["RunVersion"] = HttpContext.Session.GetInt32("RunVersion");
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem item = new();
            item = GetLogonInfo();
            item.ShipGuid = shipGuid;
           
            ReturnValueItem retur = await shipRepository.SetActiveShip(item);
            if (retur.Success) { HttpContext.Session.SetString("Units", retur.Description); }

            model.Ship.ShipGuid = shipGuid;
            model.Ship.Name = Name;
            model.Ship.ProfilGuid = ProfilGuid;
            model.Ship.ProfilName = ProfilName;
            return View(model);
        }

        public async Task<IActionResult> ElProduction(string shipGuid, string Name, string ProfilGuid, string ProfilName)
        {
            ShipModel model = new ShipModel();
            ViewData["LogOnOk"] = "2";
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["RunVersion"] = HttpContext.Session.GetInt32("RunVersion");

            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem item = new();
            item = GetLogonInfo();
            item.ShipGuid = shipGuid;

            ReturnValueItem retur = await shipRepository.SetActiveShip(item);
            if (retur.Success) { 
                HttpContext.Session.SetString("Units", retur.Description);
                ViewData["Units"] = retur.Description;
            }

            model.Ship.ShipGuid = shipGuid;
            model.Ship.Name = Name;
            model.Ship.ProfilGuid = ProfilGuid;
            model.Ship.ProfilName = ProfilName;
            return View(model);
        }

        public async Task<IActionResult> PowerProduction(string shipGuid, string Name, string ProfilGuid, string ProfilName)
        {
            ShipModel model = new ShipModel();
            ViewData["LogOnOk"] = "2";
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["RunVersion"] = HttpContext.Session.GetInt32("RunVersion");

            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem item = new();
            item = GetLogonInfo();
            item.ShipGuid = shipGuid;

            ReturnValueItem retur = await shipRepository.SetActiveShip(item);
            if (retur.Success)
            {
                HttpContext.Session.SetString("Units", retur.Description);
                ViewData["Units"] = retur.Description;
            }

            model.Ship.ShipGuid = shipGuid;
            model.Ship.Name = Name;
            model.Ship.ProfilGuid = ProfilGuid;
            model.Ship.ProfilName = ProfilName;
            return View(model);
        }
        




        [HttpPost]
        public async Task<IActionResult> DuplicateShipTypeGenerator(string generatorGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            // Buscar o gerador original pelo ID
            ShipTypeGeneratorItem generator = await shipRepository.GetShipTypeGenerator(generatorGuid);

            if (generator == null)
            {
                return Json(new { success = false, message = "Gerador não encontrado." });
            }

            // Criar uma cópia do gerador
            ShipTypeGeneratorItem copy = new ShipTypeGeneratorItem
            {
                GeneratorGuid = Guid.NewGuid().ToString(), // Novo ID único
                ShipTypeGuid = generator.ShipTypeGuid,
                Name = generator.Name + " - Copy",
                TypeGuid = generator.TypeGuid,
                FuelTypeGuid = generator.FuelTypeGuid,
                kW = generator.kW,
                KgDieselkWh = generator.KgDieselkWh,
                EfficientMotorSwitchboard = generator.EfficientMotorSwitchboard,
                MaintenanceCost = generator.MaintenanceCost,
                Order = generator.Order,
                PowerProduction = generator.PowerProduction,
                Standard = generator.Standard
            };

            // Salvar a cópia no banco de dados
            ReturnValueItem result = await shipRepository.SetShipTypeGenerator(copy);

            if (result.Success)
            {
                return Json(new { success = true, message = "Gerador duplicado com sucesso!" });
            }
            else
            {
                return Json(new { success = false, message = "Erro ao duplicar o gerador." });
            }
        }

        public IActionResult Summary(string shipGuid, string Name, string ProfilGuid, string ProfilName)
        {
            ShipModel model = new ShipModel();
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["RunVersion"] = HttpContext.Session.GetInt32("RunVersion");

            model.Ship.ShipGuid = shipGuid;
            model.Ship.Name = Name;
            model.Ship.ProfilGuid = ProfilGuid;
            model.Ship.ProfilName = ProfilName;
            return View(model);
        }

        public async Task<IActionResult> InvestmentPlan(string shipGuid, string Name, string ProfilGuid, string ProfilName)
        {
            ShipModel model = new ShipModel();
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["RunVersion"] = HttpContext.Session.GetInt32("RunVersion");

            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem item = new();
            item = GetLogonInfo();
            item.ShipGuid = shipGuid;

            ReturnValueItem retur = await shipRepository.SetActiveShip(item);
            if (retur.Success) { HttpContext.Session.SetString("Units", retur.Description); }

            model.Ship.ShipGuid = shipGuid;
            model.Ship.Name = Name;
            model.Ship.ProfilGuid = ProfilGuid;
            model.Ship.ProfilName = ProfilName;
            model.Ship.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            return View(model);
        }


        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];
            logonInfo.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
            logonInfo.Currency = HttpContext.Session.GetString("CurrencyCode");

            return logonInfo;
        }

        #region dialogbokser

        public ActionResult DialogLastOppLogo()
        {
            return PartialView("_LastOppBilde");
        }

        public ActionResult DialogOperationMode()
        {
            ShipModel model = new ShipModel();

            return PartialView("_OperationMode", model);
        }

        public async Task<ActionResult> DialogEquipmentModeEdit(string equipmentModesGuid, string operationModeGuid, string equipmentGuid, string profilGuid)
        {
            ShipModel model = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);

            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "equipmentModesGuid='" + equipmentModesGuid + "'";

            if (equipmentModesGuid != null)
            {
                ShipEquipmentModesItem item = await shipRepository.GetShipEquipmentModes(logonInfo);
                model.ShipEquipmentModes = item;
            }
            else
            {
                model.ShipEquipmentModes.OperationModeGuid = operationModeGuid;
                model.ShipEquipmentModes.EquipmentGuid = equipmentGuid;
                model.ShipEquipmentModes.ProfilGuid = profilGuid;
            }

            return PartialView("_EquipmentMode", model);
        }


        public async Task<ActionResult> DialogFuelConsumption(string generatorGuid, string fuelConsGuid)
        {
            ShipModel model = new ShipModel();
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");

            if (fuelConsGuid != null && fuelConsGuid.Length > 0)
            {
                AccountLogOnInfoItem logonInfo = GetLogonInfo();
                ShipRepository shipRepository = new ShipRepository(Configuration);
                GeneratorFuelComsuptionItem item = new();
                logonInfo.Parameters.filter = "FuelConsGuid='" + fuelConsGuid + "'";
                item = await shipRepository.GetGeneratorFuelComsuption(logonInfo);
                item.kdDieselkWh2 = item.KgDieselkWh;
                model.GeneratorFuelComsuption = item;
            }
            else
            {
                model.GeneratorFuelComsuption.LinkGuid = generatorGuid;
            }

            return PartialView("_FuelConsumption", model);
        }

        public async Task<GeneratorFuelComsuptionItem> GetGeneratorFuelComsuption(string fuelConsGuid)
        {
            GeneratorFuelComsuptionItem item = new();

            if (fuelConsGuid != null && fuelConsGuid.Length > 0)
            {
                AccountLogOnInfoItem logonInfo = GetLogonInfo();
                ShipRepository shipRepository = new ShipRepository(Configuration);
                logonInfo.Parameters.filter = "FuelConsGuid='" + fuelConsGuid + "'";
                item = await shipRepository.GetGeneratorFuelComsuption(logonInfo);
            }
            return item;
        }

        public async Task<ActionResult> DialogGeneratorModeEdit(string generatorModeGuid, string operationModeGuid, string generatorGuid, string profilGuid)
        {
            ShipModel model = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);

            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "generatorModesGuid='" + generatorModeGuid + "'";

            if (generatorModeGuid != null && generatorModeGuid.Length > 0) {
                ShipGeneratorModesItem item = await shipRepository.GetShipGeneratorsModes(logonInfo);
                model.ShipGeneratorModes = item;
            }
            else
            {
                model.ShipGeneratorModes.GeneratorGuid = generatorGuid;
                model.ShipGeneratorModes.OperationModeGuid = operationModeGuid;
                model.ShipGeneratorModes.ProfilGuid = profilGuid;
            }
            
            return PartialView("_GeneratorMode", model);
        }

        public async Task<ActionResult> DialogGeneratorHoursEdit(string generatorModeGuid, string operationModeGuid, string generatorGuid, string profilGuid)
        {
            ShipModel model = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);

            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "generatorModesGuid='" + generatorModeGuid + "'";

            if (generatorModeGuid != null && generatorModeGuid.Length > 0)
            {
                ShipGeneratorModesItem item = await shipRepository.GetShipGeneratorsModes(logonInfo);
                model.ShipGeneratorModes = item;
            }
            else
            {
                model.ShipGeneratorModes.GeneratorGuid = generatorGuid;
                model.ShipGeneratorModes.OperationModeGuid = operationModeGuid;
                model.ShipGeneratorModes.ProfilGuid = profilGuid;
            }

            return PartialView("_GeneratorHours", model);
        }

        public ActionResult DialogHeatPowerGenerator(string shipGuid)
        {
            ShipModel model = new ShipModel();
            model.ShipGeneratorHeatUnit.ShipGuid = shipGuid;

            return PartialView("_HeatPowerGenerator", model);
        }

        public async Task<ActionResult> DialogHeatPowerGeneratorEdit(string HeatUnitGuid)
        {
            ShipModel modell = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);

            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "HeatUnitGuid='" + HeatUnitGuid + "'";

            ShipGeneratorHeatUnitItem items = await shipRepository.GetShipGeneratorHeatUnit(logonInfo);

            modell.ShipGeneratorHeatUnit = items;
            //modell.ShipGeneratorHeatUnit.HeatUnitGuid = items.HeatUnitGuid;
            //modell.ShipGeneratorHeatUnit.ShipGuid = items.ShipGuid;
            //modell.ShipGeneratorHeatUnit.Name = items.Name;
            //modell.ShipGeneratorHeatUnit.kW = items.kW;
            //modell.ShipGeneratorHeatUnit.HourPrday = items.HourPrday;
            //modell.ShipGeneratorHeatUnit.Factor = items.Factor;

            return PartialView("_HeatPowerGenerator", modell);
        }


        public ActionResult DialogEquipment(string shipGuid, int equipmentType, string profileGuid)
        {
            ShipModel model = new ShipModel();
            model.ShipEquipment.ShipGuid = shipGuid;
            model.ShipEquipment.EquipmentType = equipmentType;
            model.ShipEquipment.ProfilGuid = profileGuid;

            return PartialView("_ShipEquipment", model);
        }


        public async Task<ActionResult> DialogEquipmentEdit(string equipmentGuid)
        {
            ShipModel model = new ShipModel();

            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "EquipmentGuid='" + equipmentGuid + "'";

            Models.ShipEquipmentItem item = new();

            item = await shipRepository.GetShipEquipment(logonInfo);

            model.ShipEquipment = item;

            return PartialView("_ShipEquipment", model);
        }

        public async Task<ActionResult> DialogOperationModeEdit(string operationModeGuid)
        {
            ShipModel model = new ShipModel();

            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "OperationModeGuid='" + operationModeGuid + "'";

            Models.ShipOperationModeItem item = new();

            item = await shipRepository.GetShipOperationMode(logonInfo);

            model.ShipOperationMode = item;

            return PartialView("_OperationMode", model);
        }

        public ActionResult DialogGenerator()
        {
            ShipModel model = new ShipModel();

            return PartialView("_Generator", model);
        }

        public async Task<ActionResult> DialogGeneratorEdit(string generatorGuid)
        {
            ShipModel model = new ShipModel();

            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "GeneratorGuid='" + generatorGuid + "'";

            ShipGeneratorItem item = new();

            item = await shipRepository.GetShipGenerator(logonInfo);
            item.EfficientMotorSwitchboard2 = item.EfficientMotorSwitchboard;
            item.KgDieselkWh2 = item.KgDieselkWh;
            item.MaintenanceCost2 = item.MaintenanceCost;
            model.ShipGenerator = item;

            return PartialView("_Generator", model);
        }



        public ActionResult DialogProfil()
        {
            ShipModel model = new ShipModel();

            return PartialView("_ProfileNew", model);
        }

        public async Task<ActionResult> DialogProfilEdit(string profilGuid)
        {
            ShipModel model = new ShipModel();

            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "profilGuid='" + profilGuid + "'";

            Models.ProfileItem item = new();

            item = await shipRepository.GetProfile(logonInfo);
            if (item != null)
            {
                model.Profile = item;
            }

            return PartialView("_ProfileNew", model);
        }

            #endregion

        #region Ship

        public async Task<ActionResult> GetShipsList([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering, bool picture)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.ShipItem> items = new();

            if (strFilter == null) { strFilter = ""; }

            if (picture)
            {
                items = await shipRepository.getShipList(logonInfo);
            }
            else
            {
                items = await shipRepository.getShipListWithPicture(logonInfo);
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetShip(string shipGuid)
        {
            ShipModel modell = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (shipGuid != null)
            {
                logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";
            }

            ShipItem items = await shipRepository.getShip(logonInfo);

            modell.Ship = items;

            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");

            return PartialView("_ShipInfo", modell);
        }

        //public ActionResult NewShip()
        //{
        //    ShipModel modell = new ShipModel();
        //    modell.Ship.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");
        //    return PartialView("_ShipInfo", modell);
        //}


        public async Task<ReturnValueItem> SetShip(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipItem item = new();

            item = model.Ship;

            item.logonInfo = logonInfo;

            retur = await shipRepository.setShip(item);

            return retur;
        }

        public async Task<ReturnValueItem> CreateShip(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            NewShipItem item = new();

            item = model.NewShip;

            item.logonInfo = logonInfo;

            retur = await shipRepository.CreateShip(item);

            return retur;
        }

        public async Task<ReturValueItem> uploadPicture(string shipGuid, string base64string)
        {
            ShipModel modell = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            FilerItem item = new FilerItem();

            base64string = base64string.Replace("data:image/png;base64,", "");
            var bytes = Convert.FromBase64String(base64string);
            var stream = new MemoryStream(bytes);

            Bitmap bm_in = new(stream);
            if (bm_in.Width > 300 || bm_in.Height > 300 || bm_in.HorizontalResolution > 72)
            {

                try
                {
                    int width;
                    int height;
                    double scale;
                    double w;
                    double h;
                    width = bm_in.Width;
                    height = bm_in.Height;
                    w = bm_in.Width;
                    h = bm_in.Height;

                    if (width > height)
                    {
                        scale = (double)(h / w);
                        height = (int)(scale * 300);
                        width = 300;
                    }
                    else
                    {
                        scale = (double)(w / h);
                        width = (int)(scale * 300);
                        height = 300;
                    }

                    Bitmap bm_out = new Bitmap(width, height);
                    bm_out.SetResolution(72, 72);
                    Pen blackPen = new Pen(Color.DarkGray, 1);
                    Rectangle rect = new Rectangle(0, 0, width - 1, height - 1);

                    using (Graphics graphics = Graphics.FromImage(bm_out))
                    {
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.DrawImage(bm_in, 0, 0, bm_out.Width, bm_out.Height);
                        graphics.DrawRectangle(blackPen, rect);
                    }
                    bm_in.Dispose();
                    MemoryStream streamNew = new MemoryStream();
                    bm_out.Save(streamNew, System.Drawing.Imaging.ImageFormat.Png);
                    base64string = Convert.ToBase64String(streamNew.ToArray());
                }
                catch
                {

                }

            }

            item.LinkGuid = shipGuid;
            item.byte64string = base64string;


            ReturValueItem itemWS = await shipRepository.uploadPicture(logonInfo, item);

            return itemWS;
        }

        public async Task<ReturnValueItem> RemoveShip(string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReturnValueItem retur = new();

            if (shipGuid != null)
            {
                logonInfo.ShipGuid = shipGuid;
                retur = await shipRepository.RemoveShip(logonInfo);
            }

            return retur;
        }
        #endregion

        #region Types

        public async Task<ActionResult> GetShipTypeList([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.ShipTypeItem> items = new();

            items = await shipRepository.getShipTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetPowerProductionTypeList([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.PowerProductionTypeItem> items = new();

            items = await shipRepository.GetPowerProductionTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        #endregion

        #region Operation mode

        public async Task<ActionResult> GetShipOperationModeList([DataSourceRequest] DataSourceRequest request, string shipGuid, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "ShipGuid='" + shipGuid + "'";
            logonInfo.Parameters.order = "[Order]";
            logonInfo.Parameters.fieldValue = profilGuid;

            List<Models.ShipOperationModeItem> items = new();

            items = await shipRepository.GetShipOperationModeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<List<ShipOperationModeItem>> GetShipOperationModeDataList(string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "ShipGuid='" + shipGuid + "'";
            logonInfo.Parameters.order = "[Order]";

            List<Models.ShipOperationModeItem> items = new();

            items = await shipRepository.GetShipOperationModeList(logonInfo);

            return items;
        }

        public async Task<ReturnValueItem> SetShipOperationMode(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipOperationModeItem item = new();
            item = model.ShipOperationMode;
            //item.ShipGuid = model.ShipOperationMode.ShipGuid;
            //item.OperationModeGuid = model.ShipOperationMode.OperationModeGuid;
            //item.Order = model.ShipOperationMode.Order;
            //item.HoursPrYear = model.ShipOperationMode.HoursPrYear;
            //item.Name = model.ShipOperationMode.Name;
            if (item.OperationModeGuid == null) { item.OperationModeGuid = ""; }
            item.logonInfo = logonInfo;

            retur = await shipRepository.SetShipOperationMode(item);

            return retur;
        }

        public async Task<ShipOperationModeItem> GetShipOperationMode(string operationModeGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "OperationModeGuid='" + operationModeGuid + "'";

            Models.ShipOperationModeItem item = new();

            item = await shipRepository.GetShipOperationMode(logonInfo);

            return item;
        }

        public async Task<ShipOperationModeItem> RemoveShipOperationMode(string operationModeGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "OperationModeGuid='" + operationModeGuid + "'";

            Models.ShipOperationModeItem item = new();

            item = await shipRepository.RemoveShipOperationMode(logonInfo);

            return item;
        }

        #endregion

        #region Types

        public async Task<ActionResult> GetShipEquipmentTypeList([DataSourceRequest] DataSourceRequest request)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.ShipEquipmentTypeItem> items = new();

            items = await shipRepository.GetShipEquipmentTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetShipFuelTypeList([DataSourceRequest] DataSourceRequest request)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            List<Models.ShipFuelTypeItem> items = new();

            items = await shipRepository.GetShipFuelTypeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        #endregion

        #region Equipements

        public async Task<ShipEquipmentItem> GetShipEquipment(string equipmentGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "EquipmentGuid='" + equipmentGuid + "'";

            ShipEquipmentItem item = new();

            item = await shipRepository.GetShipEquipment(logonInfo);

            return item;
        }


        public async Task<ReturnValueItem> SetShipEquipment(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipEquipmentItem item = new();

            //item.EquipmentGuid = model.ShipEquipment.EquipmentGuid;
            //item.ShipGuid = model.ShipEquipment.ShipGuid;
            //item.Name = model.ShipEquipment.Name;
            //item.Model = model.ShipEquipment.Model;
            //item.Description = model.ShipEquipment.Description;
            //item.EquipmentType = model.ShipEquipment.EquipmentType;
            //item.MaxEffect = model.ShipEquipment.MaxEffect;
            //item.Order = model.ShipEquipment.Order;
            //item.Cost = model.ShipEquipment.Cost;
            //item.FinancielSupport = model.ShipEquipment.FinancielSupport;
            //item.Active = model.ShipEquipment.Active;
            //item.Year = model.ShipEquipment.Year;

            item = model.ShipEquipment;

            item.logonInfo = logonInfo;
            if (item.Model == null) { item.Model = ""; }

            retur = await shipRepository.SetShipEquipment(item);

            return retur;
        }


        public async Task<ActionResult> GetShipEquipmentList([DataSourceRequest] DataSourceRequest request, string shipGuid, int equipmentType, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (equipmentType > 0)
            {
                logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "' AND equipmentType=" + equipmentType;
            }
            else
            {
                logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";
            }

            if (profilGuid != null)
            {
                logonInfo.Parameters.filter += " AND ProfilGuid='" + profilGuid + "' ";
            }
            else
            {
                logonInfo.Parameters.filter += " AND ProfilGuid IS NULL ";
            }
            logonInfo.Parameters.order = "Name";


            List<ShipEquipmentItem> items = new();

            items = await shipRepository.GetShipEquipmentList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReturnValueItem> RemoveShipEquipment(string equipmentGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "EquipmentGuid='" + equipmentGuid + "'";

            ReturnValueItem item = new();

            item = await shipRepository.RemoveShipEquipment(logonInfo);

            return item;
        }

        #endregion

        #region Generator

        public async Task<ShipGeneratorItem> GetShipGenerator(string generatorGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "GeneratorGuid=" + generatorGuid;

            ShipGeneratorItem item = new();

            item = await shipRepository.GetShipGenerator(logonInfo);

            return item;
        }

        public async Task<ReturnValueItem> SetShipGenerator(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipGeneratorItem item = new();

            item = model.ShipGenerator;
            item.EfficientMotorSwitchboard = item.EfficientMotorSwitchboard2;
            item.KgDieselkWh = item.KgDieselkWh2;
            item.MaintenanceCost = item.MaintenanceCost2;
            item.logonInfo = logonInfo;

            retur = await shipRepository.SetShipGenerator(item);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveShipGenerator(string generatorGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "GeneratorGuid='" + generatorGuid + "'";

            Models.ReturnValueItem item = new();

            item = await shipRepository.RemoveShipGenerator(logonInfo);

            return item;
        }


        public async Task<ActionResult> GetShipGeneratorList([DataSourceRequest] DataSourceRequest request, string shipGuid, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";
            logonInfo.Parameters.order = "[Order], Name";

            if (profilGuid != null)
            {
                logonInfo.Parameters.field = " AND GEI.ProfilGuid='" + profilGuid + "' ";
                logonInfo.Parameters.fieldValue = " EM.ProfilGuid='" + profilGuid + "' ";
            }
            else
            {
                logonInfo.Parameters.field = " AND GEI.ProfilGuid IS NULL ";
                logonInfo.Parameters.fieldValue = " EM.ProfilGuid IS NULL ";
            }

            List<ShipGeneratorItem> items = new();

            if (shipGuid != null && shipGuid.Length > 0)
            {
                items = await shipRepository.GetShipGeneratorList(logonInfo);
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetShipGeneratorHeatUnitList([DataSourceRequest] DataSourceRequest request, string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";

            List<ShipGeneratorHeatUnitItem> items = new();

            items = await shipRepository.GetShipGeneratorHeatUnitList(logonInfo);

            foreach (ShipGeneratorHeatUnitItem item in items)
            {
                
                item.CalcProdkWh = Convert.ToInt32(item.kW * item.HourPrday * item.Factor * item.NumberOfDays);
                item.CalcFVS = Convert.ToInt32(item.CalcProdkWh * item.KgDieselkWh * item.DensityMGO / 1000);
                item.CalcCO2reduction = Convert.ToInt32(item.CalcFVS * 2.664);
                Single cf = Convert.ToSingle(item.CalcFVS);
                Single fcpy = Convert.ToSingle(item.FuelConsPrYear);

                item.CalcPreduction = cf / fcpy * 100;
            }
            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetShipGeneratorHeatUnit(string HeatUnitGuid)
        {
            ShipModel modell = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);

            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "HeatUnitGuid='" + HeatUnitGuid + "'";

            ShipGeneratorHeatUnitItem items = await shipRepository.GetShipGeneratorHeatUnit(logonInfo);

            modell.ShipGeneratorHeatUnit.HeatUnitGuid = items.HeatUnitGuid;
            modell.ShipGeneratorHeatUnit.ShipGuid = items.ShipGuid;
            modell.ShipGeneratorHeatUnit.Name = items.Name;
            modell.ShipGeneratorHeatUnit.kW = items.kW;
            modell.ShipGeneratorHeatUnit.HourPrday = items.HourPrday;
            modell.ShipGeneratorHeatUnit.Factor = items.Factor;

            return PartialView("_HeatPowerGenerator", modell);
        }

        public async Task<ReturnValueItem> SetShipGeneratorHeatUnit(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipGeneratorHeatUnitItem item = new();
            item.logonInfo = logonInfo;

            item.HeatUnitGuid = model.ShipGeneratorHeatUnit.HeatUnitGuid;
            item.ShipGuid = model.ShipGeneratorHeatUnit.ShipGuid;
            item.Name = model.ShipGeneratorHeatUnit.Name;
            item.kW = model.ShipGeneratorHeatUnit.kW;

            item.HourPrday = model.ShipGeneratorHeatUnit.HourPrday;
            item.Factor = model.ShipGeneratorHeatUnit.Factor;
            item.KgDieselkWh = model.ShipGeneratorHeatUnit.KgDieselkWh;
            item.EfficientMotorSwitchboard = model.ShipGeneratorHeatUnit.EfficientMotorSwitchboard;

            retur = await shipRepository.SetShipGeneratorHeatUnit(item);

            return retur;
        }


        public async Task<ActionResult> GetFuelComsuptionGeneratorList([DataSourceRequest] DataSourceRequest request, string generatorGuid)
        {
            ShipRepository ShipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "LinkGuid='" + generatorGuid + "'";
            logonInfo.Parameters.order = "Effect";

            List<Models.GeneratorFuelComsuptionItem> items = new();

            items = await ShipRepository.GetFuelComsuptionGeneratorList(logonInfo);

            foreach(GeneratorFuelComsuptionItem itm in items)
            {
                itm.kdDieselkWh2 = itm.KgDieselkWh;
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        public async Task<ActionResult> GetFuelComsuptionGeneratorChart([DataSourceRequest] DataSourceRequest request, string generatorGuid)
        {
            ShipRepository ShipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "LinkGuid='" + generatorGuid + "'";
            logonInfo.Parameters.order = "Effect";
            List<Models.GeneratorFuelComsuptionChartItem> items = new();

            items = await ShipRepository.GetGeneratorFuelComsuptionChart(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetGeneratorFuelComsuption([DataSourceRequest] DataSourceRequest request, string FuelConsGuid)
        {
            ShipModel modell = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            logonInfo.Parameters.filter = "";

            Models.GeneratorFuelComsuptionItem item = new();

            item = await shipRepository.GetFuelComsuptionGenerator(logonInfo);

            modell.GeneratorFuelComsuption = item;

            return PartialView("_FuelComsuptionInfo", modell);
        }

        public async Task<ReturnValueItem> SetGeneratorFuelComsuption(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            GeneratorFuelComsuptionItem item = new();
            item = model.GeneratorFuelComsuption;
            item.KgDieselkWh = item.kdDieselkWh2;
            item.logonInfo = logonInfo;


            retur = await shipRepository.SetGeneratorFuelComsuption(item);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveGeneratorFuelComsuption(string FuelConsGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            logonInfo.Parameters.field = FuelConsGuid;


            retur = await shipRepository.RemoveGeneratorFuelComsuption(logonInfo);

            return retur;
        }



        [HttpGet]
        public async Task<string> GetListOfGenerators(string shipGuid, string operationModeGuid, string profilGuid)
        {
            HomeModel modell = new HomeModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";
            logonInfo.Parameters.fieldValue = " AND operationModeGuid='" + operationModeGuid + "' ";
            if (profilGuid != null) {
                logonInfo.Parameters.fieldValue += " AND ProfilGuid='" + profilGuid + "' ";
            }
            else
            {
                logonInfo.Parameters.fieldValue += "AND ProfilGuid IS NULL ";
            }
            logonInfo.Parameters.order = "[Order], Name";

            string htmlCode = "";

            List<ShipGeneratorModesShortItem> items = new();

            if (operationModeGuid != null)
            {
                items = await shipRepository.GetShipGeneratorModesShortListe(logonInfo);
            }
            int iC = 0;
            htmlCode = "<div class='row'>";

            foreach (var i in items)
            {
                iC++;

                htmlCode += "<div class='col-3'>";
                if (!i.ActiveBefore)
                {
                    htmlCode += "<img alt='Ships' src='/images/energy-electricity-filled-disabled.svg' width=32 height=32 style='vertical-align: bottom'/>";
                }
                else
                {
                    htmlCode += "<img alt='Ships' src='/images/energy-electricity-filled.svg' width=32 height=32  style='vertical-align: bottom'/>";
                }
                if (!i.Active)
                {
                    htmlCode += "<img alt='Ships' src='/images/energy-electricity-filled-disabled.svg' width=64 height=64 style='vertical-align: bottom' />";
                }
                else
                {
                    htmlCode += "<img alt='Ships' src='/images/energy-electricity-filled.svg' width=64 height=64 style='vertical-align: bottom' />";
                }
                htmlCode += "<h5>" + i.Name + "</h5>";
                htmlCode += "<p>" + i.kW + " kW</p>";
                htmlCode += "<p>Hours before: " + i.HoursBefore + "h</p>";
                htmlCode += "<p>Hours after: " + i.HoursAfter + "h</p>";
                if (i.ExcludeAutoTune)
                {
                    htmlCode += "<p>Load after: " + i.PercentSaving + "%</p>";
                }
                htmlCode += "<div class='row' style='margin-bottom: 10px;'>";
                htmlCode += "<button class='commandInline' onclick='showDialogGeneratorModeEdit(¤" + i.GeneratorModesGuid + "¤,¤" + i.GeneratorGuid + "¤)'><img alt='Ships' src='/images/endre.svg' width=24 height=24 /></button>";
                
                if (i.GeneratorModesGuid != null && i.GeneratorModesGuid.Length>0)
                {
                    if (i.ExcludeAutoTune)
                    {
                        htmlCode += "<button class='commandInline'><img alt='Ships' src='/images/stop.svg' width=24 height=24 /></button>";
                    }
                    else if (!i.Active)
                    {
                        htmlCode += "<button class='commandInline' onclick='SetGeneratorOnOff(¤" + i.GeneratorModesGuid + "¤,true)'><img alt='Ships' src='/images/light-on-filled.svg' width=24 height=24 /></button>";
                    }
                    else
                    {
                        htmlCode += "<button class='commandInline' onclick='SetGeneratorOnOff(¤" + i.GeneratorModesGuid + "¤,false)'><img alt='Ships' src='/images/light-off-filled.svg' width=24 height=24 /></button>";
                    }
                }
                htmlCode += "</div>";
                htmlCode += "</div>";
            }

            htmlCode += "</div>";

            return htmlCode;
        }

        public async Task<ReturnValueItem> AutoTune(string shipGuid, string OperationModeGuid, string ProfilGuid, int MinNumberGenerator, int NecesseryPP)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.ShipGuid= shipGuid;

            ReturnValueItem retur = new();

            AutoTuneParameteritem item = new();
            item.OperationModeGuid = OperationModeGuid;
            item.ProfilGuid = ProfilGuid;
            item.MinNumberGenerator = MinNumberGenerator;
            item.NecesseryPP = NecesseryPP;
            item.logonInfo = logonInfo;


            retur = await shipRepository.AutoTune(item);

            return retur;
        }


        public async Task<ReturnValueItem> AutoAdjustment(string shipGuid, string OperationModeGuid, string ProfilGuid, int MinNumberGenerator, int NecesseryPP)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.ShipGuid = shipGuid;

            ReturnValueItem retur = new();

            AutoTuneParameteritem item = new();
            item.OperationModeGuid = OperationModeGuid;
            item.ProfilGuid = ProfilGuid;
            item.MinNumberGenerator = MinNumberGenerator;
            item.NecesseryPP = NecesseryPP;
            item.logonInfo = logonInfo;


            retur = await shipRepository.AutoAdjustment(item);

            return retur;
        }


        public async Task<ReturnValueItem> SetShipGeneratorModesList(int updateMode, bool Active, string generatorGuid, string operationModeGuid, string generatorModesGuid, string profilGuid, int percentLoad)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipGeneratorModesListItem item = new();
            item.UpdateMode = updateMode;
            item.Active = Active;
            item.GeneratorGuid = generatorGuid; 
            item.OperationModeGuid = operationModeGuid;
            item.GeneratorModesGuid = generatorModesGuid;
            item.ProfilGuid = profilGuid;
            item.PercentLoad = percentLoad;
            item.logonInfo = logonInfo;


            retur = await shipRepository.SetShipGeneratorModesList(item);

            return retur;

        }

        #endregion

        #region Fuel savings


        public async Task<ActionResult> GetShipEquipmentModesList([DataSourceRequest] DataSourceRequest request, string equipmentGuid, string shipGuid, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "E.EquipmentGuid='" + equipmentGuid + "' AND OM.ShipGuid = '" + shipGuid + "'";
            if (profilGuid != null)
            {
                logonInfo.Parameters.field = " AND EM.ProfilGuid='" + profilGuid + "' ";
            }
            else
            {
                logonInfo.Parameters.field += " AND EM.ProfilGuid IS NULL ";
            }
            logonInfo.Parameters.order = "OM.[Order]";

            List<Models.ShipEquipmentModesItem> items = new();

            if (equipmentGuid != null && equipmentGuid.Length>0)
            {
                items = await shipRepository.GetShipEquipmentModesList(logonInfo);

                foreach (var i in items)
                {
                    i.Effect = i.HoursPrYear * i.MaxEffect * i.PercentLoad / 100;
                    i.Saving = i.Effect - (i.Effect * i.PercentSaving / 100);
                    i.PowerSaving = i.Effect - i.Saving;
                }
            }


            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReturnValueItem> SetShipEquipmentModes(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ShipEquipmentModesItem item = new();

            item.EquipmentModesGuid = model.ShipEquipmentModes.EquipmentModesGuid;
            item.OperationModeGuid = model.ShipEquipmentModes.OperationModeGuid;
            item.EquipmentGuid = model.ShipEquipmentModes.EquipmentGuid;
            item.PercentLoad = model.ShipEquipmentModes.PercentLoad;
            item.PercentSaving = model.ShipEquipmentModes.PercentSaving;
            item.ProfilGuid = model.ShipEquipmentModes.ProfilGuid;
            item.logonInfo = logonInfo;

            retur = await shipRepository.SetShipEquipmentModes(item);

            return retur;
        }

        [HttpPost]
        public async Task<ActionResult> SaveShipEquipmentModesList([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<ShipEquipmentModesItem> model)
        {
            if (model != null && ModelState.IsValid)
            {
                ShipRepository shipRepository = new ShipRepository(Configuration);
                AccountLogOnInfoItem logonInfo = GetLogonInfo();

                foreach (var EquipmentItem in model)
                {
                    ShipEquipmentModesItem item = new ShipEquipmentModesItem();
                    item.logonInfo = logonInfo;

                    #region Setter verdier

                    item.EquipmentModesGuid = EquipmentItem.EquipmentModesGuid;
                    item.Name = EquipmentItem.Name;
                    item.EquipmentGuid = EquipmentItem.EquipmentGuid;
                    item.OperationModeGuid = EquipmentItem.OperationModeGuid;
                    item.PercentLoad = EquipmentItem.PercentLoad;
                    item.PercentSaving = EquipmentItem.PercentSaving;
                    item.HoursPrYear = EquipmentItem.HoursPrYear;
                    item.MaxEffect = EquipmentItem.MaxEffect;

                    #endregion

                    await shipRepository.SetShipEquipmentModes(item);
                }

            }
            return Json(model.ToDataSourceResult(request, ModelState));
        }


        public async Task<ActionResult> GetShipGeneratorsModesList([DataSourceRequest] DataSourceRequest request, string generatorGuid, string profilGuid, string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (generatorGuid != null)
            {
                logonInfo.Parameters.filter = "G.GeneratorGuid='" + generatorGuid + "'";
            }
            else
            {
                logonInfo.Parameters.filter = "G.ShipGuid='" + shipGuid + "'";
            }
            
            logonInfo.Parameters.order = "[Order]";
            if (profilGuid != null)
            {
                logonInfo.Parameters.field = " AND EM.ProfilGuid='" + profilGuid + "' ";
            }
            else
            {
                logonInfo.Parameters.field += " AND EM.ProfilGuid IS NULL ";
            }
            List<Models.ShipGeneratorModesItem> items = new();

            if (generatorGuid != null && generatorGuid.Length>0 || shipGuid != null && shipGuid.Length>0)
            {
                items = await shipRepository.GetShipGeneratorsModesList(logonInfo);

                foreach (var i in items)
                {
                    //i.Effect = i.HoursBefore * i.kW * i.PercentLoad / 100;
                    //i.SavingEffect = i.HoursAfter * i.kW * i.PercentSaving / 100;
                    i.Saving = Convert.ToDecimal(i.EffectBefore - i.EffectAfter);
                }
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }



        public async Task<ShipGeneratorModesSummaryItem> GetShipGeneratorModesSummaryListe([DataSourceRequest] DataSourceRequest request, string operationModeGuid, string profilGuid, string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (shipGuid != null) {
                logonInfo.ShipGuid = shipGuid;
            }
            else
            {
                logonInfo.Parameters.filter = operationModeGuid;
            }
            logonInfo.Parameters.fieldValue = profilGuid;
            ShipGeneratorModesSummaryItem items = new();

            if (operationModeGuid != null && operationModeGuid.Length > 0 || shipGuid != null)
            {
                items = await shipRepository.GetShipGeneratorModesSummaryListe(logonInfo);
            }

            return items;
        }

        public async Task<ShipGeneratorModesItem> GetShipGeneratorLoad([DataSourceRequest] DataSourceRequest request, string operationModeGuid, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "OperationModeGuid = '" + operationModeGuid + "'";
            if (profilGuid != null)
            {
                logonInfo.Parameters.filter += " AND profilGuid = '" + profilGuid + "'";
            }
            else
            {
                logonInfo.Parameters.filter += " AND profilGuid IS NULL";
            }

            ShipGeneratorModesItem items = new();

            if (operationModeGuid != null && operationModeGuid.Length > 0)
            {
                items = await shipRepository.GetShipGeneratorLoad(logonInfo);
            }

            return items;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetShipGeneratorModes(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReturnValueItem retur = new();

            ShipGeneratorModesItem item = new ShipGeneratorModesItem();

            item = model.ShipGeneratorModes;
            item.PercentSaving = item.PercentSavingNew;
            item.PercentLoad = item.PercentLoadNew;
            item.logonInfo = logonInfo;

            retur = await shipRepository.SetShipGeneratorModes(item);

            return retur;
        }


        [HttpPost]
        public async Task<ActionResult> SaveShipGeneratorModesList([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<ShipGeneratorModesItem> model)
        {
            if (model != null && ModelState.IsValid)
            {
                ShipRepository shipRepository = new ShipRepository(Configuration);
                AccountLogOnInfoItem logonInfo = GetLogonInfo();

                foreach (var EquipmentItem in model)
                {
                    ShipGeneratorModesItem item = new ShipGeneratorModesItem();
                    item.logonInfo = logonInfo;

                    #region Setter verdier

                    item.GeneratorModesGuid = EquipmentItem.GeneratorModesGuid;
                    item.Name = EquipmentItem.Name;
                    item.GeneratorGuid = EquipmentItem.GeneratorGuid;
                    item.OperationModeGuid = EquipmentItem.OperationModeGuid;
                    item.HoursBefore = EquipmentItem.HoursBefore;
                    item.PercentLoad = EquipmentItem.PercentLoad;
                    item.HoursAfter = EquipmentItem.HoursAfter;
                    item.PercentSaving = EquipmentItem.PercentSaving;
                    item.HoursPrYear = EquipmentItem.HoursPrYear;
                    item.kW = EquipmentItem.kW;

                    item.Effect = EquipmentItem.HoursBefore * EquipmentItem.kW * EquipmentItem.PercentLoad / 100;
                    item.SavingEffect = EquipmentItem.HoursAfter * EquipmentItem.kW * EquipmentItem.PercentSaving / 100;
                    item.Saving = item.Effect - item.SavingEffect;


                    #endregion

                    await shipRepository.SetShipGeneratorModes(item);
                }

            }
            return Json(model.ToDataSourceResult(request, ModelState));
        }

        public async Task<ShipFuleSavingsInfoItem> GetShipFuleSavingsInfo(string shipGuid, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";
            if (profilGuid != null)
            {
                logonInfo.Parameters.filter += " AND profilGuid='" + profilGuid + "'";
            }
            else
            {
                logonInfo.Parameters.filter += " AND profilGuid IS NULL";
            }

            Models.ShipFuleSavingsInfoItem items = new();

            items = await shipRepository.GetFuelSavingsInfoShip(logonInfo);

            return items;
        }

        public async Task<ShipFuleSavingsInfoItem> GetFuelOperationSavingsInfoShip(string shipGuid, string operationModeGuid, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.fieldValue = shipGuid;

            if (operationModeGuid != null && operationModeGuid !="")
            {
                logonInfo.Parameters.filter = " AND operationModeGuid='" + operationModeGuid + "'";
            }
            if (profilGuid != null)
            {
                logonInfo.Parameters.filter += " AND profilGuid='" + profilGuid + "'";
            }
            else
            {
                logonInfo.Parameters.filter += " AND profilGuid IS NULL";
            }

            Models.ShipFuleSavingsInfoItem items = new();

            items = await shipRepository.GetFuelOperationSavingsInfoShip(logonInfo);

            return items;
        }


        public string getChart([DataSourceRequest] DataSourceRequest request, Single idBs, Single idAs, Single idPR)
        {
            HomeRepository homeRepository = new HomeRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            string jstekst = "[";
            Single iA = idBs - idPR;

            jstekst = "[";

            jstekst += "{ \u0022periode\u0022: \u0022Before measures\u0022, \u0022sum\u0022: " + idBs.ToString().Replace(",", ".") + "}";
            jstekst += ",";
            jstekst += "{ \u0022periode\u0022: \u0022After measures\u0022, \u0022sum\u0022: " + idAs.ToString().Replace(",",".") + "}";
            jstekst += ",";
            jstekst += "{ \u0022periode\u0022: \u0022Real need\u0022, \u0022sum\u0022: " + idPR.ToString().Replace(",",".") + "}";

            jstekst += "]";

            return jstekst;

        }

        public string getPieChart([DataSourceRequest] DataSourceRequest request, Single idBs, Single idAs)
        {
            HomeRepository homeRepository = new HomeRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Single idTS = idBs + idAs;

            string jstekst = "[";

            jstekst = "[";

            jstekst += "{ \u0022Name\u0022: \u0022After measures\u0022, \u0022Value\u0022: [" + idBs.ToString().Replace(",", ".") + ", " + idAs.ToString().Replace(",", ".") +  ", 0], \u0022color\u0022: \u0022#5797d1\u0022}";
            jstekst += ",";
            jstekst += "{ \u0022Name\u0022: \u0022Before measures\u0022, \u0022Value\u0022: [" + idTS.ToString().Replace(",", ".") + ", 0, 0], \u0022color\u0022: \u0022#1a4d5a\u0022}";

            jstekst += "]";

            return jstekst;

        }


        public string getChartInv(Single invCost, Single fuelSaving, Single maintSaving)
        {
            string jstekst = "[";

            jstekst = "[";

            jstekst += "{ \u0022periode\u0022: \u0022Estimated investment cost\u0022, \u0022sum\u0022: " + invCost.ToString().Replace(",", ".") + ", \u0022color\u0022: \u0022#01a379\u0022}";
            jstekst += ",";
            jstekst += "{ \u0022periode\u0022: \u0022Calculated saved fuel cost\u0022, \u0022sum\u0022: " + fuelSaving.ToString().Replace(",", ".") + ", \u0022color\u0022: \u0022#5797d1\u0022}";
            jstekst += ",";
            jstekst += "{ \u0022periode\u0022: \u0022Saved maintenance cost\u0022, \u0022sum\u0022: " + maintSaving.ToString().Replace(",", ".") + ", \u0022color\u0022: \u0022#1a4d5a\u0022}";

            jstekst += "]";

            return jstekst;

        }

        #endregion

        #region Plan
        public async Task<ActionResult> GetInvestmentPlanList([DataSourceRequest] DataSourceRequest request, string shipGuid, string profilGuids)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";

            if (profilGuids != null)
            {
                logonInfo.Parameters.filter += " AND ProfilGuid IN (" + profilGuids + ")";
                logonInfo.Parameters.field = " AND GEI.ProfilGuid IN (" + profilGuids + ") ";
                logonInfo.Parameters.fieldValue = " EM.ProfilGuid IN (" + profilGuids + ") ";
            }
            else
            {
                logonInfo.Parameters.filter += " AND ProfilGuid IS NULL ";
                logonInfo.Parameters.field = " AND GEI.ProfilGuid IS NULL ";
                logonInfo.Parameters.fieldValue = " EM.ProfilGuid IS NULL ";
            }

            List<InvestmentPlanItem> items = new();

            items = await shipRepository.GetInvestmentPlanList(logonInfo);

            foreach (var i in items)
            {
                i.Savings = i.EffectCostYear - i.SavingsCostYear;                
                i.OwnerPrice = i.Cost - (i.Cost * i.FinancielSupport / 100);
                i.PaybackTime =  i.OwnerPrice / ((i.SavingsYear + i.MaintenaceCost) / 12);
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<InvestmentPlanItem> GetInvestmentPlanData(string shipGuid, string profilGuids)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";

            logonInfo.Parameters.filter += " AND ProfilGuid IN ('" + profilGuids + "')";
            logonInfo.Parameters.field = " AND GEI.ProfilGuid IN ('" + profilGuids + "') ";
            logonInfo.Parameters.fieldValue = " EM.ProfilGuid IN ('" + profilGuids + "') ";

            List<InvestmentPlanItem> items = new();
            InvestmentPlanItem item = new();

            items = await shipRepository.GetInvestmentPlanList(logonInfo);

            foreach (var i in items)
            {
                item.OwnerPrice += i.Cost - (i.Cost * i.FinancielSupport / 100);
                item.MaintenaceCost += i.MaintenaceCost;
                item.SavingsYear += i.SavingsYear;
            }

            return item;
        }

        public async Task<ReturnValueItem> CreateInvestmentPlanList(string shipGuid, string profilGuids)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";

            if (profilGuids != null)
            {
                logonInfo.Parameters.filter += " AND GEI.ProfilGuid IN (" + profilGuids + ")";
                logonInfo.Parameters.field = " AND GEI.ProfilGuid IN (" + profilGuids + ") ";
                logonInfo.Parameters.fieldValue = " EM.ProfilGuid IN (" + profilGuids + ") ";
            }
            else
            {
                logonInfo.Parameters.filter += " AND GEI.ProfilGuid IS NULL ";
                logonInfo.Parameters.field = " AND GEI.ProfilGuid IS NULL ";
                logonInfo.Parameters.fieldValue = " EM.ProfilGuid IS NULL ";
            }

            ReturnValueItem items = new();

            items = await shipRepository.CreateInvestmentPlanList(logonInfo);

            return items;
        }

        public async Task<ActionResult> GetInvestmentPlanYear([DataSourceRequest] DataSourceRequest request, string shipGuid, string field, string profilGuids)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "shipGuid='" + shipGuid + "'";
            if (profilGuids != null)
            {
                logonInfo.Parameters.filter += " AND ProfilGuid IN (" + profilGuids + ") ";
            }
            else
            {
                logonInfo.Parameters.filter += " AND ProfilGuid IS NULL ";
            }

            logonInfo.Parameters.field = field;

            List<InvestmentPlanYearItem> items = new();

            items = await shipRepository.GetInvestmentPlanYear(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        #endregion

        #region Statistikk



        public async Task<ActionResult> GetShipOperationPowerList([DataSourceRequest] DataSourceRequest request, string shipGuid, string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "OM.ShipGuid = '" + shipGuid + "'";
            logonInfo.Parameters.order = "OM.[Order]";

            if (profilGuid != null)
            {
                logonInfo.Parameters.filter += " AND EM.ProfilGuid='" + profilGuid + "' ";
            }
            else
            {
                logonInfo.Parameters.filter += " AND EM.ProfilGuid IS NULL ";
            }

            List<Models.ShipOperationPowerItem> items = new();

            items = await shipRepository.GetShipOperationPowerList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetSavingPrModeList([DataSourceRequest] DataSourceRequest request, string shipGuid, string profilGuids)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "ShipGuid = '" + shipGuid + "'";

            if (profilGuids != null)
            {
                logonInfo.Parameters.field += " AND E.ProfilGuid IN (" + profilGuids + ")";
            }

            List<Models.ShipOperationSavingPowerItem> items = new();

            items = await shipRepository.GetSavingPrModeList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        public async Task<ActionResult> GetShipEquipmentSavingsList([DataSourceRequest] DataSourceRequest request, string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "ShipGuid = '" + shipGuid + "'";

            List<Models.ShipOperationSavingItem> items = new();

            items = await shipRepository.GetShipEquipmentSavingsList(logonInfo);

            foreach (var i in items)
            {
                i.Savings = i.OldValue - i.NewValue;
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ActionResult> GetShipOperationSavingsList([DataSourceRequest] DataSourceRequest request, string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            logonInfo.Parameters.filter = "ShipGuid = '" + shipGuid + "'";

            List<Models.ShipOperationSavingItem> items = new();

            items = await shipRepository.GetShipOperationSavingsList(logonInfo);

            foreach (var i in items)
            {
                i.Savings = i.OldValue - i.NewValue;
            }

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }


        #endregion

        #region Profile

        public async Task<ActionResult> GetProfileList([DataSourceRequest] DataSourceRequest request, string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (shipGuid != null)
            {
                logonInfo.Parameters.filter = "LinkGuid='" + shipGuid + "' ";
            }

            List<Models.ProfileItem> items = new();

            items = await shipRepository.GetProfileList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);
        }

        public async Task<ReturnValueItem> SetProfile(ShipModel modell)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            ProfileItem item = new();
            item = modell.Profile;
            item.logonInfo = logonInfo;


            retur = await shipRepository.SetProfile(item);

            return retur;
        }

        public ActionResult NewProfile()
        {
            ShipModel model = new ShipModel();
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            model.Profile.CreatedBy = logonInfo.UserId;
            return PartialView("_ProfileNew", model);
        }

        public async Task<ReturnValueItem> SetActiveProfile(string profilGuid, string linkGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            UserShipProfileItem item = new();
            item.UserGuid = logonInfo.UserId;
            item.ProfilGuid = profilGuid;
            item.ShipGuid = linkGuid;

            item.logonInfo = logonInfo;


            retur = await shipRepository.SetActiveProfile(item);

            return retur;
        }

        public async Task<ReturnValueItem> CopyFromProfile(string shipGuid, string profilGuid, string linkGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReturnValueItem retur = new();

            if (profilGuid == null)
            {
                logonInfo.Parameters.filter = "ProfilGuid IS NULL";
            }
            else
            {
                logonInfo.Parameters.filter = "ProfilGuid='" + profilGuid + "'";
            }
            logonInfo.Parameters.field = linkGuid;
            logonInfo.ShipGuid = shipGuid;

            retur = await shipRepository.CopyFromProfile(logonInfo);

            return retur;
        }


        public async Task<ReturnValueItem> RemoveProfile(string profilGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ReturnValueItem retur = new();

            if (profilGuid != null)
            {
                logonInfo.Parameters.field = profilGuid;
                retur = await shipRepository.RemoveProfile(logonInfo);
            }

            return retur;
        }

        public async Task<ReturnValueItem> SetActivProfil(string profilGuid, string shipGuid)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            logonInfo.ShipGuid = shipGuid;
            logonInfo.Parameters.fieldValue = profilGuid;

            retur = await shipRepository.SetActivProfil(logonInfo);

            return retur;
        }


        #endregion

        #region Operation mode & profile

        public async Task<ReturnValueItem> SetOperationModeProfile(ShipModel model)
        {
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            OperationModeProfileItem item = model.OperationModeProfile;
            item.logonInfo = logonInfo;


            retur = await shipRepository.SetOperationModeProfile(item);

            return retur;
        }

        public async Task<ActionResult> GetOperationModeProfile(string OperationModeProfileGuid, string OperationModeGuid, string ProfilGuid)
        {
            ShipModel modell = new ShipModel();
            ShipRepository shipRepository = new ShipRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            Models.OperationModeProfileItem item = new();

            if (OperationModeProfileGuid != null && OperationModeProfileGuid.Length>0)
            {
                logonInfo.Parameters.filter = "OperationModeProfileGuid='" + OperationModeProfileGuid + "'";

                item = await shipRepository.GetOperationModeProfile(logonInfo);
                modell.OperationModeProfile = item;
            }
            else
            {
                modell.OperationModeProfile.ProfilGuid = ProfilGuid;
                modell.OperationModeProfile.OperationModeGuid = OperationModeGuid;
            }


            return PartialView("_ProfileInfo", modell);
        }

        #endregion

    }

}
