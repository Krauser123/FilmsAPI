using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FilmsAPI
{
    public class CSVUtils
    {
        public static List<Film> LoadCSV()
        {
            List<Film> records;

            using (var reader = new StreamReader("films.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //Add some configuration
                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = null;

                //Load using mapping
                csv.Configuration.RegisterClassMap<CsvPersonMapping>();
                records = csv.GetRecords<Film>().Where(o => o != null).ToList();
            }

            return records;
        }


        public static void WriteCSV(List<Film> filmsToWrite)
        {
            // Append to the file.
            using (var stream = File.Open("films.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                //We want use ; as delimiter
                csv.Configuration.Delimiter = ";";

                csv.Configuration.HasHeaderRecord = false;

                //Write
                csv.WriteRecords(filmsToWrite);
            }
        }
    }

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