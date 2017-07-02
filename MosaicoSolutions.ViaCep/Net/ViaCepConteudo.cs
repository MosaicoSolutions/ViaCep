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

        public bool PodeSerLidoComoXml => _conteudo.Contains("xmlcep");

        public bool PossuiErro => _conteudo.Contains("erro");

        internal ViaCepConteudo(HttpContent httpContent) => _conteudo = httpContent.ReadAsStringAsync().Result;

        /// <summary>
        /// Lê o conteúdo como xml.
        /// </summary>
        /// <returns>Um Objeto do tipo <code>XDocument</code>.</returns>
        /// <exception cref="InvalidOperationException">Se não for possivel ler o conteúdo como xml.</exception>
        public XDocument LerComoXml() 
            => PodeSerLidoComoXml ? 
                XDocument.Parse(_conteudo) : throw new InvalidOperationException("Não é possivel ler o conteúdo como xml.");

        /// <summary>
        /// Lê o conteúdo como <code>string</code>.
        /// </summary>
        /// <returns>Uma string que representa o conteúdo da requisição.</returns>
        public string LerComoString() => _conteudo;

    }
}