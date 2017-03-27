using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Uma fábrica para a criação de requisições por Cep.
    /// </summary>
    public sealed class ViaCepRequisicaoPorCepFactory : IViaCepRequisicaoPorCepFactory
    {
        public IViaCepRequisicaoPor<Cep> NovaRequisicaoJson(Cep cep)
            => novaRequisicao(cep, ViaCepFormatoRequisicao.Json);

        public IViaCepRequisicaoPor<Cep> NovaRequisicaoXml(Cep cep)
            => novaRequisicao(cep, ViaCepFormatoRequisicao.Xml);

        public IViaCepRequisicaoPor<Cep> NovaRequisicaoPiped(Cep cep)
            => novaRequisicao(cep, ViaCepFormatoRequisicao.Piped);

        public IViaCepRequisicaoPor<Cep> NovaRequisicaoQuerty(Cep cep)
            => novaRequisicao(cep, ViaCepFormatoRequisicao.Querty);

        private IViaCepRequisicaoPor<Cep> novaRequisicao(Cep cep, ViaCepFormatoRequisicao formato)
            => new ViaCepRequisicaoPorPorCep(cep, formato);
    }
}