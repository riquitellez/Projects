using CursosYViajes.DatosEF.Repositorios;
using CursosYViajes.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CursosYViajes.Testing
{
    //Se componen de 3 partes 
    //1. Arrange - Preparación de datos
    //2. Action (act) - La acción para probar
    //3. Assert - comprobar resultados

    [TestClass]
    public class CalcularPreciosTest
    {
        [TestMethod]
        public void CalculoPrecioCursoYHospedajeTest()
        {
            //Arrange
            PreciosServicio _servicio = new PreciosServicio();
            PreciosRepositorio _repositorio = new PreciosRepositorio();
            var idCurso = _repositorio.GetCursos().First().IdCurso;
            var idHospedaje = 1;
            var idSemanaInicialSeleccionada = 1;
            var idSemanaFinalSeleccionada = 10;
            var preciosCursoPorSemanas = RellenarDiccionarioDePreciosFijo();
            var precioHospedajePorSemanas = RellenarDiccionarioDePreciosHospedaje();

            //Action
            _servicio.GuardarPreciosCurso(idCurso, preciosCursoPorSemanas);
            _servicio.GuardarPreciosHospedaje(idCurso, idHospedaje, precioHospedajePorSemanas);
            var model = _servicio.CalcularPrecioTotalCurso(idCurso, idHospedaje, idSemanaInicialSeleccionada, idSemanaFinalSeleccionada);

            //Assert
            var precioCurso = PrecioCurso(idSemanaInicialSeleccionada, idSemanaFinalSeleccionada, preciosCursoPorSemanas);
            var precioHospedaje = PrecioCurso(idSemanaInicialSeleccionada, idSemanaFinalSeleccionada, precioHospedajePorSemanas);
            var precioTotal = precioCurso + precioHospedaje;

            Assert.AreEqual(precioCurso, model.PrecioCurso);
            Assert.AreEqual(precioHospedaje, model.PrecioHospedaje);
            Assert.AreEqual(precioTotal, model.PrecioTotal);
            Assert.AreEqual(idCurso, model.IdCursoSeleccionado);
        }

        private IDictionary<int, double> RellenarDiccionarioDePreciosFijo()
        {
            IDictionary<int, double> preciosPorSemana = new Dictionary<int, double>();
            for (int i = 1; i <= 53; i++)
            {
                preciosPorSemana.Add(i, 10 * i);
            }
            return preciosPorSemana;
        }
        private IDictionary<int, double> RellenarDiccionarioDePreciosHospedaje()
        {
            IDictionary<int, double> preciosPorSemana = new Dictionary<int, double>();
            for (int i = 1; i <= 53; i++)
            {
                preciosPorSemana.Add(i, 20 * i);
            }
            return preciosPorSemana;
        }
        private double PrecioCurso(int semanaInicial, int semanaFinal, IDictionary<int, double> preciosPorSemana)
        {
            double suma = 0; 
            for (int i = semanaInicial; i <= semanaFinal; i++)
            {
                suma = suma + preciosPorSemana[i];
            }
            return suma;
        }
    }
}
