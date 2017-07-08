using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public class ViaCepFluentPorCep : IViaCepFluentPorCep
    {
        private readonly Cep _cep;
        private readonly IViaCepService _viaCepService;

        internal ViaCepFluentPorCep(Cep cep)
        {
            _cep = cep;
            _viaCepService = new ViaCepService();
        }

        public Endereco ComoEndereco()
            => _viaCepService.ObterEndereco(_cep);

        public string ComoJson()
            => _viaCepService.ObterEnderecoComoJson(_cep);

        public XDocument ComoXml()
            => _viaCepService.ObterEnderecoComoXml(_cep);

        public string ComoPiped()
            => _viaCepService.ObterEnderecoComoPiped(_cep);

        public string ComoQuerty()
            => _viaCepService.ObterEnderecoComoQuerty(_cep);

        public async Task<string> ComoJsonAsync()
            => await _viaCepService.ObterEnderecoComoJsonAsync(_cep);

        public async Task<XDocument> ComoXmlAsync()
            => await _viaCepService.ObterEnderecoComoXmlAsync(_cep);

        public async Task<string> ComoPipedAsync()
            => await _viaCepService.ObterEnderecoComoPipedAsync(_cep);

        public async Task<string> ComoQuertyAsync()
            => await _viaCepService.ObterEnderecoComoQuertyAsync(_cep);

        public async Task<Endereco> ComoEnderecoAsync()
            => await _viaCepService.ObterEnderecoAsync(_cep);
    }
}