using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    public interface IViaCepFluentComoJson
    {
        string ComoJson();
        Task<string> ComoJsonAsync();
    }
}