using System;
using System.Collections.Generic;

namespace MosaicoSolutions.ViaCep.Modelos
{
    public class ComparaUFPeloNomeDoEstado : IComparer<UF>
    {
        public int Compare(UF x, UF y) 
            => ReferenceEquals(x, y) ? 
                0 : ReferenceEquals(null, y) ? 
                    1 : string.Compare(x?.NomeEstado, y.NomeEstado);
    }
}