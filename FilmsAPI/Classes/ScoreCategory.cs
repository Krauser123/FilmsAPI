namespace FilmsAPI
{
    public class ScoreCategory
    {
        public int Score { get; set; }
        public string Category { get; set; }

        public ScoreCategory() { }

        public ScoreCategory( int score, string category)
        {
            Score = score;
            Category = category;
        }
    }
}
