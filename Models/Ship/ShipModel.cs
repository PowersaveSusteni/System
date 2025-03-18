namespace Susteni.Models.Ship
{
    public class ShipModel
    {
        public ShipItem Ship { get; set; }
        public NewShipItem NewShip { get; set; }
        public ShipTypeItem ShipType { get; set; }
        public ShipOperationModeItem ShipOperationMode { get; set; }
        public ShipEquipmentTypeItem ShipEquipmentType { get; set; }
        public ShipEquipmentItem ShipEquipment { get; set; }
        public ShipEquipmentModesItem ShipEquipmentModes { get; set; }
        public ShipGeneratorItem ShipGenerator { get; set; }
        public ShipGeneratorModesItem ShipGeneratorModes { get; set; }
        public ShipOperationSavingPowerItem ShipOperationSavingPower { get; set; }
        public ShipOperationSavingItem ShipOperationSaving { get; set; }
        public ShipGeneratorHeatUnitItem ShipGeneratorHeatUnit { get; set; }

        public InvestmentPlanItem InvestmentPlan { get; set; }
        public InvestmentPlanYearItem InvestmentPlanYear { get; set; }

        public ShipFuleSavingsInfoItem ShipFuleSavingsInfo { get; set; }

        public ProfileItem Profile { get; set; }
        public UserShipProfileItem UserShipProfile { get; set; }

        public GeneratorFuelComsuptionItem GeneratorFuelComsuption { get; set; }

        public OperationModeProfileItem OperationModeProfile { get; set; }
        public ShipModel()
        { 
            Ship = new ShipItem();
            NewShip = new NewShipItem();
            ShipType = new ShipTypeItem();
            ShipOperationMode = new ShipOperationModeItem();
            ShipEquipmentType = new ShipEquipmentTypeItem();
            ShipEquipment = new ShipEquipmentItem();
            ShipEquipmentModes = new ShipEquipmentModesItem();
            ShipGenerator = new ShipGeneratorItem();
            ShipGeneratorModes = new ShipGeneratorModesItem();
            ShipOperationSavingPower = new ShipOperationSavingPowerItem();
            ShipOperationSaving = new ShipOperationSavingItem();
            ShipGeneratorHeatUnit = new ShipGeneratorHeatUnitItem();

            InvestmentPlan = new InvestmentPlanItem();
            InvestmentPlanYear = new InvestmentPlanYearItem();

            ShipFuleSavingsInfo = new ShipFuleSavingsInfoItem();
            Profile = new ProfileItem();
            UserShipProfile = new UserShipProfileItem();

            GeneratorFuelComsuption = new GeneratorFuelComsuptionItem();

            OperationModeProfile = new OperationModeProfileItem();
        }
    }
}
