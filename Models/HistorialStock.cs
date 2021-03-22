using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PlasticosFortunaWeb.Api.Models
{
    public class HistorialStock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string tipoMateriaPrima { get; set; }
        public decimal valor { get; set; }
        public string idProveedor { get; set; }
        public string idCliente { get; set; }
        public string idOrden { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}