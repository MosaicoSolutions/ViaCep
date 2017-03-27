using System.Xml.Linq;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define o conteúdo da resposta de uma requisição.
    /// </summary>
    public interface IViaCepConteudo
    {
        /// <summary>
        /// Avalia se o conteúdo pode ser lido como Xml.
        /// </summary>
        bool PodeSerLidoComoXml { get; }

        /// <summary>
        /// Avalia se o conteúdo possui erro.
        /// </summary>
        bool PossuiErro { get; }

        /// <summary>
        /// Lê o conteúdo como Xml.
        /// </summary>
        /// <returns>Um <see cref="XDocument"/> que representa um Xml do conteúdo.</returns>
        XDocument LerComoXml();

        /// <summary>
        /// Lê o conteúdo como string.
        /// </summary>
        /// <returns>Uma <see cref="System.String"/> que representa o conteúdo.</returns>
        string LerComoString();

    }
}