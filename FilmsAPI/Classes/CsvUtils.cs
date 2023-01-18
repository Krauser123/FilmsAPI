using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FilmsAPI
{
    public static class CsvUtils
    {
        public static List<T> LoadCSV<T>(string filePath)
        {
            List<T> records;
            
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                //We want use ; as delimiter
                Delimiter = ";",
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                //Load using mapping
                records = csv.GetRecords<T>().Where(o => o != null).ToList();
            }

            return records;
        }

        public static void WriteCSV<T>(string filePath, List<T> itemsToWrite)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                //We want use ; as delimiter
                Delimiter = ";",
                HasHeaderRecord = false
            };

            // Append to the file.
            using (var stream = File.Open(filePath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                //Write
                csv.WriteRecords(itemsToWrite);
            }
        }
    }
}