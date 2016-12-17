using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public sealed class ViaCepRequisicaoPorEndereco : IViaCepRequisicao
    {
        public EnderecoRequisicao EnderecoRequisicao { get; }
        public ViaCepTipoResposta TipoDaResposta { get; }

        public ViaCepRequisicaoPorEndereco(EnderecoRequisicao enderecoRequisicao, ViaCepTipoResposta tipoDaResposta)
        {
            if (!enderecoRequisicao.EhValido())
                throw new ArgumentException("Requisicão por Endereço invalída. O nome da Cidade e do Logradouro deve ter ao menos 3 caracteres.");

            EnderecoRequisicao = enderecoRequisicao;
            TipoDaResposta = tipoDaResposta;
        }

        public string ObterUriDoRecurso()
            => $"{UriDoEnderecoRequisicao()}/{Util.ViaCepUtil.ObterTipoRespostaComoString(TipoDaResposta)}";

        private string UriDoEnderecoRequisicao()
            => $"{Enum.GetName(typeof(UF), EnderecoRequisicao.UF)}/{EnderecoRequisicao.Cidade}/{EnderecoRequisicao.Logradouro}";

        public static ViaCepRequisicaoPorEndereco CriarRequisicaoJson(EnderecoRequisicao enderecoRequisicao)
            => CriarRequisicao(enderecoRequisicao, ViaCepTipoResposta.Json);

        public static ViaCepRequisicaoPorEndereco CriarRequisicaoXml(EnderecoRequisicao enderecoRequisicao)
            => CriarRequisicao(enderecoRequisicao, ViaCepTipoResposta.Xml);

        private static ViaCepRequisicaoPorEndereco CriarRequisicao(EnderecoRequisicao enderecoRequisicao, ViaCepTipoResposta tipoDaResposta)
            => new ViaCepRequisicaoPorEndereco(enderecoRequisicao, tipoDaResposta);
    }
}