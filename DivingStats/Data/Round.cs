using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DivingStats.Models
{
    public class Round
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int CompetitionID { get; set; }
        public int Number { get; set; }
        public DateTime? StartTime { get; set; }

        public Competition Competition { get; set; }
        public ICollection<IndividualDive> IndividualDives { get; set; }
    }
}
