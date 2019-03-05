using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent
{
    /// <inheritdoc />
    public sealed class ViaCepBuilderPorEndereco : IViaCepBuilderPorEndereco
    {
        private EnderecoRequisicao _dados;
        private Action<Exception> _onError;
        
        /// <inheritdoc />
        public IViaCepBuilderPorEndereco ComOsDados(EnderecoRequisicao dados)
        {
            _dados = dados.EhValido()
                        ? dados
                        : throw new ArgumentException("O EnderecoRequisicao não é válido.", nameof(dados));
            return this;
        }

        /// <inheritdoc />
        public IViaCepBuilderPorEndereco Capture(Action<Exception> action)
        {
            _onError = action ?? throw new ArgumentNullException(nameof(action));
            return this;
        }

        /// <inheritdoc />
        public void RetorneComoListaDeEnderecos(Action<IEnumerable<Endereco>> callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            try
            {
                using (var viaCepService = ViaCepService.Default())
                    callback(viaCepService.ObterEnderecos(_dados));
            }
            catch (Exception e)
            {
                if (_onError == null)
                    throw;
                _onError(e);
            }
        }

        /// <inheritdoc />
        public Task RetorneComoListaDeEnderecosAsync(Action<IEnumerable<Endereco>> callback)
            => callback == null
                ? throw new ArgumentNullException(nameof(callback))
                : Task.Run(async () =>
                {
                    try
                    {
                        using (var viaCepService = ViaCepService.Default())
                            callback(await viaCepService.ObterEnderecosAsync(_dados));
                    }
                    catch (Exception e)
                    {
                        if (_onError == null)
                            throw;
                        _onError(e);
                    }
                });

        /// <inheritdoc />
        public void RetorneComoJson(Action<string> callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            try
            {
                using (var viaCepService = ViaCepService.Default())
                    callback(viaCepService.ObterEnderecosComoJson(_dados));
            }
            catch (Exception e)
            {
                if (_onError == null)
                    throw;
                _onError(e);
            }
        }

        /// <inheritdoc />
        public Task RetorneComoJsonAsync(Action<string> callback)
            => callback == null
                ? throw new ArgumentNullException(nameof(callback))
                : Task.Run(async () =>
                {
                    try
                    {
                        using (var viaCepService = ViaCepService.Default())
                            callback(await viaCepService.ObterEnderecosComoJsonAsync(_dados));
                    }
                    catch (Exception e)
                    {
                        if (_onError == null)
                            throw;
                        _onError(e);
                    }
                });

        /// <inheritdoc />
        public void RetorneComoXml(Action<XDocument> callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            try
            {
                using (var viaCepService = ViaCepService.Default())
                    callback(viaCepService.ObterEnderecosComoXml(_dados));
            }
            catch (Exception e)
            {
                if (_onError == null)
                    throw;
                _onError(e);
            }
        }

        /// <inheritdoc />
        public Task RetorneComoXmlAsync(Action<XDocument> callback)
            => callback == null
                ? throw new ArgumentNullException(nameof(callback))
                : Task.Run(async () =>
                {
                    try
                    {
                        using (var viaCepService = ViaCepService.Default())
                            callback(await viaCepService.ObterEnderecosComoXmlAsync(_dados));
                    }
                    catch (Exception e)
                    {
                        if (_onError == null)
                            throw;
                        _onError(e);
                    }
                });
    }
}