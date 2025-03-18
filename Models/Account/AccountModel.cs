using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Account
{
    public class AccountModel
    {
        public AccountSignedInItem LoginView { get; set; }

        public TokenItem Token { get; set; }
        public oAuthInfoItem oAuthInfo { get; set; }
        public UserInfoItem UserInfo { get; set; }

        public AccountsItem Account { get; set; }
        public AccountUserItem AccountUser { get; set; }

        public SystemInfoListeItem SystemInfoListe { get; set; }

        public AccountModel()
        {
            LoginView = new AccountSignedInItem();
            LoginView.LogOnOk = 0;

            Token = new TokenItem();
            Token.LogOnOk = false;

            oAuthInfo = new oAuthInfoItem();

            UserInfo = new UserInfoItem();
            Account = new AccountsItem();
            AccountUser = new AccountUserItem();

            SystemInfoListe = new SystemInfoListeItem();

        }
    }

    


}
