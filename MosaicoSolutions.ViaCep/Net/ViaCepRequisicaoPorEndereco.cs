using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa uma requisição por endereço.
    /// </summary>
    public sealed class ViaCepRequisicaoPorEndereco : ViaCepRequisicaoPor<EnderecoRequisicao>
    {
        internal ViaCepRequisicaoPorEndereco(EnderecoRequisicao objetoDaRequisicao, ViaCepFormatoRequisicao formatoRequisicao) 
            : base(objetoDaRequisicao, formatoRequisicao)
        {
            if (!objetoDaRequisicao.EhValido())
                throw new ArgumentException("O objeto da requisição não é valido.");
        }

        public override string ObterUriComoString()
            => $"{EnderecoRequisicaoParaUri()}/{FormatoRequisicao.Valor}";

        private string EnderecoRequisicaoParaUri()
            => $"{ObjetoDaRequisicao.UF.Sigla}/{ObjetoDaRequisicao.Cidade}/{ObjetoDaRequisicao.Logradouro}";
    }
}