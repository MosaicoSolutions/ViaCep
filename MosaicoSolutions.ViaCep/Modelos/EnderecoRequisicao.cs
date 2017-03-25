using System;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Representa os dados de um requisição por endereço.
    /// </summary>
    [Serializable]
    public struct EnderecoRequisicao
    {
        public UF UF { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }

        /// <summary>
        /// Para que uma requisição por endereço seja válida a <see cref="Cidade"/> e o <see cref="Logradouro"/>
        /// precisam ter no mínimo três caraceres.
        /// </summary>
        private const int QuantidadeMinimaDeCaracteres = 3;

        public EnderecoRequisicao(UF uf, string cidade, string logradouro)
        {
            UF = uf;
            Cidade = cidade;
            Logradouro = logradouro;
        }

        /// <summary>
        /// Testa se o objeto é valido segundo as seguintes condições.
        /// UF é um objeto não-nulo.
        /// Cidade e Logradouro não-nulos e com tamanho de no mínimo 3.
        /// </summary>
        /// <returns>True, se o objeto for válido, caso contrário, false.</returns>
        public bool EhValido() => UF != null && EhCidadeValida() && EhLogradouroValido();

        private bool EhCidadeValida() => !string.IsNullOrEmpty(Cidade) && Cidade.Length >= QuantidadeMinimaDeCaracteres;

        private bool EhLogradouroValido() => !string.IsNullOrEmpty(Logradouro) && Logradouro.Length >= QuantidadeMinimaDeCaracteres;
    }
}