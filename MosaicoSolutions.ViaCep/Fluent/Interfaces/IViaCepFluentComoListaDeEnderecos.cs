using System.Collections.Generic;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    public interface IViaCepFluentComoListaDeEnderecos
    {
        IEnumerable<Endereco> ComoListaDeEnderecos();
    }
}