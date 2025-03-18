using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Help
{
    public class HjelpModel
    { 
        public HelpSystemItem HelpSystem { get; set; }

        public HjelpModel()
        {
            HelpSystem = new HelpSystemItem();
        }

    }
}
