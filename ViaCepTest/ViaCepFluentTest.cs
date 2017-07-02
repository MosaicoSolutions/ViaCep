using System.Threading.Tasks;
using MosaicoSolutions.ViaCep.Fluent;
using MosaicoSolutions.ViaCep.Fluent.Callback;
using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

namespace ViaCepTest
{
    [TestFixture]
    public class ViaCepFluentTest
    {
        #region FluentPorCep

        [Test]
        public void FluentPorCepNaoDeveLancarException()
            => Assert.DoesNotThrow(() =>
            {
                var endereco = ViaCepFluent.Obter("01001000").ComoEndereco();
                var enderecoJson = ViaCepFluent.Obter("01001000").ComoJson();
                var enderecoXml = ViaCepFluent.Obter("01001000").ComoXml();
                var enderecoPiped = ViaCepFluent.Obter("01001000").ComoPiped();
                var enderecoQuerty = ViaCepFluent.Obter("01001000").ComoQuerty();
            });

        [Test]
        public void FluentPorCepNaoDeveLancarExceptionAsync()
            => Assert.DoesNotThrowAsync(async () =>
            {
                var endereco = await ViaCepFluent.Obter("01001000").ComoEnderecoAsync();
                var enderecoJson = await ViaCepFluent.Obter("01001000").ComoJsonAsync();
                var enderecoXml = await ViaCepFluent.Obter("01001000").ComoXmlAsync();
                var enderecoPiped = await ViaCepFluent.Obter("01001000").ComoPipedAsync();
                var enderecoQuerty = await ViaCepFluent.Obter("01001000").ComoQuertyAsync();
            });

        [Test]
        public void FluentPorCepComCallbackNaoDeveLancarException()
            => Assert.DoesNotThrow(() =>
            {
                ViaCepFluent.Obter("01001000").ComoEndereco(endereco =>
                {

                });
                ViaCepFluent.Obter("01001000").ComoJson(endereco =>
                {

                });
                ViaCepFluent.Obter("01001000").ComoXml(endereco =>
                {

                });
                ViaCepFluent.Obter("01001000").ComoPiped(endereco =>
                {

                });
                ViaCepFluent.Obter("01001000").ComoQuerty(endereco =>
                {

                });

            });

        [Test]
        public void FluentPorCepComCallbackNaoDeveLancarExceptionAsync() 
            => Assert.DoesNotThrowAsync(async () =>
            {
                await ViaCepFluent.Obter("01001000").ComoEnderecoAsync(endereco =>
                {
    
                });
                await ViaCepFluent.Obter("01001000").ComoJsonAsync(endereco =>
                {
    
                });
                await ViaCepFluent.Obter("01001000").ComoXmlAsync(endereco =>
                {
    
                });
                await ViaCepFluent.Obter("01001000").ComoPipedAsync(endereco =>
                {
    
                });
                await ViaCepFluent.Obter("01001000").ComoQuertyAsync((endereco) =>
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
                var endereco = ViaCepFluent.Obter(enderecoRequisicao).ComoListaDeEnderecos();
                var enderecoJson = ViaCepFluent.Obter(enderecoRequisicao).ComoJson();
                var enderecoXml = ViaCepFluent.Obter(enderecoRequisicao).ComoXml();

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
                var endereco = await ViaCepFluent.Obter(enderecoRequisicao).ComoListaDeEnderecosAsync();
                var enderecoJson = await ViaCepFluent.Obter(enderecoRequisicao).ComoJsonAsync();
                var enderecoXml = await ViaCepFluent.Obter(enderecoRequisicao).ComoXmlAsync();
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
                ViaCepFluent.Obter(enderecoRequisicao).ComoListaDeEnderecos(enderecos =>
                {

                });
                ViaCepFluent.Obter(enderecoRequisicao).ComoJson(enderecos =>
                {

                });
                ViaCepFluent.Obter(enderecoRequisicao).ComoXml(enderecos =>
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
                await ViaCepFluent.Obter(enderecoRequisicao).ComoListaDeEnderecosAsync(enderecos =>
                {

                });
                await ViaCepFluent.Obter(enderecoRequisicao).ComoJsonAsync(enderecos =>
                {

                });
                await ViaCepFluent.Obter(enderecoRequisicao).ComoXmlAsync(enderecos =>
                {

                });
            });
        

        #endregion
    }
}