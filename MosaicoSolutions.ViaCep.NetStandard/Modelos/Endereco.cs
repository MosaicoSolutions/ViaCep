using System;
using System.Text;

namespace MosaicoSolutions.ViaCep.Modelos
{
    [Serializable]
    public struct Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Unidade { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }

        public override string ToString() 
            => new StringBuilder()
                  .Append(nameof(Cep)).Append(" : ").Append(Cep).Append(Environment.NewLine)
                  .Append(nameof(Logradouro)).Append(" : ").Append(Logradouro).Append(Environment.NewLine)
                  .Append(nameof(Complemento)).Append(" : ").Append(Complemento).Append(Environment.NewLine)
                  .Append(nameof(Localidade)).Append(" : ").Append(Localidade).Append(Environment.NewLine)
                  .Append(nameof(UF)).Append(" : ").Append(UF).Append(Environment.NewLine)
                  .Append(nameof(Unidade)).Append(" : ").Append(Unidade).Append(Environment.NewLine)
                  .Append(nameof(IBGE)).Append(" : ").Append(IBGE).Append(Environment.NewLine)
                  .Append(nameof(GIA)).Append(" : ").Append(GIA).Append(Environment.NewLine)
                  .ToString();
    }
}
