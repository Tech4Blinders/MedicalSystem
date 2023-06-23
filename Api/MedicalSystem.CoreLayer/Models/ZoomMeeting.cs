using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer
{
    public class ZoomMeeting
    {
        
        public int Id { get; set; }
        public string MeetingId { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
    }
}
