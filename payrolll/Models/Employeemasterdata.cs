using System.ComponentModel.DataAnnotations;

namespace payrolll.Models
{
    public class Employeemasterdata
    {
        [Key]
        public int Empid { get; set; }

        [Required]
        //[Range(0,999, ErrorMessage ="value should 0 - 999")]
        public string EmpName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string WA_Country  { get; set; }
        [Required]
        public string WA_City { get; set; }
        [Required]
        public string WA_Block { get; set; }
        [Required]
        public string WA_street { get; set; }
        [Required]
        public string WA_Religion { get; set; }
        [Required]

        public string HA_Country { get; set; }
        [Required]
        public string HA_City { get; set; }
        [Required]
        public string HA_Block { get; set; }
        [Required]
        public string HA_street { get; set; }
        [Required]
        public string HA_Religion { get; set; }

    }
}
