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

        internal ViaCepFluentPorEndereco(EnderecoRequisicao enderecoRequisicao)
        {
            _enderecoRequisicao = enderecoRequisicao;
        }

        public string ComoJson()
            => ViaCep.ObterEnderecosComoJson(_enderecoRequisicao);

        public XDocument ComoXml()
            => ViaCep.ObterEnderecosComoXml(_enderecoRequisicao);

        public IEnumerable<Endereco> ComoListaDeEnderecos()
            => ViaCep.ObterEnderecos(_enderecoRequisicao);

        public async Task<string> ComoJsonAsync()
            => await ViaCep.ObterEnderecosComoJsonAsync(_enderecoRequisicao);

        public async Task<XDocument> ComoXmlAsync()
            => await ViaCep.ObterEnderecosComoXmlAsync(_enderecoRequisicao);

        public async Task<IEnumerable<Endereco>> ComoListaDeEnderecosAsync()
            => await ViaCep.ObterEnderecosAsync(_enderecoRequisicao);
    }
}