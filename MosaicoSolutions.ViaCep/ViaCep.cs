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
        public static async Task<string> ObterEnderecoComoJsonAsync(string cep)
        {
            return await ObterEnderecoComoJsonAsync(new Cep(cep));
        }

        private static async Task<string> ObterEnderecoComoJsonAsync(Cep cep)
        {
            if (cep == null)
                throw new ArgumentNullException(nameof(cep));

            var requisicao = ViaCepRequisicaoPorCep.CriarRequisicaoJson(cep);
            var responseMessage = await ViaCepCliente.ObterResponseMessageAsync(requisicao);

            if (!responseMessage.IsSuccessStatusCode)
                throw ViaCepUtil.CriarExceptionPeloStatusCode(responseMessage.StatusCode);

            var conteudo = await responseMessage.Content.ReadAsStringAsync();

            if (!EhConteudoDaRequisicaoValido(conteudo))
                throw ViaCepUtil.CriarExceptionCepInexistente();

            return conteudo;
        }

        private static bool EhConteudoDaRequisicaoValido(string conteudo) => !conteudo.Contains("erro");
    }
}