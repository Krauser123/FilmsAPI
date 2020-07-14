namespace FilmsAPI
{
    public interface IDataProvider
    {
        public DataProvider DataProvider
        {
            get => new DataProvider();
        }
    }
}