namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define uma requisição Json.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto contendo os dados da requisição. <see cref="MosaicoSolutions.ViaCep.Modelos.Cep"/> ou <see cref="MosaicoSolutions.ViaCep.Modelos.EnderecoRequisicao"/>
    /// </typeparam>
    public interface IViaCepRequisicaoJsonDe<T>
    {
        /// <summary>
        /// Cria uma nova requisição Json.
        /// </summary>
        /// <param name="obj">O objeto contendo os dados da requisição.</param>
        /// <returns>Um objeto que representa o contexto da requisição.</returns>
        IViaCepRequisicaoPor<T> NovaRequisicaoJson(T obj);
    }
}