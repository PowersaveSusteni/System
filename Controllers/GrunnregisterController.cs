using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Susteni.Models;
using Susteni.Repository;
using Susteni.Models.Grunnregister;
using Susteni.Models.Kalender;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class GrunnregisterController : Controller
    {

        private readonly IConfiguration Configuration;

        public GrunnregisterController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }


        public IActionResult Tjenester()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult Bank()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult Dimensjoner()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult Etikett()
        {
            KalenderModel modell = new KalenderModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult Eksportformat()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult Fakturatyper()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult Sokn()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult VedlMaler()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }

        public IActionResult Rapporter()
        {
            GrunnregisterModel modell = new GrunnregisterModel();
            ViewData["LogOnOk"] = "2";
            ViewData["Bruker"] = HttpContext.Session.GetString("BrukerId");
            ViewData["AccMedarbieder"] = HttpContext.Session.GetInt32("ModulMedarbeider");
            ViewData["AccKH"] = HttpContext.Session.GetInt32("ModulKH");
            ViewData["AccByra"] = HttpContext.Session.GetInt32("ModulByra");
            ViewData["AccGravplass"] = HttpContext.Session.GetInt32("ModulGravplass");
            ViewData["AccEngrafo"] = HttpContext.Session.GetInt32("ModulEngrafo");
            ViewData["AccOkonomi"] = HttpContext.Session.GetInt32("ModulOkonomi");
            ViewData["AccStatistikk"] = HttpContext.Session.GetInt32("ModulStatistikk");
            ViewData["AccGrunnregister"] = HttpContext.Session.GetInt32("ModulGrunnregister");
            ViewData["AccKisteskanning"] = HttpContext.Session.GetInt32("ModulKisteskanning");
            ViewData["AccKrematorium"] = HttpContext.Session.GetInt32("ModulKrematorium");
            ViewData["AcckWeb"] = HttpContext.Session.GetInt32("ModulkWeb");
            ViewData["SuperBruker"] = HttpContext.Session.GetInt32("SuperBruker");
            ViewData["Brukernavn"] = HttpContext.Session.GetString("Brukernavn");
            return View(modell);
        }


    }

}
