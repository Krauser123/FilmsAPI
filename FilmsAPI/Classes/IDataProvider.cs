using System.Collections.Generic;

namespace FilmsAPI
{
    public interface IDataProvider
    {
        public DataProvider DataProvider
        {
            get => new DataProvider();
        }

        List<FilmWithCategory> FilmsWithScoreCategory();
        List<Film> GetAllFilms();
        IEnumerable<Film> GetByHigherScore(int limit);
        IEnumerable<Film> GetByLowerScore(int limit);
        IEnumerable<Film> GetByScore(int score);
        IEnumerable<Film> GetByStarringLike(string nameToSearch);
        IEnumerable<Film> GetTitleContains(string wordToSearchInTitle);
        void SaveNewFilm(Film film);
        List<CategoryWithFilms> ScoreCategoryWithFilms();
    }
}