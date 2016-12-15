using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public sealed class ViaCepRequisicaoPipedPorCep : ViaCepRequisicaoPorCep
    {
        public ViaCepRequisicaoPipedPorCep(Cep cep) : base(cep)
        {
            Resposta = ViaCepRespostas.Piped;
        }

        protected override IViaCepResposta Resposta { get; }
    }
}