using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;

        public FilmsController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Film> Create(Film film)
        {            
            _dataProvider.DataProvider.SaveNewFilm(film);
            return CreatedAtAction("Create", film);
        }

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _dataProvider.DataProvider.GetAllFilms();
        }

        [HttpGet]
        [Route("ByScore/{score}")]
        public IEnumerable<Film> ByScore(int score)
        {
            return _dataProvider.DataProvider.GetByScore(score);
        }

        [HttpGet]
        [Route("ByLowerScore/{numberOfItemsWithLowestScore}")]
        public IEnumerable<Film> ByLowerScore(int numberOfItemsWithLowestScore)
        {
            return _dataProvider.DataProvider.GetByLowerScore(numberOfItemsWithLowestScore);
        }

        [HttpGet]
        [Route("ByHigherScore/{numberOfItemsWithHighestScore}")]
        public IEnumerable<Film> ByHigherScore(int numberOfItemsWithHighestScore)
        {
            return _dataProvider.DataProvider.GetByHigherScore(numberOfItemsWithHighestScore);
        }

        [HttpGet]
        [Route("TitleContains/{wordToSearchInTitle}")]
        public IEnumerable<Film> TitleContains(string wordToSearchInTitle)
        {
            return _dataProvider.DataProvider.GetTitleContains(wordToSearchInTitle);
        }

        [HttpGet]
        [Route("ByStarringLike/{nameToSearch}")]
        public IEnumerable<Film> ByStarringLike(string nameToSearch)
        {
            return _dataProvider.DataProvider.GetByStarringLike(nameToSearch);
        }

        [HttpGet]
        [Route("FilmsWithScoreCategory")]
        public IEnumerable<Film> FilmsWithScoreCategory()
        {
            return _dataProvider.DataProvider.FilmsWithScoreCategory();
        }

        [HttpGet]
        [Route("CategoryWithFilms")]
        public IEnumerable<CategoryWithFilms> ScoreCategoryWithFilms()
        {
            return _dataProvider.DataProvider.ScoreCategoryWithFilms();
        }
    }
}
