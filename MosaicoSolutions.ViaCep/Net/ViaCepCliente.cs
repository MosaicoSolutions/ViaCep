using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <inheritdoc />
    public sealed class ViaCepCliente : IViaCepCliente
    {
        private readonly HttpClient _cliente = new HttpClient { BaseAddress = new Uri("http://viacep.com.br/ws/") };

        /// <inheritdoc />
        public Task<IViaCepResposta> ObterRespostaAsync(Func<string> uri)
            => uri == null
                ? throw new ArgumentNullException(nameof(uri))
                : ObterRespostaAsync(uri());

        /// <inheritdoc />
        public Task<IViaCepResposta> ObterRespostaAsync(string uri)
            => uri == null
                ? throw new ArgumentNullException(nameof(uri))
                : Task.Run(async () => ViaCepResposta.Of(await _cliente.GetAsync(uri)));

        /// <inheritdoc />
        public IViaCepResposta ObterResposta(Func<string> uri)
            => uri == null
                ? throw new ArgumentNullException(nameof(uri))
                : ObterResposta(uri());

        /// <inheritdoc />
        public IViaCepResposta ObterResposta(string uri)
            => uri == null
                ? throw new ArgumentNullException(nameof(uri))
                : ViaCepResposta.Of(_cliente.GetAsync(uri).Result);

        #region IDisposable Support
        private bool disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _cliente.Dispose();
                }

                disposedValue = true;
            }
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