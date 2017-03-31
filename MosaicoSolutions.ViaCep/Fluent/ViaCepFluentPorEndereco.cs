using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public class ViaCepFluentPorEndereco : IViaCepFluentPorEndereco
    {
        private readonly EnderecoRequisicao _enderecoRequisicao;
        private readonly IViaCep _viaCep;

        internal ViaCepFluentPorEndereco(EnderecoRequisicao enderecoRequisicao)
        {
            _enderecoRequisicao = enderecoRequisicao;
            _viaCep = new ViaCep();
        }

        public string ComoJson()
            => _viaCep.ObterEnderecosComoJson(_enderecoRequisicao);

        public XDocument ComoXml()
            => _viaCep.ObterEnderecosComoXml(_enderecoRequisicao);

        public IEnumerable<Endereco> ComoListaDeEnderecos()
            => _viaCep.ObterEnderecos(_enderecoRequisicao);

        public async Task<string> ComoJsonAsync()
            => await _viaCep.ObterEnderecosComoJsonAsync(_enderecoRequisicao);

        public async Task<XDocument> ComoXmlAsync()
            => await _viaCep.ObterEnderecosComoXmlAsync(_enderecoRequisicao);

        public async Task<IEnumerable<Endereco>> ComoListaDeEnderecosAsync()
            => await _viaCep.ObterEnderecosAsync(_enderecoRequisicao);
    }
}