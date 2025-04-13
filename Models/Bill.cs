using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Bill
    {
        [Key]
        public Guid BillID { get; set; }
        public DateTime CreatAt { get; set; }

        [ForeignKey("Enrollment")]
        public Guid EnrollmentID { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}