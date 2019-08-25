﻿using CallCenterBO.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Profesores
{
    public class DetallesProfesorModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string NombreEmpresa { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public IEnumerable<ClaseDadaProfesorGridModel> ClasesDadas { get; set; }
    }
}
