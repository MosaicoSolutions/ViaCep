using System.Threading.Tasks;
using MosaicoSolutions.ViaCep;
using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

namespace ViaCepTest.MosaicoSolutions.ViaCep
{
    [TestFixture]
    public class ViaCepTest
    {
        private IViaCepService _viaCepService;
        private EnderecoRequisicao _enderecoRequisicao;

        [SetUp]
        public void SetUp()
        {
            _viaCepService = new ViaCepService();
            _enderecoRequisicao = new EnderecoRequisicao
            {
                UF = UF.RS,
                Cidade = "Porto Alegre",
                Logradouro = "Olavo"
            };
        }

        #region ObterEnderecoComoXml

        [Test]
        public async Task DeveObterEnderecoComoXmlAsync()
        {
            var enderecoXml = await _viaCepService.ObterEnderecoComoXmlAsync("01001000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            enderecoXml = await _viaCepService.ObterEnderecoComoXmlAsync("01001-000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            var enderecosXml = await _viaCepService.ObterEnderecosComoXmlAsync(_enderecoRequisicao);
            Assert.NotNull(enderecosXml);
            Assert.True(enderecosXml.ToString().Contains("<xmlcep>"));
        }

        [Test]
        public void DeveObterEnderecoComoXml()
        {
            var enderecoXml = _viaCepService.ObterEnderecoComoXml("01001000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            enderecoXml = _viaCepService.ObterEnderecoComoXml("01001-000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            var enderecosXml = _viaCepService.ObterEnderecosComoXml(_enderecoRequisicao);
            Assert.NotNull(enderecosXml);
            Assert.True(enderecosXml.ToString().Contains("<xmlcep>"));
        }

            #endregion

        #region ObterEnderecoComoQuerty

        [Test]
        public async Task DeveObterEnderecoComoQuertyAsync()
        {
            var quertyEndereco = await _viaCepService.ObterEnderecoComoQuertyAsync("01001000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));

            quertyEndereco = await _viaCepService.ObterEnderecoComoQuertyAsync("01001-000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));
        }

        [Test]
        public void DeveObterEnderecoComoQuerty()
        {
            var quertyEndereco = _viaCepService.ObterEnderecoComoQuerty("01001000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));

            quertyEndereco = _viaCepService.ObterEnderecoComoQuerty("01001-000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));
        }

        #endregion

        #region ObterEnderecoComoPiped

        [Test]
        public async Task DeveObterEnderecoComoPipedAsync()
        {
            var pipedEndereco = await _viaCepService.ObterEnderecoComoPipedAsync("01001000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));

            pipedEndereco = await _viaCepService.ObterEnderecoComoPipedAsync("01001-000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));
        }

        [Test]
        public void DeveObterEnderecoComoPiped()
        {
            var pipedEndereco = _viaCepService.ObterEnderecoComoPiped("01001000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));

            pipedEndereco = _viaCepService.ObterEnderecoComoPiped("01001-000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));
        }

            #endregion

        #region ObterEnderecoComoJson

        [Test]
        public async Task DeveObterEnderecoComoJsonAsync()
        {
            var jsonEndereco = await _viaCepService.ObterEnderecoComoJsonAsync("01001000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            jsonEndereco = await _viaCepService.ObterEnderecoComoJsonAsync("01001-000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            var jsonEnderecos = await _viaCepService.ObterEnderecosComoJsonAsync(_enderecoRequisicao);
            Assert.True(jsonEnderecos.Contains("\"localidade\": \"Porto Alegre\""));
        }

        [Test]
        public void DeveObterEnderecoComoJson()
        {
            var jsonEndereco = _viaCepService.ObterEnderecoComoJson("01001000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            jsonEndereco = _viaCepService.ObterEnderecoComoJson("01001-000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            var jsonEnderecos = _viaCepService.ObterEnderecosComoJson(_enderecoRequisicao);
            Assert.True(jsonEnderecos.Contains("\"localidade\": \"Porto Alegre\""));
        }

            #endregion

        #region ObterEndereco

        [Test]
        public async Task DeveObterEnderecoAsync()
        {
            var endereco = await _viaCepService.ObterEnderecoAsync("01001000");
            Assert.NotNull(endereco);

            endereco = await _viaCepService.ObterEnderecoAsync("01001-000");
            Assert.NotNull(endereco);

            var enderecos = await _viaCepService.ObterEnderecosAsync(_enderecoRequisicao);
            Assert.NotNull(enderecos);
        }

        [Test]
        public void DeveObterEndereco()
        {
            var endereco = _viaCepService.ObterEndereco("01001000");
            Assert.NotNull(endereco);

            endereco = _viaCepService.ObterEndereco("01001-000");
            Assert.NotNull(endereco);

            var enderecos = _viaCepService.ObterEnderecos(_enderecoRequisicao);
            Assert.NotNull(enderecos);
        }

        [Test]
        public void DeveFalharPoisCepNaoExiste() 
            => Assert.Throws<CepInexistenteException>(() =>
            {
                _viaCepService.ObterEndereco("00000-000");
            });

        #endregion
    }
}