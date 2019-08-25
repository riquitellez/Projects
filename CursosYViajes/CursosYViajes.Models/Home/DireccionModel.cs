using Newtonsoft.Json;

namespace CursosYViajes.Models.Home
{
    public class DireccionModel
    {
        [JsonProperty("calle")]
        public string Calle { get; set; }

        [JsonProperty("num")]
        public int Numero { get; set; }

        [JsonProperty("piso")]
        public string Piso { get; set; }

        [JsonProperty("puerta")]
        public string Puerta { get; set; }

        [JsonProperty("localidad")]
        public string Localidad { get; set; }

        [JsonProperty("prov")]
        public string Provincia { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("cp")]
        public string CodigoPostal { get; set; }
    }
}