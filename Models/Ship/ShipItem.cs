using System;

namespace Susteni.Models
{
    public class ShipItem
    {
        public string ShipGuid { get; set; } = "";
        public string CustomerGuid { get; set; } = "";
        public string IMO { get; set; } = "";
        public string Name { get; set; } = "";
        public string ShipTypeGuid { get; set; } = "";
        public int GrossTonnage { get; set; } = 0;
        public int Length { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int YearOfBuilt { get; set; } = 0;
        public int OperationDays { get; set; } = 0;
        public Single DensityMGO { get; set; } = 0;
        public int NumberOfDays { get; set; } = 0;
        public int FuelConsPrYear { get; set; } = 0;
        public string Picture { get; set; } = "";
        public string PicturePrint { get; set; } = "";
        public string byte64Picture { get; set; } = "";
        public int UnitOfMeasurement { get; set; } = 0;
        public string ProfilGuid { get; set; } = "";
        public string ProfilName { get; set; } = "";
        public string InfoText { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class NewShipItem
    {
        public string? ShipGuid { get; set; }
        public string CustomerGuid { get; set; } = "";
        public string IMO { get; set; } = "";
        public string Name { get; set; } = "";
        public string ShipTypeGuid { get; set; } = "";
        public int GrossTonnage { get; set; } = 0;
        public int Length { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int YearOfBuilt { get; set; } = 0;
        public int OperationDays { get; set; } = 0;
        public Single DensityMGO { get; set; } = 0;
        public int NumberOfDays { get; set; } = 0;
        public int FuelConsPrYear { get; set; } = 0;
        public int UnitOfMeasurement { get; set; } = 0;
        public string ProfilGuid { get; set; } = "";
        public string ProfilName { get; set; } = "";
        public string InfoText { get; set; } = "";
        public string OperationModes { get; set; } = "";
        public string Generators { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }


    public class ShipTypeItem
    {
        public string ShipTypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
    }


    public class PowerProductionTypeItem
    {
        public string TypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class ShipFuelTypeItem
    {
        public string FuelTypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public Single CarbonContent { get; set; } = 0;
        public Single Cf { get; set; } = 0;
    }

    public class ShipOperationModeItem
    {
        public string OperationModeGuid { get; set; } = "";
        public string? OperationModeProfileGuid { get; set; }
        public string ShipGuid { get; set; } = "";
        public string ProfilGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public int Order { get; set; } = 0;
        public int HoursPrYear { get; set; } = 0;
        public int NumberGenerator { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ShipEquipmentItem
    {
        public string EquipmentGuid { get; set; } = "";
        public string ShipGuid { get; set; } = "";
        public string ProfilGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public string Model { get; set; } = "";
        public string Description { get; set; } = "";
        public int EquipmentType { get; set; } = 0;
        public Single MaxEffect { get; set; } = 0;
        public int Order { get; set; } = 0;
        public Single Cost { get; set; } = 0;
        public int FinancielSupport { get; set; } = 0;
        public bool Active { get; set; } = true;
        public int Year { get; set; } = 0;  
        public Single MaintenanceCode { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }


    public class ShipEquipmentTypeItem
    {
        public int Type { get; set; } = 0;
        public string Name { get; set; } = "";
    }


    public class ShipEquipmentModesItem
    {
        public string EquipmentModesGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public string EquipmentGuid { get; set; } = "";
        public string OperationModeGuid { get; set; } = "";
        public string ProfilGuid { get; set; } = "";
        public int HoursBefore { get; set; } = 0;
        public decimal PercentLoad { get; set; } = 0;
        public decimal Effect { get; set; } = 0; 
        public int HoursAfter { get; set; } = 0;
        public decimal PercentSaving { get; set; } = 0;
        public decimal Saving { get; set; } = 0;
        public int HoursPrYear { get; set; } = 0;
        public decimal MaxEffect { get; set; } = 0;
        public decimal PowerSaving { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ShipGeneratorItem
    {
        public string GeneratorGuid { get; set; } = "";
        public string ShipGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public int Order { get; set; } = 0;
        public string TypeGuid { get; set; } = "";
        public string FuelTypeGuid { get; set; } = "";
        public int kW { get; set; } = 0;
        public float KgDieselkWh { get; set; } = 0;
        public float KgDieselkWh2 { get; set; } = 0;
        public float EfficientMotorSwitchboard { get; set; } = 0;
        public float EfficientMotorSwitchboard2 { get; set; } = 0;
        public float MaintenanceCost { get; set; } = 0;
        public float MaintenanceCost2 { get; set; } = 0;
        public float FuelPrice { get; set; } = 0;
        public float FuelPrice2 { get; set; } = 0;
        public bool PowerProduction { get; set; } = true;
        public bool ExcludeAutoTune { get; set; } = false;
        public int EffectBefore { get; set; } = 0;
        public int EffectAfter { get; set; } = 0;
        public Single Faktor { get; set; } = 0;
        public Single FuelBefore { get; set; } = 0;
        public Single FuelAfter { get; set; } = 0;
        public Single CO2Before { get; set; } = 0;
        public Single CO2After { get; set; } = 0;
        public Single NOxBefore { get; set; } = 0;
        public Single NOxAfter { get; set; } = 0;
        public Single SOxBefore { get; set; } = 0;
        public Single SOxAfter { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }


    public class ShipGeneratorModesItem
    {
        public string GeneratorModesGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public string GeneratorGuid { get; set; } = "";
        public string OperationModeGuid { get; set; } = "";
        public string ProfilGuid { get; set; } = "";
        public int HoursBefore { get; set; } = 0;
        public decimal PercentLoad { get; set; } = 0;
        public decimal PercentLoadNew { get; set; } = 0;
        public decimal Effect { get; set; } = 0;
        public int HoursAfter { get; set; } = 0;
        public decimal PercentSaving { get; set; } = 0;
        public decimal PercentSavingNew { get; set; } = 0;
        public decimal SavingEffect { get; set; } = 0;
        public int HoursPrYear { get; set; } = 0;
        public int kW { get; set; } = 0;
        public decimal Saving { get; set; } = 0;
        public double EffectBefore { get; set; } = 0;
        public double EffectAfter { get; set; } = 0;
        public double KgDieselKwhB { get; set; } = 0;
        public double KgDieselKwhA { get; set; } = 0;
        public double FuelBefore { get; set; } = 0;
        public double FuelAfter { get; set; } = 0;
        public int MaintenanceCost { get; set; } = 0;
        public bool Active { get; set; } = false;
        public bool ActiveBefore { get; set; } = false;
        public int NumberGenerator { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class AutoTuneParameteritem
    {
        public string OperationModeGuid { get; set; } = "";
        public string ProfilGuid { get; set; } = "";
        public int MinNumberGenerator { get; set; } = 0;
        public int NecesseryPP { get; set; } = 0;
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ShipGeneratorModesSummaryItem
    {
        public string Name { get; set; } = "";
        public int HoursPrYear { get; set; } = 0;
        public double MaintenanceCost { get; set; } = 0;
        public double EffectBefore { get; set; } = 0;
        public double EffectAfter { get; set; } = 0;
        public double FuelBefore { get; set; } = 0;
        public double FuelAfter { get; set; } = 0;
        public double CO2Before { get; set; } = 0;
        public double CO2After { get; set; } = 0;
        public double NOxBefore { get; set; } = 0;
        public double NOxAfter { get; set; } = 0;
        public double SOxBefore { get; set; } = 0;
        public double SOxAfter { get; set; } = 0;
    }


    public class ShipGeneratorModesShortItem
    {
        public string GeneratorModesGuid { get; set; } = "";
        public string GeneratorGuid { get; set; } = "";
        public string OperationModeGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public int kW { get; set; } = 0;
        public string? ProfilGuid { get; set; } = "";
        public decimal PercentLoad { get; set; } = 0;
        public decimal PercentSaving { get; set; } = 0;
        public int HoursBefore { get; set; } = 0;
        public int HoursAfter { get; set; } = 0;
        public bool Active { get; set; } = false;
        public bool ActiveBefore { get; set; } = false;
        public bool ExcludeAutoTune { get; set; } = false;
    }

    public class ShipGeneratorModesListItem
    {
        public string? GeneratorModesGuid { get; set; } = "";
        public string GeneratorGuid { get; set; } = "";
        public string OperationModeGuid { get; set; } = "";
        public int UpdateMode { get; set; } = 0;
        public string? ProfilGuid { get; set; } = "";
        public decimal PercentLoad { get; set; } = 0;
        public decimal PercentSaving { get; set; } = 0;
        public bool Active { get; set; } = false;
        public bool ActiveBefore { get; set; } = false;
        public ErrorItem Error { get; set; } = new ErrorItem();

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }


    public class ShipOperationPowerItem
    {
        public string Name { get; set; } = "";
        public string Order { get; set; } = "";
        public int HoursPrYear { get; set; } = 0;
        public int PowerPre { get; set; } = 0;
        public int PowerPast { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ShipOperationSavingPowerItem
    {
        public string EquipmentTypeName { get; set; } = "";
        public int OperationMode1 { get; set; } = 0;
        public int OperationMode2 { get; set; } = 0;
        public int OperationMode3 { get; set; } = 0;
        public int OperationMode4 { get; set; } = 0;
        public int OperationMode5 { get; set; } = 0;
        public int OperationMode6 { get; set; } = 0;
        public int OperationMode7 { get; set; } = 0;
        public int OperationMode8 { get; set; } = 0;
        public int OperationMode9 { get; set; } = 0;
        public int OperationMode0 { get; set; } = 0;

        public ErrorItem Error { get; set; } = new ErrorItem();

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ShipOperationSavingItem
    {
        public string Name { get; set; } = "";
        public int OldValue { get; set; } = 0;
        public int NewValue { get; set; } = 0;
        public int Savings { get; set; } = 0;

    }

    public class ShipGeneratorHeatUnitItem
    {
        public string HeatUnitGuid { get; set; } = "";
        public string ShipGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public int kW { get; set; } = 0;
        public double HourPrday { get; set; } = 0;
        public double Factor { get; set; } = 0;
        public int NumberOfDays { get; set; } = 0;
        public Single KgDieselkWh { get; set; } = 0;
        public Single EfficientMotorSwitchboard { get; set; } = 0;
        public Single DensityMGO { get; set; } = 0;
        public int FuelConsPrYear { get; set; } = 0;
        public int CalcProdkWh { get; set; } = 0;
        public int CalcFVS { get; set; } = 0;
        public int CalcCO2reduction { get; set; } = 0;
        public Single CalcPreduction { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }


    public class GeneratorFuelComsuptionItem
    {
        public string FuelConsGuid { get; set; } = "";
        public string LinkGuid { get; set; } = "";
        public int Effect { get; set; } = 0;
        public double KgDieselkWh { get; set; } = 0;
        public double kdDieselkWh2 { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }


    public class GeneratorFuelComsuptionChartItem
    {
        public string Effect { get; set; } = "";
        public double KgDieselkWh { get; set; } = 0;

    }

    public class InvestmentPlanItem
    {
        public string ShipGuid { get; set; } = "";
        public string EquipmentGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public Single Effect { get; set; } = 0;
        public Single Savings { get; set; } = 0;
        public Single Total { get; set; } = 0;
        public int InvYear { get; set; } = 0;
        public Single Cost { get; set; } = 0;
        public int FinancielSupport { get; set; } = 0;
        public Single KgDieselkWh { get; set; } = 0;
        public Single GenPowerPrLiter { get; set; } = 0;
        public Single PriceKwh { get; set; } = 0;
        public Single SavingsYear { get; set; } = 0;
        public Single MaintenaceCost { get; set; } = 0;
        public Single OwnerPrice { get; set; } = 0;
        public Single PaybackTime { get; set; } = 0;
        public Single EffectCostYear { get; set; } = 0;
        public Single SavingsCostYear { get; set; } = 0;
    }

    public class InvestmentPlanYearItem
    {
        public string ShipGuid { get; set; } = "";
        public string EquipmentGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public Single Year2023 { get; set; } = 0;
        public Single Year2024 { get; set; } = 0;
        public Single Year2025 { get; set; } = 0;
        public Single Year2026 { get; set; } = 0;

        public Single Year2027 { get; set; } = 0;
        public Single Year2028 { get; set; } = 0;
        public Single Year2029 { get; set; } = 0;
        public Single Year2030 { get; set; } = 0;
    }


    public class ShipFuleSavingsInfoItem
    {
        public String ShipGuid { get; set; } = "";
        public Single Effect { get; set; } = 0;
        public Single Savings { get; set; } = 0;
    }

    public class ProfileItem
    {
        public string? ProfilGuid { get; set; } = "";
        public string LinkGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public DateTime CreatDate { get; set; } = DateTime.Now;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }


    public class UserShipProfileItem
    {
        public String UserGuid { get; set; } = "";
        public String ShipGuid { get; set; } = "";
        public String ProfilGuid { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class OperationModeProfileItem
    {
        public string? OperationModeProfileGuid { get; set; } = "";
        public string OperationModeGuid { get; set; } = "";
        public string ProfilGuid { get; set; } = "";
        public int NumberGenerator { get; set; } = 0;
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

}
