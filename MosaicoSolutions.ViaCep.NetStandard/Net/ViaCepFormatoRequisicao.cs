using System;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa os formatos suportados pela requisição.
    /// </summary>
    [Serializable]
    public sealed class ViaCepFormatoRequisicao : IEquatable<ViaCepFormatoRequisicao>
    {
        public static readonly ViaCepFormatoRequisicao Json = new ViaCepFormatoRequisicao("json");

        public static readonly ViaCepFormatoRequisicao Xml = new ViaCepFormatoRequisicao("xml");

        public static readonly ViaCepFormatoRequisicao Piped = new ViaCepFormatoRequisicao("piped");

        public static readonly ViaCepFormatoRequisicao Querty = new ViaCepFormatoRequisicao("querty");
        
        /// <summary>
        /// O valor do formato da requisição em string. Exemplo: ViaCepFormatoRequisicao.Json.Valor => "json".
        /// </summary>
        public string Valor { get; }

        private ViaCepFormatoRequisicao(string value) => Valor = value;

        /// <inheritdoc />
        public override bool Equals(object obj)
            => obj is ViaCepFormatoRequisicao && Equals((ViaCepFormatoRequisicao) obj);

        /// <inheritdoc />
        public bool Equals(ViaCepFormatoRequisicao other)
            => other != null && Valor == other.Valor;

        /// <inheritdoc />
        public override int GetHashCode()
            => Valor?.GetHashCode() ?? 0;
        
        public override string ToString() => Valor;
    }
}