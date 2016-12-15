namespace MosaicoSolutions.ViaCep.Net
{
    public class ViaCepRequisicaoJsonPorEndereco : ViaCepRequisicaoPorEndereco
    {
        public ViaCepRequisicaoJsonPorEndereco(EnderecoRequisicao enderecoRequisicao) : base(enderecoRequisicao)
        {
            Resposta = ViaCepRespostas.Json;
        }

        protected override IViaCepResposta Resposta { get; }
    }
}