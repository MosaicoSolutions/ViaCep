using System;
using System.Collections.Generic;
using System.Linq;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Unidade Federativa.
    /// </summary>
    [Serializable]
    public sealed class UF : IComparable<UF>, IComparable, IEquatable<UF>
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

        private static readonly IEnumerable<UF> Ufs;

        #region Estados

        public static UF RO
        {
            get { return EncontraPelaSigla("RO"); }
        }

        public static UF AC
        {
            get { return EncontraPelaSigla("AC"); }
        }

        public static UF AM
        {
            get { return EncontraPelaSigla("AM"); }
        }

        public static UF RR
        {
            get { return EncontraPelaSigla("RR"); }
        }

        public static UF PA
        {
            get { return EncontraPelaSigla("PA"); }
        }

        public static UF AP
        {
            get { return EncontraPelaSigla("AP"); }
        }

        public static UF TO
        {
            get { return EncontraPelaSigla("TO"); }
        }

        public static UF MA
        {
            get { return EncontraPelaSigla("MA"); }
        }

        public static UF PI
        {
            get { return EncontraPelaSigla("PI"); }
        }

        public static UF CE
        {
            get { return EncontraPelaSigla("CE"); }
        }

        public static UF RN
        {
            get { return EncontraPelaSigla("RN"); }
        }

        public static UF PB
        {
            get { return EncontraPelaSigla("PB"); }
        }

        public static UF PE
        {
            get { return EncontraPelaSigla("PE"); }
        }

        public static UF AL
        {
            get { return EncontraPelaSigla("AL"); }
        }

        public static UF SE
        {
            get { return EncontraPelaSigla("SE"); }
        }

        public static UF BA
        {
            get { return EncontraPelaSigla("BA"); }
        }

        public static UF MG
        {
            get { return EncontraPelaSigla("MG"); }
        }

        public static UF ES
        {
            get { return EncontraPelaSigla("ES"); }
        }

        public static UF RJ
        {
            get { return EncontraPelaSigla("RJ"); }
        }

        public static UF SP
        {
            get { return EncontraPelaSigla("SP"); }
        }

        public static UF PR
        {
            get { return EncontraPelaSigla("PR"); }
        }

        public static UF SC
        {
            get { return EncontraPelaSigla("SC"); }
        }

        public static UF RS
        {
            get { return EncontraPelaSigla("RS"); }
        }

        public static UF MS
        {
            get { return EncontraPelaSigla("MS"); }
        }

        public static UF MT
        {
            get { return EncontraPelaSigla("MT"); }
        }

        public static UF GO
        {
            get { return EncontraPelaSigla("GO"); }
        }

        public static UF DF
        {
            get { return EncontraPelaSigla("DF"); }
        }

        #endregion

        private UF(int codigo, string nomeEstado, string sigla)
        {
            Codigo = codigo;
            Sigla = sigla;
            NomeEstado = nomeEstado;
        }

        static UF()
        {
            Ufs = new[]
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
                throw new UFInexistenteException("Não existe nenhum estado com este código: " + codigo, e);
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
                throw new UFInexistenteException("Não existe nenhum estado com esta sigla: " + sigla, e);
            }
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
                return 1;

            if (ReferenceEquals(this, obj))
                return 0;

            if (!(obj is UF))
                throw new ArgumentException($"Objeto deve ser do tipo {nameof(UF)}");

            return CompareTo((UF) obj);
        }

        public int CompareTo(UF other)
        {
            if (ReferenceEquals(this, other))
                return 0;

            if (ReferenceEquals(null, other))
                return 1;

            return Codigo.CompareTo(other.Codigo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var other = obj as UF;

            return other != null && Equals(other);
        }

        public bool Equals(UF other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Codigo == other.Codigo;
        }

        public override int GetHashCode()
        {
            return Codigo;
        }
    }
}