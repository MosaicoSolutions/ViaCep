using System;
using System.Text.RegularExpressions;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Representa o Cep de um endereço.
    /// </summary>
    [Serializable]
    public struct Cep : IComparable, IComparable<Cep>, IEquatable<Cep>
    {   
        //Expressão regular para Cep sem formato. Pattern: "^\\d{8}$"
        private const string CepUnformatedPattern = "^\\d{8}$";

        //Expressão regular para Cep com formato. Pattern: "^\\d{5}-\\d{3}$"
        private const string CepFormatedPattern = "^\\d{5}-\\d{3}$";

        //Expressão regular para Cep com ou sem formato.
        private const string CepPattern =  CepFormatedPattern + "|" + CepUnformatedPattern;
        
        private readonly string _cep;
        
        /// <summary>
        /// Converte implicitamente um <see cref="Cep"/> em uma <see cref="string"/>.
        /// </summary>
        /// <param name="cep">Um objeto do tipo <see cref="Cep"/> a ser convertido.</param>
        /// <returns>Uma <see cref="string"/> contendo o Cep.</returns>
        public static implicit operator string(Cep cep) => cep._cep;
        
        /// <summary>
        /// Converte implicitamente uma <see cref="string"/> em um <see cref="Cep"/>.
        /// </summary>
        /// <param name="cep">Uma <see cref="string"/> a ser convertida.</param>
        /// <returns>Um <see cref="Cep"/> contendo o Cep.</returns>
        /// <exception cref="CepInvalidoException">Se o Cep estiver em um formato inválido.</exception>
        public static implicit operator Cep(string cep) => Of(cep);

        /// <summary>
        /// Converte uma string em um objeto do tipo <code>Cep</code>.
        /// </summary>
        /// <param name="cep">Uma string a ser convertida.</param>
        /// <returns>Uma objeto da tipo Cep equivalente ao contido em <code>cep</code>.</returns>
        /// <exception cref="CepInvalidoException">Se o Cep estiver em um formato inválido.</exception>
        public static Cep Of(string cep) => EhCepValido(cep) ? new Cep(cep) : throw new CepInvalidoException();
        
        private Cep(string cep) => _cep = Regex.IsMatch(cep, CepFormatedPattern) ? FormataCepSomenteNumeros(cep) : cep;

        /// <summary>
        /// Avalia se o Cep é válido.
        /// </summary>
        /// <param name="cep">O cep.</param>
        /// <returns>true, se o cep está em um formato válido, caso contrário, false.</returns>
        public static bool EhCepValido(string cep) => Regex.IsMatch(cep, CepPattern);

        private static string FormataCepSomenteNumeros(string cep) => cep.Replace("-", "");

        /// <summary>
        /// Retorna o Cep no formato 00000-000.
        /// </summary>
        /// <returns>O Cep no formato 00000-000.</returns>
        public string Formatado() => $"{_cep.Substring(0, 5)}-{_cep.Substring(5, 3)}";

        /// <summary>
        /// Compara a instância atual com outro objeto do mesmo tipo e retorna um inteiro que indica se a instância atual precede,
        /// segue ou ocorre na mesma posição na ordem de classificação do outro objeto.
        /// </summary>
        /// <param name="obj">Um objeto para comparar com esta instância.</param>
        /// <returns>
        /// Um valor que indica a ordem relativa dos objetos que estão sendo comparados.
        /// O valor de retorno tem esses significados: Valor Significado Menos que zero Essa instância precede obj na ordem de classificação.
        /// Zero Esta instância ocorre na mesma posição na ordem de classificação como obj.
        /// Maior que zero Esta instância segue obj na ordem de classificação.</returns>
        /// <exception cref="ArgumentException">obj não é do mesmo tipo que esta instância.</exception>
        public int CompareTo(object obj) 
            => obj == null ? 
                1 : (obj is Cep) ? 
                   CompareTo((Cep) obj) : throw new ArgumentException("Argumento deve ser do tipo Cep.");

        /// <summary>
        /// Compara o objeto atual com outro objeto do mesmo tipo.
        /// </summary>
        /// <param name="other">Um objeto para comparar com este objeto.</param>
        /// <returns>Um valor que indica a ordem relativa dos objetos que estão sendo comparados.
        /// O valor de retorno tem os seguintes significados: Valor Significado Menos que zero Este objeto é menor que o outro parâmetro.
        /// Zero Este objeto é igual a outro. Maior que zero Este objeto é maior que outro.
        /// </returns>
        public int CompareTo(Cep other) => string.Compare(_cep, other._cep);

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com o objeto atual.</param>
        /// <returns>true se o objeto especificado for igual ao objeto atual; Caso contrário, false.</returns>
        public override bool Equals(object obj) => obj is Cep && Equals((Cep)obj);

        /// <summary>
        /// Determina se o objeto atual é igual a outro objeto do mesmo tipo.
        /// </summary>
        /// <param name="other">Um objeto para comparar com este objeto.</param>
        /// <returns>true se o objeto atual for igual ao outro parâmetro; Caso contrário, false.</returns>
        public bool Equals(Cep other) => _cep == other._cep;

        /// <summary>
        /// Retorna o código hash para esta instância.
        /// </summary>
        /// <returns>Um código de hash</returns>
        public override int GetHashCode()
        {
            var hashcode = 0;
            unchecked
            {
                hashcode += 1000000007 * _cep.GetHashCode();
            }
            return hashcode;
        }
        
        /// <summary>
        /// Retorna a expressão regular para validar o Cep.
        /// </summary>
        public static Regex Pattern => new Regex(CepPattern);
        
        /// <summary>
        /// Retorna o valor do cep deste objeto.
        /// </summary>
        /// <returns>Uma string que representa o cep.</returns>
        public override string ToString() => _cep;

        /// <summary>
        /// Avalia para True, se o objeto está vazio (o cep não foi informado), caso contrário, False.
        /// </summary>
        public bool IsEmpty => _cep == null;
    }
}
