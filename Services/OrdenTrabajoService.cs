using PlasticosFortunaWeb.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PlasticosFortunaWeb.Api.Services
{
    public class OrdenTrabajoService
    {
        private readonly IMongoCollection<OrdenTrabajo> _ordenTrabajo;

        public OrdenTrabajoService(IPlasticosFortunaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ordenTrabajo = database.GetCollection<OrdenTrabajo>(settings.OrdenTrabajoCollectionName);
        }

        public List<OrdenTrabajo> Get() =>
            _ordenTrabajo.Find(ordenTrabajo => true).ToList();

        public OrdenTrabajo Get(string id) =>
            _ordenTrabajo.Find<OrdenTrabajo>(ordenTrabajo => ordenTrabajo.Id == id).FirstOrDefault();

        public OrdenTrabajo Create(OrdenTrabajo ordenTrabajo)
        {
                _ordenTrabajo.InsertOne(ordenTrabajo);
                return ordenTrabajo;
        }

        public void Update(string id, OrdenTrabajo ordenTrabajoIn) =>
            _ordenTrabajo.ReplaceOne(ordenTrabajo => ordenTrabajo.Id == id, ordenTrabajoIn);

        public void Remove(OrdenTrabajo ordenTrabajoIn) =>
            _ordenTrabajo.DeleteOne(ordenTrabajo => ordenTrabajo.Id == ordenTrabajoIn.Id);

        public void Remove(string id) => 
            _ordenTrabajo.DeleteOne(ordenTrabajo => ordenTrabajo.Id == id);
    }
}