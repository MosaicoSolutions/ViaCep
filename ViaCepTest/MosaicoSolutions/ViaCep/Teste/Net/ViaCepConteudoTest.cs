using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Net;
using NUnit.Framework;
using Rhino.Mocks;

namespace ViaCepTest.MosaicoSolutions.ViaCep.Teste.Net
{
    [TestFixture]
    public class ViaCepConteudoTest
    {
        private MockRepository _mockRepository;
        private IViaCepConteudo _conteudo;

        private const string XmlContent = @"<xmlcep>
                                            <cep>01001-000</cep>
                                            <logradouro>Praça da Sé</logradouro>
                                            <complemento>lado ímpar</complemento>
                                            <bairro>Sé</bairro>
                                            <localidade>São Paulo</localidade>
                                            <uf>SP</uf>
                                            <unidade/>
                                            <ibge>3550308</ibge>
                                            <gia>1004</gia>
                                            </xmlcep>";

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _conteudo = _mockRepository.StrictMock<IViaCepConteudo>();
        }

        [Test]
        public void DeveSerLidoComoXml()
        {
            _conteudo = _mockRepository.StrictMock<IViaCepConteudo>();
            _conteudo.Expect(m => m.PodeSerLidoComoXml).Return(true).Repeat.Once();
            _conteudo.Expect(m => m.LerComoString()).Return(XmlContent).Repeat.Once();
            _conteudo.Expect(m => m.LerComoXml()).Return(XDocument.Parse(XmlContent)).Repeat.Once();
            _conteudo.Expect(m => m.PossuiErro).Return(true).Repeat.Once();

            _conteudo.Replay();

            if (!_conteudo.PodeSerLidoComoXml)
                throw new AssertionException("O conteudo não pode ser lido como xml.");

            Assert.AreEqual(XmlContent, _conteudo.LerComoString());

            Assert.DoesNotThrow(() => _conteudo.LerComoXml());
        }
    }
}