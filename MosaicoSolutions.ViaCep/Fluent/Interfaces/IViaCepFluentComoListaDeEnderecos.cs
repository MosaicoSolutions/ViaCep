using System.Collections.Generic;
using System.Threading.Tasks;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    public interface IViaCepFluentComoListaDeEnderecos
    {
        IEnumerable<Endereco> ComoListaDeEnderecos();
        Task<IEnumerable<Endereco>> ComoListaDeEnderecosAsync();
    }
}