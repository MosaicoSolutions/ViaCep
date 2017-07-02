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
        private readonly IViaCep _viaCep = new ViaCep();

        internal ViaCepFluentPorCep(Cep cep) => _cep = cep;

        public Endereco ComoEndereco()
            => EnderecoConvert.DeJsonParaEndereco(ComoJson());

        public string ComoJson()
            => _viaCep.ObterEnderecoComoJson(_cep);

        public XDocument ComoXml()
            => _viaCep.ObterEnderecoComoXml(_cep);

        public string ComoPiped()
            => _viaCep.ObterEnderecoComoPiped(_cep);

        public string ComoQuerty()
            => _viaCep.ObterEnderecoComoQuerty(_cep);

        public async Task<string> ComoJsonAsync()
            => await _viaCep.ObterEnderecoComoJsonAsync(_cep);

        public async Task<XDocument> ComoXmlAsync()
            => await _viaCep.ObterEnderecoComoXmlAsync(_cep);

        public async Task<string> ComoPipedAsync()
            => await _viaCep.ObterEnderecoComoPipedAsync(_cep);

        public async Task<string> ComoQuertyAsync()
            => await _viaCep.ObterEnderecoComoQuertyAsync(_cep);

        public async Task<Endereco> ComoEnderecoAsync()
            => await _viaCep.ObterEnderecoAsync(_cep);
    }
}