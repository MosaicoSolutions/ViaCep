using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep
{
    /// <summary>
    /// Define um cliente responsável por retornar a resposta de uma requisição.
    /// </summary>
    public interface IViaCepService
    {
        /// <summary>
        /// Obtém o endereço do cep espeficado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um objeto do tipo <see cref="Endereco"/> contendo os dados.</returns>
        Endereco ObterEndereco(Cep cep);

        /// <summary>
        /// Obtém o endereço, de forma assíncrona, do cep espeficado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um objeto do tipo <see cref="Endereco"/> contendo os dados.</returns>
        Task<Endereco> ObterEnderecoAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como json, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como json.</returns>
        Task<string> ObterEnderecoComoJsonAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como json, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como json.</returns>
        string ObterEnderecoComoJson(Cep cep);

        /// <summary>
        /// Obtém o endereço, como piped, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como piped.</returns>
        Task<string> ObterEnderecoComoPipedAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como piped, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como piped.</returns>
        string ObterEnderecoComoPiped(Cep cep);

        /// <summary>
        /// Obtém o endereço, como querty, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como querty.</returns>
        Task<string> ObterEnderecoComoQuertyAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como querty, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Uma <see cref="System.String"/> contendo o endereço como querty.</returns>
        string ObterEnderecoComoQuerty(Cep cep);

        /// <summary>
        /// Obtém o endereço, como xml, de forma assíncrona, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um <see cref="XDocument"/> contendo o endereço.</returns>
        Task<XDocument> ObterEnderecoComoXmlAsync(Cep cep);

        /// <summary>
        /// Obtém o endereço, como xml, do cep especificado.
        /// </summary>
        /// <param name="cep">O <see cref="Cep"/> do endereço.</param>
        /// <returns>Um <see cref="XDocument"/> contendo o endereço.</returns>
        XDocument ObterEnderecoComoXml(Cep cep);

        /// <summary>
        /// Obtém os endereços, de forma assíncrona, da requisicao especificada.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um objeto do tipo <see cref="IEnumerable{T}"/> contendo os dados.</returns>
        Task<IEnumerable<Endereco>> ObterEnderecosAsync(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, da requisicao especificada.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um objeto do tipo <see cref="IEnumerable{T}"/> contendo os dados.</returns>
        IEnumerable<Endereco> ObterEnderecos(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, de forma assíncrona, da requisicao especificada como json.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Uma <see cref="string"/> contendo os endereços como json.</returns>
        Task<string> ObterEnderecosComoJsonAsync(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, da requisicao especificada como json.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Uma <see cref="string"/> contendo os endereços como json.</returns>
        string ObterEnderecosComoJson(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, de forma assíncrona, da requisicao especificada como xml.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um <see cref="XDocument"/> contendo os endereços.</returns>
        Task<XDocument> ObterEnderecosComoXmlAsync(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém os endereços, da requisicao especificada como xml.
        /// </summary>
        /// <param name="enderecoRequisicao">O <see cref="EnderecoRequisicao"/> dos endereços.</param>
        /// <returns>Um <see cref="XDocument"/> contendo os endereços.</returns>
        XDocument ObterEnderecosComoXml(EnderecoRequisicao enderecoRequisicao);

        /// <summary>
        /// Obtém o conteúdo de uma requisição.
        /// </summary>
        /// <param name="uri">O <see cref="IViaCepUri"/> da requisição.</param>
        /// <returns>Um <see cref="IViaCepConteudo"/> que representa a requisição.</returns>
        IViaCepConteudo ObterConteudo(IViaCepUri uri);

        /// <summary>
        /// Obtém o conteúdo de uma requisição, de forma assíncrona.
        /// </summary>
        /// <param name="uri">O <see cref="IViaCepUri"/> da requisição.</param>
        /// <returns>Um <see cref="IViaCepConteudo"/> que representa a requisição.</returns>
        Task<IViaCepConteudo> ObterConteudoAsync(IViaCepUri uri);

        /// <summary>
        /// Obtém a resposta de uma requisição.
        /// </summary>
        /// <param name="uri">O <see cref="IViaCepUri"/> da requisição.</param>
        /// <returns>Um <see cref="IViaCepResposta"/> que representa a requisição.</returns>
        IViaCepResposta ObterResposta(IViaCepUri uri);

        /// <summary>
        /// Obtém a resposta de uma requisição.
        /// </summary>
        /// <param name="uri">O <see cref="IViaCepUri"/> da requisição.</param>
        /// <returns>Um <see cref="IViaCepResposta"/> que representa a requisição.</returns>
        Task<IViaCepResposta> ObterRespostaAsync(IViaCepUri uri);

    }
}