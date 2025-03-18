using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Funksjoner
{
    public class FunctionsModel
    {
        public PoststedItem Poststed { get; set; }
        public RapporterItem Rapporter { get; set; }
        public InfoLoggItem InfoLogg { get; set; }
        public HurtigmenyItem Hurtigmeny { get; set; }
        public MenuFunksjonItem MenuFunksjon { get; set; }
        public BrukerFunksjonItem BrukerFunksjon { get; set; }
        public LandItem Land { get; set; }

        public TypeFuelItem TypeFuel { get; set; }
        public TypeShipItem TypeShip { get; set; }
        public ShipTypeOperationModesItem ShipTypeOperationModes { get; set; }
        public ShipTypeGeneratorsItem ShipTypeGenerators { get; set; }

        public TypeEquipmentItem TypeEquipment { get; set; }
        public TypePowerProductionItem TypePowerProduction { get; set; }
        public EquipmentLibraryItem EquipmentLibrary { get; set; }

        public GeneratorVendorItem GeneratorVendor { get; set; }
        public GeneratorModelItem GeneratorModel { get; set; }

        public FunctionsModel()
        {
            Poststed = new PoststedItem();
            Rapporter = new RapporterItem();

            InfoLogg = new InfoLoggItem();
            Hurtigmeny = new HurtigmenyItem();
            MenuFunksjon = new MenuFunksjonItem();
            BrukerFunksjon = new BrukerFunksjonItem();

            Land = new LandItem();

            TypeFuel = new TypeFuelItem();
            TypeShip = new TypeShipItem();
            ShipTypeOperationModes = new ShipTypeOperationModesItem();
            ShipTypeGenerators = new ShipTypeGeneratorsItem();
            TypeEquipment = new TypeEquipmentItem();
            TypePowerProduction = new TypePowerProductionItem();
            EquipmentLibrary = new EquipmentLibraryItem();

            GeneratorVendor = new GeneratorVendorItem();
            GeneratorModel = new GeneratorModelItem();
        }
    }

}
