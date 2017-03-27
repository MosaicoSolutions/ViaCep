using System.Net;
using System.Net.Http;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa a resposta de uma requisiçao.
    /// </summary>
    public sealed class ViaCepResposta : IViaCepResposta
    {
        private readonly HttpResponseMessage _responseMessage;

        public HttpStatusCode CodigoDeStatus => _responseMessage.StatusCode;

        public bool EhCodigoDeSucesso => CodigoDeStatus == HttpStatusCode.OK;

        internal ViaCepResposta(HttpResponseMessage responseMessage)
        {
            _responseMessage = responseMessage;
        }

        public IViaCepConteudo ObterConteudo() => new ViaCepConteudo(_responseMessage.Content);
    }
}