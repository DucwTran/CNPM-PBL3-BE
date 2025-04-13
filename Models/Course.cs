using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Course
    {
        [Key]
        public Guid CourseID { get; set; }

        public string CourseName { get; set; }=string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } =string.Empty;
        public int TotalLessons { get; set; }
        public double AverageRating  { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<FavouriteCourse> Favorites { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}