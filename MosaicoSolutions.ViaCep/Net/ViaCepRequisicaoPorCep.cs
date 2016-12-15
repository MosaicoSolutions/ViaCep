using System;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Net
{
    public abstract class ViaCepRequisicaoPorCep : IViaCepRequisicao
    {
        protected ViaCepRequisicaoPorCep(Cep cep)
        {
            if(cep == null)
                throw new NullReferenceException("cep não pode ser nulo.");

            Cep = cep;
        }

        public string ObterUriDoRecurso()
            => $"{Cep.GetCep()}/{Resposta.TipoDaResposta}";

        public Cep Cep { get; }
        protected abstract IViaCepResposta Resposta { get; }
    }
}