using System;
using System.Text;
using MosaicoSolutions.ViaCep.Util;

namespace MosaicoSolutions.ViaCep.Modelos
{
    [Serializable]
    public sealed class EnderecoCompleto
    {
        public Cep Cep { get; }
        public string Logradouro { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string Localidade { get; }
        public UF UF { get; }
        public string Estado { get; }
        public string Unidade { get; }
        public string IBGE { get; }
        public string GIA { get; }

        public EnderecoCompleto(Endereco endereco)
        {
            Cep = new Cep(endereco.CEP);
            Logradouro = endereco.Logradouro;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Localidade = endereco.Localidade;
            UF = ViaCepUtil.ObterUFPelaSiglaDoEstado(endereco.UF);
            Estado = ViaCepUtil.ObterNomeDoEstadoPelaUF(UF);
            Unidade = endereco.Unidade;
            IBGE = endereco.IBGE;
            GIA = endereco.GIA;
        }

        public override string ToString() => ToString(" : ");

        public string ToString(string separador)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameof(Cep)).Append(separador).Append(Cep.GetCep()).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Logradouro)).Append(separador).Append(Logradouro).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Complemento)).Append(separador).Append(Complemento).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Localidade)).Append(separador).Append(Localidade).Append(Environment.NewLine);
            stringBuilder.Append(nameof(UF)).Append(separador).Append(UF).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Estado)).Append(separador).Append(Estado).Append(Environment.NewLine);
            stringBuilder.Append(nameof(Unidade)).Append(separador).Append(Unidade).Append(Environment.NewLine);
            stringBuilder.Append(nameof(IBGE)).Append(separador).Append(IBGE).Append(Environment.NewLine);
            stringBuilder.Append(nameof(GIA)).Append(separador).Append(GIA).Append(Environment.NewLine);
            return stringBuilder.ToString();
        }
    }
}