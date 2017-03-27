namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa o Uri do recurso a ser consumido.
    /// </summary>
    public interface IViaCepUri
    {
        /// <summary>
        /// Retorna o Uri do recurso como <see cref="string"/>.
        /// </summary>
        /// <returns>Uma <see cref="string"/> que representa o Uri do recurso.</returns>
        string ObterUriComoString();
    }
}