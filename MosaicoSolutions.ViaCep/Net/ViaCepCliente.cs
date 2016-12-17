using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Net
{
    internal static class ViaCepCliente
    {
        private static HttpClient _instancia;

        internal static HttpClient Instancia
            => _instancia ?? (_instancia = new HttpClient {BaseAddress = new Uri("http://viacep.com.br/ws/")});

        internal static async Task<HttpResponseMessage> ObterResponseMessageAsync(IViaCepRequisicao requisicao)
            => await Instancia.GetAsync(requisicao.ObterUriDoRecurso());

        internal static HttpResponseMessage ObterResponseMessage(IViaCepRequisicao requisicao)
            => Instancia.GetAsync(requisicao.ObterUriDoRecurso()).Result;
    }
}