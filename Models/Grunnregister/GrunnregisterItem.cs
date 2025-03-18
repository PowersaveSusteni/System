using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class TjenesteItem
    {
        public string Fellesraad { get; set; }
        public int TjenesteNr { get; set; }
        public string TjenesteGuid { get; set; }
        public string Enhet { get; set; }
        public string Tittel { get; set; }
        public string Tekst { get; set; }
        public string TjenesteGruppe { get; set; }
        public string GruppeNavn { get; set; }
        public string KontoNr { get; set; }
        public string VareNrExt { get; set; }
        public bool MomsKode { get; set; }
        public Single PrisPrUMVA { get; set; }
        public Single PrisPrMMVA { get; set; }
        public string ExtKontoNr { get; set; }
        public int FaktLType { get; set; }
        public string Dim1 { get; set; }
        public string Dim2 { get; set; }
        public string Dim3 { get; set; }
        public string Dim4 { get; set; }
        public string Dim5 { get; set; }
        public bool Aktiv { get; set; }
        public bool Matrise { get; set; }
        public int TypeAlder { get; set; }
        public int Sortering { get; set; }
        public bool EnGangPrGrav { get; set; }
        public bool OrdreListe { get; set; }
        public int FaktId { get; set; }
        public bool PaaLister { get; set; }
        public bool TjForbruk { get; set; }
        public int RevRapCol { get; set; }
        public bool Innberettes { get; set; }
        public string Kommentar { get; set; }
        public DateTime SistEndretDato { get; set; }
        public string EndretAv { get; set; }
        public int TypeFakt { get; set; }
        public string PaaStellListeFra { get; set; }
        public string PaaStellListeTil { get; set; }
        public string DebetKonto { get; set; }
        public string KreditKonto { get; set; }
        public string FaktType_GUID { get; set; }
        public bool OverforKunHeader { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Dim6 { get; set; }
        public int Modul { get; set; }
        public string GruppeId { get; set; }
        public string Salgskonto { get; set; }
        public string FargeNavn { get; set; }
    }

    public class BankItem
    {
        public bool OCRKonto { get; set; }
        public string Fellesraad { get; set; }
        public string BankId { get; set; }
        public string Navn { get; set; }
        public string SerieNavn { get; set; }
        public string KontoNr { get; set; }
        public int BankType { get; set; }
        public string Kontakt_GUID { get; set; }
        public int UniKlient { get; set; }
        public string SWIFT { get; set; }
        public string IBAN { get; set; }
        public string FakturaFil { get; set; }
        public string MottakerNavn { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string PostNr { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public int FakturaSystem { get; set; }
        public bool Faktura { get; set; }
        public string OrgNr { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public int FakturaNrSerie { get; set; }
        public bool Aktiv { get; set; }
        public int OCRKunde { get; set; }
        public int OCRFaktura { get; set; }
        public bool Ordre { get; set; }
        public int PostNrId { get; set; }
        public string Epost { get; set; }
        public string Heading { get; set; }
        public string BankGuid { get; set; }
        public string FulltNavn { get; set; }
    }

    public class BankBrukerItem
    {
        public int Id { get; set; }
        public string Fellesraad { get; set; }
        public string KontoNr { get; set; }
        public string Brukerid { get; set; }
        public bool Standard { get; set; }
        public string BrukerNavn { get; set; }
    }

    public class TjenesteGrupperItem
    {
        public string Fellesraad { get; set; }
        public string TjenesteGruppe { get; set; }
        public string Navn { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string TjenesteGruppeGuid { get; set; }
    }

    public class TjenestePrismatriseItem
    {
        public int TjenesteNr { get; set; }
        public string Fellesraad { get; set; }
        public string Tjeneste_Matrise_GUID { get; set; }
        public string Kirkegard_GUID { get; set; }
        public int Alder { get; set; }
        public Single Pris { get; set; }
        public int FraAar { get; set; }
        public int TilAar { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
    }

    public class FakturaSystemerItem
    {
        public bool EPostVedlegg { get; set; }
        public string FtpServer { get; set; }
        public string FtpUser { get; set; }
        public string FtpPassword { get; set; }
        public string XLOppdGiver { get; set; }
        public string XLUserId { get; set; }
        public string XLPassword { get; set; }
        public int XLAuto { get; set; }
        public int XLKundeNummer { get; set; }
        public bool XLTest { get; set; }
        public int XLfraNr { get; set; }
        public int XLtilNr { get; set; }
        public string Momskode { get; set; }
        public bool TaMedDimmensjoner { get; set; }
        public bool UQ_BrukXML { get; set; }
        public bool XLEHF { get; set; }
        public int DatabaseType { get; set; }
        public string ServerNavn { get; set; }
        public string DatabaseNavn { get; set; }
        public string DBBrukerId { get; set; }
        public string DBPassord { get; set; }
        public string Fellesraad { get; set; }
        public string FaktEksp_GUID { get; set; }
        public string Navn { get; set; }
        public int FakturaType { get; set; }
        public int UM_KlientId { get; set; }
        public string UM_Brukernavn { get; set; }
        public string UM_Passord { get; set; }
        public string UM_SU { get; set; }
        public string UM_SBlob { get; set; }
        public string AG_BatchId { get; set; }
        public string AG_ClientId { get; set; }
        public string AG_Ansvarlig { get; set; }
        public string AG_Ansvarlig2 { get; set; }
        public string AG_KontrollSti { get; set; }
        public int AG_OrdreNrMaks { get; set; }
        public int AG_OrdreNrNeste { get; set; }
        public int AG_PersonNrText { get; set; }
        public string AG_PGKonto { get; set; }
        public int UQ_Auto { get; set; }
        public string UQ_OppdragGiver { get; set; }
        public string UQ_SelskapNr { get; set; }
        public int UQ_InfoTjenesteNr { get; set; }
        public int UQ_FormaterNavn { get; set; }
        public string IBM_KundeNr { get; set; }
        public string AX_KlientId { get; set; }
        public string AX_KundeGruppe { get; set; }
        public string AX_FolderNavn { get; set; }
        public string VB_KlientId { get; set; }
        public string EksportFil { get; set; }
        public string EPost { get; set; }
    }

    public class FakturaSerieItem
    {
        public string Fellesraad { get; set; }
        public int FakturaNrSerie { get; set; }
        public string Navn { get; set; }
        public string FaktEkspGuid { get; set; }
        public bool Aktiv { get; set; }
    }

    public class SoknItem
    {
        public string Navn { get; set; }
        public string Fellesraad { get; set; }
        public string Sokn_Id { get; set; }
        public string KommuneNr { get; set; }
        public string SoknNr { get; set; }
        public string PresteGjeld_Id { get; set; }
        public int ReknKode { get; set; }
        public string Prosti_ID { get; set; }
        public bool Proste_Sete { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string PostNr { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Fax { get; set; }
        public string EPost { get; set; }
        public int GudstjenesteOrdning { get; set; }
        public string Spraak { get; set; }
        public string OrgNr_Sokn { get; set; }
        public string OrgNr_Fellesraad { get; set; }
        public string OrgNr_Prosti { get; set; }
        public string OrgNr_Bispedoemme { get; set; }
        public string Hjelper1 { get; set; }
        public string Hjelper2 { get; set; }
        public string Hjelper3 { get; set; }
        public string Hjelper4 { get; set; }
        public string Hjelper5 { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string Agrando_Id { get; set; }
        public int ppSlideNotebilde { get; set; }
        public string ppTittelFarge { get; set; }
        public string ppTittelFont { get; set; }
        public int ppTittelFontSize { get; set; }
        public int ppTittelAlign { get; set; }
        public string ppTekstFarge { get; set; }
        public string ppTekstFont { get; set; }
        public int ppTekstFontSize { get; set; }
        public int ppTekstAlign { get; set; }
        public int ppTekstLinjer { get; set; }
        public int EndreTekst { get; set; }
        public string LiturgTekst { get; set; }
        public string MenighetTekst { get; set; }
        public string AlleTekst { get; set; }
        public string FargeMenighetTekst { get; set; }
        public string FargeLiturgTekst { get; set; }
        public string LTMLTekst { get; set; }
        public string FargeInfoTekst { get; set; }
        public string GruppeNavn { get; set; }
        public int PostNrId { get; set; }
        public bool Visible { get; set; }
        public int AgrandoKID { get; set; }
        public string BemanningsAnsvarlig_GUID { get; set; }
        public bool FrivilligVisGenerell { get; set; }
        public string SoknGuid { get; set; }
    }

    public class FakturaTyperItem
    {
        public string Fellesraad { get; set; }
        public string FaktType_GUID { get; set; }
        public int FaktId { get; set; }
        public string Beskrivelse { get; set; }
        public string Att1id { get; set; }
        public string Att2id { get; set; }
        public string Att3id { get; set; }
        public string Att4id { get; set; }
        public string Att5id { get; set; }
        public string Att6id { get; set; }
        public string Att7id { get; set; }
        public string Att8id { get; set; }
        public string Att9id { get; set; }
        public string DimValue1 { get; set; }
        public string DimValue2 { get; set; }
        public string DimValue3 { get; set; }
        public string DimValue4 { get; set; }
        public string DimValue5 { get; set; }
        public string DimValue6 { get; set; }
        public string DimValue7 { get; set; }
        public string DimValue8 { get; set; }
        public string DimValue9 { get; set; }
        public string Dim1 { get; set; }
        public string Dim2 { get; set; }
        public string Dim3 { get; set; }
        public string Dim4 { get; set; }
        public string Dim5 { get; set; }
        public string Dim6 { get; set; }
        public string Dim7 { get; set; }
        public string Dim8 { get; set; }
        public string Dim9 { get; set; }
        public int VareId { get; set; }
        public string FaktTekst { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public bool FasteAvgifter { get; set; }
        public string KontoGruppe { get; set; }
        public string KundeGruppe { get; set; }
        public string KontoNr { get; set; }
        public int FastAvgiftTN { get; set; }
        public int PurregebyrTN { get; set; }
    }

    public class TjenesteDimensjonerItem
    {
        public string Fellesraad { get; set; }
        public int Nivaa { get; set; }
        public string Verdi { get; set; }
        public string Tekst { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
        public string TjenesteDimGuid { get; set; }
    }

    public class DistriktItem
    {
        public string Fellesraad { get; set; }
        public string Distrikt_GUID { get; set; }
        public int DistriktId { get; set; }
        public string Distrikt { get; set; }
        public string Tlf { get; set; }
        public string Tider { get; set; }
        public string Leder { get; set; }
        public string EPost { get; set; }
        public string FargeNavn { get; set; }
        public string OpprettetAv { get; set; }
        public DateTime OpprettetDate { get; set; }
        public string EndretAv { get; set; }
        public DateTime EndretDato { get; set; }
        public string SlettetAv { get; set; }
        public DateTime SlettetDato { get; set; }
    }

}
