using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{

    public class HelpSystemItem
    {
        public string HelpGuid { get; set; } = "";
        public int Modul { get; set; } = 0;
        public string ModulName { get; set; } = "";
        public string Screen { get; set; } = "";
        public string Title { get; set; } = "";
        public string Info { get; set; } = "";
        public bool Active { get; set; } = false;
        public string Kategori { get; set; } = "";
        public ErrorItem Error { get; set; } = new ErrorItem();
        public AccountLogOnInfoItem logonInfo { get; set; } = new AccountLogOnInfoItem();
    }

}
