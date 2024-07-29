namespace DivingStats.Models
{
    public class AthleteProfileModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string InstagramHandle { get; set; }
        public string FacebookPage { get; set; }
        public string YoutubePage { get; set; }
        public string GiveaLittlePage { get; set; }
        public decimal PersonalBestScore { get; set; }
        public List<string> NationalTitles { get; set; }
        public List<string> Achievements { get; set; }
        public List<CompetitionScoreModel> LastThreeCompetitionScores { get; set; }

        public AthleteProfileModel()
        {
            NationalTitles = new List<string>();
            Achievements = new List<string>();
            LastThreeCompetitionScores = new List<CompetitionScoreModel>();
        }
    }

    public class CompetitionScoreModel
    {
        public string CompetitionName { get; set; }
        public decimal Score { get; set; }
        public DateTime Date { get; set; }

        public CompetitionScoreModel()
        {
        }

        public CompetitionScoreModel(string competitionName, decimal score, DateTime date)
        {
            CompetitionName = competitionName;
            Score = score;
            Date = date;
        }
    }
}
