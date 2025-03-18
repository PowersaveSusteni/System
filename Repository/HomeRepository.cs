using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class HomeRepository : Controller
    {

        private readonly IConfiguration Configuration;

        public HomeRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }



    }
}
