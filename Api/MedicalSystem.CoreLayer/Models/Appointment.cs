﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{

    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Range(0, maximum: 99999)]
        public int Cost { get; set; }
        public Report? Report { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }


        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

        [Required]
        public Boolean isOnline { get; set; }


        [ForeignKey("ZoomMeeting")]
        public int? ZoomMeetingId { get; set; }
        public ZoomMeeting? ZoomMeeting { get; set; }
    }
}
