using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Cliente responsável por retornar a resposta de uma requisição a partir do Uri do recurso.
    /// </summary>
    public sealed class ViaCepCliente : IViaCepCliente
    {
        private readonly HttpClient _cliente;

        public ViaCepCliente()
        {
            _cliente = new HttpClient { BaseAddress = new Uri("http://viacep.com.br/ws/") };
        }

        public async Task<IViaCepResposta> ObterRespostaAsync(IViaCepUri uri)
            => new ViaCepResposta(await _cliente.GetAsync(uri.ObterUriComoString()));

        public IViaCepResposta ObterResposta(IViaCepUri uri)
            => new ViaCepResposta(_cliente.GetAsync(uri.ObterUriComoString()).Result);
    }
}