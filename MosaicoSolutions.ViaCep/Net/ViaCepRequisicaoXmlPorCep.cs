
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public sealed class ViaCepRequisicaoXmlPorCep : ViaCepRequisicaoPorCep
    {
        public ViaCepRequisicaoXmlPorCep(Cep cep) : base(cep)
        {
            Resposta = ViaCepRespostas.Xml;
        }

        protected override IViaCepResposta Resposta { get; }
    }
}