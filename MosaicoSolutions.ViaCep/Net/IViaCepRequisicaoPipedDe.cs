namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define uma requisição Piped.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto contendo os dados da requisição.</typeparam>
    public interface IViaCepRequisicaoPipedDe<T>
    {
        /// <summary>
        /// Cria uma nova requisição Piped.
        /// </summary>
        /// <param name="obj">O objeto contendo os dados da requisição.</param>
        /// <returns>Um objeto que representa o contexto da requisição.</returns>
        IViaCepRequisicaoPor<T> NovaRequisicaoPiped(T obj);
    }
}