using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Scheduler
{
    public partial class MeetingAttendee
    {
        public string MeetingID { get; set; }
        public string AttendeeID { get; set; }

        public virtual Meeting Meeting { get; set; }
    }
}
