namespace PlasticosFortunaWeb.Api.Models
{
    public class PlasticosFortunaDBSettings : IPlasticosFortunaDBSettings
    {
        public string TestCollectionName { get; set; }
        public string OpcionCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPlasticosFortunaDBSettings
    {
        string TestCollectionName { get; set; }
        public string OpcionCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}