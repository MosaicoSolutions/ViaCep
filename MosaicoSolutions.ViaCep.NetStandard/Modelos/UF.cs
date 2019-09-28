using System;
using System.Collections.Generic;
using System.Linq;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Unidade Federativa.
    /// </summary>
    [Serializable]
    public sealed class UF : IEquatable<UF>
    {
        private static readonly IEnumerable<UF> Ufs;
        
        #region Estados

        public static UF RO => PelaSigla("RO");

        public static UF AC => PelaSigla("AC");

        public static UF AM => PelaSigla("AM");

        public static UF RR => PelaSigla("RR");

        public static UF PA => PelaSigla("PA");

        public static UF AP => PelaSigla("AP");

        public static UF TO => PelaSigla("TO");

        public static UF MA => PelaSigla("MA");

        public static UF PI => PelaSigla("PI");

        public static UF CE => PelaSigla("CE");

        public static UF RN => PelaSigla("RN");

        public static UF PB => PelaSigla("PB");

        public static UF PE => PelaSigla("PE");

        public static UF AL => PelaSigla("AL");

        public static UF SE => PelaSigla("SE");

        public static UF BA => PelaSigla("BA");

        public static UF MG => PelaSigla("MG");

        public static UF ES => PelaSigla("ES");

        public static UF RJ => PelaSigla("RJ");

        public static UF SP => PelaSigla("SP");

        public static UF PR => PelaSigla("PR");

        public static UF SC => PelaSigla("SC");

        public static UF RS => PelaSigla("RS");

        public static UF MS => PelaSigla("MS");

        public static UF MT => PelaSigla("MT");

        public static UF GO => PelaSigla("GO");

        public static UF DF => PelaSigla("DF");

        #endregion
        
        public int Codigo { get; }
        public string Sigla { get; }
        public string NomeEstado { get; }

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
        /// Retorna todas as UF's;
        /// </summary>
        /// <returns>Um <see cref="IEnumerable{UF}"/> contendo todas as UF's</returns>
        public static IEnumerable<UF> Todas => Ufs;
        
        /// <summary>
        /// Encontra uma UF a partir do código do estado.
        /// </summary>
        /// <param name="codigo">O código do estado que se deseja obter.</param>
        /// <returns>A UF do estado pertencente ao código.</returns>
        /// <exception cref="UFInexistenteException">Se não existe UF com este código de estado.</exception>
        public static UF PeloCodigo(int codigo)
        {
            try
            {
                return Ufs.First(uf => uf.Codigo == codigo);
            }
            catch (Exception e)
            {
                throw new UFInexistenteException($"Não existe nenhum estado com este código: {codigo}", e);
            }
        }
    
        /// <summary>
        /// Encontra uma UF a partir do nome do estado.
        /// </summary>
        /// <param name="nome">O nome do estado que se deseja obter.</param>
        /// <returns>A UF do estado pertencente ao nome.</returns>
        /// <exception cref="UFInexistenteException">Se não existe UF com este nome.</exception>
        public static UF PeloNomeDoEstado(string nome)
        {
            try
            {
                return Ufs.First(uf => uf.NomeEstado == nome);
            }
            catch (Exception e)
            {
                throw new UFInexistenteException($"Não existe nenhum estado com este nome: {nome}", e);
            }
        }

        /// <summary>
        /// Encontra uma UF a partir da sigla do estado.
        /// </summary>
        /// <param name="sigla">A sigla do estado que se deseja obter.</param>
        /// <returns>A UF do estado pertencente a sigla</returns>
        /// <exception cref="UFInexistenteException">Se não existe UF com esta sigla.</exception>
        public static UF PelaSigla(string sigla)
        {
            try
            {
                return Ufs.First(uf => uf.Sigla == sigla);
            }
            catch (Exception e)
            {
                throw new UFInexistenteException($"Não existe nenhum estado com esta sigla: {sigla}", e);
            }
        }

        /// <summary>
        /// Retorna uma coleção de UF's que atendam a uma determinada condição.
        /// </summary>
        /// <param name="predicado">Um <see cref="Func{UF, Boolean}"/> que determina a condição.</param>
        /// <returns>Um <see cref="IEnumerable{UF}"/> contendo todas as UF's que satisfaçam a condição do predicado.</returns>
        public static IEnumerable<UF> Onde(Func<UF, bool> predicado)
            => predicado != null 
                ? from uf in Ufs where predicado(uf) select uf 
                : throw new ArgumentNullException(nameof(predicado));

        /// <summary>
        /// Aplica uma função de mapeamento para cada UF.
        /// </summary>
        /// <param name="map">Uma função função que recebe uma <see cref="UF"/> como argumento e 
        /// retorna um <see cref="TResult"/>.</param>
        /// <typeparam name="TResult">O Tipo de destino do mapeamento.</typeparam>
        /// <returns>Uma <see cref="IEnumerable{TResult}"/> que representa o resultado do mapeamento.</returns>
        public static IEnumerable<TResult> Map<TResult>(Func<UF, TResult> map)
            => map != null 
                ? from uf in Ufs select map(uf) 
                : throw new ArgumentNullException(nameof(map));
        
        /// <summary>
        /// Retorna todos os códigos das UF's.
        /// </summary>
        /// <returns>Um <see cref="IEnumerable{Int32}"/> contendo todos os códigos.</returns>
        public static IEnumerable<int> TodosOsCodigos() => Map(uf => uf.Codigo);
        
        /// <summary>
        /// Retorna todos as siglas das UF's.
        /// </summary>
        /// <returns>Um <see cref="IEnumerable{Int32}"/> contendo todos as siglas.</returns>
        public static IEnumerable<string> TodasAsSiglas() => Map(uf => uf.Sigla);
        
        /// <summary>
        /// Retorna todos os nomes das UF's.
        /// </summary>
        /// <returns>Um <see cref="IEnumerable{Int32}"/> contendo todos os nomes.</returns>
        public static IEnumerable<string> TodosOsNomes() => Map(uf => uf.NomeEstado);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            
            return ReferenceEquals(this, obj) || obj is UF && Equals((UF) obj);
        }

        /// <inheritdoc />
        public bool Equals(UF other) => !(other is null) && Codigo == other.Codigo;

        /// <inheritdoc />
        public override int GetHashCode() => Codigo;
        
    }
}