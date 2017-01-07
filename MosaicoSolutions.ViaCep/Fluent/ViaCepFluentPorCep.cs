using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep.Fluent
{
    //TODO: Implementar métodos restantes.
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
        {
            throw new System.NotImplementedException();
        }

        public string ComoQuerty()
        {
            throw new System.NotImplementedException();
        }

    }
}