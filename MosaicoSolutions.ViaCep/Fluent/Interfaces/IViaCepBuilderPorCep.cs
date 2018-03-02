using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent.Interfaces
{
    /// <summary>
    /// Um Builder Pattern para realizar uma requisição ViaCep por Cep.
    /// </summary>
    public interface IViaCepBuilderPorCep
    {
        /// <summary>
        /// Define os dados da requisição.
        /// </summary>
        /// <param name="cep">Um <see cref="Cep"/> que representa os dados da requisição.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Caso o cep esteja vazio.</exception>
        IViaCepBuilderPorCep ComOsDados(Cep cep);

        /// <summary>
        /// Define um método que irá ser chamado se ocorrer algum erro durante a requisição.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Se action for nulo.</exception>
        IViaCepBuilderPorCep Capture(Action<Exception> action);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como <see cref="Endereco"/>.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        void RetorneComoEndereco(Action<Endereco> callback);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como <see cref="Endereco"/>.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        /// <returns>Uma <see cref="Task"/> para ser executada de forma assíncrona.</returns>
        Task RetorneComoEnderecoAsync(Action<Endereco> callback);


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
        /// Executa uma requisição ViaCep e retorna como Piped.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        void RetorneComoPiped(Action<string> callback);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como Piped.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        /// <returns>Uma <see cref="Task"/> para ser executada de forma assíncrona.</returns>
        Task RetorneComoPipedAsync(Action<string> callback);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como Querty.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        void RetorneComoQuerty(Action<string> callback);

        /// <summary>
        /// Executa uma requisição ViaCep e retorna como Querty.
        /// </summary>
        /// <param name="callback">Método que será executado logo após a requisição.</param>
        /// <returns>Uma <see cref="Task"/> para ser executada de forma assíncrona.</returns>
        Task RetorneComoQuertyAsync(Action<string> callback);

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