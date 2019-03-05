using System;
using System.Runtime.Serialization;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Exception lançada quando pelos métodos <see cref="UF.PelaSigla"/>, <see cref="UF.PeloCodigo"/> e
    /// <see cref="UF.PeloNomeDoEstado"/> quando não encontram a UF com os parâmetros especificados.
    /// </summary>
    [Serializable]
    public class UFInexistenteException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UFInexistenteException"/>.
        /// </summary>
        public UFInexistenteException() : base("A UF não existe.") { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UFInexistenteException"/> com a mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo da exceção.</param>
        public UFInexistenteException(string message) : base(message) { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UFInexistenteException"/> com a mensagem de erro especificada.
        /// e uma referência para a exceção interna que é a causa dessa exceção.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo para a exceção.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.
        /// Se o <code>innerException</code> parâmetro não é uma referência nula,
        /// a exceção atual é gerada em um bloco catch que manipula a exceção interna.
        /// </param>
        public UFInexistenteException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UFInexistenteException"/> com dados serializados.
        /// </summary>
        /// <param name="info">O objeto que contém os dados do objeto serializado.</param>
        /// <param name="context">As informações contextuais sobre a origem ou o destino.</param>
        protected UFInexistenteException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}