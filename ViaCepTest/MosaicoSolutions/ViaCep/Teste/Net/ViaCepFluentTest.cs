using MosaicoSolutions.ViaCep.Fluent;
using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;
using System.Linq;

namespace ViaCepTest.MosaicoSolutions.ViaCep.Teste.Net
{
    [TestFixture]
    public class ViaCepFluentTest
    {
        #region FluentPorCep

        [Test]
        public void FluentPorCepNaoDeveLancarException()
            => Assert.DoesNotThrow(() =>
            {
                ViaCepFluent.RequisicaoPorCep
                            .ComOsDados("01001000")
                            .RetorneComoJson(json => Assert.True(json.Contains("01001-000")));
            });

        [Test]
        public void FluentPorCepNaoDeveLancarExceptionAsync()
            => Assert.DoesNotThrowAsync(async () =>
            {
                var cep = Cep.Of("01001000");

                await ViaCepFluent.RequisicaoPorCep
                                  .ComOsDados(cep)
                                  .RetorneComoEnderecoAsync(endereco => Assert.True(cep.Formatado() == endereco.Cep));

                await ViaCepFluent.RequisicaoPorCep
                                  .ComOsDados(cep)
                                  .RetorneComoJsonAsync(json => Assert.True(json.Contains(cep.Formatado())));

                await ViaCepFluent.RequisicaoPorCep
                                  .ComOsDados(cep)
                                  .RetorneComoPipedAsync(piped => Assert.True(piped.Contains("cep:01001-000|")));

                await ViaCepFluent.RequisicaoPorCep
                                  .ComOsDados(cep)
                                  .RetorneComoQuertyAsync(querty => Assert.True(querty.Contains("cep=01001-000")));

                await ViaCepFluent.RequisicaoPorCep
                                  .ComOsDados(cep)
                                  .RetorneComoXmlAsync(xml => Assert.True(xml.FirstNode.ToString().Contains("<cep>01001-000</cep>")));

            });

        [Test]
        public void FluentPorCepComDeveCapturarAException()
            => Assert.DoesNotThrow(() =>
            {
                var cep = (Cep)"00000000"; //Cep inexistente.
                var exceptionComoEndereco = false;
                var exceptionComoJson = false;
                var exceptionComoPiped = false;
                var exceptionComoQuerty = false;
                var exceptionComoXml = false;

                ViaCepFluent.RequisicaoPorCep
                                .ComOsDados(cep)
                                .Capture(e => exceptionComoEndereco = true)
                                .RetorneComoEndereco(endereco => { });

                ViaCepFluent.RequisicaoPorCep
                                .ComOsDados(cep)
                                .Capture(e => exceptionComoJson = true)
                                .RetorneComoJson(json => { });

                ViaCepFluent.RequisicaoPorCep
                                .ComOsDados(cep)
                                .Capture(e => exceptionComoPiped = true)
                                .RetorneComoPiped(piped => { });

                ViaCepFluent.RequisicaoPorCep
                                .ComOsDados(cep)
                                .Capture(e => exceptionComoQuerty = true)
                                .RetorneComoQuerty(querty => { });

                ViaCepFluent.RequisicaoPorCep
                                .ComOsDados(cep)
                                .Capture(e => exceptionComoXml = true)
                                .RetorneComoXml(xml => { });

                Assert.True(exceptionComoEndereco);
                Assert.True(exceptionComoJson);
                Assert.True(exceptionComoPiped);
                Assert.True(exceptionComoQuerty);
                Assert.True(exceptionComoXml);
            });

        [Test]
        public void FluentPorCepComDeveCapturarAExceptionAsync()
                    => Assert.DoesNotThrowAsync(async () =>
                    {
                        var cep = (Cep)"00000000"; //Cep inexistente.
                        var exceptionComoEndereco = false;
                        var exceptionComoJson = false;
                        var exceptionComoPiped = false;
                        var exceptionComoQuerty = false;
                        var exceptionComoXml = false;

                        await ViaCepFluent.RequisicaoPorCep
                                          .ComOsDados(cep)
                                          .Capture(e => exceptionComoEndereco = true)
                                          .RetorneComoEnderecoAsync(endereco => { });

                        await ViaCepFluent.RequisicaoPorCep
                                          .ComOsDados(cep)
                                          .Capture(e => exceptionComoJson = true)
                                          .RetorneComoJsonAsync(json => { });

                        await ViaCepFluent.RequisicaoPorCep
                                          .ComOsDados(cep)
                                          .Capture(e => exceptionComoPiped = true)
                                          .RetorneComoPipedAsync(piped => { });

                        await ViaCepFluent.RequisicaoPorCep
                                          .ComOsDados(cep)
                                          .Capture(e => exceptionComoQuerty = true)
                                          .RetorneComoQuertyAsync(querty => { });

                        await ViaCepFluent.RequisicaoPorCep
                                          .ComOsDados(cep)
                                          .Capture(e => exceptionComoXml = true)
                                          .RetorneComoXmlAsync(xml => { });

                        Assert.True(exceptionComoEndereco);
                        Assert.True(exceptionComoJson);
                        Assert.True(exceptionComoPiped);
                        Assert.True(exceptionComoQuerty);
                        Assert.True(exceptionComoXml);
                    });

        #endregion

        #region FluentPorEndereco

        [Test]
        public void FluentPorEnderecoNaoDeveLancarException()
            => Assert.DoesNotThrow(() =>
            {
                var enderecoRequisicao = new EnderecoRequisicao
                {
                    UF = UF.PE,
                    Cidade = "Recife",
                    Logradouro = "Praça"
                };

                ViaCepFluent.RequisicaoPorEndereco
                            .ComOsDados(enderecoRequisicao)
                            .RetorneComoListaDeEnderecos(enderecos => Assert.AreEqual(enderecos.Count(), 50));
            });

        [Test]
        public void FluentPorEnderecoNaoDeveLancarExceptionAsync()
            => Assert.DoesNotThrowAsync(async () =>
            {
                var enderecoRequisicao = new EnderecoRequisicao
                {
                    UF = UF.PE,
                    Cidade = "Recife",
                    Logradouro = "Praça"
                };
                
                await ViaCepFluent.RequisicaoPorEndereco
                                   .ComOsDados(enderecoRequisicao)
                                   .RetorneComoListaDeEnderecosAsync(Assert.IsNotEmpty);
                
                await ViaCepFluent.RequisicaoPorEndereco
                                  .ComOsDados(enderecoRequisicao)
                                  .RetorneComoJsonAsync(Assert.IsNotEmpty);
                
                await ViaCepFluent.RequisicaoPorEndereco
                                   .ComOsDados(enderecoRequisicao)
                                   .RetorneComoXmlAsync(xml => Assert.True(xml.FirstNode.ToString().Contains("<endereco>")));
            });

        #endregion
    }
}