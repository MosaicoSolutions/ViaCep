using System;
using System.Net.Http;
using System.Xml.Linq;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa o conteúdo de uma requisisão.
    /// </summary>
    public class ViaCepConteudo : IViaCepConteudo
    {
        private readonly string _conteudo;

        public bool PodeSerLidoComoXml
        {
            get
            {
                try
                {
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    XDocument.Parse(_conteudo);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool PossuiErro => _conteudo.Contains("erro");

        internal ViaCepConteudo(HttpContent httpContent)
        {
            _conteudo = httpContent.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Lê o conteúdo como xml.
        /// </summary>
        /// <returns>Um Objeto do tipo <code>XDocument</code>.</returns>
        /// <exception cref="InvalidOperationException">Se não for possivel ler o conteúdo como xml.</exception>
        public XDocument LerComoXml()
        {
            if (!PodeSerLidoComoXml)
                throw new InvalidOperationException("Não é possivel ler o conteúdo como xml.");

            return XDocument.Parse(_conteudo);
        }

        /// <summary>
        /// Lê o conteúdo como <code>string</code>.
        /// </summary>
        /// <returns>Uma string que representa o conteúdo da requisição.</returns>
        public string LerComoString() => _conteudo;

    }
}