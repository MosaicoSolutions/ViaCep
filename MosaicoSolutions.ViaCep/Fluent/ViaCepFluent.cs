using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public static class ViaCepFluent
    {
        public static IViaCepFluentPorCep Obter(Cep cep)
        {
            ViaCep.GarantirCepPreenchidoOuLancaExcecao(cep);

            return new ViaCepFluentPorCep(cep);
        }

        public static IViaCepFluentPorEndereco Obter(EnderecoRequisicao enderecoRequisicao)
        {
            if (!enderecoRequisicao.EhValido())
                throw new System.ArgumentException("O enderecoRequisicao não é válido.", nameof(enderecoRequisicao));

            return new ViaCepFluentPorEndereco(enderecoRequisicao);
        }
    }
}
