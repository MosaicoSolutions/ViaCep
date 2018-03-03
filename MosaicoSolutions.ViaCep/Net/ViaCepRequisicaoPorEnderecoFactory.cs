using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <inheritdoc />
    public class ViaCepRequisicaoPorEnderecoFactory : IViaCepRequisicaoPorEnderecoFactory
    {
        /// <inheritdoc />
        public IViaCepRequisicaoPor<EnderecoRequisicao> NovaRequisicaoJson(EnderecoRequisicao enderecoRequisicao)
            => NovaRequisicao(enderecoRequisicao, ViaCepFormatoRequisicao.Json);

        /// <inheritdoc />
        public IViaCepRequisicaoPor<EnderecoRequisicao> NovaRequisicaoXml(EnderecoRequisicao enderecoRequisicao)
            => NovaRequisicao(enderecoRequisicao, ViaCepFormatoRequisicao.Xml);

        private static IViaCepRequisicaoPor<EnderecoRequisicao> NovaRequisicao(EnderecoRequisicao enderecoRequisicao, 
                                                                               ViaCepFormatoRequisicao formato)
            => new ViaCepRequisicaoPorEndereco(enderecoRequisicao, formato);
    }
}