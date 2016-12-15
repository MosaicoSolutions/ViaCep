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

        private bool EhCidadeValida() => !string.IsNullOrEmpty(Cidade) && Cidade.Length >= 3;

        private bool EhLogradouroValido() => !string.IsNullOrEmpty(Logradouro) && Logradouro.Length >= 3;

        public UF UF { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
    }
}