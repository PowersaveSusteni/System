using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Susteni.Models;
using System.Text;

namespace Susteni.Repository
{
    public class HelpRepository : Controller
    {
        private readonly IConfiguration Configuration;

        public HelpRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<List<Models.HelpSystemItem>> GetHelpSystemListe(Models.AccountLogOnInfoItem logoninfo)
        {

            List<Models.HelpSystemItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Functions", "GetHelpSystemListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.HelpSystemItem>>(result);

            return itemWS;

        }

        public async Task<Models.HelpSystemItem> GetHelpSystem(Models.AccountLogOnInfoItem logoninfo)
        {

            Models.HelpSystemItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Functions", "GetHelpSystem", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.HelpSystemItem>(result);

            return itemWS;

        }

        [HttpPost]
        public async Task<ReturnValueItem> SetHelpSystem(Models.HelpSystemItem item)
        {
            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Functions", "SetHelpSystem", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
        }


        [HttpPost]
        public async Task<ReturnValueItem> RemoveHelpSystem(Models.AccountLogOnInfoItem logoninfo)
        {
            ReturnValueItem retur = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Functions", "RemoveHelpSystem", json, "");

            retur = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return retur;
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
