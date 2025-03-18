using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Susteni.Models.Kalender
{

    public class KalenderModel : ISchedulerEvent
    {

        public KalenderAvtalerItem Avtale { get; set; }
        public EtikettItem Etikett { get; set; }
        public KalenderDatoerItem KalenderDatoer { get; set; }
        public KalenderRessursItem Ressurs { get; set; }

        public KalenderRessurserItem Ressurser { get; set; }

        public HierarchicalKalenderItem HierarkiskKalender { get; set; }

        public KalenderAttentiesItem Attenties { get; set; }

        public HelligdagerItem Helligdager { get; set; }

        public KalenderRessurserListeItem KalenderRessurserListe { get; set; }
        public KalenderGruppeItem KalenderGruppe { get; set; }
        public string MeetingID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }

        public string StartTimezone { get; set; }

        private DateTime end;

        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
            }
        }

        public string EndTimezone { get; set; }

        public string RecurrenceRule { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool IsAllDay { get; set; }
        public string Timezone { get; set; }
        public string RoomID { get; set; }
        //public IEnumerable<string> Attendees { get; set; }
        //public virtual ICollection<Attendee> Attendees { get; set; }
        public IEnumerable<int> Attendees { get; set; }


        public Meeting ToEntity()
        {
            var meeting = new Meeting
            {
                MeetingID = MeetingID,
                Title = Title,
                Start = Start,
                StartTimezone = StartTimezone,
                End = End,
                EndTimezone = EndTimezone,
                Description = Description,
                IsAllDay = IsAllDay,
                RecurrenceRule = RecurrenceRule,
                RecurrenceException = RecurrenceException,
                RecurrenceID = RecurrenceID,
                RoomID = RoomID,
                //Attendees = Attendees
            };

            return meeting;
        }

        public KalenderModel()
        {
            //Attendees = new HashSet<Attendee>();
            Etikett = new EtikettItem();
            Ressurs = new KalenderRessursItem();
            HierarkiskKalender = new HierarchicalKalenderItem();
            Attenties = new KalenderAttentiesItem();
            Avtale = new KalenderAvtalerItem();
            Ressurser = new KalenderRessurserItem();
            KalenderRessurserListe = new KalenderRessurserListeItem();
            KalenderDatoer = new KalenderDatoerItem();
            KalenderGruppe = new KalenderGruppeItem();
            Helligdager = new HelligdagerItem();


        }
    }

   

}
