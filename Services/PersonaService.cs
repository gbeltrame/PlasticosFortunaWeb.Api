using PlasticosFortunaWeb.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace PlasticosFortunaWeb.Api.Services
{
    public class PersonaService
    {
        private readonly IMongoCollection<Persona> _persona;

        public PersonaService(IPlasticosFortunaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _persona = database.GetCollection<Persona>(settings.PersonaCollectionName);
        }

        public List<Persona> Get() =>
            _persona.Find(persona => true).ToList();

        public Persona Get(string id) =>
            _persona.Find<Persona>(persona => persona.Id == id).FirstOrDefault();

        public Persona Create(Persona persona)
        {
            _persona.InsertOne(persona);
            return persona;
        }

        public void Update(string id, Persona personaIn) =>
            _persona.ReplaceOne(persona => persona.Id == id, personaIn);

        public void Remove(Persona personaIn) =>
            _persona.DeleteOne(persona => persona.Id == personaIn.Id);

        public void Remove(string id) => 
            _persona.DeleteOne(persona => persona.Id == id);
    }
}