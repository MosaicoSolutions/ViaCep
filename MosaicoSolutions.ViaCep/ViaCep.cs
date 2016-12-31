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

Authors: Anderson Oliveira - https://github.com/RunF0rrestRun
         Bruno Xavier de Moura - https://github.com/brunoSpeedrun
         Johnnys Martins - https://github.com/JohnnysMartins
*/

using System;
using System.Threading.Tasks;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep
{
    //TODO: Classe que executa as requisições.
    public static class ViaCep
    {
        public static async Task<Endereco> ObterEnderecoAsync(string cep)
            => await ObterEnderecoAsync(new Cep(cep));

        public static async Task<Endereco> ObterEnderecoAsync(Cep cep)
        {
            if (cep == null)
                throw new ArgumentNullException(nameof(cep));

            var json = await ObterEnderecoComoJsonAsync(cep);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(json);
        }

        public static async Task<string> ObterEnderecoComoJsonAsync(string cep)
            => await ObterEnderecoComoJsonAsync(new Cep(cep));

        public static async Task<string> ObterEnderecoComoJsonAsync(Cep cep)
        {
            if (cep == null)
                throw new ArgumentNullException(nameof(cep));

            var conteudo = await ObterConteudoAsync(ViaCepRequisicaoPorCep.CriarRequisicaoJson(cep));

            return conteudo.LerComoString();
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

        public static string ObterEnderecoComoJson(string cep)
            => ObterEnderecoComoJson(new Cep(cep));

        public static string ObterEnderecoComoJson(Cep cep)
        {
            if (cep == null)
                throw new ArgumentNullException(nameof(cep));

            var conteudo = ObterConteudo(ViaCepRequisicaoPorCep.CriarRequisicaoJson(cep));

            return conteudo.LerComoString();
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
    }
}