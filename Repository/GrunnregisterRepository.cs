using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class GrunnregisterRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public GrunnregisterRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }



    }
}
