using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_CodeFirst.Model
{
    [Table("StateMaster")]
    public class StateMaster
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CountryID { get; set; }
    }
}
