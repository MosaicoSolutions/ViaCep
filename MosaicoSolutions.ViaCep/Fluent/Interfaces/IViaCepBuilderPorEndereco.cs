using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    /// <summary>
    /// Um Builder Pattern para realizar uma requisição ViaCep por Endereço.
    /// </summary>
    public interface IViaCepBuilderPorEndereco
    {
        /// <summary>
        /// Define os dados da requisição.
        /// </summary>
        /// <param name="dados">Um <see cref="EnderecoRequisicao"/> que representa os dados da requisição.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Caso dados seja inválido.</exception>
        IViaCepBuilderPorEndereco ComOsDados(EnderecoRequisicao dados);

        /// <summary>
        /// Define um método que irá ser chamado se ocorrer algum erro durante a requisição.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Se action for nulo.</exception>
        IViaCepBuilderPorEndereco Capture(Action<Exception> action);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como <see cref="IEnumerable{Endereco}"/>.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        void RetorneComoListaDeEnderecos(Action<IEnumerable<Endereco>> callback);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como <see cref="IEnumerable{Endereco}"/>.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        /// <returns>Uma <see cref="Task"/> para ser executada de forma assíncrona.</returns>
        Task RetorneComoListaDeEnderecosAsync(Action<IEnumerable<Endereco>> callback);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como Json.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        void RetorneComoJson(Action<string> callback);
        
        /// <summary>
        /// Executa uma requisição ViaCep e retorna como Json.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        /// <returns>Uma <see cref="Task"/> para ser executada de forma assíncrona.</returns>
        Task RetorneComoJsonAsync(Action<string> callback);
        
        /// <summary>
        /// Executa uma requisição ViaCep e retorna como <see cref="XDocument"/>.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        void RetorneComoXml(Action<XDocument> callback);
        
        /// <summary>
        /// Executa uma requisição ViaCep e retorna como <see cref="XDocument"/>.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        /// <returns>Uma <see cref="Task"/> para ser executada de forma assíncrona.</returns>
        Task RetorneComoXmlAsync(Action<XDocument> callback);
    }
}