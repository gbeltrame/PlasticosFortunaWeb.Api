using PlasticosFortunaWeb.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PlasticosFortunaWeb.Api.Services
{
    public class HistorialOrdenTrabajoService
    {
        private readonly IMongoCollection<HistorialOrdenTrabajo> _histOrdenTrabajo;

        public HistorialOrdenTrabajoService(IPlasticosFortunaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _histOrdenTrabajo = database.GetCollection<HistorialOrdenTrabajo>(settings.HistorialOrdenTrabajoCollectionName);
        }

        public List<HistorialOrdenTrabajo> Get() =>
            _histOrdenTrabajo.Find(histOrdenTrabajo => true).ToList();

        public HistorialOrdenTrabajo Get(string id) =>
            _histOrdenTrabajo.Find<HistorialOrdenTrabajo>(histOrdenTrabajo => histOrdenTrabajo.Id == id).FirstOrDefault();

        public HistorialOrdenTrabajo Create(HistorialOrdenTrabajo histOrdenTrabajo)
        {
            _histOrdenTrabajo.InsertOne(histOrdenTrabajo);
            return histOrdenTrabajo;
        }

        public void Update(string id, HistorialOrdenTrabajo histOrdenTrabajoIn) =>
            _histOrdenTrabajo.ReplaceOne(histOrdenTrabajo => histOrdenTrabajo.Id == id, histOrdenTrabajoIn);

        public void Remove(HistorialOrdenTrabajo histOrdenTrabajoIn) =>
            _histOrdenTrabajo.DeleteOne(histOrdenTrabajo => histOrdenTrabajo.Id == histOrdenTrabajoIn.Id);

        public void Remove(string id) => 
            _histOrdenTrabajo.DeleteOne(histOrdenTrabajo => histOrdenTrabajo.Id == id);
    }
}