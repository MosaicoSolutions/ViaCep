using System;

namespace MosaicoSolutions.ViaCep.Util
{
    internal static class MensagensDeErro
    {
        internal static readonly string CepInvalido =
            "O Cep não estava em um formato válido. Um dos seguintes formatos eram esperados: 00000000 ou 00000-000";

        internal static readonly string ErroDeRequisicao = "Ocorreu um erro ao tentar obter o(s) endereço(s).";

        internal static readonly string BadRequest = ErroDeRequisicao + Environment.NewLine +
                                                     "A requisicao está mal formada.";

        internal static readonly string AutenticacaoProxyRequerida = ErroDeRequisicao + Environment.NewLine +
                                                                     "Autenticação de proxy é requerida";

        internal static readonly string CepInexistente = "O Cep especificado não existe.";
    }
}