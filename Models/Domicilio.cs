namespace PlasticosFortunaWeb.Api.Models
{
    public class Domicilio
    {
        public string calle { get; set; }
        public int numero { get; set; }
        public string piso { get; set; }
        public string dpto { get; set; }
        public string localidad { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string codigoPostal { get; set; }
    }
}