/*
================================================================
ViaCepService - Um módulo para a consulta de endereços da API ViaCepService
================================================================

ViaCepService - https://viacep.com.br

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
using System.Threading.Tasks;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep
{
    /// <inheritdoc />
    public sealed partial class ViaCepService : IViaCepService
    {
        private readonly IViaCepCliente _cliente;
        private readonly IEnderecoConvert _enderecoConvert;
        private readonly IViaCepRequisicaoPorCepFactory _requisicaoPorCepFactory;
        private readonly IViaCepRequisicaoPorEnderecoFactory _requisicaoPorEnderecoFactory;
        
        /// <summary>
        /// Devolve um serviço ViaCep padrão.
        /// </summary>
        /// <returns>Um <see cref="IViaCepService"/> que representa um serviço ViaCep.</returns>
        public static IViaCepService Default()
            => new ViaCepService(new ViaCepCliente(),
                                 new EnderecoConvert(), 
                                 new ViaCepRequisicaoPorCepFactory(), 
                                 new ViaCepRequisicaoPorEnderecoFactory());

        /// <inheritdoc />
        public ViaCepService(IViaCepCliente viaCepCliente,
                             IEnderecoConvert enderecoConvert,
                             IViaCepRequisicaoPorCepFactory requisicaoPorCepFactory,
                             IViaCepRequisicaoPorEnderecoFactory requisicaoPorEnderecoFactory)
        {
            _cliente = viaCepCliente ?? throw new ArgumentNullException(nameof(viaCepCliente));
            _enderecoConvert = enderecoConvert ?? throw new ArgumentNullException(nameof(enderecoConvert));
            _requisicaoPorCepFactory = requisicaoPorCepFactory ?? throw new ArgumentNullException(nameof(requisicaoPorCepFactory));
            _requisicaoPorEnderecoFactory = requisicaoPorEnderecoFactory ?? throw new ArgumentNullException(nameof(requisicaoPorEnderecoFactory));
        }

        #region Helpers

        private static ArgumentException ThrowCepVazioErro(string nomeParametro)
            => new ArgumentException("O Cep não pode ser nulo ou vazio. ", nomeParametro);
        
        private static ArgumentException ThrowEnderecoRequisicaoInvalido(string nomeParametro)
            => new ArgumentException("O objeto da requisição por Endereço não é válido.", nomeParametro);

        private string ObterEnderecoPorCepComoString(Cep cep, ViaCepFormatoRequisicao formatoRequisicao)
        {
            IViaCepRequisicaoPor<Cep> requisicao = NovaRequisicaoPorCep(cep, formatoRequisicao);
            IViaCepResposta resposta = _cliente.ObterResposta(requisicao.ToUri);

            GaranteCodigoDeSucessoOuLancaException(resposta);

            IViaCepConteudo conteudo = resposta.ObterConteudo();

            GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
            return conteudo.LerComoString();
        }

        private Task<string> ObterEnderecoPorCepComoStringAsync(Cep cep, ViaCepFormatoRequisicao formatoRequisicao)
            => Task.Run(async () =>
            {
                IViaCepRequisicaoPor<Cep> requisicao = NovaRequisicaoPorCep(cep, formatoRequisicao);
                IViaCepResposta resposta = await _cliente.ObterRespostaAsync(requisicao.ToUri);

                GaranteCodigoDeSucessoOuLancaException(resposta);

                IViaCepConteudo conteudo = resposta.ObterConteudo();

                GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
                return conteudo.LerComoString();
            });
        
        private static IViaCepRequisicaoPor<Cep> NovaRequisicaoPorCep(Cep cep, ViaCepFormatoRequisicao formatoRequisicao) 
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

        #region IDisposable Support
        private bool _disposedValue;

        private void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
                _cliente.Dispose();

            _disposedValue = true;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        
        #endregion
    }
}
