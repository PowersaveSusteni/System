using Microsoft.AspNetCore.Mvc;
using System;

namespace Susteni.Models
{

    public class KartItem
    {
        public string Fellesraad { get; set; }
        public string KartGuid { get; set; }
        public string KirkegardGuid { get; set; }
        public string Filnavn { get; set; }
        public string Bruker { get; set; }
        public string BrukerId { get; set; }
        public string Navn { get; set; }
        public string WebFilNavn { get; set; }
        public string Papir { get; set; }
        public string SkalaTekst { get; set; }
        public int Skala { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime EndretDato { get; set; }
        public string Beskrivelse { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Orientering { get; set; }
    }

    public class KartEndredeGraverItem
    {
        public string Fellesraad { get; set; }
        public string KartGuid { get; set; }
        public DateTime GravEndretDato { get; set; }
        public DateTime WebKartDato { get; set; }
        public int Laast { get; set; }
        public int LopeNr { get; set; }
        public int GravlagtPos { get; set; }
        public string Navn { get; set; }
        public DateTime FDato { get; set; }
        public DateTime DDato { get; set; }
        public DateTime GDato { get; set; }
        public int GAar { get; set; }
        public int ForfallAar { get; set; }
        public int Fredningstid { get; set; }
        public string GravFelles { get; set; }
        public string Plassering { get; set; }
        public string KirkegardGuid { get; set; }
        public string KontaktGuid { get; set; }
    }


    public class KirkegardGravItem
    {
        public int Sortering { get; set; }
        public string Fellesraad { get; set; }
        public string GravGuid { get; set; }
        public int GravNr { get; set; }
        public string GravNr2 { get; set; }
        public string KartGuid { get; set; }
        public string RekkeGuid { get; set; }
        public string SistGravlagtGuid { get; set; }
        public string GravstedGuid { get; set; }
        public string FesteGuid { get; set; }
        public int GravId { get; set; }
        public int ForfallAar { get; set; }
        public int Fredningstid { get; set; }
        public int VareId { get; set; }
        public int HarNotat { get; set; }
        public bool UrneGrav { get; set; }
        public string Plassering { get; set; }
        public bool Faktureres { get; set; }
        public int TilbudFornying { get; set; }
        public int Laast { get; set; }
        public int TypeGrav { get; set; }
        public bool FaktureresStell { get; set; }
        public int AntallGravlagte { get; set; }
        public bool Historiske { get; set; }
        public Single Gravareal { get; set; }
        public DateTime SikretDato { get; set; }
        public int Parorende { get; set; }
        public string Kart { get; set; }
        public string objHandle { get; set; }
        public DateTime KartOppdatertDato { get; set; }
        public DateTime GravEndretDato { get; set; }
        public int SlettesAar { get; set; }
        public string FeltGuid { get; set; }
        public string KirkegardGuid { get; set; }
        public string FeltNavn { get; set; }
        public string RekkeNavn { get; set; }
        public bool Boltet { get; set; }
        public DateTime LaastTilDato { get; set; }
        public DateTime LaastTilDatoVurder { get; set; }
        public string LaastTilTekst { get; set; }
        public int BegrensBruk { get; set; }
        public DateTime BegrensBrukTil { get; set; }
        public DateTime BegrensBrukTilVurder { get; set; }
        public string BegrensBrukTekst { get; set; }
        public string vRekkeNavn { get; set; }
        public int StellStatus { get; set; }
        public bool Historisk { get; set; }
        public string Bestilling_GUID { get; set; }
        public bool FRI_JANEI_1 { get; set; }
        public bool FRI_JANEI_2 { get; set; }
        public bool FRI_JANEI_3 { get; set; }
        public bool FRI_JANEI_4 { get; set; }
        public bool FRI_JANEI_5 { get; set; }
        public bool FRI_JANEI_6 { get; set; }
        public bool FRI_JANEI_7 { get; set; }
        public bool FRI_JANEI_8 { get; set; }
        public bool FRI_JANEI_9 { get; set; }
        public bool FRI_JANEI_10 { get; set; }
        public bool FRI_JANEI_11 { get; set; }
        public bool FRI_JANEI_12 { get; set; }
        public bool FRI_JANEI_13 { get; set; }
        public bool FRI_JANEI_14 { get; set; }
        public bool FRI_JANEI_15 { get; set; }
        public string FRI_TEKST_1 { get; set; }
        public string FRI_TEKST_2 { get; set; }
        public string FRI_TEKST_3 { get; set; }
        public string FRI_TEKST_4 { get; set; }
        public string FRI_TEKST_5 { get; set; }
        public string FRI_TEKST_6 { get; set; }
        public string FRI_TEKST_7 { get; set; }
        public string FRI_TEKST_8 { get; set; }
        public string FRI_TEKST_9 { get; set; }
        public string FRI_TEKST_10 { get; set; }
        public string FRI_TEKST_11 { get; set; }
        public string FRI_TEKST_12 { get; set; }
        public string FRI_TEKST_13 { get; set; }
        public string FRI_TEKST_14 { get; set; }
        public string FRI_TEKST_15 { get; set; }
        public string FRI_TEKST_16 { get; set; }
        public string FRI_TEKST_17 { get; set; }
        public string FRI_TEKST_18 { get; set; }
        public string FRI_TEKST_19 { get; set; }
        public string FRI_TEKST_20 { get; set; }
        public int FRI_TALL_1 { get; set; }
        public int FRI_TALL_2 { get; set; }
        public int FRI_TALL_3 { get; set; }
        public int FRI_TALL_4 { get; set; }
        public int FRI_TALL_5 { get; set; }
        public int FRI_TALL_6 { get; set; }
        public int FRI_TALL_7 { get; set; }
        public int FRI_TALL_8 { get; set; }
        public int FRI_TALL_9 { get; set; }
        public int FRI_TALL_10 { get; set; }
        public DateTime FRI_DATO_1 { get; set; }
        public DateTime FRI_DATO_2 { get; set; }
        public DateTime FRI_DATO_3 { get; set; }
        public DateTime FRI_DATO_4 { get; set; }
        public DateTime FRI_DATO_5 { get; set; }
        public DateTime FRI_DATO_6 { get; set; }
        public DateTime FRI_DATO_7 { get; set; }
        public DateTime FRI_DATO_8 { get; set; }
        public DateTime FRI_DATO_9 { get; set; }
        public DateTime FRI_DATO_10 { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string InfoTekst { get; set; }
        public int ForfallAarLarvik { get; set; }
        public int FredTidLarvik { get; set; }
        public Single Lat { get; set; }
        public Single Long { get; set; }
        public int Public360RecNo { get; set; }
        public bool LoggProdusert { get; set; }
        public DateTime WebKartDato { get; set; }
    }

}
