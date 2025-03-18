using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class MinSideViewModel
    {
        public string RessursGuid { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        public string Telefon { get; set; }
        public string Mobil { get; set; }
        public string Epost { get; set; }
        //public string MineFunksjoner As List(Of FrivilligeFunksjonerItem)
        //public string MittSamtykke As SamtykkeItem
        //public string FrivilligeBehov As List(Of FrivilligeBehovItem)
        //public string UtilgjengeligPeriode As List(Of UtilgjengeligItem)
        public Boolean PersonvernGodkjenn { get; set; }
        public Boolean TilskrivTelefon { get; set; }
        public Boolean TilskrivSMS { get; set; }
        public Boolean TilskrivEpost { get; set; }
        public Boolean TilskrivBrev { get; set; }
        //public string PersonvernVarighet As Dictionary(Of Integer, String)
        public string ValgtVarighet { get; set; }
        public DateTime FornyetTilDato { get; set; }
        public string SoknIds { get; set; }
        public string ValgtBehovId { get; set; }

        public MinSideViewModel()
        {
            Mobil = "";
            Navn = "";
            Epost = "";
            //        UtilgjengeligPeriode = New List(Of UtilgjengeligItem)
            //        MineFunksjoner = New List(Of FrivilligeFunksjonerItem)
            //        FrivilligeBehov = New List(Of FrivilligeBehovItem)
            //        MittSamtykke = New SamtykkeItem
        }

        public class UtilgjengeligItem
        {
            public string KalenderGuid { get; set; }
            public DateTime StartDato { get; set; }
            public DateTime SluttDato { get; set; }
            public string Emne { get; set; }
        }
    }
}
