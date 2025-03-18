namespace Susteni.Models
{
    public class CustomerItem
    {
        public string CustomerGuid { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string Adresse { get; set; } = "";
        public string Zip { get; set; } = "";
        public string? City { get; set; } = "";
        public string Phone { get; set; } = "";
        public string? EPost { get; set; } = "";
        public string? OrgNr { get; set; } = "";
        public string Logo { get; set; } = "";
        public double OilPrice { get; set; } = 0;
        public string CurrencyCode { get; set; } = "";
        public string Byte64Picture { get; set; } = "";
        public int NumberLicense { get; set; } = 0;
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

    public class ZipCityItem
    {
        public string ZipCode { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";

    }

}
