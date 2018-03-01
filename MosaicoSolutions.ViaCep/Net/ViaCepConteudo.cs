using System;
using System.Net.Http;
using System.Xml.Linq;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <inheritdoc />
    public sealed class ViaCepConteudo : IViaCepConteudo
    {
        internal static IViaCepConteudo Of(HttpContent httpContent) => new ViaCepConteudo(httpContent);

        private readonly string _conteudo;
        
        private ViaCepConteudo(HttpContent httpContent) => _conteudo = httpContent.ReadAsStringAsync().Result;
        
        /// <inheritdoc />
        public bool PodeSerLidoComoXml => _conteudo.Contains("xmlcep");

        /// <inheritdoc />
        public bool PossuiErro => _conteudo.Contains("erro");

        /// <inheritdoc />
        public XDocument LerComoXml() 
            => PodeSerLidoComoXml 
                ? XDocument.Parse(_conteudo) 
                : throw new InvalidOperationException("Não é possivel ler o conteúdo como xml.");

        /// <inheritdoc />
        public string LerComoString() => _conteudo;
    }
}