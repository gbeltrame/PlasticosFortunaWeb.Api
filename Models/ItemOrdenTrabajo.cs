namespace PlasticosFortunaWeb.Api.Models
{
    public class ItemOrdenTrabajo
    {
        public int idItem { get; set; }
        public int cantidadBobinas { get; set; }
        public string tipoMateriaPrima { get; set; }
        public int ancho { get; set; }
        public int largo { get; set; }
        public int espesor { get; set; }
    }
}