using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MosaicoSolutions.ViaCep.Modelos;
using static System.String;

namespace MosaicoSolutions.ViaCep.Util
{
    /// <summary>
    /// Classe utilitária.
    /// </summary>
    public static class ViaCepUtil
    {

        public static string ObterNomeDoEstadoPelaUF(UF uf) => NomesDosEstados[uf];

        public static UF ObterUFPelaSiglaDoEstado(string siglaUF)
        {
            if(NomesDosEstados.Keys.Any(uf => CompareUFComString(siglaUF, uf)))
                return NomesDosEstados.Keys.First(uf => CompareUFComString(siglaUF, uf));

            throw new ArgumentException("A sigla \"" + siglaUF + "\" não existe.");
        }

        private static bool CompareUFComString(string siglaUF, UF uf)
            => string.Equals(Enum.GetName(typeof(UF), uf), siglaUF, StringComparison.InvariantCultureIgnoreCase);

        private static readonly Dictionary<UF, string> NomesDosEstados = new Dictionary<UF, string>
        {
            {UF.AC, "Acre"},
            {UF.AL, "Alagoas"},
            {UF.AM, "Amazonas"},
            {UF.AP, "Amapá"},
            {UF.BA, "Bahia"},
            {UF.CE, "Ceará"},
            {UF.DF, "Distrito Federal"},
            {UF.ES, "Espírito Santo"},
            {UF.GO, "Goiás"},
            {UF.MA, "Maranhão"},
            {UF.MT, "Mato Grosso"},
            {UF.MS, "Mato Grosso do Sul"},
            {UF.MG, "Minas Gerais"},
            {UF.PA, "Pará"},
            {UF.PB, "Paraíba"},
            {UF.PR, "Paraná"},
            {UF.PE, "Pernambuco"},
            {UF.PI, "Piauí"},
            {UF.RJ, "Rio de Janeiro"},
            {UF.RN, "Rio Grande do Norte"},
            {UF.RS, "Rio Grande do Sul"},
            {UF.RO, "Rondônia"},
            {UF.RR, "Roraima"},
            {UF.SC, "Santa Catarina"},
            {UF.SP, "São Paulo"},
            {UF.SE, "Sergipe"},
            {UF.TO, "Tocantins"}
        };
    }
}