namespace MosaicoSolutions.ViaCep.Net
{
    public class ViaCepRequisicaoXmlPorEndereco : ViaCepRequisicaoPorEndereco
    {
        public ViaCepRequisicaoXmlPorEndereco(EnderecoRequisicao enderecoRequisicao) : base(enderecoRequisicao)
        {
            Resposta = ViaCepRespostas.Xml;
        }

        protected override IViaCepResposta Resposta { get; }
    }
}