using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Uma fábrica para a criação de requisições por Endereço.
    /// </summary>
    public class ViaCepRequisicaoPorEnderecoFactory : IViaCepRequisicaoPorEnderecoFactory
    {
        public IViaCepRequisicaoPor<EnderecoRequisicao> NovaRequisicaoJson(EnderecoRequisicao enderecoRequisicao)
            => NovaRequisicao(enderecoRequisicao, ViaCepFormatoRequisicao.Json);

        public IViaCepRequisicaoPor<EnderecoRequisicao> NovaRequisicaoXml(EnderecoRequisicao enderecoRequisicao)
            => NovaRequisicao(enderecoRequisicao, ViaCepFormatoRequisicao.Xml);

        private IViaCepRequisicaoPor<EnderecoRequisicao> NovaRequisicao(EnderecoRequisicao enderecoRequisicao, ViaCepFormatoRequisicao formato)
            => new ViaCepRequisicaoPorEndereco(enderecoRequisicao, formato);
    }
}