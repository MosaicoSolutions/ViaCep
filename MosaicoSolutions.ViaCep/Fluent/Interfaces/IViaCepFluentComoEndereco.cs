using System.Threading.Tasks;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    public interface IViaCepFluentComoEndereco
    {
        Endereco ComoEndereco();
        Task<Endereco> ComoEnderecoAsync();
    }
}