using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa uma requisição por endereço.
    /// </summary>
    public sealed class ViaCepRequisicaoPorEndereco : IViaCepRequisicaoPor<EnderecoRequisicao>
    {
        public EnderecoRequisicao Dados { get; }
        public ViaCepFormatoRequisicao Formato { get; }
        
        internal ViaCepRequisicaoPorEndereco(EnderecoRequisicao dados, ViaCepFormatoRequisicao formato) 
        {
            if (!dados.EhValido())
                throw new ArgumentException("O objeto da requisição não é valido.");

            Dados = dados;
            Formato = formato;
        }

        public string ObterUriComoString() => $"{Dados.UF.Sigla}/{Dados.Cidade}/{Dados.Logradouro}/{Formato}";
    }
}