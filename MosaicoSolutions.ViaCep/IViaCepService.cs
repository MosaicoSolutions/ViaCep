using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep
{
    /// <summary>
    /// Define um serviço responsável por realizar requisições ViaCep.
    /// </summary>
    public interface IViaCepService : IDisposable
    {
        /// <summary>
        /// Obtém o endereço, de forma assíncrona, do cep espeficado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um objeto do tipo <see cref="Endereco"/> contendo os dados.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        Task<Endereco> ObterEnderecoAsync(Cep cep);
        
        /// <summary>
        /// Obtém o endereço do cep espeficado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um objeto do tipo <see cref="Endereco"/> contendo os dados.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        Endereco ObterEndereco(Cep cep);

        /// <summary>
        /// Obtém o endereço, como json, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como json.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        Task<string> ObterEnderecoComoJsonAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como json, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como json.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        string ObterEnderecoComoJson(Cep cep);

        /// <summary>
        /// Obtém o endereço, como piped, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como piped.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        Task<string> ObterEnderecoComoPipedAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como piped, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como piped.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        string ObterEnderecoComoPiped(Cep cep);

        /// <summary>
        /// Obtém o endereço, como querty, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como querty.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        Task<string> ObterEnderecoComoQuertyAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como querty, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como querty.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        string ObterEnderecoComoQuerty(Cep cep);

        /// <summary>
        /// Obtém o endereço, como xml, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um <see cref="XDocument"/> contendo o endereço.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        Task<XDocument> ObterEnderecoComoXmlAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como xml, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um <see cref="XDocument"/> contendo o endereço.</returns>
        /// <exception cref="System.ArgumentException">Se o cep estiver vazio.</exception>
        XDocument ObterEnderecoComoXml(Cep cep);

        /// <summary>
        /// Obtém os endereços, de forma assíncrona, da requisicao especificada.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um objeto do tipo <see cref="IEnumerable{T}"/> contendo os dados.</returns>
        /// <exception cref="System.ArgumentException">Se enderecoRequisicao for inválido.</exception>
        Task<IEnumerable<Endereco>> ObterEnderecosAsync(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, da requisicao especificada.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um objeto do tipo <see cref="IEnumerable{T}"/> contendo os dados.</returns>
        /// <exception cref="System.ArgumentException">Se enderecoRequisicao for inválido.</exception>
        IEnumerable<Endereco> ObterEnderecos(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, de forma assíncrona, da requisicao especificada como json.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Uma <see cref="string"/> contendo os endereços como json.</returns>
        /// <exception cref="System.ArgumentException">Se enderecoRequisicao for inválido.</exception>
        Task<string> ObterEnderecosComoJsonAsync(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, da requisicao especificada como json.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Uma <see cref="string"/> contendo os endereços como json.</returns>
        /// <exception cref="System.ArgumentException">Se enderecoRequisicao for inválido.</exception>
        string ObterEnderecosComoJson(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, de forma assíncrona, da requisicao especificada como xml.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um <see cref="XDocument"/> contendo os endereços.</returns>
        /// <exception cref="System.ArgumentException">Se enderecoRequisicao for inválido.</exception>
        Task<XDocument> ObterEnderecosComoXmlAsync(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, da requisicao especificada como xml.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um <see cref="XDocument"/> contendo os endereços.</returns>
        /// <exception cref="System.ArgumentException">Se enderecoRequisicao for inválido.</exception>
        XDocument ObterEnderecosComoXml(EnderecoRequisicao enderecoRequisicao);
    }
}