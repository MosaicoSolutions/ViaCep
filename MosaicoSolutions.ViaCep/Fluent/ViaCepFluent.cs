using System;
using MosaicoSolutions.ViaCep.Fluent.Interfaces;
using MosaicoSolutions.ViaCep.Modelos;

namespace MosaicoSolutions.ViaCep.Fluent
{
    public static class ViaCepFluent
    {
        public static IViaCepFluentPorCep De(Cep cep) 
            => cep.IsEmpty ? 
            throw new ArgumentException("O cep está vazio.", nameof(cep)) : new ViaCepFluentPorCep(cep);

        public static IViaCepFluentPorEndereco De(EnderecoRequisicao enderecoRequisicao) 
            => enderecoRequisicao.EhValido() ?
            new ViaCepFluentPorEndereco(enderecoRequisicao) : 
            throw new ArgumentException("O enderecoRequisicao não é válido.", nameof(enderecoRequisicao));
    }
}
