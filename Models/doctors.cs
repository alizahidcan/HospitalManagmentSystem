using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagment.Models
{
    public class doctors
    {
        [Key] 
        public int id {  get; set; }
        public int age { get; set; }
        public string name { get; set; }

        public string Image {  get; set; }

        public string Description { get; set; }

        public string holidayDay { get; set; }

        public string workingHours { get; set; }

        [ForeignKey("department")]

        public int departmentId { get; set; }
        public department? department {  get; set; }
        
    }
}
