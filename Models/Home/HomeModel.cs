using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Susteni.Models.Home
{
    public class HomeModel
    {


        public KalenderHuskelisteItem Huskeliste { get; set; }

        public HomeNyhetItem Nyhet { get; set; }

        public FakturaStatusItem FakturaStatus { get; set; }

        public HomeModel()
        {
            Huskeliste = new KalenderHuskelisteItem();
            Nyhet = new HomeNyhetItem();
            FakturaStatus = new FakturaStatusItem();
        }

        
    }
}
