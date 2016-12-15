using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public sealed class ViaCepRequisicaoJsonPorCep : ViaCepRequisicaoPorCep
    {
        public ViaCepRequisicaoJsonPorCep(Cep cep) : base(cep)
        {
            Resposta = ViaCepRespostas.Json;
        }

        protected override IViaCepResposta Resposta { get; }
    }
}