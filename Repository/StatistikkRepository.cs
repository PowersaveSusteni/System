using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Susteni.Repository
{
    public class StatistikkRepository : Controller
    {


        private readonly IConfiguration Configuration;

        public StatistikkRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }


    }
}
