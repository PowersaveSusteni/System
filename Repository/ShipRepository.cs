using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using Susteni.Models.Customer;
using Susteni.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class ShipRepository : Controller
    {

        private readonly IConfiguration Configuration;

        public ShipRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region Ship

        [HttpPost]
        public async Task<List<Models.ShipItem>> getShipList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipsList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> setShip(Models.ShipItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShip", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> CreateShip(Models.NewShipItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "CreateShip", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetActiveShip(Models.AccountLogOnInfoItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetActiveShip", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<Models.ShipItem> getShip(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShip", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<List<Models.ShipItem>> getShipListWithPicture(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipsListWithPicture", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipItem>>(result);

            return itemWS;
        }

        public async Task<ReturValueItem> uploadPicture(AccountLogOnInfoItem logonInfo, Models.FilerItem item)
        {

            item.logOnInfo = logonInfo;


            Models.ReturValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetPicture", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ReturValueItem>(result);

            return itemWS;

        }

        [HttpPost]
        public async Task<ReturnValueItem> RemoveShip(AccountLogOnInfoItem logoninfo)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "RemoveShip", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion


        #region Types

        [HttpPost]
        public async Task<List<Models.ShipTypeItem>> getShipTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipTypeItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipTypeList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipTypeItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.PowerProductionTypeItem>> GetPowerProductionTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.PowerProductionTypeItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetPowerProductionTypeList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.PowerProductionTypeItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<List<Models.ShipFuelTypeItem>> GetShipFuelTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipFuelTypeItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipFuelTypeList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipFuelTypeItem>>(result);

            return itemWS;
        }

        #endregion

        #region Operation modes

        [HttpPost]
        public async Task<List<Models.ShipOperationModeItem>> GetShipOperationModeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipOperationModeItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipOperationModeList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipOperationModeItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> SetShipOperationMode(Models.ShipOperationModeItem item)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShipOperationMode", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<Models.ShipOperationModeItem> GetShipOperationMode(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipOperationModeItem item = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipOperationMode", json, "");

            item = JsonConvert.DeserializeObject<Models.ShipOperationModeItem>(result);

            return item;
        }

        [HttpPost]
        public async Task<Models.ShipOperationModeItem> RemoveShipOperationMode(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipOperationModeItem item = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "RemoveShipOperationMode", json, "");

            item = JsonConvert.DeserializeObject<Models.ShipOperationModeItem>(result);

            return item;
        }
        #endregion

        #region Types



        [HttpPost]
        public async Task<List<Models.ShipEquipmentTypeItem>> GetShipEquipmentTypeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipEquipmentTypeItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipEquipmentTypeList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipEquipmentTypeItem>>(result);

            return itemWS;
        }


        #endregion

        #region Equipments


        [HttpPost]
        public async Task<List<Models.ShipEquipmentItem>> GetShipEquipmentList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipEquipmentItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipEquipmentList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipEquipmentItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ShipEquipmentItem> GetShipEquipment(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipEquipmentItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipEquipment", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipEquipmentItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.ReturnValueItem> SetShipEquipment(Models.ShipEquipmentItem item)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShipEquipment", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveShipEquipment(Models.AccountLogOnInfoItem logoninfo)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "RemoveShipEquipment", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion


        #region Generators


        [HttpPost]
        public async Task<List<Models.ShipGeneratorItem>> GetShipGeneratorList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipGeneratorItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipGeneratorItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ShipGeneratorItem> GetShipGenerator(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipGeneratorItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGenerator", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipGeneratorItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.ReturnValueItem> SetShipGenerator(Models.ShipGeneratorItem item)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShipGenerator", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveShipGenerator(Models.AccountLogOnInfoItem logoninfo)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "RemoveShipGenerator", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }




        [HttpPost]
        public async Task<List<Models.ShipGeneratorModesShortItem>> GetShipGeneratorModesShortListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipGeneratorModesShortItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorModesShortListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipGeneratorModesShortItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetShipGeneratorModesList(ShipGeneratorModesListItem item)
        {
            ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShipGeneratorModesList", json, "");

            itemWS = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> AutoTune(AutoTuneParameteritem item)
        {
            ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "AutoTune", json, "");

            itemWS = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> AutoAdjustment(AutoTuneParameteritem item)
        {
            ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "AutoAdjustment", json, "");

            itemWS = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.ShipGeneratorHeatUnitItem>> GetShipGeneratorHeatUnitList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipGeneratorHeatUnitItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorHeatUnitList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipGeneratorHeatUnitItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.ReturnValueItem> SetShipGeneratorHeatUnit(Models.ShipGeneratorHeatUnitItem item)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShipGeneratorHeatUnit", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<Models.ShipGeneratorHeatUnitItem> GetShipGeneratorHeatUnit(Models.AccountLogOnInfoItem logoninfo)
        {

            ShipGeneratorHeatUnitItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorHeatUnit", json, "");

            retur = JsonConvert.DeserializeObject<Models.ShipGeneratorHeatUnitItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<List<Models.GeneratorFuelComsuptionItem>> GetFuelComsuptionGeneratorList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.GeneratorFuelComsuptionItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetGeneratorFuelComsuptionList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.GeneratorFuelComsuptionItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.GeneratorFuelComsuptionChartItem>> GetGeneratorFuelComsuptionChart(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.GeneratorFuelComsuptionChartItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetGeneratorFuelComsuptionChart", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.GeneratorFuelComsuptionChartItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.GeneratorFuelComsuptionItem> GetFuelComsuptionGenerator(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.GeneratorFuelComsuptionItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetGeneratorFuelComsuption", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.GeneratorFuelComsuptionItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<GeneratorFuelComsuptionItem> GetGeneratorFuelComsuption(AccountLogOnInfoItem logoninfo)
        {
            Models.GeneratorFuelComsuptionItem item = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetGeneratorFuelComsuption", json, "");

            item = JsonConvert.DeserializeObject<Models.GeneratorFuelComsuptionItem>(result);

            return item;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetGeneratorFuelComsuption(Models.GeneratorFuelComsuptionItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetGeneratorFuelComsuption", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> RemoveGeneratorFuelComsuption(Models.AccountLogOnInfoItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "RemoveGeneratorFuelComsuption", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        #region Fule savings

        [HttpPost]
        public async Task<List<Models.ShipEquipmentModesItem>> GetShipEquipmentModesList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipEquipmentModesItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipEquipmentModesList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipEquipmentModesItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ShipEquipmentModesItem> GetShipEquipmentModes(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipEquipmentModesItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipEquipmentModes", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipEquipmentModesItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<ReturnValueItem> SetShipEquipmentModes(Models.ShipEquipmentModesItem item)
        {
            ReturnValueItem retur = new();


            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShipEquipmentModes", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<Models.ShipGeneratorModesItem> GetShipGeneratorsModes(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipGeneratorModesItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorModes", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipGeneratorModesItem>(result);
            itemWS.PercentSavingNew = itemWS.PercentSaving;
            itemWS.PercentLoadNew = itemWS.PercentLoad;
            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ShipGeneratorModesItem> GetShipGeneratorLoad(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipGeneratorModesItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorLoad", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipGeneratorModesItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.ShipGeneratorModesItem>> GetShipGeneratorsModesList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipGeneratorModesItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorModesList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipGeneratorModesItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ShipGeneratorModesSummaryItem> GetShipGeneratorModesSummaryListe(Models.AccountLogOnInfoItem logoninfo)
        {
            ShipGeneratorModesSummaryItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipGeneratorModesSummaryListe", json, "");

            itemWS = JsonConvert.DeserializeObject<ShipGeneratorModesSummaryItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<ReturnValueItem> SetShipGeneratorModes(Models.ShipGeneratorModesItem item)
        {
            ReturnValueItem retur = new();


            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetShipGeneratorModes", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<Models.ShipFuleSavingsInfoItem> GetFuelSavingsInfoShip(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipFuleSavingsInfoItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipFuelSavingsInfo", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipFuleSavingsInfoItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ShipFuleSavingsInfoItem> GetFuelOperationSavingsInfoShip(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ShipFuleSavingsInfoItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipOperationFuelSavingsInfo", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ShipFuleSavingsInfoItem>(result);

            return itemWS;
        }

        #endregion

        #region Plan

        [HttpPost]
        public async Task<List<Models.InvestmentPlanItem>> GetInvestmentPlanList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.InvestmentPlanItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetInvestmentPlanList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.InvestmentPlanItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> CreateInvestmentPlanList(Models.AccountLogOnInfoItem logoninfo)
        {
            ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "CreateInvestmentPlanList", json, "");

            itemWS = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.InvestmentPlanYearItem>> GetInvestmentPlanYear(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.InvestmentPlanYearItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetInvestmentPlanYear", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.InvestmentPlanYearItem>>(result);

            return itemWS;
        }

        #endregion

        #region Statistikk


        [HttpPost]
        public async Task<List<Models.ShipOperationPowerItem>> GetShipOperationPowerList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipOperationPowerItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipOperationPowerList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipOperationPowerItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.ShipOperationSavingPowerItem>> GetSavingPrModeList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipOperationSavingPowerItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetSavingPrModeList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipOperationSavingPowerItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<List<Models.ShipOperationSavingItem>> GetShipOperationSavingsList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipOperationSavingItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipOperationSavingsList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipOperationSavingItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.ShipOperationSavingItem>> GetShipEquipmentSavingsList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.ShipOperationSavingItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetShipEquipmentSavingsList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ShipOperationSavingItem>>(result);

            return itemWS;
        }

        #endregion

        #region Profile

        [HttpPost]
        public async Task<List<ProfileItem>> GetProfileList(AccountLogOnInfoItem logoninfo)
        {
            List<Models.ProfileItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetProfileList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.ProfileItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetProfile(ProfileItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ProfileItem> GetProfile(AccountLogOnInfoItem logoninfo)
        {
            Models.ProfileItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ProfileItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<ReturnValueItem> SetActiveProfile(UserShipProfileItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetActiveProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<ReturnValueItem> CopyFromProfile(AccountLogOnInfoItem logoninfo)
        {
            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "CopyFromProfile", json, "");

            retur = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> RemoveProfile(AccountLogOnInfoItem logoninfo)
        {
            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "RemoveProfile", json, "");

            retur = JsonConvert.DeserializeObject<ReturnValueItem>(result);

            return retur;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetActivProfil(AccountLogOnInfoItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetActivProfil", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }

        #endregion

        #region Operation mode & profile

        [HttpPost]
        public async Task<Models.OperationModeProfileItem> GetOperationModeProfile(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.OperationModeProfileItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Ship", "GetOperationModeProfile", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.OperationModeProfileItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<ReturnValueItem> SetOperationModeProfile(Models.OperationModeProfileItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Ship", "SetOperationModeProfile", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

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


    }
}
