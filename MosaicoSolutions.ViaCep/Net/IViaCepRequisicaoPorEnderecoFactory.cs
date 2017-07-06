using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    /// <summary>
    /// Define um Factory para a criação de requisições por Endereço.
    /// </summary>
    public interface IViaCepRequisicaoPorEnderecoFactory : IViaCepRequisicaoJsonDe<EnderecoRequisicao>, 
                                                           IViaCepRequisicaoXmlDe<EnderecoRequisicao>
    { }
}