
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; } = string.Empty;

        public string Fullname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Sex { get; set; } = false;
        public DateTime BirthDate { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AvatarURl { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime LastLogin { get; set; }
    }
}