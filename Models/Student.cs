namespace api.Models
{
    public class Student: User
    {
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<FavouriteCourse> Favorites { get; set; } = new List<FavouriteCourse>();
    }
}