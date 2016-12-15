using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public class ViaCepRequisicaoQuertyPorCep : ViaCepRequisicaoPorCep
    {
        public ViaCepRequisicaoQuertyPorCep(Cep cep) : base(cep)
        {
            Resposta = ViaCepRespostas.Querty;
        }

        protected override IViaCepResposta Resposta { get; }
    }
}