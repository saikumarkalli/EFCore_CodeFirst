using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_EF.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int id { get; set; }
        public string empname { get; set; } = string.Empty;
        public string emailid { get; set; } = string.Empty;
        public string phonenumber { get; set; } = string.Empty;
    }
}
