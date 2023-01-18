namespace FilmsAPI
{
    public class Film
    {
        public int Year { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Starring { get; set; }

        public Film() { }

        public Film(int year, int score, string title, string starring)
        {
            Year = year;
            Score = score;
            Title = title;
            Starring = starring;
        }
    }
}
