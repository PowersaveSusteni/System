using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Scheduler
{

    public partial class Meeting 
        {
            public Meeting()
            {
                Attendees = new HashSet<Attendee>();
            }

            public string MeetingID { get; set; }
            public string Description { get; set; }
            public DateTime End { get; set; }
            public string EndTimezone { get; set; }
            public bool IsAllDay { get; set; }
            public string RecurrenceException { get; set; }
            public int? RecurrenceID { get; set; }
            public string RecurrenceRule { get; set; }
            public string RoomID { get; set; }
            public DateTime Start { get; set; }
            public string StartTimezone { get; set; }
            public string Title { get; set; }

            public virtual ICollection<Attendee> Attendees { get; set; }
            public virtual Meeting Recurrence { get; set; }
            public virtual ICollection<Meeting> InverseRecurrence { get; set; }
        }
    }
