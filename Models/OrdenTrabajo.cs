using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PlasticosFortunaWeb.Api.Models
{
    public class OrdenTrabajo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string estado { get; set; }
        public string sector { get; set; }
        public string idCliente { get; set; }
        public ICollection<ItemOrdenTrabajo> items { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}