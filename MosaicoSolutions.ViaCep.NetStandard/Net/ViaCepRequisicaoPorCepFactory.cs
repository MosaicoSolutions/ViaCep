using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <inheritdoc />
    public sealed class ViaCepRequisicaoPorCepFactory : IViaCepRequisicaoPorCepFactory
    {
        /// <inheritdoc />
        public IViaCepRequisicaoPor<Cep> NovaRequisicaoJson(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Json);

        /// <inheritdoc />
        public IViaCepRequisicaoPor<Cep> NovaRequisicaoXml(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Xml);

        /// <inheritdoc />
        public IViaCepRequisicaoPor<Cep> NovaRequisicaoPiped(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Piped);

        /// <inheritdoc />
        public IViaCepRequisicaoPor<Cep> NovaRequisicaoQuerty(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Querty);

        private static IViaCepRequisicaoPor<Cep> NovaRequisicao(Cep cep, ViaCepFormatoRequisicao formato)
            => new ViaCepRequisicaoPorCep(cep, formato);
    }
}