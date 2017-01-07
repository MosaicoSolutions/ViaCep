using System;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public static class ViaCepFluent
    {
        public static ViaCepFluentPorCep ObterPorCep(string cep)
            => new ViaCepFluentPorCep(new Cep(cep));

        public static ViaCepFluentPorCep ObterPorCep(Cep cep)
        {
            if (cep == null)
                throw new ArgumentNullException(nameof(cep));

            return new ViaCepFluentPorCep(cep);
        }

        public static ViaCepFluentPorEndereco ObterPorEndereco(EnderecoRequisicao enderecoRequisicao)
            => new ViaCepFluentPorEndereco(enderecoRequisicao);
    }
}