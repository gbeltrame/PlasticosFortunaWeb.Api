using PlasticosFortunaWeb.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PlasticosFortunaWeb.Api.Services
{
    public class OpcionService
    {
        private readonly IMongoCollection<Opcion> _opcion;

        public OpcionService(IPlasticosFortunaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _opcion = database.GetCollection<Opcion>(settings.OpcionCollectionName);
        }

        public List<Opcion> Get() =>
            _opcion.Find(opcion => true).ToList();

        public Opcion Get(string id) =>
            _opcion.Find<Opcion>(opcion => opcion.Id == id).FirstOrDefault();

        public Opcion Create(Opcion opcion)
        {
            _opcion.InsertOne(opcion);
            return opcion;
        }

        public void Update(string id, Opcion opcionIn) =>
            _opcion.ReplaceOne(opcion => opcion.Id == id, opcionIn);

        public void Remove(Opcion opcionIn) =>
            _opcion.DeleteOne(book => book.Id == opcionIn.Id);

        public void Remove(string id) => 
            _opcion.DeleteOne(opcion => opcion.Id == id);
    }
}