using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPT_JOBPORTAL
{
    public enum JobStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class JobModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Job Name")]
        public string? NameJob { get; set; }        
        public int CategoryId { get; set; }
        [DisplayName("Job Description")]
        public string? DescriptionJob { get; set; }
        public string? Company { get; set; }
        [DisplayName("Posted Date")]
        public DateTime DatePost { get; set; } = DateTime.Now;
        public double? Salary { get; set; }
        public string? Requirement { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryModel? Category { get; set; }
        public JobStatus Status { get; set; }

    }
}