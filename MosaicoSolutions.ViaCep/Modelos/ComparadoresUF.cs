using System;

namespace MosaicoSolutions.ViaCep.Modelos
{
    /// <summary>
    /// Define funções de comparação para UF's.
    /// </summary>
    public static class ComparadoresUF
    {
        /// <summary>
        /// Compara duas UF's pela Sigla.
        /// </summary>
        public static Comparison<UF> PelaSigla
            => (uf1, uf2) =>
            {
                if (ReferenceEquals(uf1, uf2))
                    return 0;

                if (ReferenceEquals(null, uf1))
                    return -1;

                if (ReferenceEquals(null, uf2))
                    return 1;

                return string.Compare(uf1.Sigla, uf2.Sigla);
            };

        /// <summary>
        /// Compara duas UF's pelo código.
        /// </summary>
        public static Comparison<UF> PeloCodigo
            => (uf1, uf2) =>
            {
                if (ReferenceEquals(uf1, uf2))
                    return 0;

                if (ReferenceEquals(null, uf1))
                    return -1;

                if (ReferenceEquals(null, uf2))
                    return 1;

                return uf1.Codigo.CompareTo(uf2.Codigo);
            };

        /// <summary>
        /// Compara duas UF's pelo nome do estado.
        /// </summary>
        public static Comparison<UF> PeloNomeDoEstado
            => (uf1, uf2) =>
            {
                if (ReferenceEquals(uf1, uf2))
                    return 0;

                if (ReferenceEquals(null, uf1))
                    return -1;

                if (ReferenceEquals(null, uf2))
                    return 1;

                return uf1.NomeEstado.CompareTo(uf2.NomeEstado);
            };
    }
}