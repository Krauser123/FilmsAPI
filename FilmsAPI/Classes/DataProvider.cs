using System.Collections.Generic;
using System.Linq;

namespace FilmsAPI
{
    public class DataProvider : IDataProvider
    {
        private List<Film> LoadedFilms { get; set; }
        private List<ScoreCategory> LoadedScoreCategories { get; set; }

        public DataProvider()
        {
            LoadedFilms = CsvUtils.LoadCSV<Film>("./Data/films.csv");
            LoadedScoreCategories = CsvUtils.LoadCSV<ScoreCategory>("./Data/scoreCategories.csv");
        }

        public IEnumerable<Film> GetByScore(int score)
        {
            var itemByScore = LoadedFilms.Where(o => o.Score == score);
            return itemByScore;
        }

        public IEnumerable<Film> GetByHigherScore(int limit)
        {
            var itemByScore = LoadedFilms.OrderByDescending(o => o.Score).Take(limit);
            return itemByScore;
        }

        public IEnumerable<Film> GetByLowerScore(int limit)
        {
            var itemByScore = LoadedFilms.OrderBy(o => o.Score).Take(limit);
            return itemByScore;
        }

        public IEnumerable<Film> GetTitleContains(string wordToSearchInTitle)
        {
            var filmsWithTitleMatch = LoadedFilms.Where(o => o.Title.Contains(wordToSearchInTitle));
            return filmsWithTitleMatch;
        }

        public IEnumerable<Film> GetByStarringLike(string nameToSearch)
        {
            var filmsWithStarringMatch = LoadedFilms.Where(o => o.Starring.Contains(nameToSearch));
            return filmsWithStarringMatch;
        }

        public List<Film> GetAllFilms()
        {
            return LoadedFilms;
        }

        public List<FilmWithCategory> FilmsWithScoreCategory()
        {
            var query = from film in LoadedFilms
                        join scoreCat in LoadedScoreCategories on film.Score
                        equals scoreCat.Score into gj
                        from subScore in gj.DefaultIfEmpty()
                        select new
                        {
                            film,
                            ScoreCategory = subScore?.Category ?? string.Empty
                        };

            var listOfFilms = new List<FilmWithCategory>();
            foreach (var v in query)
            {
                listOfFilms.Add(new FilmWithCategory
                {
                    Category = v.ScoreCategory,
                    Starring = v.film.Starring,
                    Title = v.film.Title,
                    Score = v.film.Score,
                    Year = v.film.Year
                });
            }

            return listOfFilms;
        }

        public List<CategoryWithFilms> ScoreCategoryWithFilms()
        {

            var query = from scoreCat in LoadedScoreCategories
                        join film in LoadedFilms on scoreCat.Score
                        equals film.Score into gj
                        from film in gj.DefaultIfEmpty()
                        select new
                        {
                            scoreCat,
                            Film = film?.Title ?? string.Empty
                        };

            var listOfCategory = new List<CategoryWithFilms>();
            foreach (var v in query)
            {
                listOfCategory.Add(new CategoryWithFilms
                {
                    Category = v.scoreCat.Category,
                    Film = v.Film
                });
            }

            return listOfCategory;
        }

        public void SaveNewFilm(Film film)
        {
            //Add to in memory data 
            LoadedFilms.Add(film);

            //Save record
            CsvUtils.WriteCSV("./Data/films.csv", new List<Film> { film });
        }
    }
}
