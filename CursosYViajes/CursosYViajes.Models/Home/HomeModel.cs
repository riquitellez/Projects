using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Home
{
    public class HomeModel
    {
        [JsonProperty("info")]
        public string Info { get; set; }
        [JsonProperty("dir")]
        public DireccionModel Direccion { get; set; }
        [JsonProperty("telf")]
        public string Telefono { get; set; }
        [JsonProperty("ciudades")]
        public List<string> Ciudades { get; set; }

    }
}
