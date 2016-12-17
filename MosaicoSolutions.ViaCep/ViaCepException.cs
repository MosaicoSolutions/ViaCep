using System;
using System.Runtime.Serialization;


namespace MosaicoSolutions.ViaCep
{
    /// <summary>
    /// A exceção que é lançada quando o ocorre algum erro na requisição do endereço.
    /// </summary>
    [Serializable]
    public class ViaCepException : Exception
    {

        /// <summary>
        /// Inicializa uma nova instância da class <code>ViaCepException</code>.
        /// </summary>
        public ViaCepException()
            : base(Util.MensagensDeErro.ErroDeRequisicao)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da class <code>ViaCepException</code> com a mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo da exceção.</param>
        public ViaCepException(string message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da class <code>ViaCepException</code> com a mensagem de erro especificada.
        /// e uma referência para a exceção interna que é a causa dessa exceção.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo para a exceção.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.
        /// Se o <code>innerException</code> parâmetro não é uma referência nula,
        /// a exceção atual é gerada em um bloco catch que manipula a exceção interna.
        /// </param>
        public ViaCepException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <code>ViaCepException</code> com dados serializados.
        /// </summary>
        /// <param name="info">O objeto que contém os dados do objeto serializado.</param>
        /// <param name="context">As informações contextuais sobre a origem ou o destino.</param>
        protected ViaCepException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}