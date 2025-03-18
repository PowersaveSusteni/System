using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.HelpDesk
{

    public class HelpDeskModel
    {
        public HelpDeskItem HelpDesk { get; set; }
        public HelpDeskBildeItem HelpDeskBilde { get; set; }
        public HelpDeskLoggItem HelpDeskLogg { get; set; }
        public HelpDeskProgramItem HelpDeskProgram { get; set; }
        public HelpDeskStatusItem HelpDeskStatus { get; set; }
        public HelpDeskTypeItem HelpDeskType { get; set; }
        public HelpdeskStatistikkItem HelpdeskStatistikk { get; set; }

        public HelpDeskModel()
        {
            HelpDesk = new HelpDeskItem();  
            HelpDeskBilde = new HelpDeskBildeItem();
            HelpDeskLogg = new HelpDeskLoggItem();
            HelpDeskProgram = new HelpDeskProgramItem();
            HelpDeskStatus = new HelpDeskStatusItem();
            HelpDeskType = new HelpDeskTypeItem();
            HelpdeskStatistikk = new HelpdeskStatistikkItem();
        }
    }


}
