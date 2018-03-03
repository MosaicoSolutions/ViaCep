using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa uma requisição ViaCep contendo o objeto com os dados da requisição e um formato.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto que contém os dados da requisição, <see cref="Cep"/> ou <see cref="EnderecoRequisicao"/>.</typeparam>
    public interface IViaCepRequisicaoPor<out T>
    {
        /// <summary>
        /// Objeto contendo os dados da requisição.
        /// </summary>
        T Dados { get; }

        /// <summary>
        /// O formato desta requisição.
        /// </summary>
        ViaCepFormatoRequisicao Formato { get; }
        
        /// <summary>
        /// Retorna a Uri desta requisição.
        /// </summary>
        /// <returns>Uma <see cref="System.String"/> que representa a Uri desta requisição.</returns>
        string ToUri();
    }
}