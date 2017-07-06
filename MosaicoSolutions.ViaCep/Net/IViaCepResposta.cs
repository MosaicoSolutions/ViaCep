using System.Net;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define a resposta de uma requisição.
    /// </summary>
    public interface IViaCepResposta
    {
        /// <summary>
        /// Obtém o código de status da requisição.
        /// </summary>
        HttpStatusCode CodigoDeStatus { get; }
        
        /// <summary>
        /// A Reason Phrase da resposta.
        /// </summary>
        string ReasonPhrase { get; }
        
        /// <summary>
        /// Avalia se é código de sucesso. <see cref="HttpStatusCode.OK"/> => 200.
        /// </summary>
        bool EhCodigoDeSucesso { get; }

        /// <summary>
        /// Obtém o conteúdo da requisição.
        /// </summary>
        /// <returns></returns>
        IViaCepConteudo ObterConteudo();
    }
}