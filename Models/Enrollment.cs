using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace api.Models
{
    public class Enrollment
    {
        [Key]
        public Guid EnrollmentID { get; set; }

        [ForeignKey("Student")]      
        public Guid UserID { get; set; }
        public virtual Student Student { get; set; } = new Student();

        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();
        public virtual Bill Bill { get; set; }

        public DateTime EnrolementAt { get; set; } 
        public bool StatusPayment { get; set; } = false;

    }
}