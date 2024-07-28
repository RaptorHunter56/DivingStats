using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DivingStats.Data;
using Newtonsoft.Json.Linq;

namespace DivingStats.Models
{
    public class IndividualDive
    {
        [Key]
        [Column(Order = 0)]
        public int DiverID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int RoundID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int RoundNumber { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string DiveID { get; set; }
        [Required]
        public decimal DiveBoard { get; set; }


        public int? Judge1ID { get; set; }
        public decimal? Value1 { get; set; }
        public int? Judge2ID { get; set; }
        public decimal? Value2 { get; set; }
        public int? Judge3ID { get; set; }
        public decimal? Value3 { get; set; }
        public int? Judge4ID { get; set; }
        public decimal? Value4 { get; set; }
        public int? Judge5ID { get; set; }
        public decimal? Value5 { get; set; }
        public int? Judge6ID { get; set; }
        public decimal? Value6 { get; set; }
        public int? Judge7ID { get; set; }
        public decimal? Value7 { get; set; }

        public Diver Diver { get; set; }
        public Round Round { get; set; }
        public Dive Dive { get; set; }

        [NotMapped]
        public Dictionary<int?, decimal?> JudgeValues 
        { 
            get { return GetJudgeValues(); } 
            set { SetJudgeValues(value); } 
        }
        public Dictionary<int?, decimal?> GetJudgeValues()
        {
            Dictionary<int?, decimal?> keys = new Dictionary<int?, decimal?>();
            keys.Add(Judge1ID, Value1);
            keys.Add(Judge2ID, Value2);
            keys.Add(Judge3ID, Value3);
            keys.Add(Judge4ID, Value4);
            keys.Add(Judge5ID, Value5);
            keys.Add(Judge6ID, Value6);
            keys.Add(Judge7ID, Value7);
            return keys;
        }
        public void SetJudgeValues(Dictionary<int?, decimal?> keys)
        {
            int id = 1;
            foreach (var item in keys)
            {
                switch (id)
                {
                    case 1:
                        Judge1ID = item.Key;
                        Value1 = item.Value;
                        break;
                    case 2:
                        Judge2ID = item.Key;
                        Value2 = item.Value;
                        break;
                    case 3:
                        Judge3ID = item.Key;
                        Value3 = item.Value;
                        break;
                    case 4:
                        Judge4ID = item.Key;
                        Value4 = item.Value;
                        break;
                    case 5:
                        Judge5ID = item.Key;
                        Value5 = item.Value;
                        break;
                    case 6:
                        Judge6ID = item.Key;
                        Value6 = item.Value;
                        break;
                    case 7:
                        Judge7ID = item.Key;
                        Value7 = item.Value;
                        break;
                    default:
                        break;
                }
            }
        }

        [NotMapped]
        public decimal? Score
        { 
            get { return JudgeValues.Values.Count() >= 3 ? JudgeValues.Values.OrderBy(v => v).Skip((JudgeValues.Count - 3) / 2).Take(3).Sum(v => v.GetValueOrDefault(0)) * Dive.DD : (decimal?)null; }
        }
    }
}
