namespace MosaicoSolutions.ViaCep.Net
{
    public static class ViaCepRespostas
    {
        private static readonly IViaCepResposta RespostaJson   = new ViaCepRespostaJson();
        private static readonly IViaCepResposta RespostaXml    = new ViaCepRespostaXml();
        private static readonly IViaCepResposta RespostaPiped  = new ViaCepRespostaPiped();
        private static readonly IViaCepResposta RespostaQuerty = new ViaCepRespostaQuerty();

        public static IViaCepResposta Json   { get; } = RespostaJson;
        public static IViaCepResposta Xml    { get; } = RespostaXml;
        public static IViaCepResposta Piped  { get; } = RespostaPiped;
        public static IViaCepResposta Querty { get; } = RespostaQuerty;
    }
}