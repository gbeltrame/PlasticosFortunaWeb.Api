using PlasticosFortunaWeb.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PlasticosFortunaWeb.Api.Services
{
    public class StockService
    {
                private readonly IMongoCollection<Stock> _stock;

        public StockService(IPlasticosFortunaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _stock = database.GetCollection<Stock>(settings.StockCollectionName);
        }

        public List<Stock> Get() =>
            _stock.Find(stock => true).ToList();

        public Stock Get(string id) =>
            _stock.Find<Stock>(stock => stock.Id == id).FirstOrDefault();

        public Stock Create(Stock stock)
        {
            _stock.InsertOne(stock);
            return stock;
        }

        public void Update(string id, Stock stockIn) =>
            _stock.ReplaceOne(stock => stock.Id == id, stockIn);

        public void Remove(Stock stockIn) =>
            _stock.DeleteOne(stock => stock.Id == stockIn.Id);

        public void Remove(string id) => 
            _stock.DeleteOne(stock => stock.Id == id);
    }
}