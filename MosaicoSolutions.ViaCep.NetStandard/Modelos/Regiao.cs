using System;
using System.Collections.Generic;
using System.Linq;

namespace MosaicoSolutions.ViaCep.Modelos
{
    [Serializable]
    public sealed class Regiao
    {
        public static Regiao CentroOeste { get; }
        public static Regiao Nordeste { get; }
        public static Regiao Norte { get; }
        public static Regiao Sudeste { get; }
        public static Regiao Sul { get; }

        public string Nome { get; }
        public IEnumerable<UF> Estados { get; }

        private Regiao(string nome, params UF[] estatos)
        {
            Nome = nome;
            Estados = estatos;
        }

        static Regiao()
        {
            CentroOeste = new Regiao("Centro-Oeste", UF.DF, UF.GO, UF.MT, UF.MS);
            Nordeste = new Regiao("Nordeste", UF.AL, UF.BA, UF.CE, UF.MA, UF.PB, UF.PE, UF.PI, UF.RN, UF.SE);
            Norte = new Regiao("Norte", UF.AC, UF.AM, UF.AP, UF.PA, UF.RO, UF.RR, UF.TO);
            Sudeste = new Regiao("Sudeste", UF.ES, UF.MG, UF.RJ, UF.SP);
            Sul = new Regiao("Sul", UF.PR, UF.RS, UF.SC);
        }
        
        /// <summary>
        /// Avalia se um determinado <see cref="UF"/> pertence a região.
        /// </summary>
        /// <param name="uf">A <see cref="UF"/> a ser avaliada.</param>
        /// <returns>true, se a uf pertencer a este objeto, caso contrário, false.</returns>
        public bool ContemOEstado(UF uf) => Estados.Contains(uf);
    }
}