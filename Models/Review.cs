using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace api.Models
{
    public class Review
    {
        [Key]
        public Guid ReViewID { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }

        [ForeignKey("Course")]
        public Guid CourseID { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Student")] 
        public Guid UserID { get; set; }
        public virtual Student Student { get; set; }
    }
}