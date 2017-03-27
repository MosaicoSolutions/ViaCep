using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Cliente responsável por retornar a resposta de uma requisição a partir do Uri do recurso.
    /// </summary>
    public interface IViaCepCliente
    {
        /// <summary>
        /// Obtém a resposta, de forma assíncrona, a partir do Uri do recurso.
        /// </summary>
        /// <param name="uri">Uri do recurso.</param>
        /// <returns>A resposta contendo os dados da requisição.</returns>
        Task<IViaCepResposta> ObterRespostaAsync(IViaCepUri uri);

        /// <summary>
        /// Obtém a resposta a partir do Uri do recurso.
        /// </summary>
        /// <param name="uri">Uri do recurso.</param>
        /// <returns>A resposta contendo os dados da requisição.</returns>
        IViaCepResposta ObterResposta(IViaCepUri uri);
    }
}