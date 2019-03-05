using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <inheritdoc />
    public sealed class ViaCepRequisicaoPorCep : IViaCepRequisicaoPor<Cep>
    {
        /// <inheritdoc />
        public Cep Dados { get; }

        /// <inheritdoc />
        public ViaCepFormatoRequisicao Formato { get; }

        internal ViaCepRequisicaoPorCep(Cep cep, ViaCepFormatoRequisicao formato)
        {
            if (cep.IsEmpty)
                throw new ArgumentException("O cep não pode estar vazio.", nameof(cep));

            Dados = cep;
            Formato = formato;
        }

        /// <inheritdoc />
        public string ToUri() => $"{Dados}/{Formato}";
    }
}
