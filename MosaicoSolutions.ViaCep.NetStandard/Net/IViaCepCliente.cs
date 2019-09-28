using System;
using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>s
    /// Cliente responsável por retornar a resposta de uma requisição ViaCep a partir do Uri do recurso.
    /// </summary>
    public interface IViaCepCliente : IDisposable
    {
        /// <summary>
        /// Obtém a resposta, de forma assíncrona, a partir do Uri do recurso.
        /// </summary>
        /// <param name="uri">Um <see cref="Func{String}"/> que devolve o uri do recurso.</param>
        /// <returns>A resposta contendo os dados da requisição.</returns>
        Task<IViaCepResposta> ObterRespostaAsync(Func<string> uri);

        /// <summary>
        /// Obtém a resposta, de forma assíncrona, a partir do Uri do recurso.
        /// </summary>
        /// <param name="uri">Uri do recurso.</param>
        /// <returns>A resposta contendo os dados da requisição.</returns>
        Task<IViaCepResposta> ObterRespostaAsync(string uri);

        /// <summary>
        /// Obtém a resposta a partir do Uri do recurso.
        /// </summary>
        /// <param name="uri">Um <see cref="Func{String}"/> que devolve o uri do recurso.</param>
        /// <returns>A resposta contendo os dados da requisição.</returns>
        IViaCepResposta ObterResposta(Func<string> uri);
        
        /// <summary>
        /// Obtém a resposta a partir do Uri do recurso.
        /// </summary>
        /// <param name="uri">Uri do recurso.</param>
        /// <returns>A resposta contendo os dados da requisição.</returns>
        IViaCepResposta ObterResposta(string uri);
    }
}