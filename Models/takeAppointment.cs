using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagment.Models
{
    public class takeAppointment
    {
        [Required]
        
        public DateOnly justDate { get; set; }

        [Required]
        
        public TimeOnly time { get; set; }


        [ForeignKey("doctors")]

        public int doctorId { get; set; }
        public doctors? doctors { get; set; }

        [ForeignKey("department")]

        public int departmentId { get; set; }
        public department? department { get; set; }


        public SelectList DepartmentData { get; set; }
        
        public int SelectedDepartmentId { get; set; }
        public SelectList DoctorData { get; set; }
        [Required]
        public int SelectedDoctorId { get; set; }


    }
}
