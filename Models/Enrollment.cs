using Microsoft.EntityFrameworkCore;
namespace api.Models
{
    public class Enrollment
    {
      
       public int Id { get; set; }
       public int UserId { get; set; }
       public int CourseId { get; set; }
        public DateTime EnrolementAt { get; set; } 
        public string Status { get; set; } = string.Empty;
        public virtual Course Course { get; set; } = new Course();
        public virtual Student Student { get; set; } = new Student();

        public Enrollment()
        {
            EnrolementAt = DateTime.Now;
        }
        public Enrollment(int userId, int courseId)
        {
            UserId = userId;
            CourseId = courseId;
            EnrolementAt = DateTime.Now;
        }
        public Enrollment(int userId, int courseId, string status)
        {
            UserId = userId;
            CourseId = courseId;
            EnrolementAt = DateTime.Now;
            Status = status;
        }
        public Enrollment(int userId, int courseId, DateTime enrolementAt)
        {
            UserId = userId;
            CourseId = courseId;
            EnrolementAt = enrolementAt;
        }
        public Enrollment(int userId, int courseId, DateTime enrolementAt, string status)
        {
            UserId = userId;
            CourseId = courseId;
            EnrolementAt = enrolementAt;
            Status = status;
        }
        public Enrollment(int userId, int courseId, DateTime enrolementAt, string status, Course course, Student student)
        {
            UserId = userId;
            CourseId = courseId;
            EnrolementAt = enrolementAt;
            Status = status;
            Course = course;
            Student = student;
        }
        public Enrollment(int userId, int courseId, DateTime enrolementAt, string status, Course course)
        {
            UserId = userId;
            CourseId = courseId;
            EnrolementAt = enrolementAt;
            Status = status;
            Course = course;
        }
        public Enrollment(int userId, int courseId, DateTime enrolementAt, string status, Student student)
        {
            UserId = userId;
            CourseId = courseId;
            EnrolementAt = enrolementAt;
            Status = status;
            Student = student;
        }

    }
}