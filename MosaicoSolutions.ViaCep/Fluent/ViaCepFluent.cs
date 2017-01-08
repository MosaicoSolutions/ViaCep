using System;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public static class ViaCepFluent
    {
        public static ViaCepFluentPorCep Obter(string cep)
            => new ViaCepFluentPorCep(new Cep(cep));

        public static ViaCepFluentPorCep Obter(Cep cep)
        {
            if (cep == null)
                throw new ArgumentNullException(nameof(cep));

            return new ViaCepFluentPorCep(cep);
        }

        public static ViaCepFluentPorEndereco ObterEnderecos(EnderecoRequisicao enderecoRequisicao)
            => new ViaCepFluentPorEndereco(enderecoRequisicao);
    }
}