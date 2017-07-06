using System;
using System.Runtime.Serialization;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// A exceção que é lançada quando o Cep está em um formato inválido.
    /// </summary>
    [Serializable]
    public class CepInvalidoException : Exception
    {
        private const string CepInexistenteError =
            "O Cep não estava em um formato válido. Um dos seguintes formatos eram esperados: 00000000 ou 00000-000";

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="CepInexistenteException"/>.
        /// </summary>
        public CepInvalidoException() : base(CepInexistenteError) { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="CepInexistenteException"/> com a mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo da exceção.</param>
        public CepInvalidoException(string message) : base(message) { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="CepInexistenteException"/> com a mensagem de erro especificada.
        /// e uma referência para a exceção interna que é a causa dessa exceção.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo para a exceção.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.
        /// Se o <code>innerException</code> parâmetro não é uma referência nula,
        /// a exceção atual é gerada em um bloco catch que manipula a exceção interna.
        /// </param>
        public CepInvalidoException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="CepInexistenteException"/> com dados serializados.
        /// </summary>
        /// <param name="info">O objeto que contém os dados do objeto serializado.</param>
        /// <param name="context">As informações contextuais sobre a origem ou o destino.</param>
        protected CepInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}