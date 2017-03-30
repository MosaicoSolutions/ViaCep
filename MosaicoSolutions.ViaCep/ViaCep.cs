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

        public ViaCep(IViaCepCliente cliente, IViaCepRequisicaoPorCepFactory requisicaoPorCepFactory, IViaCepRequisicaoPorEnderecoFactory requisicaoPorEnderecoFactory)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (requisicaoPorCepFactory == null)
                throw new ArgumentNullException(nameof(requisicaoPorCepFactory));

            if (requisicaoPorEnderecoFactory == null)
                throw new ArgumentNullException(nameof(requisicaoPorEnderecoFactory));

            _cliente = cliente;
            _requisicaoPorCepFactory = requisicaoPorCepFactory;
            _requisicaoPorEnderecoFactory = requisicaoPorEnderecoFactory;
        }

        public Endereco ObterEndereco(Cep cep)
        {
            var json = ObterEnderecoComoJson(cep);
            return EnderecoConvert.DeJsonParaEndereco(json);
        }

        public async Task<Endereco> ObterEnderecoAsync(Cep cep)
        {
            var json = await ObterEnderecoComoJsonAsync(cep);
            return EnderecoConvert.DeJsonParaEndereco(json);
        }

        public async Task<string> ObterEnderecoComoJsonAsync(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoJson(cep);
            var conteudo = await TentaObterConteudoAsync(requisicao);
            return conteudo.LerComoString();
        }

        public string ObterEnderecoComoJson(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoJson(cep);
            var conteudo = TentaObterConteudo(requisicao);
            return conteudo.LerComoString();
        }

        public async Task<string> ObterEnderecoComoPipedAsync(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoPiped(cep);
            var conteudo = await TentaObterConteudoAsync(requisicao);
            return conteudo.LerComoString();
        }

        public string ObterEnderecoComoPiped(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoPiped(cep);
            var conteudo = TentaObterConteudo(requisicao);
            return conteudo.LerComoString();
        }

        public async Task<string> ObterEnderecoComoQuertyAsync(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoQuerty(cep);
            var conteudo = await TentaObterConteudoAsync(requisicao);
            return conteudo.LerComoString();
        }

        public string ObterEnderecoComoQuerty(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoQuerty(cep);
            var conteudo = TentaObterConteudo(requisicao);
            return conteudo.LerComoString();
        }

        public async Task<XDocument> ObterEnderecoComoXmlAsync(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoXml(cep);
            var conteudo = await TentaObterConteudoAsync(requisicao);
            return conteudo.LerComoXml();
        }

        public XDocument ObterEnderecoComoXml(Cep cep)
        {
            var requisicao = _requisicaoPorCepFactory.NovaRequisicaoXml(cep);
            var conteudo = TentaObterConteudo(requisicao);
            return conteudo.LerComoXml();
        }

        public async Task<IEnumerable<Endereco>> ObterEnderecosAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var json = await ObterEnderecosComoJsonAsync(enderecoRequisicao);
            return EnderecoConvert.DeJsonParaListaDeEnderecos(json);
        }

        public IEnumerable<Endereco> ObterEnderecos(EnderecoRequisicao enderecoRequisicao)
        {
            var json = ObterEnderecosComoJson(enderecoRequisicao);
            return EnderecoConvert.DeJsonParaListaDeEnderecos(json);
        }

        public async Task<string> ObterEnderecosComoJsonAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoJson(enderecoRequisicao);
            var conteudo = await TentaObterConteudoAsync(requisicao);
            return conteudo.LerComoString();
        }

        public string ObterEnderecosComoJson(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoJson(enderecoRequisicao);
            var conteudo = TentaObterConteudo(requisicao);
            return conteudo.LerComoString();
        }

        public async Task<XDocument> ObterEnderecosComoXmlAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(enderecoRequisicao);
            var conteudo = await TentaObterConteudoAsync(requisicao);
            return conteudo.LerComoXml();
        }

        public XDocument ObterEnderecosComoXml(EnderecoRequisicao enderecoRequisicao)
        {
            var requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(enderecoRequisicao);
            var conteudo = TentaObterConteudo(requisicao);
            return conteudo.LerComoXml();
        }

        private IViaCepConteudo TentaObterConteudo(IViaCepUri uri)
        {
            var conteudo = TentaObterResposta(uri).ObterConteudo();

            GaranteConteudoSemErroOuLancaException(conteudo);

            return conteudo;
        }

        private async Task<IViaCepConteudo> TentaObterConteudoAsync(IViaCepUri uri)
        {
            var conteudo = (await TentaObterRespostaAsync(uri)).ObterConteudo();

            GaranteConteudoSemErroOuLancaException(conteudo);

            return conteudo;
        }

        private static void GaranteConteudoSemErroOuLancaException(IViaCepConteudo conteudo)
        {
            if (conteudo.PossuiErro)
                throw new CepInexistenteException();
        }

        private IViaCepResposta TentaObterResposta(IViaCepUri uri)
        {
            var resposta = _cliente.ObterResposta(uri);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            return resposta;
        }

        private async Task<IViaCepResposta> TentaObterRespostaAsync(IViaCepUri uri)
        {
            var resposta = await _cliente.ObterRespostaAsync(uri);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            return resposta;
        }

        private static void GaranteCodigoDeSucessoOuLancaException(IViaCepResposta resposta)
        {
            if (!resposta.EhCodigoDeSucesso)
                throw new ViaCepException(resposta.CodigoDeStatus);
        }

        public IViaCepConteudo ObterConteudo(IViaCepUri uri)
            => ObterResposta(uri).ObterConteudo();

        public async Task<IViaCepConteudo> ObterConteudoAsync(IViaCepUri uri)
            => (await ObterRespostaAsync(uri)).ObterConteudo();

        public IViaCepResposta ObterResposta(IViaCepUri uri)
            => _cliente.ObterResposta(uri);

        public async Task<IViaCepResposta> ObterRespostaAsync(IViaCepUri uri)
            => await _cliente.ObterRespostaAsync(uri);

        internal static void GarantirCepPreenchidoOuLancaExcecao(Cep cep)
        {
            if (cep.IsEmpty)
                throw new ArgumentException("O cep está vazio.");
        }
    }
}
