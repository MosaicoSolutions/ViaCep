using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public class ViaCepFluentPorEndereco : IViaCepFluentPorEndereco
    {
        private readonly EnderecoRequisicao _enderecoRequisicao;
        private readonly IViaCepService _viaCepService;

        internal ViaCepFluentPorEndereco(EnderecoRequisicao enderecoRequisicao)
        {
            _enderecoRequisicao = enderecoRequisicao;
            _viaCepService = new ViaCepService();
        }
        
        public string ComoJson()
            => _viaCepService.ObterEnderecosComoJson(_enderecoRequisicao);

        public XDocument ComoXml()
            => _viaCepService.ObterEnderecosComoXml(_enderecoRequisicao);

        public IEnumerable<Endereco> ComoListaDeEnderecos()
            => _viaCepService.ObterEnderecos(_enderecoRequisicao);

        public async Task<string> ComoJsonAsync()
            => await _viaCepService.ObterEnderecosComoJsonAsync(_enderecoRequisicao);

        public async Task<XDocument> ComoXmlAsync()
            => await _viaCepService.ObterEnderecosComoXmlAsync(_enderecoRequisicao);

        public async Task<IEnumerable<Endereco>> ComoListaDeEnderecosAsync()
            => await _viaCepService.ObterEnderecosAsync(_enderecoRequisicao);
    }
}