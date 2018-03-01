using System.Collections.Generic;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep
{
    public partial class ViaCepService
    {
        /// <inheritdoc />
        public Endereco ObterEndereco(Cep cep) 
            => _enderecoConvert.DeJsonParaEndereco(ObterEnderecoComoJson(cep));

        /// <inheritdoc />
        public string ObterEnderecoComoJson(Cep cep) 
            => ObterEnderecoPorCepComoString(cep, ViaCepFormatoRequisicao.Json);

        /// <inheritdoc />
        public string ObterEnderecoComoPiped(Cep cep) 
            => ObterEnderecoPorCepComoString(cep, ViaCepFormatoRequisicao.Piped);

        /// <inheritdoc />
        public string ObterEnderecoComoQuerty(Cep cep) 
            => ObterEnderecoPorCepComoString(cep, ViaCepFormatoRequisicao.Querty);

        /// <inheritdoc />
        public XDocument ObterEnderecoComoXml(Cep cep)
        {
            IViaCepRequisicaoPor<Cep> requisicao = _requisicaoPorCepFactory.NovaRequisicaoXml(cep);
            IViaCepResposta resposta = _cliente.ObterResposta(requisicao.ToUri);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            IViaCepConteudo conteudo = resposta.ObterConteudo();

            GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
            return conteudo.LerComoXml();
        }

        /// <inheritdoc />
        public IEnumerable<Endereco> ObterEnderecos(EnderecoRequisicao enderecoRequisicao) 
            => _enderecoConvert.DeJsonParaListaDeEnderecos(ObterEnderecosComoJson(enderecoRequisicao));

        /// <inheritdoc />
        public string ObterEnderecosComoJson(EnderecoRequisicao enderecoRequisicao)
        {
            IViaCepRequisicaoPor<EnderecoRequisicao> requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoJson(enderecoRequisicao);
            IViaCepResposta resposta = _cliente.ObterResposta(requisicao.ToUri);
            
            GaranteCodigoDeSucessoOuLancaException(resposta);
            
            return resposta.ObterConteudo()
                           .LerComoString();
        }

        /// <inheritdoc />
        public XDocument ObterEnderecosComoXml(EnderecoRequisicao enderecoRequisicao)
        {
            IViaCepRequisicaoPor<EnderecoRequisicao> requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(enderecoRequisicao);
            IViaCepResposta resposta = _cliente.ObterResposta(requisicao.ToUri);
            
            GaranteCodigoDeSucessoOuLancaException(resposta);
            
            return resposta.ObterConteudo()
                           .LerComoXml();
        }
    }
}