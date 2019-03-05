using System;
using System.Net;
using System.Net.Http;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <inheritdoc />
    public sealed class ViaCepResposta : IViaCepResposta
    {
        internal static IViaCepResposta Of(HttpResponseMessage httpResponseMessage)
            => new ViaCepResposta(httpResponseMessage);
        
        private readonly HttpResponseMessage _responseMessage;

        private ViaCepResposta(HttpResponseMessage responseMessage) => _responseMessage = responseMessage;
        
        /// <inheritdoc />
        public HttpStatusCode CodigoDeStatus => _responseMessage.StatusCode;
        
        /// <inheritdoc />
        public string ReasonPhrase => _responseMessage.ReasonPhrase;

        /// <inheritdoc />
        public bool EhCodigoDeSucesso => _responseMessage.IsSuccessStatusCode;

        /// <inheritdoc />
        public IViaCepConteudo ObterConteudo() => ViaCepConteudo.Of(_responseMessage.Content);

        #region IDisposable Support
        private bool _disposedValue;

        private void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
                _responseMessage.Dispose();

            _disposedValue = true;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}