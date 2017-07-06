using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

namespace ViaCepTest.MosaicoSolutions.ViaCep.Teste.Modelos
{
    [TestFixture]
    public class RegiaoTest
    {
        [Test]
        public void DeveConterOEstado()
        {
            Assert.True(Regiao.CentroOeste.ContemOEstado(UF.DF));
            Assert.True(Regiao.Nordeste.ContemOEstado(UF.PE));
            Assert.True(Regiao.Norte.ContemOEstado(UF.AM));
            Assert.True(Regiao.Sudeste.ContemOEstado(UF.RJ));
            Assert.True(Regiao.Sul.ContemOEstado(UF.SC));
        }
    }
}