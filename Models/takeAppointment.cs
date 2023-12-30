using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagment.Models
{
    public class takeAppointment 
    {
        public DateOnly justDate { get; set; }

        public TimeOnly time { get; set; }


        [ForeignKey("doctors")]

        public int doctorId { get; set; }
        public doctors? doctors { get; set; }

        [ForeignKey("department")]

        public int departmentId { get; set; }
        public department? department { get; set; }
    }
}
