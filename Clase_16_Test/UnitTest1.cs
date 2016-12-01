using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clase_16_Library;

namespace Clase_16_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DNIInvalidoInfArg()
        {
            try
            {
                Persona per = new Persona("Agustin", "Prado", 0, Persona.ENacionalidad.Argentino);
                Assert.Fail("No lanzó excepción.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void DNIInvalidoSupArg()
        {
            try
            {
                Persona per = new Persona("Agustin", "Prado", 90000000, Persona.ENacionalidad.Argentino);
                Assert.Fail("No lanzó excepción.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void DNIInvalidoInfExt()
        {
            try
            {
                Persona per = new Persona("Agustin", "Prado", 89999999, Persona.ENacionalidad.Extranjero);
                Assert.Fail("No lanzó excepción.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void DNIInvalidoSupExt()
        {
            try
            {
                Persona per = new Persona("Agustin", "Prado", 100000000, Persona.ENacionalidad.Extranjero);
                Assert.Fail("No lanzó excepción.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }


    }
}
