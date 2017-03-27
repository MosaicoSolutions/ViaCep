using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define uma requisição Json.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto contendo os dados da requisição. <see cref="Cep"/> ou <see cref="EnderecoRequisicao"/></typeparam>
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