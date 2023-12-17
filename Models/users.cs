using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class users
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public int age { get; set; }

    }
}
