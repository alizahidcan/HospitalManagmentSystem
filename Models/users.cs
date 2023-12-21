using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class users
    {
        [Key] public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int age { get; set; }

        public string problem { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public int phone { get; set; }
        
        [Required]
        [MinLength(4)]
        public string password {  get; set; }

        [Required]
        [MinLength(4)]
        [Compare(nameof(password))]
        public string rePassword { get; set; }
    }
}
