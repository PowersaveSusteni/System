using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Admin
{
    public class AdminModel
    {

        public RolleItem Rolle { get; set; }
        public BrukerItem Bruker { get; set; }
        public BrukerTilgangItem BrukerTilgang { get; set; }
        public BrukerRolleItem BrukerRolle { get; set; }
        public KalenderTilgangTypeItem KalenderTilgangType { get; set; }
        public KalenderTilgangerItem KalenderTilganger { get; set; }
        public AdminModel()
        {
            Rolle = new RolleItem();
            Bruker = new BrukerItem();
            BrukerTilgang = new BrukerTilgangItem();
            BrukerRolle = new BrukerRolleItem();
            KalenderTilgangType = new KalenderTilgangTypeItem();
            KalenderTilganger = new KalenderTilgangerItem();
        }

    }
}
