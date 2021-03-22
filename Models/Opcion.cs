using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlasticosFortunaWeb.Api.Models
{
    public class Opcion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string campo { get; set; }
        public string valorTexto { get; set; }
        public string valorNumerico { get; set; }
    }
}