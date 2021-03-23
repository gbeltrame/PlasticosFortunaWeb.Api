using PlasticosFortunaWeb.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PlasticosFortunaWeb.Api.Services
{
    public class HistorialStockService
    {
                private readonly IMongoCollection<HistorialStock> _historialStock;

        public HistorialStockService(IPlasticosFortunaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _historialStock = database.GetCollection<HistorialStock>(settings.HistorialStockCollectionName);
        }

        public List<HistorialStock> Get() =>
            _historialStock.Find(hitsorialStock => true).ToList();

        public HistorialStock Get(string id) =>
            _historialStock.Find<HistorialStock>(hitsorialStock => hitsorialStock.Id == id).FirstOrDefault();

        public HistorialStock Create(HistorialStock hitsorialStock)
        {
            _historialStock.InsertOne(hitsorialStock);
            return hitsorialStock;
        }

        public void Update(string id, HistorialStock hitsorialStockIn) =>
            _historialStock.ReplaceOne(hitsorialStock => hitsorialStock.Id == id, hitsorialStockIn);

        public void Remove(HistorialStock hitsorialStockIn) =>
            _historialStock.DeleteOne(hitsorialStock => hitsorialStock.Id == hitsorialStockIn.Id);

        public void Remove(string id) => 
            _historialStock.DeleteOne(hitsorialStock => hitsorialStock.Id == id);
    }
}