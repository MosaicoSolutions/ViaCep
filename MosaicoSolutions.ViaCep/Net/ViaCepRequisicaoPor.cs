using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Representa uma requisição ViaCep contendo o objeto com os dados da requisição e um formato.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto que contém os dados da requisição, <see cref="Cep"/> ou <see cref="EnderecoRequisicao"/>.</typeparam>
    public abstract class ViaCepRequisicaoPor<T> : IViaCepRequisicaoPor<T>
    {
        public T ObjetoDaRequisicao { get; }
        public ViaCepFormatoRequisicao FormatoRequisicao { get; }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ViaCepRequisicaoPor{T}"/> com os dados da requisição e o formato.
        /// </summary>
        /// <param name="objetoDaRequisicao">O objeto contendo os dados da requisição. <see cref="Cep"/> ou <see cref="EnderecoRequisicao"/></param>
        /// <param name="formatoRequisicao">O formato da requisição.</param>
        protected ViaCepRequisicaoPor(T objetoDaRequisicao, ViaCepFormatoRequisicao formatoRequisicao)
        {
            ObjetoDaRequisicao = objetoDaRequisicao;
            FormatoRequisicao = formatoRequisicao;
        }

        public abstract string ObterUriComoString();
    }
}