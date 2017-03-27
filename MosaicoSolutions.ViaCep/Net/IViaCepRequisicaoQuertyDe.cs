namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define uma requisição Querty.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto contendo os dados da requisição.</typeparam>
    public interface IViaCepRequisicaoQuertyDe<T>
    {
        /// <summary>
        /// Cria uma nova requisição Querty.
        /// </summary>
        /// <param name="obj">O objeto contendo os dados da requisição.</param>
        /// <returns>Um objeto que representa o contexto da requisição.</returns>
        IViaCepRequisicaoPor<T> NovaRequisicaoQuerty(T obj);
    }
}