using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Clases
{
    public class IndexModel
    {
        public CalculadorNumeroDeClasesModel CalculadorDeClasesDadas { get; set; }
        public IEnumerable<ListadoClaseModel> ListadoDeClasesDadas { get; set; }
    }
}
