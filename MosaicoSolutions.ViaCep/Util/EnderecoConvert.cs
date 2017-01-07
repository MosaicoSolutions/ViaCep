using System.Collections.Generic;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Util
{
    public static class EnderecoConvert
    {
        public static Endereco DeJsonParaEndereco(string json)
            => Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(json);

        public static IEnumerable<Endereco> DeJsonParaListaDeEnderecos(string json)
            => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Endereco>>(json);
    }
}