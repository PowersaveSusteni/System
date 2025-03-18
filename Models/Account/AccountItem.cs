using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{

    public class AccountsItem
    { 
        public string Fellesraad { get; set; }
        public string Navn { get; set; }
        public string BrukerId { get; set; }
        public string AktivFellesraad { get; set; }
    }

    public class AccountPassordItem
    {
        public string UserId { get; set; } = "";
        public string Password { get; set; } = "";

    }

    public class AccountUserItem
    {
        public string UserGuid { get; set; } = "";
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public bool SuperBruker { get; set; } = false;
        public bool SuperAdmin { get; set; } = false;
        public string Password { get; set; } = "";
        public string Mobil { get; set; } = "";
        public string Email { get; set; } = "";
        public string? AktivCustomerGuid { get; set; } = "";
        public int AuthLevel { get; set; } = 0;
        public string oAuthUrl { get; set; } = "";
        public bool Activ { get; set; } = true;
        public string SecretKey { get; set; } = "";
        public string SmsCode { get; set; } = "";
        public int RunVersion { get; set; } = 0;
        //public DateTime? SmsCodeTimeStampt { get; set; } = null;
        public ErrorItem Error { get; set; } = new ErrorItem();

        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }



    public class AccountLogOnInfoItem
    {
        public string UserId { get; set; } = "";
        public string Password { get; set; } = "";
        public string Server { get; set; } = "";
        public string Database { get; set; } = "";
        public string CustomerGuid { get; set; } = "";
        public string? ShipGuid { get; set; } = "";
        public string? Currency { get; set; } = "";
        public ParametersItem Parameters { get; set; } = new ParametersItem();
    }

    public class ParametersItem
    {
        public string filter { get; set; } = "";
        public string order { get; set; } = "";
        public string? field { get; set; } = "";
        public string? fieldValue { get; set; } = "";
        public int numbers { get; set; } = 100;
        public bool yesno { get; set; } = false;
    }



    public class AccountSignedInItem
    {
        public string CustomId { get; set; } = "";
        public string CurrencyCode { get; set; } = "";
        public string CustomLogo { get; set; } = "";
        public string UserGuid { get; set; } = "";
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public int SuperAdmin { get; set; } = 0;
        public int SuperBruker { get; set; } = 0;
        public int CustomerCount { get; set; } = 0;
        public string Email { get; set; } = "";
        public string Mobil { get; set; } = "";
        public string Password { get; set; } = "";
        public int LogOnOk { get; set; } = 0;
        public string SecretCode { get; set; } = "";
        public int AutLevel { get; set; } = 0;
        public string ErrorText { get; set; } = "";
        public string ErrorTextHjelp { get; set; } = "";
        public string oAuthUrl { get; set; } = "";
        public int RunVersion { get; set; } = 0;
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class UsersShipItem
    {
        public string UserShipGuid { get; set; } = "";
        public string ShipGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public bool active { get; set; } = false;
    }

    public class UsersShipsItem
    {
        public string ShipGuidList { get; set; } = "";
        public string UserId { get; set; } = "";
        public string CustomerGuid { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();

    }

    public class HierarchicalUsersShipItem
    {
        public string UserShipGuid { get; set; } = "";
        public string ShipGuid { get; set; } = "";
        public string Name { get; set; } = "";
        public string parentId { get; set; } = "";
        public bool hasChildren { get; set; } = false;
        public bool expanded { get; set; } = false;
        public string imageUrl { get; set; } = "";
        public bool @checked { get; set; } = false;
        public List<HierarchicalUsersShipItem> items = new List<HierarchicalUsersShipItem>();
    }

    public class CustomerUserItem
    {
        public string UserGuid { get; set; } = "";
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string AktivCustomerGuid { get; set; } = "";
        public bool Activ { get; set; } = false;
    }

    public class TokenItem
    {
        public string Token { get; set; }
        public DateTime Varighet { get; set; }
        public bool LogOnOk { get; set; }

        public int AutNiva { get; set; }
        public int ErrorNumber { get; set; }
        public string ErrorText { get; set; }
        public string IdentifikatorType { get; set; }
        public string Mobil { get; set; }
        public string AktivFellesraad { get; set; }
        public string brukerId { get; set; }
        public string passord { get; set; }
    }

    public class ErrorItem
    {
        public int ErrorCode { get; set; } = 0;
        public string Message { get; set; } = "";

    }

    public class oAuthInfoItem
    {
        public String Fellesraad { get; set; }
        public String oAuthGuid { get; set; }
        public String AppId { get; set; }
        public String SecretId { get; set; }
        public String TenantId { get; set; }
        public Boolean Aktiv { get; set; }
    }

    public class UserInfoItem
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public class SystemInfoListeItem
    {
        public string Fellesraad { get; set; }
        public string Navn { get; set; }
    }

}
