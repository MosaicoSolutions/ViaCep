using System;
using System.Runtime.Remoting.Messaging;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public abstract class ViaCepRequisicaoPorEndereco : IViaCepRequisicao
    {
        protected ViaCepRequisicaoPorEndereco(EnderecoRequisicao enderecoRequisicao)
        {
            if (!enderecoRequisicao.EhValido())
                throw new ArgumentException("Requisicão por Endereço invalída. O nome da Cidade e do Logradouro deve ter ao menos 3 caracteres.");

            EnderecoRequisicao = enderecoRequisicao;
        }

        public string ObterUriDoRecurso()
            => $"{UriDoEnderecoRequisicao()}/{Resposta.TipoDaResposta}";

        private string UriDoEnderecoRequisicao()
            => $"{Enum.GetName(typeof(UF), EnderecoRequisicao.UF)}/{EnderecoRequisicao.Cidade}/{EnderecoRequisicao.Logradouro}";

        public EnderecoRequisicao EnderecoRequisicao { get; }
        protected abstract IViaCepResposta Resposta { get; }
    }
}