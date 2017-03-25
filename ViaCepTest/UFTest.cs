using System;
using System.Collections.Generic;
using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

namespace ViaCepTest
{
    [TestFixture]
    public class UFTest
    {
        [Test]
        public void UFsDevemSerIguais()
        {
            var uf = UF.PE;
            var uf2 = UF.PE;

            Assert.AreEqual(uf, uf2);
            Assert.True(uf.Equals(uf2));
        }

        [Test]
        public void NaoDeveEncontrarUFPeloCodigo()
            => Assert.Throws<UFInexistenteException>(() => UF.EncontraPeloCodigo(100));

        [Test]
        public void NaoDeveEncontrarUFPelaSigla()
            => Assert.Throws<UFInexistenteException>(() => UF.EncontraPelaSigla("LOL"));

        [Test]
        public void DeveEncontrarUFPeloCodigo()
        {
            var uf = UF.EncontraPeloCodigo(26);
        }

        [Test]
        public void DeveEncontrarUFPelaSigla()
        {
            var uf = UF.EncontraPelaSigla("PE");
        }

        [Test]
        public void TestaAComparacaoEntreUFs()
        {
            var pernambuco = UF.PE;
            var sergipe = UF.SE;
            var ceara = UF.CE;

            Assert.AreEqual(pernambuco.CompareTo(sergipe), -1);
            Assert.AreEqual(pernambuco.CompareTo(pernambuco), 0);
            Assert.AreEqual(pernambuco.CompareTo(ceara), 1);
        }

        [Test]
        public void ComparaPeloNomeDoEstado()
        {
            var pernambuco = UF.PE;
            var matoGrosso = UF.MT;
            var matoGrossoDoSul = UF.MS;
            IComparer<UF> comparer = new ComparaUFPeloNomeDoEstado();

            Assert.AreEqual(comparer.Compare(pernambuco, matoGrosso), 1);
            Assert.AreEqual(comparer.Compare(pernambuco, pernambuco), 0);
            Assert.AreEqual(comparer.Compare(matoGrosso, matoGrossoDoSul), -1);
        }

        [Test]
        public void ComparaPelaSigla()
        {
            var pernambuco = UF.PE;
            var matoGrosso = UF.MT;
            var matoGrossoDoSul = UF.MS;
            IComparer<UF> comparer = new ComparaUFPelaSigla();

            Assert.AreEqual(comparer.Compare(pernambuco, matoGrosso), 1);
            Assert.AreEqual(comparer.Compare(pernambuco, pernambuco), 0);
            Assert.AreEqual(comparer.Compare(matoGrosso, matoGrossoDoSul), 1);
        }
    }
}