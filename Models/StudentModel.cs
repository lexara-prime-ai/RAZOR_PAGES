using System.ComponentModel.DataAnnotations;

namespace CollegeWebsite.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Hobbies { get; set; }
        public string? Courses { get; set; }
        public string? Skills { get; set; }
    }
}