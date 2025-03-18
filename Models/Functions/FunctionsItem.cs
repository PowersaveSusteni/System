using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class MenuItem
    {
        public string Function { get; set; } = "";
        public string FunctionGuid { get; set; } = "";
        public string MainMenu { get; set; } = "";
        public string Title { get; set; } = "";
        public string URL { get; set; } = "";
        public string Icon { get; set; } = "";
        public int Order { get; set; } = 0;
        public int AuthNiva { get; set; } = 0;
        public bool SuperAdmin { get; set; } = false;
    }
    public class ReturnValueItem
    {
        public bool Success { get; set; }
        public List<ErrorItem> Error { get; set; } = new();
        public int Status { get; set; } = 0;
        public string Description { get; set; } = "";
        public string NewGuid { get; set; } = "";
        public bool Refresh { get; set; } = false;
        public string Base64String { get; set; } = "";
    }
    public class RapporterItem
    {
        public string Fellesraad { get; set;}
        public string FilNavn { get; set; }
        public string RapId { get; set; }
        public string Tittel { get; set; }
        public string Beskrivelse { get; set; }
        public string Skjerm { get; set; }
        public string Kategori { get; set; }
        public int RapType { get; set; }
        public string Farge { get; set; }
        public bool Godkjent { get; set; }
        public bool EgenSelektering { get; set; }
        public bool expanded { get; set; }
        public string imageUrl { get; set; }
        public List<RapporterItem> Items { get; set; }

    }
    public class InfoLoggItem
    {
        public string InfoLoggGuid { get; set; }
        public string RegistreringGuid { get; set; }
        public string Tabell { get; set; }
        public DateTime OpprettetDato { get; set; }
        public string OpprettetAv { get; set; }
        public string Tittel { get; set; }
        public string SubTittel { get; set; }
        public string Ikon { get; set; }
        public string InfoTekst { get; set; }
        public DateTime Dato { get; set; }
    }
    public class HurtigmenyItem
    {
        public string Funksjon { get; set; }
        public string Tittel { get; set; }
        public string Beskrivelse { get; set; }
        public string URL { get; set; }
        public String Hovedmeny { get; set; }
        public String Ikon { get; set; }
    }
    public class MenuFunksjonItem
    {
        public String Funksjon { get; set; }
        public String FunksjonGuid { get; set; }
        public String Hovedmeny { get; set; }
        public String Tittel { get; set; }
        public String Beskrivelse { get; set; }
        public String URL { get; set; }
        public String Ikon { get; set; }
    }
    public class BrukerFunksjonItem
    {
        public string BrukerFunksjonGuid { get; set; }
        public string FunksjonGuid { get; set; }
        public string BrukerId { get; set; }
        public int Niva { get; set; }
        public string Funksjon { get; set; }
        public int Tilgang { get; set; }
        public int Sortering { get; set; }
    }
    public class GridFeltItem
    {
        public string FeltNavn { get; set; }
        public string Tittel { get; set; }
        public bool Synlig { get; set; }
    }
    public class PoststedItem
    {
        public string PostNr { get; set; }
        public int PostNrId { get; set; }
        public string Sted { get; set; }
        public string KommuneNr { get; set; }
        public string KommuneNavn { get; set; }
        public string InfoBestilling { get; set; }
        public string FylkeNr { get; set; }
        public string Fylkenavn { get; set; }
        public string Landskode { get; set; }
        public string Land { get; set; }
        public string ProgramGuid { get; set; }
        public bool Utenbys { get; set; }
        public bool Aktiv { get; set; }
    }
    public class LandItem
    {
        public string Landskode { get; set; }
        public string Navn { get; set; }
        public bool Skjul { get; set; }
        public string ProgramGuid { get; set; }
        public string KodeLang { get; set; }
        public string Domene { get; set; }
        public string TelefonKode { get; set; }
        public string NavnNorsk { get; set; }
    }
    public class EndrlingsloggItem
    {
        public string Logg_GUID { get; set; }
        public string BrukerId { get; set; }
        public DateTime Tidspunkt { get; set; }
        public string Tabell { get; set; }
        public string Post { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Program { get; set; }
        public string Program_GUID { get; set; }
        public string Fellesraad { get; set; }
    }
    public class EndrlingsloggInfoItem
    {
        public string Fellesraad { get; set; }
        public string Logg_GUID { get; set; }
        public string LoggInfo_GUID { get; set; }
        public string Felt { get; set; }
        public string Beskrivelse { get; set; }
        public string GammelVerdi { get; set; }
        public string NyVerdi { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Program_GUID { get; set; }
    }

    public class FilerItem
    {
        public string CustomerGuid { get; set; } = "";
        public string LinkGuid { get; set; } = "";
        public string FilNavn { get; set; } = "";
        public string Ext { get; set; } = "";
        public string byte64string { get; set; } = "";

        public AccountLogOnInfoItem logOnInfo { get; set; } = new AccountLogOnInfoItem();
    }
    public class ReturValueItem
    {
        public int Status { get; set; } = 0;
        public string Description { get; set; } = "";

    }

    public class TypeFuelItem
    {
        public string FuelTypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public double CarbonContent { get; set; } = 0;
        public double Cf { get; set; } = 0;
        public double DensityMGO { get; set; } = 0;
        public double Metan { get; set; } = 0;
        public double Lystgass { get; set; } = 0;
        public double NOx { get; set; } = 0;
        public double SOx { get; set; } = 0;

        public double CarbonContent2 { get; set; } = 0;
        public double Cf2 { get; set; } = 0;
        public double DensityMGO2 { get; set; } = 0;
        public double Metan2 { get; set; } = 0;
        public double Lystgass2 { get; set; } = 0;
        public double NOx2 { get; set; } = 0;
        public double SOx2 { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class TypeShipItem
    {
        public string ShipTypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }


    public class ShipTypeOperationModesItem
    {
        public string OperationModeGuid { get; set; } = "";
        public string ShipTypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public int Order { get; set; } = 0;
        public int HoursPrYear { get; set; } = 0;
        public int NumberGenerators { get; set; } = 0;
        public bool Standard { get; set; } = false;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class ShipTypeGeneratorsItem
    {
        public string? GeneratorGuid { get; set; }
        public string ShipTypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public string FuelTypeGuid { get; set; } = "";
        public string TypeGuid { get; set; } = "";
        public int kW { get; set; } = 0;
        public Single KgDieselkWh { get; set; } = 0;
        public Single EfficientMotorSwitchboard { get; set; } = 0;
        public Single MaintenanceCost { get; set; } = 0;
        public bool PowerProduction { get; set; } = false;
        public int Order { get; set; } = 0;
        public bool Standard { get; set; } = false;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }


    public class TypeEquipmentItem
    {
        public string? EquipmentTypesGuid { get; set; } = "";
        public int Type { get; set; } = 0;
        public string Name { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class TypePowerProductionItem
    {
        public string TypeGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public int Order { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class EquipmentLibraryItem
    {
        public string LibraryGuid { get; set; } = "";
        public string ProfileName { get; set; } = "";
        public string EquipmentType { get; set; } = "";
        public string FunctionDescription { get; set; } = "";
        public string Notes { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class GeneratorVendorItem
    {
        public string GeneratorVendorGuid { get; set; } = "";
        public string Vendor { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class GeneratorModelItem
    {
        public string GeneratorModelGuid { get; set; } = "";
        public string GeneratorVendorGuid { get; set; } = "";
        public string Model { get; set; } = "";
        public string TypeGuid { get; set; } = "";
        public string FuelTypeGuid { get; set; } = "";
        public int kW { get; set; } = 0;
        public Double KgDieselkWh { get; set; } = 0;
        public Single EfficientMotorSwitchboard { get; set; } = 0;
        public Single MaintenanceCost { get; set; } = 0;

        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class GeneratorImportItem
    {
        public string GeneratorModelGuid { get; set; } = "";
        public string ShipGuid { get; set; } = "";
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class GeneratorVendorModelItem
    {
        public string GeneratorVendorGuid { get; set; } = "";
        public string Vendor { get; set; } = "";
        public string GeneratorModelGuid { get; set; } = "";
        public string Model { get; set; } = "";
    }

    public class HierarchicalVendorItem
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string FulltNavn { get; set; }
        public bool HasChildren { get; set; }
        public bool expanded { get; set; }
        public string imageUrl { get; set; }
        public string ColorName { get; set; }
        public bool checkedFiles { get; set; }
        public string Eier { get; set; }
        public bool @checked { get; set; }
        public int niva { get; set; }
        public string Kommentar { get; set; }
        public string Type { get; set; }

        public List<HierarchicalVendorItem> items = new List<HierarchicalVendorItem>();
    }

    public class FuelComsuptionImportItem
    {
        public string FromGuid { get; set; } = "";
        public string GeneratorGuid { get; set; } = "";
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

}
