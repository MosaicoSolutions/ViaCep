using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <inheritdoc />
    public sealed class ViaCepRequisicaoPorEndereco : IViaCepRequisicaoPor<EnderecoRequisicao>
    {
        /// <inheritdoc />
        public EnderecoRequisicao Dados { get; }

        /// <inheritdoc />
        public ViaCepFormatoRequisicao Formato { get; }

        internal ViaCepRequisicaoPorEndereco(EnderecoRequisicao dados, ViaCepFormatoRequisicao formato) 
        {
            if (!dados.EhValido())
                throw new ArgumentException("O objeto da requisição não é valido.", nameof(dados));

            Dados = dados;
            Formato = formato;
        }

        /// <inheritdoc />
        public string ToUri() => $"{Dados.UF.Sigla}/{Dados.Cidade}/{Dados.Logradouro}/{Formato}";
    }
}