using System.Collections.Generic;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Util
{
    /// <summary>
    /// Fornece métodos para converter de Json para <see cref="Endereco"/>
    /// </summary>
    public interface IEnderecoConvert
    {
        /// <summary>
        /// Converte um Json para um <see cref="Endereco"/>.
        /// </summary>
        /// <param name="json">Uma string que representa o Endereço.</param>
        /// <returns>Um <see cref="Endereco"/>.</returns>
        Endereco DeJsonParaEndereco(string json);
        
        /// <summary>
        /// Converte um Json para um <see cref="IEnumerable{Endereco}"/>.
        /// </summary>
        /// <param name="json">Uma string que representa um array de Endereços.</param>
        /// <returns>Um <see cref="IEnumerable{Endereco}"/>.</returns>
        IEnumerable<Endereco> DeJsonParaListaDeEnderecos(string json);
    }
}