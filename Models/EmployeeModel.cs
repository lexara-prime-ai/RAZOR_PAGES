using System.ComponentModel.DataAnnotations;

namespace CollegeWebsite.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? MobileNumber { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
    }
}