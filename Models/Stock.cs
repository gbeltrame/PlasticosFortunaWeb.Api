using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PlasticosFortunaWeb.Api.Models
{
    public class Stock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string tipoMateriaPrima { get; set; }
        public decimal stock { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}