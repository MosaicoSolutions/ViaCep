using MosaicoSolutions.ViaCep.Fluent.Interfaces;

namespace MosaicoSolutions.ViaCep.Fluent
{
    /// <summary>
    /// Define uma Fluent Interface para realizar consultas de Endereços.
    /// </summary>
    public static class ViaCepFluent
    {
        /// <summary>
        /// Um Builder para realizar requisições por Cep.
        /// </summary>
        public static IViaCepBuilderPorCep RequisicaoPorCep => new ViaCepBuilderPorCep();

        /// <summary>
        /// Um Builder para realizar requisições por Endereco.
        /// </summary>
        public static IViaCepBuilderPorEndereco RequisicaoPorEndereco => new ViaCepBuilderPorEndereco();
    }
}
