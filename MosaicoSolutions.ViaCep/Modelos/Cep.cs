using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Representa o CEP de um endereço.
    /// </summary>
    [Serializable]
    public struct Cep : IComparable, IComparable<Cep>, IEquatable<Cep>
    {
        private readonly string _cep;

        /// <summary>
        /// Expressão regular para CEP sem formato. Pattern: "^\\d{8}$"
        /// </summary>
        public const string CepUnformatedPattern = "^\\d{8}$";

        /// <summary>
        /// Expressão regular para CEP com formato. Pattern: "^\\d{5}-\\d{3}$"
        /// </summary>
        public const string CepFormatedPattern = "^\\d{5}-\\d{3}$";

        /// <summary>
        /// Expressão regular para CEP com ou sem formato.
        /// </summary>
        public const string CepPattern =  CepFormatedPattern + "|" + CepUnformatedPattern;

        /// <summary>
        /// Inicializa uma nova instância da class <code>Cep</code> com o valor do cep especificado.
        /// </summary>
        /// <param name="cep">O cep.</param>
        /// <exception cref="CepInvalidoException">Se o CEP estiver em um formato inválido.</exception>
        private Cep(string cep)
        {
            _cep = Regex.IsMatch(cep, CepFormatedPattern) ? FormataCepSomenteNumeros(cep) : cep;
        }

        public static implicit operator string(Cep cep)
            => cep._cep;

        public static implicit operator Cep(string cep)
            => Parse(cep);

        /// <summary>
        /// Converte uma string em um objeto do tipo <code>Cep</code>.
        /// </summary>
        /// <param name="cep">Uma string a ser convertida.</param>
        /// <returns>Uma objeto da tipo Cep equivalente ao contido em <code>cep</code>.</returns>
        /// <exception cref="CepInvalidoException">Se o CEP estiver em um formato inválido.</exception>
        public static Cep Parse(string cep)
        {
            if (!EhCepValido(cep))
                throw new CepInvalidoException();

            return new Cep(cep);
        }

        /// <summary>
        /// Testa se o CEP é válido.
        /// </summary>
        /// <param name="cep">O cep.</param>
        /// <returns>true, se o cep está em um formato válido, caso contrário, false.</returns>
        public static bool EhCepValido(string cep) => Regex.IsMatch(cep, CepPattern);

        /// <summary>
        /// Retira a máscara do Cep.
        /// </summary>
        /// <param name="cep">O cep.</param>
        /// <returns>O cep somente com digitos.</returns>
        private static string FormataCepSomenteNumeros(string cep) => cep.Replace("-", "");

        /// <summary>
        /// Retorna o CEP no formato 00000-000.
        /// </summary>
        /// <returns>O CEP no formato 00000-000.</returns>
        public string GetCepFormatado() => FormataCep();

        /// <summary>
        /// Retorna o CEP no formato 00000-000.
        /// </summary>
        /// <returns>O CEP formatado.</returns>
        private string FormataCep()
        {
            var formatBuilder = new StringBuilder();
            formatBuilder.Append(_cep.Substring(0, 5));
            formatBuilder.Append("-");
            formatBuilder.Append(_cep.Substring(5, 3));
            return formatBuilder.ToString();
        }

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
        {
            if (obj == null)
                return 1;

            if (!(obj is Cep))
                throw new ArgumentException("Argumento deve ser do tipo Cep.");

            return CompareTo((Cep)obj);
        }

        /// <summary>
        /// Compara o objeto atual com outro objeto do mesmo tipo.
        /// </summary>
        /// <param name="other">Um objeto para comparar com este objeto.</param>
        /// <returns>Um valor que indica a ordem relativa dos objetos que estão sendo comparados.
        /// O valor de retorno tem os seguintes significados: Valor Significado Menos que zero Este objeto é menor que o outro parâmetro.
        /// Zero Este objeto é igual a outro. Maior que zero Este objeto é maior que outro.
        /// </returns>
        public int CompareTo(Cep other)
            => string.Compare(_cep, other._cep, StringComparison.Ordinal);

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com o objeto atual.</param>
        /// <returns>true se o objeto especificado for igual ao objeto atual; Caso contrário, false.</returns>
        public override bool Equals(object obj)
            => obj is Cep && Equals((Cep)obj);

        /// <summary>
        /// Indica se o objeto atual é igual a outro objeto do mesmo tipo.
        /// </summary>
        /// <param name="other">true se o objeto atual for igual ao outro parâmetro; Caso contrário, false.</param>
        /// <returns>Um objeto para comparar com este objeto.</returns>
        public bool Equals(Cep other)
            => _cep == other._cep;

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
        /// Retorna o valor do cep deste objeto.
        /// </summary>
        /// <returns>Uma string que representa o cep.</returns>
        public override string ToString()
            => _cep;

        /// <summary>
        /// Avalia para True, se o objeto está vazio (o cep não foi informado), caso contrário, False.
        /// </summary>
        public bool IsEmpty
            => _cep == null;
    }
}
