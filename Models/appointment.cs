using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagment.Models
{
    public class appointment
    {
        [Key] 
        public int id {  get; set; }

        public DateOnly justDate { get; set; }

        public TimeOnly time { get; set; }

        [ForeignKey("users")]

        public int userId { get; set; }
        public users? users { get; set; }
        
        [ForeignKey("doctors")]

        public int doctorId { get; set; }
        public doctors? doctors { get; set; }

        [ForeignKey("department")]

        public int departmentId { get; set; }
        public department? department {  get; set; }
        
    }
}
