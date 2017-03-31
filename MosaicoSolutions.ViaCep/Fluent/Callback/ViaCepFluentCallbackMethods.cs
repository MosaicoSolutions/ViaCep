using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent.Callback
{
    public static class ViaCepFluentCallbackMethods
    {
        public static void ComoEndereco(this IViaCepFluentPorCep fluent, Action<Endereco> callback)
            => callback(fluent.ComoEndereco());

        public static async Task ComoEnderecoAsync(this IViaCepFluentPorCep fluent, Action<Endereco> callback)
            => callback(await fluent.ComoEnderecoAsync());

        public static void ComoJson(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(fluent.ComoJson());

        public static async Task ComoJsonAsync(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(await fluent.ComoJsonAsync());

        public static void ComoPiped(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(fluent.ComoPiped());

        public static async Task ComoPipedAsync(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(await fluent.ComoPipedAsync());

        public static void ComoQuerty(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(fluent.ComoQuerty());

        public static async Task ComoQuertyAsync(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(await fluent.ComoQuertyAsync());

        public static void ComoXml(this IViaCepFluentPorCep fluent, Action<XDocument> callback)
            => callback(fluent.ComoXml());

        public static async Task ComoXmlAsync(this IViaCepFluentPorCep fluent, Action<XDocument> callback)
            => callback(await fluent.ComoXmlAsync());

        public static void ComoJson(this IViaCepFluentPorEndereco fluent, Action<string> callback)
            => callback(fluent.ComoJson());

        public static async Task ComoJsonAsync(this IViaCepFluentPorEndereco fluent, Action<string> callback)
            => callback(await fluent.ComoJsonAsync());

        public static void ComoXml(this IViaCepFluentPorEndereco fluent, Action<XDocument> callback)
            => callback(fluent.ComoXml());

        public static async Task ComoXmlAsync(this IViaCepFluentPorEndereco fluent, Action<XDocument> callback)
            => callback(await fluent.ComoXmlAsync());

        public static void ComoListaDeEnderecos(this IViaCepFluentPorEndereco fluent, Action<IEnumerable<Endereco>> callback)
            => callback(fluent.ComoListaDeEnderecos());

        public static async Task ComoListaDeEnderecosAsync(this IViaCepFluentPorEndereco fluent, Action<IEnumerable<Endereco>> callback)
            => callback(await fluent.ComoListaDeEnderecosAsync());
    }
}