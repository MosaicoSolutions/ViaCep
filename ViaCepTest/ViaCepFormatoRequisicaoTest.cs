using MosaicoSolutions.ViaCep.Net;
using NUnit.Framework;

namespace ViaCepTest
{
    [TestFixture]
    public class ViaCepFormatoRequisicaoTest
    {
        [Test]
        public void TestandoOsFormatos()
        {
            Assert.AreEqual(ViaCepFormatoRequisicao.Json.Valor, "json");
            Assert.AreEqual(ViaCepFormatoRequisicao.Piped.Valor, "piped");
            Assert.AreEqual(ViaCepFormatoRequisicao.Querty.Valor, "querty");
            Assert.AreEqual(ViaCepFormatoRequisicao.Xml.Valor, "xml");
        }
    }
}