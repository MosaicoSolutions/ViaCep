using System.Collections.Generic;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep.Fluent
{
    //TODO: Implementar métodos restantes.
    public class ViaCepFluentPorEndereco : IViaCepFluentPorEndereco
    {
        private readonly EnderecoRequisicao _enderecoRequisicao;

        internal ViaCepFluentPorEndereco(EnderecoRequisicao enderecoRequisicao)
        {
            _enderecoRequisicao = enderecoRequisicao;
        }

        public string ComoJson()
        {
            throw new System.NotImplementedException();
        }

        public XDocument ComoXml()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Endereco> ComoListaDeEnderecos()
        {
            throw new System.NotImplementedException();
        }
    }
}