using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class FavouriteCourse
    {
        [Key]
        public Guid FavouriteCourseID {  get; set; }

        [ForeignKey("Student")] 
        public Guid UserID { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Course")]
        public Guid CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
