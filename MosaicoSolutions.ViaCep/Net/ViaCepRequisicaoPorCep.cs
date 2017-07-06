using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa uma requisição por Cep.
    /// </summary>
    public sealed class ViaCepRequisicaoPorCep : IViaCepRequisicaoPor<Cep>
    {
        public Cep Dados { get; }
        public ViaCepFormatoRequisicao Formato { get; }
        
        internal ViaCepRequisicaoPorCep(Cep cep, ViaCepFormatoRequisicao formato)
        {
            if (cep.IsEmpty)
                throw new ArgumentException("O cep não pode estar vazio.");

            Dados = cep;
            Formato = formato;
        }

        public string ObterUriComoString() => $"{Dados}/{Formato}";
    }
}
