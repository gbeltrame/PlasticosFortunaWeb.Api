using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace PlasticosFortunaWeb.Api.Models
{
    public class OrdenTrabajo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string estado { get; set; }
        [Required(ErrorMessage="Sector es un campo obligatorio.")]
        public string sector { get; set; }
        public string idCliente { get; set; }
        public ICollection<ItemOrdenTrabajo> items { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaAlta { get; set; } = DateTime.Now;
        
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaModificacion { get; set; } = DateTime.Now;
    }
}