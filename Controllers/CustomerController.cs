using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Susteni.Repository;
using Susteni.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Http;
using Susteni.Models.Customer;
using Susteni.Models.Ship;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration Configuration;

        public CustomerController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["LogOnOk"] = "2";
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("AccOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("AccStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("AccGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            return View();
        }

        public IActionResult Customers()
        {
            CustomerModel model = new CustomerModel();  
            ViewData["LogOnOk"] = "2";
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("AccOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("AccStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("AccGrunnregister");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["SuperAdmin"] = HttpContext.Session.GetInt32("SuperAdmin");
            ViewData["CustomerGuid"] = HttpContext.Session.GetString("CustomerGuid");
            return View(model);
        }

        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];
            logonInfo.CustomerGuid = HttpContext.Session.GetString("CustomerGuid");

            return logonInfo;
        }

        public ActionResult DialogLastOppLogo()
        {
            return PartialView("_LastOppLogo");
        }

        public async Task<ActionResult> getCustomerList([DataSourceRequest] DataSourceRequest request, string strFilter, string sortering)
        {
            CustomerRepository customerRepository = new CustomerRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            if (strFilter != null) { logonInfo.Parameters.filter = strFilter; }
            if (sortering != null) { logonInfo.Parameters.order = sortering; }

            List<Models.CustomerItem> items = new();

            if (strFilter == null) { strFilter = ""; }

            items = await customerRepository.getCustomerList(logonInfo);

            DataSourceResult result = items.ToDataSourceResult(request);

            return Json(result);

        }

        public ActionResult NewCustomer()
        {
            CustomerModel modell = new CustomerModel();

            return PartialView("_CustomerInfo", modell);
        }

        public async Task<ReturnValueItem> SetCustomer(CustomerModel model)
        {
            CustomerRepository customerRepository = new CustomerRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            CustomerItem item = new();
            item = model.Customer;
            item.logonInfo = logonInfo;


            retur = await customerRepository.SetCustomer(item);

            return retur;
        }

        public async Task<ReturnValueItem> RemoveCustomer([DataSourceRequest] DataSourceRequest request, string CustomerGuid)
        {
            CustomerRepository customerRepository = new CustomerRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            ReturnValueItem retur = new();

            if (CustomerGuid != null) { 
                logonInfo.Parameters.filter = "CustomerGuid = '" + CustomerGuid + "'";
                retur = await customerRepository.RemoveCustomer(logonInfo);
            }

            return retur;

        }

        public async Task<ActionResult> GetCustomer(string customerGuid)
        {
            CustomerModel modell = new CustomerModel();
            CustomerRepository customerRepository = new CustomerRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();

            if (customerGuid != null)
            {
                logonInfo.Parameters.filter = "CustomerGuid='" + customerGuid + "'";
            }

            CustomerItem items = await customerRepository.getCustomer(logonInfo);

            modell.Customer = items;

            return PartialView("_CustomerInfo", modell);
        }

        public async Task<ReturValueItem> uploadPicture(string customerGuid, string base64string)
        {
            ShipModel modell = new ShipModel();
            CustomerRepository customerRepository = new CustomerRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            FilerItem item = new FilerItem();

            item.LinkGuid = customerGuid;
            item.byte64string = base64string;

            HttpContext.Session.SetString("Logo", base64string);

            ReturValueItem itemWS = await customerRepository.uploadLogo(logonInfo, item);

            return itemWS;
        }

        public string GetLogo(string customerGuid)
        {
            string logo = HttpContext.Session.GetString("Logo");
            return logo;
        }

        public string GetPictureShip(string customerGuid)
        {
            string logo = HttpContext.Session.GetString("PictureShip");
            return logo;
        }

        public async Task<ZipCityItem> GetCity(string zip)
        {
            CustomerModel modell = new CustomerModel();
            CustomerRepository customerRepository = new CustomerRepository(Configuration);
            AccountLogOnInfoItem logonInfo = GetLogonInfo();
            ZipCityItem items = new();

            if (zip != null)
            {
                logonInfo.Parameters.filter = "zip='" + zip + "'";
                items = await customerRepository.GetCity(logonInfo);
            }

           
            return items;
        }


    }
}
