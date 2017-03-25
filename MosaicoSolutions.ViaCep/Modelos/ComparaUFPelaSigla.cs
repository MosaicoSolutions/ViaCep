using System.Collections.Generic;

namespace MosaicoSolutions.ViaCep.Modelos
{
    public class ComparaUFPelaSigla : IComparer<UF>
    {
        public int Compare(UF x, UF y)
        {
            if (ReferenceEquals(x, y))
                return 0;

            if (ReferenceEquals(null, y))
                return 1;

            return string.Compare(x?.Sigla, y.Sigla);
        }
    }
}