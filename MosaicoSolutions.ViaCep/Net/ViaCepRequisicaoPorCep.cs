using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public sealed class ViaCepRequisicaoPorCep : IViaCepRequisicao
    {
        public Cep Cep { get; }
        public ViaCepTipoResposta TipoDaResposta { get; }

        private ViaCepRequisicaoPorCep(Cep cep, ViaCepTipoResposta tipoDaResposta)
        {
            Cep = cep;
            TipoDaResposta = tipoDaResposta;
        }

        public string ObterUriDoRecurso()
            => $"{Cep.GetCep()}/{Util.ViaCepUtil.ObterTipoRespostaComoString(TipoDaResposta)}";

        public static ViaCepRequisicaoPorCep CriarRequisicaoJson(Cep cep)
            => CriarRequisicao(cep, ViaCepTipoResposta.Json);

        public static ViaCepRequisicaoPorCep CriarRequisicaoXml(Cep cep)
            => CriarRequisicao(cep, ViaCepTipoResposta.Xml);

        public static ViaCepRequisicaoPorCep CriarRequisicaoPiped(Cep cep)
            => CriarRequisicao(cep, ViaCepTipoResposta.Piped);

        public static ViaCepRequisicaoPorCep CriarRequisicaoQuerty(Cep cep)
            => CriarRequisicao(cep, ViaCepTipoResposta.Querty);

        private static ViaCepRequisicaoPorCep CriarRequisicao(Cep cep, ViaCepTipoResposta resposta)
            => new ViaCepRequisicaoPorCep(cep, resposta);
    }
}