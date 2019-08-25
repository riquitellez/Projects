using CursosYViajes.Models.Home;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CursosYViajes.Servicios
{
    public class HomeServicio
    {
        public HomeModel ObtenerDatos(string json)
        {
            return JsonConvert.DeserializeObject<HomeModel>(json);
        }
    }
}
