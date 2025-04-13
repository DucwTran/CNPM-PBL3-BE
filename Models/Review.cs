using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace api.Models
{
    public class Review
    {
        public int ReViewId { get; set; }
        public int Rating { get; set; }

        public string comment { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; }
        public virtual Course Course { get; set; } = new Course();
        public virtual Student Student { get; set; } = new Student();
    }
}