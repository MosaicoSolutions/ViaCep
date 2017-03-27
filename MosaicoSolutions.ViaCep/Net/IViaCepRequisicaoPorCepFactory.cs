using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define um Factory para a criação de requisições por Cep.
    /// </summary>
    public interface IViaCepRequisicaoPorCepFactory : IViaCepRequisicaoJsonDe<Cep>, IViaCepRequisicaoPipedDe<Cep>, IViaCepRequisicaoQuertyDe<Cep>, IViaCepRequisicaoXmlDe<Cep>
    {

    }
}