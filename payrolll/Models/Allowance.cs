using System.ComponentModel.DataAnnotations;

namespace payrolll.Models
{
    public class Allowance
    {
        [Key]
        [Required]
        public int Empid { get; set; }
        [Required]
        public string Emp_Name { get; set; }
        [Required]
        public string Allowance_code { get; set; }
        [Required]
        public string Allowance_Type { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public DateTime Effective_Date { get; set; }
    }
}
