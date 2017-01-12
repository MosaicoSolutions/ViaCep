using System;
using System.Collections.Generic;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent.Callback
{
    public static class ViaCepFluentCallbackMethods
    {
        public static void ComoEndereco(this IViaCepFluentPorCep fluent, Action<Endereco> callback)
            => callback(fluent.ComoEndereco());

        public static void ComoJson(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(fluent.ComoJson());

        public static void ComoPiped(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(fluent.ComoPiped());

        public static void ComoQuerty(this IViaCepFluentPorCep fluent, Action<string> callback)
            => callback(fluent.ComoQuerty());

        public static void ComoXml(this IViaCepFluentPorCep fluent, Action<XDocument> callback)
            => callback(fluent.ComoXml());

        public static void ComoJson(this IViaCepFluentPorEndereco fluent, Action<string> callback)
            => callback(fluent.ComoJson());

        public static void ComoXml(this IViaCepFluentPorEndereco fluent, Action<XDocument> callback)
            => callback(fluent.ComoXml());

        public static void ComoListaDeEnderecos(this IViaCepFluentPorEndereco fluent, Action<IEnumerable<Endereco>> callback)
            => callback(fluent.ComoListaDeEnderecos());
    }
}