using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public class KalenderItem
    {
        public String KalenderGuid { get; set; }
        public DateTime StartDato { get; set; }
        public String StartTid { get; set; }
        public DateTime SluttDato { get; set; }
        public String SluttTid { get; set; }
        public String Emne { get; set; }
        public String Tekst { get; set; }
        public int Monster { get; set; }
        public int Dager { get; set; }
        public int DagInt { get; set; }
        public int UkeInt { get; set; }
        public Boolean UkeMan { get; set; }
        public Boolean UkeTir { get; set; }
        public Boolean UkeOns { get; set; }
        public Boolean UkeTor { get; set; }
        public Boolean UkeFre { get; set; }
        public Boolean UkeLor { get; set; }
        public Boolean UkeSon { get; set; }
        public DateTime MonsterStartDato { get; set; }
        public DateTime MonsterStopDato { get; set; }
        public Boolean UtenStopp { get; set; }
        public int AntallRepiteringer { get; set; }
        public int MndPattern { get; set; }
        public int MndDato { get; set; }
        public int MndDatoIntervall { get; set; }
        public int MndUke { get; set; }
        public int MndDag { get; set; }
        public int MndDagIntervall { get; set; }
        public int AarInt { get; set; }
        public int AarDag { get; set; }
        public int AarMnd { get; set; }
        public int PreTid { get; set; }
        public int PostTid { get; set; }
        public String Eier { get; set; }
        public Boolean PaaMin { get; set; }
        public int PaaMinTid { get; set; }
        public String RessursTekst { get; set; }
        public string RessursId { get; set; }
    }
}
