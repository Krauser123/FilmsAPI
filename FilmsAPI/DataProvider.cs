using System.Collections.Generic;
using System.Linq;

namespace FilmsAPI
{
    public class DataProvider : IDataProvider
    {
        private List<Film> AllItemsInStorage { get; set; }

        public DataProvider()
        {
            AllItemsInStorage = CsvUtils.LoadCSV();
        }

        public IEnumerable<Film> GetByScore(int score)
        {
            var itemByScore = AllItemsInStorage.Where(o => o.Score == score);
            return itemByScore;
        }

        public IEnumerable<Film> GetByHigherScore(int limit)
        {
            var itemByScore = AllItemsInStorage.OrderByDescending(o => o.Score).Take(limit);
            return itemByScore;
        }

        public IEnumerable<Film> GetByLowerScore(int limit)
        {
            var itemByScore = AllItemsInStorage.OrderBy(o => o.Score).Take(limit);
            return itemByScore;
        }

        public IEnumerable<Film> GetTitleContains(string wordToSearchInTitle)
        {
            var filmsWithTitleMatch = AllItemsInStorage.Where(o => o.Title.Contains(wordToSearchInTitle));
            return filmsWithTitleMatch;
        }

        public IEnumerable<Film> GetByStarringLike(string nameToSearch)
        {
            var filmsWithStarringMatch = AllItemsInStorage.Where(o => o.Starring.Contains(nameToSearch));
            return filmsWithStarringMatch;
        }

        public List<Film> GetAllFilms()
        {
            return AllItemsInStorage;
        }

        public void SaveNewFilm(Film film)
        {
            //Add to in memory data 
            AllItemsInStorage.Add(film);

            //Save record
            CsvUtils.WriteCSV(new List<Film> { film });
        }
    }
}
