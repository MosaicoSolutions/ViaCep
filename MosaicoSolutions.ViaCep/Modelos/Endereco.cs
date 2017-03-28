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
        {
            const string separador = " : ";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameof(Cep)).Append(separador).Append(Cep).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Logradouro)).Append(separador).Append(Logradouro).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Complemento)).Append(separador).Append(Complemento).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Localidade)).Append(separador).Append(Localidade).Append(Environment.NewLine);
            stringBuilder.Append(nameof(UF)).Append(separador).Append(UF).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Unidade)).Append(separador).Append(Unidade).Append(Environment.NewLine);
            stringBuilder.Append(nameof(IBGE)).Append(separador).Append(IBGE).Append(Environment.NewLine);
            stringBuilder.Append(nameof(GIA)).Append(separador).Append(GIA).Append(Environment.NewLine);
            return stringBuilder.ToString();
        }
    }
}
