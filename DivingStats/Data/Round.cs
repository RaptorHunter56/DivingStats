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

        [NotMapped]
        public Dictionary<int, int> Placements { 
            get
            {
                var place = IndividualDives.GroupBy(x => x.DiverID).ToDictionary(x => x.Sum(y => y.Score), x => x.First().DiverID);
                return place.Keys.ToList().OrderByDescending(x => x).Select(x => place[x]).Select((value, index) => new { Value = value, Index = index }).ToDictionary(x => x.Index + 1, x => x.Value);
            }
        }
    }
}
