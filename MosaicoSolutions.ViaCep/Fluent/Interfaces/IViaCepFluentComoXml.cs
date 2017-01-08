using System.Threading.Tasks;
using System.Xml.Linq;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    public interface IViaCepFluentComoXml
    {
        XDocument ComoXml();
        Task<XDocument> ComoXmlAsync();
    }
}