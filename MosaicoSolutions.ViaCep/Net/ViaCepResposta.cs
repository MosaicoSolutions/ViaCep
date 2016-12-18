using System.Net;
using System.Net.Http;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa a resposta de uma requisiçao.
    /// </summary>
    public sealed class ViaCepResposta
    {
        private readonly HttpResponseMessage _responseMessage;

        internal ViaCepResposta(HttpResponseMessage responseMessage)
        {
            _responseMessage = responseMessage;
        }

        public HttpStatusCode CodigoDeStatus => _responseMessage.StatusCode;

        public bool EhCodigoDeSucesso => CodigoDeStatus == HttpStatusCode.OK;

        public ViaCepConteudo ObterConteudo() => new ViaCepConteudo(_responseMessage.Content);
    }
}