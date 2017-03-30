using System.Threading.Tasks;
using MosaicoSolutions.ViaCep;
using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

namespace ViaCepTest
{
    [TestFixture]
    public class ViaCepTest
    {
        private IViaCep _viaCep;
        private EnderecoRequisicao _enderecoRequisicao;

        [SetUp]
        public void SetUp()
        {
            _viaCep = new ViaCep();
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
            var enderecoXml = await _viaCep.ObterEnderecoComoXmlAsync("01001000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            enderecoXml = await _viaCep.ObterEnderecoComoXmlAsync("01001-000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            var enderecosXml = await _viaCep.ObterEnderecosComoXmlAsync(_enderecoRequisicao);
            Assert.NotNull(enderecosXml);
            Assert.True(enderecosXml.ToString().Contains("<xmlcep>"));
        }

        [Test]
        public void DeveObterEnderecoComoXml()
        {
            var enderecoXml = _viaCep.ObterEnderecoComoXml("01001000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            enderecoXml = _viaCep.ObterEnderecoComoXml("01001-000");
            Assert.NotNull(enderecoXml);
            Assert.True(enderecoXml.ToString().Contains("<xmlcep>"));

            var enderecosXml = _viaCep.ObterEnderecosComoXml(_enderecoRequisicao);
            Assert.NotNull(enderecosXml);
            Assert.True(enderecosXml.ToString().Contains("<xmlcep>"));
        }

            #endregion

        #region ObterEnderecoComoQuerty

        [Test]
        public async Task DeveObterEnderecoComoQuertyAsync()
        {
            var quertyEndereco = await _viaCep.ObterEnderecoComoQuertyAsync("01001000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));

            quertyEndereco = await _viaCep.ObterEnderecoComoQuertyAsync("01001-000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));
        }

        [Test]
        public void DeveObterEnderecoComoQuerty()
        {
            var quertyEndereco = _viaCep.ObterEnderecoComoQuerty("01001000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));

            quertyEndereco = _viaCep.ObterEnderecoComoQuerty("01001-000");
            Assert.True(quertyEndereco.Contains("cep=01001-000&logradouro=Pra%C3%A7a+da+S%C3%A9"));
        }

        #endregion

        #region ObterEnderecoComoPiped

        [Test]
        public async Task DeveObterEnderecoComoPipedAsync()
        {
            var pipedEndereco = await _viaCep.ObterEnderecoComoPipedAsync("01001000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));

            pipedEndereco = await _viaCep.ObterEnderecoComoPipedAsync("01001-000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));
        }

        [Test]
        public void DeveObterEnderecoComoPiped()
        {
            var pipedEndereco = _viaCep.ObterEnderecoComoPiped("01001000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));

            pipedEndereco = _viaCep.ObterEnderecoComoPiped("01001-000");
            Assert.True(pipedEndereco.Contains("cep:01001-000"));
        }

            #endregion

        #region ObterEnderecoComoJson

        [Test]
        public async Task DeveObterEnderecoComoJsonAsync()
        {
            var jsonEndereco = await _viaCep.ObterEnderecoComoJsonAsync("01001000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            jsonEndereco = await _viaCep.ObterEnderecoComoJsonAsync("01001-000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            var jsonEnderecos = await _viaCep.ObterEnderecosComoJsonAsync(_enderecoRequisicao);
            Assert.True(jsonEnderecos.Contains("\"localidade\": \"Porto Alegre\""));
        }

        [Test]
        public void DeveObterEnderecoComoJson()
        {
            var jsonEndereco = _viaCep.ObterEnderecoComoJson("01001000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            jsonEndereco = _viaCep.ObterEnderecoComoJson("01001-000");
            Assert.True(jsonEndereco.Contains("\"cep\": \"01001-000\""));

            var jsonEnderecos = _viaCep.ObterEnderecosComoJson(_enderecoRequisicao);
            Assert.True(jsonEnderecos.Contains("\"localidade\": \"Porto Alegre\""));
        }

            #endregion

        #region ObterEndereco

        [Test]
        public async Task DeveObterEnderecoAsync()
        {
            var endereco = await _viaCep.ObterEnderecoAsync("01001000");
            Assert.NotNull(endereco);

            endereco = await _viaCep.ObterEnderecoAsync("01001-000");
            Assert.NotNull(endereco);

            var enderecos = await _viaCep.ObterEnderecosAsync(_enderecoRequisicao);
            Assert.NotNull(enderecos);
        }

        [Test]
        public void DeveObterEndereco()
        {
            var endereco = _viaCep.ObterEndereco("01001000");
            Assert.NotNull(endereco);

            endereco = _viaCep.ObterEndereco("01001-000");
            Assert.NotNull(endereco);

            var enderecos = _viaCep.ObterEnderecos(_enderecoRequisicao);
            Assert.NotNull(enderecos);
        }

        [Test]
        public void DeveFalharPoisCepNaoExiste()
        {
            Assert.Throws<CepInexistenteException>(() =>
            {
                _viaCep.ObterEndereco("00000-000");
            });
        }

        #endregion
    }
}