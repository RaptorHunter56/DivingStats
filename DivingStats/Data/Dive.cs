using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DivingStats.Models
{
    public class Dive
    {
        [Key]
        [Column(Order = 0)]
        public string ID { get; set; }
        [Key]
        [Column(Order = 1)]
        public decimal Board { get; set; }
        [Required]
        public decimal DD { get; set; }

        public ICollection<IndividualDive> IndividualDives { get; set; }
    }
}
