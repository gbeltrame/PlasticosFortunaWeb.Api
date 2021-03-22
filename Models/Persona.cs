using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PlasticosFortunaWeb.Api.Models
{
    public class Persona
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public Domicilio domicilio { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }
    }


}