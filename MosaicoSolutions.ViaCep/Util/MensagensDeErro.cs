using System;

namespace MosaicoSolutions.ViaCep.Util
{
    internal static class MensagensDeErro
    {
        internal const string ErroDeRequisicao = "Ocorreu um erro ao tentar obter o(s) endereço(s).";

        internal const string CepInexistente = "O Cep especificado não existe.";
        
        internal static readonly string BadRequest = ErroDeRequisicao + Environment.NewLine +
                                                     "A requisicao está mal formada.";

        internal static readonly string AutenticacaoProxyRequerida = ErroDeRequisicao + Environment.NewLine +
                                                                     "Autenticação de proxy é requerida";
    }
}