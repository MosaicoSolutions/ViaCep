using System.Threading.Tasks;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    public interface IViaCepFluentComoPiped
    {
        string ComoPiped();
        Task<string> ComoPipedAsync();
    }
}