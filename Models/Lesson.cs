namespace api.Models
{
    public class Lesson
    {
        public string LessonId { get; set; }=string.Empty;
        public string LessonName { get; set; }=string.Empty;
        public int Oder { get; set; }
        public string Description { get; set; }=string.Empty;
        public string Duration { get; set; }=string.Empty;
        public string URLVideo { get; set; }=string.Empty;
    }
}