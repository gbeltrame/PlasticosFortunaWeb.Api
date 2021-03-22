using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PlasticosFortunaWeb.Api.Models
{
    public class HistorialOrdenTrabajo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string idOrden { get; set; }
        public string estado { get; set; }
        public string sector { get; set; }
        public DateTime fechaCambio { get; set; }
    }
}