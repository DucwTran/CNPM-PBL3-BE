using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Lesson
    {
        [Key]
        public Guid LessonID { get; set; }=string.Empty;

        public string LessonName { get; set; }=string.Empty;
        public int Oder { get; set; }
        public string Description { get; set; }=string.Empty;
        public string Duration { get; set; }=string.Empty;
        public string URLVideo { get; set; }=string.Empty;

        [ForeignKey("Course")]
        public Guid CourseID {  get; set; }
        public virtual Course Course { get; set; }
    }
}