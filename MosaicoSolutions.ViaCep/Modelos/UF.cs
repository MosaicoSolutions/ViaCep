using System;
using System.Collections.Generic;
using System.Linq;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Unidade Federativa.
    /// </summary>
    [Serializable]
    public sealed class UF
    {
        /// <summary>
        /// O código da UF
        /// </summary>
        public int Codigo { get; }

        /// <summary>
        /// Sigla
        /// </summary>
        public string Sigla { get; }

        /// <summary>
        /// O nome do estado.
        /// </summary>
        public string NomeEstado { get; }

        public static UF RO { get; } = EncontraPelaSigla("RO");

        public static UF AC { get; } = EncontraPelaSigla("AC");

        public static UF AM { get; } = EncontraPelaSigla("AM");

        public static UF RR { get; } = EncontraPelaSigla("RR");

        public static UF PA { get; } = EncontraPelaSigla("PA");

        public static UF AP { get; } = EncontraPelaSigla("AP");

        public static UF TO { get; } = EncontraPelaSigla("TO");

        public static UF MA { get; } = EncontraPelaSigla("MA");

        public static UF PI { get; } = EncontraPelaSigla("PI");

        public static UF CE { get; } = EncontraPelaSigla("CE");

        public static UF RN { get; } = EncontraPelaSigla("RN");

        public static UF PB { get; } = EncontraPelaSigla("PB");

        public static UF PE { get; } = EncontraPelaSigla("PE");

        public static UF AL { get; } = EncontraPelaSigla("AL");

        public static UF SE { get; } = EncontraPelaSigla("SE");

        public static UF BA { get; } = EncontraPelaSigla("BA");

        public static UF MG { get; } = EncontraPelaSigla("MG");

        public static UF ES { get; } = EncontraPelaSigla("ES");

        public static UF RJ { get; } = EncontraPelaSigla("RJ");

        public static UF SP { get; } = EncontraPelaSigla("SP");

        public static UF PR { get; } = EncontraPelaSigla("PR");

        public static UF SC { get; } = EncontraPelaSigla("SC");

        public static UF RS { get; } = EncontraPelaSigla("RS");

        public static UF MS { get; } = EncontraPelaSigla("MS");

        public static UF MT { get; } = EncontraPelaSigla("MT");

        public static UF GO { get; } = EncontraPelaSigla("GO");

        public static UF DF { get; } = EncontraPelaSigla("DF");

        private static readonly IEnumerable<UF> Ufs = new[]
        {
            new UF(11,"Rondônia","RO"), new UF(12, "Acre", "AC"), new UF(13,"Amazonas","AM"),
            new UF(14,"Roraima","RR"), new UF(15,"Pará","PA"), new UF(16,"Amapá","AP"),
            new UF(17,"Tocantins","TO"),new UF(21,"Maranhão", "MA"), new UF(22, "Piauí", "PI"),
            new UF(23,"Ceará","CE"), new UF(24,"Rio Grande do Norte","RN"), new UF(25,"Paraíba","PB"),
            new UF(26,"Pernambuco","PE"),new UF(27,"Alagoas","AL"), new UF(28,"Sergipe","SE"),
            new UF(29,"Bahia","BA"), new UF(31,"Minas Gerais","MG"),new UF(32,"Espírito Santo","ES"),
            new UF(33,"Rio de Janeiro","RJ"), new UF(35,"São Paulo","SP"), new UF(41,"Paraná","PR"),
            new UF(42,"Santa Catarina","SC"), new UF(50,"Mato Grosso do Sul","MS"), new UF(51,"Mato grosso","MT"),
            new UF(52,"Goiás","GO"), new UF(53,"Distrito Federal","DF"), new UF(43,"Rio Grande do Sul","RS")
        };

        private UF(int codigo, string nomeEstado, string sigla)
        {
            Codigo = codigo;
            Sigla = sigla;
            NomeEstado = nomeEstado;
        }

        /// <summary>
        /// Encontra uma UF a partir do código do estado.
        /// </summary>
        /// <param name="codigo">O código do estado que se deseja obter.</param>
        /// <returns>A UF do estado pertencente ao código.</returns>
        /// <exception cref="InvalidOperationException">Se não existe UF com este código de estado.</exception>
        public static UF EncontraPeloCodigo(int codigo)
        {
            try
            {
                return Ufs.First(uf => uf.Codigo == codigo);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Não existe nenhum estado com este código: " + codigo, e);
            }
        }

        /// <summary>
        /// Encontra uma UF a partir da sigla do estado.
        /// </summary>
        /// <param name="sigla">A sigla do estado que se deseja obter.</param>
        /// <returns>A UF do estado pertencente a sigla</returns>
        /// <exception cref="InvalidOperationException">Se não existe UF com esta sigla.</exception>
        public static UF EncontraPelaSigla(string sigla)
        {
            try
            {
                return Ufs.First(uf => uf.Sigla == sigla);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Não existe nenhum estado com esta sigla: " + sigla, e);
            }
        }
    }
}