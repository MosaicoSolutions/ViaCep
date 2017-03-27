using System;
using System.Net;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;
using NUnit.Framework;

namespace ViaCepTest
{
    [TestFixture]
    public class ViaCepRequisicaoPorEnderecoTest
    {
        private IViaCepRequisicaoPorEnderecoFactory _requisicaoPorEnderecoFactory;
        private EnderecoRequisicao _enderecoRequisicao;
        private IViaCepCliente _cliente;

        [SetUp]
        public void SetUp()
        {
            _cliente = new ViaCepCliente();
            _enderecoRequisicao = new EnderecoRequisicao
            {
                UF = UF.RS,
                Cidade = "Porto Alegre",
                Logradouro = "Olavo"
            };

            _requisicaoPorEnderecoFactory = new ViaCepRequisicaoPorEnderecoFactory();
        }

        [Test]
        public void DeveSerUmaRequisicaoJsonValida()
        {
            var requisicaoJson = _requisicaoPorEnderecoFactory.NovaRequisicaoJson(_enderecoRequisicao);

            var resposta = _cliente.ObterResposta(requisicaoJson);

            Assert.True(resposta.EhCodigoDeSucesso);
            Assert.AreEqual(resposta.CodigoDeStatus, HttpStatusCode.OK);
        }

        [Test]
        public void DeveSerUmaRequisicaoXmlValida()
        {
            var requisicaoXml = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(_enderecoRequisicao);

            var resposta = _cliente.ObterResposta(requisicaoXml);

            Assert.True(resposta.EhCodigoDeSucesso);
            Assert.AreEqual(resposta.CodigoDeStatus, HttpStatusCode.OK);
        }

        [Test]
        public void DeveFalharPoisEnderecoRequisicaoNaoEhValido()
            =>  Assert.Throws<ArgumentException>(() =>
                {
                    //Deve Falhar pois a Cidade tem menos do que três caracteres.
                    //Consulte o método EnderecoRequisicao.EhValido() para mais informações.
                    var enderecoRequisicao = new EnderecoRequisicao
                    {
                        Cidade = "AB",
                        UF = UF.AC,
                        Logradouro = "ABC"
                    };

                    var requisicaoXml = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(enderecoRequisicao);

                    var resposta = _cliente.ObterResposta(requisicaoXml);

                    Assert.True(resposta.EhCodigoDeSucesso);
                    Assert.AreEqual(resposta.CodigoDeStatus, HttpStatusCode.OK);
                });
    }
}