using System.ComponentModel.DataAnnotations;

namespace payrolll.Models
{
    public class attendance
    {
        [Key]
        public int Empid { get; set; }
        public string Emp_Name { get; set; }

        [Required]
        //[Range(0,999, ErrorMessage ="value should 0 - 999")]
        public DateTime Date_TimeIN { get; set; }
        [Required]
        public DateTime Date_TimeOut { get; set; }
       
        
    }
}
