using MosaicoSolutions.ViaCep.Fluent;
using MosaicoSolutions.ViaCep.Fluent.Callback;
using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

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
                var endereco = ViaCepFluent.De("01001000").ComoEndereco();
                var enderecoJson = ViaCepFluent.De("01001000").ComoJson();
                var enderecoXml = ViaCepFluent.De("01001000").ComoXml();
                var enderecoPiped = ViaCepFluent.De("01001000").ComoPiped();
                var enderecoQuerty = ViaCepFluent.De("01001000").ComoQuerty();
            });

        [Test]
        public void FluentPorCepNaoDeveLancarExceptionAsync()
            => Assert.DoesNotThrowAsync(async () =>
            {
                var endereco = await ViaCepFluent.De("01001000").ComoEnderecoAsync();
                var enderecoJson = await ViaCepFluent.De("01001000").ComoJsonAsync();
                var enderecoXml = await ViaCepFluent.De("01001000").ComoXmlAsync();
                var enderecoPiped = await ViaCepFluent.De("01001000").ComoPipedAsync();
                var enderecoQuerty = await ViaCepFluent.De("01001000").ComoQuertyAsync();
            });

        [Test]
        public void FluentPorCepComCallbackNaoDeveLancarException()
            => Assert.DoesNotThrow(() =>
            {
                ViaCepFluent.De("01001000").ComoEndereco(endereco =>
                {

                });
                ViaCepFluent.De("01001000").ComoJson(endereco =>
                {

                });
                ViaCepFluent.De("01001000").ComoXml(endereco =>
                {

                });
                ViaCepFluent.De("01001000").ComoPiped(endereco =>
                {

                });
                ViaCepFluent.De("01001000").ComoQuerty(endereco =>
                {

                });

            });

        [Test]
        public void FluentPorCepComCallbackNaoDeveLancarExceptionAsync() 
            => Assert.DoesNotThrowAsync(async () =>
            {
                await ViaCepFluent.De("01001000").ComoEnderecoAsync(endereco =>
                {
    
                });
                await ViaCepFluent.De("01001000").ComoJsonAsync(endereco =>
                {
    
                });
                await ViaCepFluent.De("01001000").ComoXmlAsync(endereco =>
                {
    
                });
                await ViaCepFluent.De("01001000").ComoPipedAsync(endereco =>
                {
    
                });
                await ViaCepFluent.De("01001000").ComoQuertyAsync((endereco) =>
                {
    
                });
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
                var endereco = ViaCepFluent.De(enderecoRequisicao).ComoListaDeEnderecos();
                var enderecoJson = ViaCepFluent.De(enderecoRequisicao).ComoJson();
                var enderecoXml = ViaCepFluent.De(enderecoRequisicao).ComoXml();

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
                var endereco = await ViaCepFluent.De(enderecoRequisicao).ComoListaDeEnderecosAsync();
                var enderecoJson = await ViaCepFluent.De(enderecoRequisicao).ComoJsonAsync();
                var enderecoXml = await ViaCepFluent.De(enderecoRequisicao).ComoXmlAsync();
            });

        [Test]
        public void FluentPorEnderecoComCallbackNaoDeveLancarException()
            => Assert.DoesNotThrow(() =>
            {
                var enderecoRequisicao = new EnderecoRequisicao
                {
                    UF = UF.PE,
                    Cidade = "Recife",
                    Logradouro = "Praça"
                };
                ViaCepFluent.De(enderecoRequisicao).ComoListaDeEnderecos(enderecos =>
                {

                });
                ViaCepFluent.De(enderecoRequisicao).ComoJson(enderecos =>
                {

                });
                ViaCepFluent.De(enderecoRequisicao).ComoXml(enderecos =>
                {

                });
            });

        [Test]
        public void FluentPorEnderecoComCallbackNaoDeveLancarExceptionAsync()
            => Assert.DoesNotThrowAsync(async () =>
            {
                var enderecoRequisicao = new EnderecoRequisicao
                {
                    UF = UF.PE,
                    Cidade = "Recife",
                    Logradouro = "Praça"
                };
                await ViaCepFluent.De(enderecoRequisicao).ComoListaDeEnderecosAsync(enderecos =>
                {

                });
                await ViaCepFluent.De(enderecoRequisicao).ComoJsonAsync(enderecos =>
                {

                });
                await ViaCepFluent.De(enderecoRequisicao).ComoXmlAsync(enderecos =>
                {

                });
            });
        

        #endregion
    }
}