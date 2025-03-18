using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using Susteni.Models.Customer;
using Susteni.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Susteni.Repository
{
    public class HelpdeskRepository : Controller
    {

        private readonly IConfiguration Configuration;

        public HelpdeskRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Helpdesk

        [HttpPost]
        public async Task<List<Models.HelpDeskItem>> GetHelpDeskListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.HelpDeskItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.HelpDeskItem>>(result);

            foreach (var item in itemWS)
            {
                switch(item.TypeId)
                {
                    case 0:
                        item.TypeNavn = "Support";
                        item.ikon = "phone-call-filled";
                        break;

                    case 1:
                        item.TypeNavn = "Bug";
                        item.ikon = "bug-filled";
                        break;

                    case 2:
                        item.TypeNavn = "Skrivefeil";
                        item.ikon = "spell-check";
                        break;

                    case 3:
                        item.TypeNavn = "Funksjonsendring";
                        break;

                    case 4:
                        item.TypeNavn = "Mangel";
                        break;

                    case 5:
                        item.TypeNavn = "Senere";
                        item.ikon = "alarm";
                        break;

                    case 7:
                        item.TypeNavn = "Kommer";
                        item.ikon = "calendar-2";
                        break;

                    case 9:
                        item.TypeNavn = "Kommer";
                        item.ikon = "calendar-2";
                        break;
                }
            }

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.HelpDeskItem> GetHelpDesk(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.HelpDeskItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDesk", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.HelpDeskItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> SetHelpDesk(Models.HelpDeskItem item)
        {
            Models.ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Helpdesk", "SetHelpDesk", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return itemWS;
        }

        [HttpPost]
        public async Task<Models.ReturnValueItem> RemoveHelpDesk(Models.HelpDeskItem item)
        {
            Models.ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Helpdesk", "RemoveHelpDesk", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return itemWS;
        }

        #endregion

        #region Logg

        [HttpPost]
        public async Task<List<Models.HelpDeskLoggItem>> GetHelpDeskLoggListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.HelpDeskLoggItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskLoggListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.HelpDeskLoggItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.HelpDeskLoggItem> GetHelpDeskLogg(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.HelpDeskLoggItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskLogg", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.HelpDeskLoggItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> SetHelpDeskLogg(Models.HelpDeskLoggItem item)
        {
            Models.ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Helpdesk", "SetHelpDeskLogg", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return itemWS;
        }

        #endregion


        #region Bilder

        [HttpPost]
        public async Task<List<Models.HelpDeskBildeItem>> GetHelpDeskBildeListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.HelpDeskBildeItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskBildeListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.HelpDeskBildeItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.HelpDeskBildeItem> GetHelpDeskBilde(Models.AccountLogOnInfoItem logoninfo)
        {
            Models.HelpDeskBildeItem itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskBilde", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.HelpDeskBildeItem>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<Models.ReturnValueItem> SetHelpDeskBilde(Models.HelpDeskBildeItem item)
        {
            Models.ReturnValueItem itemWS = new();

            string json = JsonConvert.SerializeObject(item);

            string result = await SusteniExecuteJson("Helpdesk", "SetHelpDeskBilde", json, "");

            itemWS = JsonConvert.DeserializeObject<Models.ReturnValueItem>(result);

            return itemWS;
        }

        #endregion

        #region Typer

        [HttpPost]
        public async Task<List<Models.HelpDeskProgramItem>> GetHelpDeskProgramListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.HelpDeskProgramItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskProgramListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.HelpDeskProgramItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.HelpDeskStatusItem>> GetHelpDeskStatusListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.HelpDeskStatusItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskStatusListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.HelpDeskStatusItem>>(result);

            return itemWS;
        }


        [HttpPost]
        public async Task<List<Models.HelpDeskTypeItem>> GetHelpDeskTypeListe(Models.AccountLogOnInfoItem logoninfo)
        {
            List<Models.HelpDeskTypeItem> itemWS = new();

            string json = JsonConvert.SerializeObject(logoninfo);

            string result = await SusteniExecuteJson("Helpdesk", "GetHelpDeskTypeListe", json, "");

            itemWS = JsonConvert.DeserializeObject<List<Models.HelpDeskTypeItem>>(result);

            return itemWS;
        }


        #endregion



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
