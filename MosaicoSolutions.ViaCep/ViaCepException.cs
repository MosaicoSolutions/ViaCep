using System;
using System.Net;
using System.Runtime.Serialization;


namespace MosaicoSolutions.ViaCep
{
    /// <summary>
    /// A exceção que é lançada quando o ocorre algum erro em uma requisição ao serviço ViaCepService.
    /// </summary>
    [Serializable]
    public class ViaCepException : Exception
    {
        private readonly string _message;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ViaCepException"/>.
        /// </summary>
        public ViaCepException() => _message = Util.MensagensDeErro.ErroDeRequisicao;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ViaCepException"/> com a mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo da exceção.</param>
        public ViaCepException(string message) => _message = message;

        /// <summary>
        /// Inicializa uma nova instância da class <code>ViaCepException</code> com a mensagem de erro especificada.
        /// e uma referência para a exceção interna que é a causa dessa exceção.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica o motivo para a exceção.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.
        /// Se o parâmetro <see cref="Exception.InnerException"/> não é uma referência nula,
        /// a exceção atual é gerada em um bloco catch que manipula a exceção interna.
        /// </param>
        public ViaCepException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ViaCepException"/> com dados serializados.
        /// </summary>
        /// <param name="info">O objeto que contém os dados do objeto serializado.</param>
        /// <param name="context">As informações contextuais sobre a origem ou o destino.</param>
        protected ViaCepException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        internal ViaCepException(HttpStatusCode codigoDeStatus)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (codigoDeStatus)
            {
                case HttpStatusCode.BadRequest:
                    _message = Util.MensagensDeErro.BadRequest;
                    break;
                case HttpStatusCode.ProxyAuthenticationRequired:
                    _message = Util.MensagensDeErro.AutenticacaoProxyRequerida;
                    break;
                default:
                    _message = Util.MensagensDeErro.ErroDeRequisicao;
                    break;
            }
        }

        public override string Message => _message ?? base.Message;
    }
}