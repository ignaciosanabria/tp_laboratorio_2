using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTestTP3
    {
        /// <summary>
        /// Comprueba que el el formato del DNI no tenga coma
        /// Arroja NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Gimnasio gim = new Gimnasio();
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit,
                Alumno.EEstadoCuenta.MesPrueba);
                gim += a1;
                Assert.Fail("Sin excepcion para NacionalidadInvalidaException");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
       /// <summary>
       /// Comprueba que no haya valores nulos
       /// Arroja NullReferenceException
       /// </summary>
        [TestMethod]
        public void TestMethod2()
        { 
            try
            {
                Gimnasio gim = new Gimnasio();
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion,
                Alumno.EEstadoCuenta.Deudor);
                Alumno a3 = null;
                gim += a2;
                gim += a3;
                Assert.Fail("Sin excepcion para NullReferenceException");
            }
           catch(Exception e)
            {
           Assert.IsInstanceOfType(e,typeof(NullReferenceException));
           }
        }
    }
}
