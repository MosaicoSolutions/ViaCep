using System;
using System.Net;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;
using NUnit.Framework;

namespace ViaCepTest
{
    [TestFixture]
    public class ViaCepRequisicaoPorCepTest
    {
        private IViaCepCliente _cliente;
        private IViaCepRequisicaoPorCepFactory _requisicaoPorCepFactory;
        private Cep _cep;

        [SetUp]
        public void SetUp()
        {
            _requisicaoPorCepFactory = new ViaCepRequisicaoPorCepFactory();
            _cep = "01001000";
            _cliente = new ViaCepCliente();
        }

        [Test]
        public void DeveSerUmaRequisicaoJsonValida()
        {
            var requisicaoCepJson = _requisicaoPorCepFactory.novaRequisicaoJson(_cep);

            var resposta = _cliente.ObterResposta(requisicaoCepJson);

            Assert.True(resposta.EhCodigoDeSucesso);
            Assert.AreEqual(resposta.CodigoDeStatus, HttpStatusCode.OK);
        }

        [Test]
        public void DeveSerUmaRequisicaoXmlValida()
        {
            var requisicaoCepXml = _requisicaoPorCepFactory.novaRequisicaoXml(_cep);

            var resposta = _cliente.ObterResposta(requisicaoCepXml);

            Assert.True(resposta.EhCodigoDeSucesso);
            Assert.AreEqual(resposta.CodigoDeStatus, HttpStatusCode.OK);
        }

        [Test]
        public void DeveSerUmaRequisicaoPipedValida()
        {
            var requisicaoCepPiped = _requisicaoPorCepFactory.novaRequisicaoPiped(_cep);

            var resposta = _cliente.ObterResposta(requisicaoCepPiped);

            Assert.True(resposta.EhCodigoDeSucesso);
            Assert.AreEqual(resposta.CodigoDeStatus, HttpStatusCode.OK);
        }

        [Test]
        public void DeveSerUmaRequisicaoQuertyValida()
        {
            var requisicaoCepQuerty = _requisicaoPorCepFactory.novaRequisicaoQuerty(_cep);

            var resposta = _cliente.ObterResposta(requisicaoCepQuerty);

            Assert.True(resposta.EhCodigoDeSucesso);
            Assert.AreEqual(resposta.CodigoDeStatus, HttpStatusCode.OK);
        }

        [Test]
        public void DeveFalharPoisCepEstaVazio()
            => Assert.Throws<ArgumentException>(() =>
               {
                   var cep = new Cep();

                   var requisicaoCepQuerty = _requisicaoPorCepFactory.novaRequisicaoQuerty(cep);
               });
    }
}