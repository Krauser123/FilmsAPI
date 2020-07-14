using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace FilmsAPI
{
    public class ReadFromCSV
    {
        public static List<Film> LoadCSV()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ';');
            CsvPersonMapping csvMapper = new CsvPersonMapping();
            CsvParser<Film> csvParser = new CsvParser<Film>(csvParserOptions, csvMapper);

            var records = csvParser.ReadFromFile("films.csv", Encoding.UTF8);

            return records.Select(x => x.Result).Where(o => o != null).ToList();
        }
    }


    public class CsvPersonMapping : CsvMapping<Film>
    {
        public CsvPersonMapping() : base()
        {
            MapProperty(0, x => x.Year);
            MapProperty(1, x => x.Score);
            MapProperty(2, x => x.Title);
            MapProperty(3, x => x.Starring);
        }
    }
}