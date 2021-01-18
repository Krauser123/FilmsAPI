using CsvHelper.Configuration;

namespace FilmsAPI
{
    public class CsvPersonMapping : ClassMap<Film>
    {
        public CsvPersonMapping()
        {
            Map(x => x.Year);
            Map(x => x.Score);
            Map(x => x.Title);
            Map(x => x.Starring);
        }
    }
}
