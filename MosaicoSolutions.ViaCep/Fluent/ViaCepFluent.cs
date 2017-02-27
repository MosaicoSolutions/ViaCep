using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public static class ViaCepFluent
    {
        public static ViaCepFluentPorCep Obter(Cep cep)
        {
            ViaCep.GarantirCepPreenchidoOuLancaExcecao(cep);

            return new ViaCepFluentPorCep(cep);
        }

        public static ViaCepFluentPorEndereco ObterEnderecos(EnderecoRequisicao enderecoRequisicao)
            => new ViaCepFluentPorEndereco(enderecoRequisicao);
    }
}
