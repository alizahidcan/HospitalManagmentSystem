using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagment.Models
{
    public class department
    {
        [Key] 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image {  get; set; }

        public string Description { get; set; }

        [Required]
        public string role { get; set; } = "klinik";
    }
}
