/*
================================================================
ViaCep - Um módulo para a consulta de endereços da API ViaCep
================================================================

ViaCep - https://viacep.com.br

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

Copyright (C) 2016 Mosaico Solutions.

Authors: Bruno Xavier de Moura - https://github.com/brunoSpeedrun


*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep
{
    /// <summary>
    /// Cliente responsável por retornar a resposta de uma requisição.
    /// </summary>
    public sealed class ViaCep : IViaCep
    {
        private readonly IViaCepCliente _cliente;
        private readonly IViaCepRequisicaoPorCepFactory _requisicaoPorCepFactory;
        private readonly IViaCepRequisicaoPorEnderecoFactory _requisicaoPorEnderecoFactory;

        public ViaCep() : this(new ViaCepCliente(), new ViaCepRequisicaoPorCepFactory(), new ViaCepRequisicaoPorEnderecoFactory())
        {
        }

        public ViaCep(IViaCepCliente cliente, 
                      IViaCepRequisicaoPorCepFactory requisicaoPorCepFactory, 
                      IViaCepRequisicaoPorEnderecoFactory requisicaoPorEnderecoFactory)
        {
            _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            _requisicaoPorCepFactory = requisicaoPorCepFactory ?? throw new ArgumentNullException(nameof(requisicaoPorCepFactory));
            _requisicaoPorEnderecoFactory = requisicaoPorEnderecoFactory ?? throw new ArgumentNullException(nameof(requisicaoPorEnderecoFactory));
        }

        public Endereco ObterEndereco(Cep cep) 
            => EnderecoConvert.DeJsonParaEndereco(ObterEnderecoComoJson(cep));

        public async Task<Endereco> ObterEnderecoAsync(Cep cep) 
            => EnderecoConvert.DeJsonParaEndereco(await ObterEnderecoComoJsonAsync(cep));

        public async Task<string> ObterEnderecoComoJsonAsync(Cep cep) 
            => await ObterComoStringAsync(cep, ViaCepFormatoRequisicao.Json);

        public string ObterEnderecoComoJson(Cep cep) 
            => ObterComoString(cep, ViaCepFormatoRequisicao.Json);

        public async Task<string> ObterEnderecoComoPipedAsync(Cep cep) 
            => await ObterComoStringAsync(cep, ViaCepFormatoRequisicao.Piped);

        public string ObterEnderecoComoPiped(Cep cep) 
            => ObterComoString(cep, ViaCepFormatoRequisicao.Piped);

        public async Task<string> ObterEnderecoComoQuertyAsync(Cep cep) 
            => await ObterComoStringAsync(cep, ViaCepFormatoRequisicao.Querty);

        public string ObterEnderecoComoQuerty(Cep cep) 
            => ObterComoString(cep, ViaCepFormatoRequisicao.Querty);

        public async Task<XDocument> ObterEnderecoComoXmlAsync(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoXml(cep);
            var resposta = await _cliente.ObterRespostaAsync(requisicao);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            var conteudo = resposta.ObterConteudo();

            GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
            return conteudo.LerComoXml();
        }

        public XDocument ObterEnderecoComoXml(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoXml(cep);
            var resposta = _cliente.ObterResposta(requisicao);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            var conteudo = resposta.ObterConteudo();

            GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
            return conteudo.LerComoXml();
        }

        public async Task<IEnumerable<Endereco>> ObterEnderecosAsync(EnderecoRequisicao enderecoRequisicao) 
            => EnderecoConvert.DeJsonParaListaDeEnderecos(await ObterEnderecosComoJsonAsync(enderecoRequisicao));

        public IEnumerable<Endereco> ObterEnderecos(EnderecoRequisicao enderecoRequisicao) 
            => EnderecoConvert.DeJsonParaListaDeEnderecos(ObterEnderecosComoJson(enderecoRequisicao));

        public async Task<string> ObterEnderecosComoJsonAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoJson(enderecoRequisicao);
            var resposta = await _cliente.ObterRespostaAsync(requisicao);
            
            GaranteCodigoDeSucessoOuLancaException(resposta);
            
            var conteudo = resposta.ObterConteudo();
            return conteudo.LerComoString();
        }

        public string ObterEnderecosComoJson(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoJson(enderecoRequisicao);
            var resposta = _cliente.ObterResposta(requisicao);
            
            GaranteCodigoDeSucessoOuLancaException(resposta);
            
            var conteudo = resposta.ObterConteudo();
            return conteudo.LerComoString();
        }

        public async Task<XDocument> ObterEnderecosComoXmlAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(enderecoRequisicao);
            var resposta = await _cliente.ObterRespostaAsync(requisicao);
            
            GaranteCodigoDeSucessoOuLancaException(resposta);
            
            var conteudo = resposta.ObterConteudo();
            return conteudo.LerComoXml();
        }

        public XDocument ObterEnderecosComoXml(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(enderecoRequisicao);
            var resposta = _cliente.ObterResposta(requisicao);
            
            GaranteCodigoDeSucessoOuLancaException(resposta);
            
            var conteudo = resposta.ObterConteudo();
            return conteudo.LerComoXml();
        }

        public IViaCepConteudo ObterConteudo(IViaCepUri uri)
            => ObterResposta(uri).ObterConteudo();

        public async Task<IViaCepConteudo> ObterConteudoAsync(IViaCepUri uri)
            => (await ObterRespostaAsync(uri)).ObterConteudo();

        public IViaCepResposta ObterResposta(IViaCepUri uri)
            => _cliente.ObterResposta(uri);

        public async Task<IViaCepResposta> ObterRespostaAsync(IViaCepUri uri)
            => await _cliente.ObterRespostaAsync(uri);
        

        #region Helpers

        private string ObterComoString(Cep cep, ViaCepFormatoRequisicao formatoRequisicao)
        {
            var requisicao = NovaRequisicao(cep, formatoRequisicao);
            var resposta = _cliente.ObterResposta(requisicao);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            var conteudo = resposta.ObterConteudo();

            GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
            return conteudo.LerComoString();
        }
        
        private async Task<string> ObterComoStringAsync(Cep cep, ViaCepFormatoRequisicao formatoRequisicao)
        {
            var requisicao = NovaRequisicao(cep, formatoRequisicao);
            var resposta = await _cliente.ObterRespostaAsync(requisicao);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            var conteudo = resposta.ObterConteudo();

            GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
            return conteudo.LerComoString();
        }
        
        private static ViaCepRequisicaoPor<Cep> NovaRequisicao(Cep cep, ViaCepFormatoRequisicao formatoRequisicao) 
            => new ViaCepRequisicaoPorCep(cep, formatoRequisicao);
        
        private static void GaranteCodigoDeSucessoOuLancaException(IViaCepResposta resposta)
        {
            if (!resposta.EhCodigoDeSucesso)
                throw new ViaCepException(resposta.CodigoDeStatus);
        }
        
        private static void GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(IViaCepConteudo conteudo)
        {
            if (conteudo.PossuiErro)
                throw new CepInexistenteException();
        }

        #endregion
    }
}
