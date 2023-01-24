using FilmsAPI.Controllers;
using Moq;

namespace FilmsAPI.TestProject
{
    public class FilmControllerTests
    {

        private readonly Mock<IDataProvider> _mockDataProvider;
        private readonly FilmsController _controller;
        public FilmControllerTests()
        {

            _mockDataProvider = new Mock<IDataProvider>();
            _mockDataProvider.CallBase = true;
            _controller = new FilmsController(_mockDataProvider.Object);
        }

        [Test]
        public void ByHigherScore()
        {
            var result = _controller.ByHigherScore(1);
            var items = result.ToList();

            Assert.That(items[0].Score, Is.EqualTo(100));
        }

        [Test]
        public void ByHigherScoreCount()
        {
            var result = _controller.ByHigherScore(10);
            var countItems = result.ToList().Count;
            Assert.That(countItems, Is.EqualTo(10));
        }

        [Test]
        public void ByLowerScore()
        {
            var result = _controller.ByLowerScore(1);
            var items = result.ToList();

            Assert.That(items[0].Score, Is.EqualTo(4));
        }

        [Test]
        public void ByLowerScoreCount()
        {
            var result = _controller.ByLowerScore(2);
            var countItems = result.ToList().Count;
            Assert.That(countItems, Is.EqualTo(2));
        }
    }
}