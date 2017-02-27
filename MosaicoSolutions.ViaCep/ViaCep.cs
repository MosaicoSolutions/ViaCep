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

    public static class ViaCep
    {
        private const string CepVazioMensagemErro = "O cep não foi preenchido.";

        public static async Task<Endereco> ObterEnderecoAsync(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var json = await ObterEnderecoComoJsonAsync(cep);

            return EnderecoConvert.DeJsonParaEndereco(json);
        }

        public static async Task<string> ObterEnderecoComoJsonAsync(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = await ObterConteudoAsync(ViaCepRequisicaoPorCep.CriarRequisicaoJson(cep));

            return conteudo.LerComoString();
        }

        public static async Task<XDocument> ObterEnderecoComoXmlAsync(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = await ObterConteudoAsync(ViaCepRequisicaoPorCep.CriarRequisicaoXml(cep));

            return conteudo.LerComoXml();
        }

        public static async Task<string> ObterEnderecoComoPipedAsync(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = await ObterConteudoAsync(ViaCepRequisicaoPorCep.CriarRequisicaoPiped(cep));

            return conteudo.LerComoString();
        }

        public static async Task<string> ObterEnderecoComoQuertyAsync(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = await ObterConteudoAsync(ViaCepRequisicaoPorCep.CriarRequisicaoQuerty(cep));

            return conteudo.LerComoString();
        }

        public static async Task<IEnumerable<Endereco>> ObterEnderecosAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var json = await ObterEnderecosComoJsonAsync(enderecoRequisicao);

            return EnderecoConvert.DeJsonParaListaDeEnderecos(json);
        }

        public static async Task<string> ObterEnderecosComoJsonAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var conteudo = await ObterConteudoAsync(ViaCepRequisicaoPorEndereco.CriarRequisicaoJson(enderecoRequisicao));

            return conteudo.LerComoString();
        }

        public static async Task<XDocument> ObterEnderecosComoXmlAsync(EnderecoRequisicao enderecoRequisicao)
        {
            var conteudo = await ObterConteudoAsync(ViaCepRequisicaoPorEndereco.CriarRequisicaoXml(enderecoRequisicao));

            return conteudo.LerComoXml();
        }

        public static async Task<ViaCepConteudo> ObterConteudoAsync(IViaCepRequisicao requisicao)
        {
            var conteudo =  (await ObterRespostaAsync(requisicao)).ObterConteudo();

            if (conteudo.PossuiErro())
                throw ViaCepUtil.CriarExceptionCepInexistente();

            return conteudo;
        }

        public static async Task<ViaCepResposta> ObterRespostaAsync(IViaCepRequisicao requisicao)
        {
            var resposta = await ViaCepCliente.ObterResponseMessageAsync(requisicao);

            if (!resposta.EhCodigoDeSucesso)
                throw ViaCepUtil.CriarExceptionPeloStatusCode(resposta.CodigoDeStatus);

            return resposta;
        }

        public static Endereco ObterEndereco(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var json = ObterEnderecoComoJson(cep);

            return EnderecoConvert.DeJsonParaEndereco(json);
        }

        public static string ObterEnderecoComoJson(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = ObterConteudo(ViaCepRequisicaoPorCep.CriarRequisicaoJson(cep));

            return conteudo.LerComoString();
        }

        public static XDocument ObterEnderecoComoXml(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = ObterConteudo(ViaCepRequisicaoPorCep.CriarRequisicaoXml(cep));

            return conteudo.LerComoXml();
        }

        public static string ObterEnderecoComoPiped(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = ObterConteudo(ViaCepRequisicaoPorCep.CriarRequisicaoPiped(cep));

            return conteudo.LerComoString();
        }

        public static string ObterEnderecoComoQuerty(Cep cep)
        {
            GarantirCepPreenchidoOuLancaExcecao(cep);

            var conteudo = ObterConteudo(ViaCepRequisicaoPorCep.CriarRequisicaoQuerty(cep));

            return conteudo.LerComoString();
        }

        public static IEnumerable<Endereco> ObterEnderecos(EnderecoRequisicao enderecoRequisicao)
        {
            var json = ObterEnderecosComoJson(enderecoRequisicao);

            return EnderecoConvert.DeJsonParaListaDeEnderecos(json);
        }

        public static string ObterEnderecosComoJson(EnderecoRequisicao enderecoRequisicao)
        {
            var conteudo = ObterConteudo(ViaCepRequisicaoPorEndereco.CriarRequisicaoJson(enderecoRequisicao));

            return conteudo.LerComoString();
        }

        public static XDocument ObterEnderecosComoXml(EnderecoRequisicao enderecoRequisicao)
        {
            var conteudo = ObterConteudo(ViaCepRequisicaoPorEndereco.CriarRequisicaoXml(enderecoRequisicao));

            return conteudo.LerComoXml();
        }

        public static ViaCepConteudo ObterConteudo(IViaCepRequisicao requisicao)
        {
            var conteudo = ObterResposta(requisicao).ObterConteudo();

            if (conteudo.PossuiErro())
                throw ViaCepUtil.CriarExceptionCepInexistente();

            return conteudo;
        }

        public static ViaCepResposta ObterResposta(IViaCepRequisicao requisicao)
        {
            var resposta = ViaCepCliente.ObterResponseMessage(requisicao);

            if (!resposta.EhCodigoDeSucesso)
                throw ViaCepUtil.CriarExceptionPeloStatusCode(resposta.CodigoDeStatus);

            return resposta;
        }

        internal static void GarantirCepPreenchidoOuLancaExcecao(Cep cep)
        {
            if (cep.IsEmpty)
                throw new ArgumentException(CepVazioMensagemErro);
        }
    }
}
