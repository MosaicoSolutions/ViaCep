using System;
using System.Runtime.Serialization;

namespace MosaicoSolutions.ViaCep
{
    /// <summary>
    /// A exceção que é lançada quando o cep informado não existe.
    /// </summary>
    [Serializable]
    public class CepInexistenteException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="CepInexistenteException"/>.
        /// </summary>
        public CepInexistenteException() : base(Util.MensagensDeErro.CepInexistente)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CepInexistenteException"/> com a mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo da exceção.</param>
        public CepInexistenteException(string message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CepInexistenteException"/> com a mensagem de erro especificada.
        /// e uma referência para a exceção interna que é a causa dessa exceção.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo para a exceção.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.
        /// Se o parâmetro <see cref="Exception.InnerException"/> não é uma referência nula,
        /// a exceção atual é gerada em um bloco catch que manipula a exceção interna.
        /// </param>
        public CepInexistenteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CepInexistenteException"/> com dados serializados.
        /// </summary>
        /// <param name="info">O objeto que contém os dados do objeto serializado.</param>
        /// <param name="context">As informações contextuais sobre a origem ou o destino.</param>
        protected CepInexistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}