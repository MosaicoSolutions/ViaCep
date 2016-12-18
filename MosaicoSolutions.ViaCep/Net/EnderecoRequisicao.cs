using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public struct EnderecoRequisicao
    {
        public EnderecoRequisicao(UF uf, string cidade, string logradouro)
        {
            UF = uf;
            Cidade = cidade;
            Logradouro = logradouro;
        }

        public bool EhValido() => EhCidadeValida() && EhLogradouroValido();

        private bool EhCidadeValida() => !string.IsNullOrEmpty(Cidade) && Cidade.Length >= QuantidadeMinimaDeCaracteres;

        private bool EhLogradouroValido() => !string.IsNullOrEmpty(Logradouro) && Logradouro.Length >= QuantidadeMinimaDeCaracteres;

        public UF UF { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }

        /// <summary>
        /// Quantidade de Caracteres mínimo da Cidade e Logradouro para uma requisicao por endereço válida.
        /// </summary>
        public const int QuantidadeMinimaDeCaracteres = 3;
    }
}