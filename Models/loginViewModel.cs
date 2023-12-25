using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class loginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "username can be max 50 characters")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password can be min 6 characters")]
        [MaxLength(20, ErrorMessage = "Password can be max 20 characters")]
        public string Password { get; set; }

    }
}
