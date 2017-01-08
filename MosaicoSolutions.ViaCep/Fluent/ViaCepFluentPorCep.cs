using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public class ViaCepFluentPorCep : IViaCepFluentPorCep
    {
        private readonly Cep _cep;

        internal ViaCepFluentPorCep(Cep cep)
        {
            _cep = cep;
        }

        public Endereco ComoEndereco()
            => EnderecoConvert.DeJsonParaEndereco(ComoJson());

        public string ComoJson()
            => ViaCep.ObterEnderecoComoJson(_cep);

        public XDocument ComoXml()
            => ViaCep.ObterEnderecoComoXml(_cep);

        public string ComoPiped()
            => ViaCep.ObterEnderecoComoPiped(_cep);

        public string ComoQuerty()
            => ViaCep.ObterEnderecoComoQuerty(_cep);

        public async Task<string> ComoJsonAsync()
            => await ViaCep.ObterEnderecoComoJsonAsync(_cep);

        public async Task<XDocument> ComoXmlAsync()
            => await ViaCep.ObterEnderecoComoXmlAsync(_cep);

        public async Task<string> ComoPipedAsync()
            => await ViaCep.ObterEnderecoComoPipedAsync(_cep);

        public async Task<string> ComoQuertyAsync()
            => await ViaCep.ObterEnderecoComoQuertyAsync(_cep);

        public async Task<Endereco> ComoEnderecoAsync()
            => await ViaCep.ObterEnderecoAsync(_cep);
    }
}