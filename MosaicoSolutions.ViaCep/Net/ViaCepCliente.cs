using System;
using System.Net.Http;
using System.Threading.Tasks;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public static class ViaCepCliente
    {
        private static HttpClient _instancia;

        internal static HttpClient Instancia
            => _instancia ?? (_instancia = new HttpClient {BaseAddress = new Uri("http://viacep.com.br/ws/")});

        public static async Task<string> ObterStringAsync(IViaCepRequisicao requisicao)
            => await Instancia.GetStringAsync(requisicao.ObterUriDoRecurso());
    }
}