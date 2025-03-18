using Susteni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class CustomerRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<List<Models.CustomerItem>> getCustomerList(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.CustomerItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Customer", "GetCustomerList", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.CustomerItem>>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.CustomerItem> getCustomer(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.CustomerItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Customer", "GetCustomer", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.CustomerItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<ReturnValueItem> SetCustomer(Models.CustomerItem item)
        {
            Models.ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Customer", "SetCustomer", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveCustomer(Models.AccountLogOnInfoItem logoninfo)
        {

            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Customer", "RemoveCustomer", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        public async Task<ReturValueItem> uploadLogo(AccountLogOnInfoItem logonInfo, Models.FilerItem item)
        {

            item.logOnInfo = logonInfo;


            Models.ReturValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Customer", "SetLogo", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ReturValueItem>(result);

            return itemWS;

        }


        [HttpPost]
        public async Task<Models.ZipCityItem> GetCity(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.ZipCityItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Customer", "GetCity", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ZipCityItem>(result);

            return itemWS;
        }

        public async Task<string> SusteniExecuteJson(string service, string funksjon, string json, string parameters)
        {
            WebHeaderCollection wHeader = new WebHeaderCollection();
            string myText = "";
            string sUrl = "";
            string paramter = json.ToString();
            wHeader.Clear();

            sUrl = Configuration["MySettings:WebserviceUrl"];

            if (sUrl != null && sUrl.Length > 0)
            {
                try
                {
                    if (parameters != null && parameters.Length > 0)
                        sUrl += service + "/" + funksjon + "?" + parameters;
                    else
                        sUrl += service + "/" + funksjon;

                    var client = new HttpClient();
                    client.BaseAddress = new Uri(sUrl);

                    var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(sUrl, content).Result;
                    return await result.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    myText = ex.Message;
                }
            }

            return myText;
        }


    }
}
