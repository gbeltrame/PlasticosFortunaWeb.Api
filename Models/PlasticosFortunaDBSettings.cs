namespace PlasticosFortunaWeb.Api.Models
{
    public class PlasticosFortunaDBSettings : IPlasticosFortunaDBSettings
    {
        public string TestCollectionName { get; set; }
        public string OpcionCollectionName { get; set; }
        public string StockCollectionName { get; set; }
        public string HistorialStockCollectionName { get; set; }
        public string OrdenTrabajoCollectionName { get; set; }
        public string HistorialOrdenTrabajoCollectionName { get; set; }
        public string PersonaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPlasticosFortunaDBSettings
    {
        string TestCollectionName { get; set; }
        public string OpcionCollectionName { get; set; }
        public string StockCollectionName { get; set; }
        public string HistorialStockCollectionName { get; set; }
        public string OrdenTrabajoCollectionName { get; set; }
        public string HistorialOrdenTrabajoCollectionName { get; set; }
        public string PersonaCollectionName { get; set; }        
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}