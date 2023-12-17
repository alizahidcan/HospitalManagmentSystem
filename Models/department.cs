using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class department
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Doctors { get; set; }
    }
}
