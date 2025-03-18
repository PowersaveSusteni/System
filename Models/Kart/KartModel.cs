using Microsoft.AspNetCore.Mvc;

namespace Susteni.Models.Kart
{
    public class KartModel
    {

        public KartItem Kart { get; set; }
        public KartEndredeGraverItem KartEndredeGraver { get; set; }
        public KirkegardGravItem KirkegardGrav { get; set; }

        public KartModel ()
        {
            Kart = new KartItem();
            KartEndredeGraver = new KartEndredeGraverItem();
            KirkegardGrav = new KirkegardGravItem();
        }

    }
}
