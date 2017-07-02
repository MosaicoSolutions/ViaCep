using System.Collections.Generic;

namespace MosaicoSolutions.ViaCep.Modelos
{
    public class ComparaUFPelaSigla : IComparer<UF>
    {
        public int Compare(UF x, UF y) 
            => ReferenceEquals(x, y) ? 
                0 : ReferenceEquals(null, y) ? 
                    1 : string.Compare(x?.Sigla, y.Sigla);
    }
}