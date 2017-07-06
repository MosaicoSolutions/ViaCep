using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Uma fábrica para a criação de requisições por Cep.
    /// </summary>
    public sealed class ViaCepRequisicaoPorCepFactory : IViaCepRequisicaoPorCepFactory
    {
        public IViaCepRequisicaoPor<Cep> NovaRequisicaoJson(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Json);

        public IViaCepRequisicaoPor<Cep> NovaRequisicaoXml(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Xml);

        public IViaCepRequisicaoPor<Cep> NovaRequisicaoPiped(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Piped);

        public IViaCepRequisicaoPor<Cep> NovaRequisicaoQuerty(Cep cep)
            => NovaRequisicao(cep, ViaCepFormatoRequisicao.Querty);

        private static IViaCepRequisicaoPor<Cep> NovaRequisicao(Cep cep, ViaCepFormatoRequisicao formato)
            => new ViaCepRequisicaoPorCep(cep, formato);
    }
}