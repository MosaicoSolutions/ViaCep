using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    public interface IViaCepFluentComoQuerty
    {
        string ComoQuerty();
        Task<string> ComoQuertyAsync();
    }
}