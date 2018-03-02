using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent
{
    /// <inheritdoc />
    public sealed class ViaCepBuilderPorCep : IViaCepBuilderPorCep
    {
        private Action<Exception> _onError;
        private Cep _dados;

        /// <inheritdoc />
        public IViaCepBuilderPorCep ComOsDados(Cep dados)
        {
            _dados = dados.IsEmpty
                ? throw new ArgumentException("O Cep não pode ser vazio ou nulo.", nameof(dados))
                : dados;
            return this;
        }

        /// <inheritdoc />
        public IViaCepBuilderPorCep Capture(Action<Exception> action)
        {
            _onError = action ?? throw new ArgumentNullException(nameof(action));
            return this;
        }

        /// <inheritdoc />
        public void RetorneComoEndereco(Action<Endereco> callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            try
            {
                using (var viaCepService = ViaCepService.Default())
                    callback(viaCepService.ObterEndereco(_dados));
            }
            catch (Exception e)
            {
                if (_onError == null)
                    throw;
                _onError(e);
            }
        }

        /// <inheritdoc />
        public Task RetorneComoEnderecoAsync(Action<Endereco> callback)
            => callback == null
                ? throw new ArgumentNullException(nameof(callback))
                : Task.Run(async () =>
                {
                    try
                    {
                        using (var viaCepService = ViaCepService.Default())
                            callback(await viaCepService.ObterEnderecoAsync(_dados));
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
                    callback(viaCepService.ObterEnderecoComoJson(_dados));
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
                            callback(await viaCepService.ObterEnderecoComoJsonAsync(_dados));
                    }
                    catch (Exception e)
                    {
                        if (_onError == null)
                            throw;
                        _onError(e);
                    }
                });

        /// <inheritdoc />
        public void RetorneComoPiped(Action<string> callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            try
            {
                using (var viaCepService = ViaCepService.Default())
                    callback(viaCepService.ObterEnderecoComoPiped(_dados));
            }
            catch (Exception e)
            {
                if (_onError == null)
                    throw;
                _onError(e);
            }
        }

        /// <inheritdoc />
        public Task RetorneComoPipedAsync(Action<string> callback)
            => callback == null
                ? throw new ArgumentNullException(nameof(callback))
                : Task.Run(async () =>
                {
                    try
                    {
                        using (var viaCepService = ViaCepService.Default())
                            callback(await viaCepService.ObterEnderecoComoPipedAsync(_dados));
                    }
                    catch (Exception e)
                    {
                        if (_onError == null)
                            throw;
                        _onError(e);
                    }
                });

        /// <inheritdoc />
        public void RetorneComoQuerty(Action<string> callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            try
            {
                using (var viaCepService = ViaCepService.Default())
                    callback(viaCepService.ObterEnderecoComoQuerty(_dados));
            }
            catch (Exception e)
            {
                if (_onError == null)
                    throw;
                _onError(e);
            }
        }

        /// <inheritdoc />
        public Task RetorneComoQuertyAsync(Action<string> callback)
            => callback == null
                ? throw new ArgumentNullException(nameof(callback))
                : Task.Run(async () =>
                {
                    try
                    {
                        using (var viaCepService = ViaCepService.Default())
                            callback(await viaCepService.ObterEnderecoComoQuertyAsync(_dados));
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
                    callback(viaCepService.ObterEnderecoComoXml(_dados));
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
                            callback(await viaCepService.ObterEnderecoComoXmlAsync(_dados));
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