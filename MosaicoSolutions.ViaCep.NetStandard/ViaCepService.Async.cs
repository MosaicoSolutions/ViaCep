using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MosaicoSolutions.ViaCep.Modelos;
using MosaicoSolutions.ViaCep.Net;

namespace MosaicoSolutions.ViaCep
{
    public partial class ViaCepService
    {
        /// <inheritdoc />
        public Task<Endereco> ObterEnderecoAsync(Cep cep)
            => cep.IsEmpty
                ? throw ThrowCepVazioErro(nameof(cep))
                : Task.Run(async () => _enderecoConvert.DeJsonParaEndereco(await ObterEnderecoComoJsonAsync(cep)));
        
        /// <inheritdoc />
        public Task<string> ObterEnderecoComoJsonAsync(Cep cep)
            => cep.IsEmpty
                ? throw ThrowCepVazioErro(nameof(cep))
                : Task.Run(async () => await ObterEnderecoPorCepComoStringAsync(cep, ViaCepFormatoRequisicao.Json));
        
        /// <inheritdoc />
        public Task<string> ObterEnderecoComoPipedAsync(Cep cep)
            => cep.IsEmpty
                ? throw ThrowCepVazioErro(nameof(cep))
                : Task.Run(async () => await ObterEnderecoPorCepComoStringAsync(cep, ViaCepFormatoRequisicao.Piped)); 
        
        /// <inheritdoc />
        public Task<string> ObterEnderecoComoQuertyAsync(Cep cep)
            => cep.IsEmpty
                ? throw ThrowCepVazioErro(nameof(cep))
                : Task.Run(async () => await ObterEnderecoPorCepComoStringAsync(cep, ViaCepFormatoRequisicao.Querty));
        
        /// <inheritdoc />
        public Task<XDocument> ObterEnderecoComoXmlAsync(Cep cep)
            => cep.IsEmpty
                ? throw ThrowCepVazioErro(nameof(cep))
                : Task.Run(async () =>
                {
                    IViaCepRequisicaoPor<Cep> requisicao = _requisicaoPorCepFactory.NovaRequisicaoXml(cep);
                    IViaCepResposta resposta = await _cliente.ObterRespostaAsync(requisicao.ToUri);

                    GaranteCodigoDeSucessoOuLancaException(resposta);

                    IViaCepConteudo conteudo = resposta.ObterConteudo();

                    GaranteConteudoDaRequisicaoPorCepSemErroOuLancaException(conteudo);
            
                    return conteudo.LerComoXml();
                });
        
        /// <inheritdoc />
        public Task<IEnumerable<Endereco>> ObterEnderecosAsync(EnderecoRequisicao enderecoRequisicao)
            => enderecoRequisicao.EhValido()
                ? Task.Run(async () =>
                    _enderecoConvert.DeJsonParaListaDeEnderecos(await ObterEnderecosComoJsonAsync(enderecoRequisicao)))
                : throw ThrowEnderecoRequisicaoInvalido(nameof(enderecoRequisicao));
        
        /// <inheritdoc />
        public Task<string> ObterEnderecosComoJsonAsync(EnderecoRequisicao enderecoRequisicao)
            => enderecoRequisicao.EhValido()
                ? Task.Run(async () => 
                {
                    IViaCepRequisicaoPor<EnderecoRequisicao> requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoJson(enderecoRequisicao);
                    IViaCepResposta resposta = await _cliente.ObterRespostaAsync(requisicao.ToUri);
                    
                    GaranteCodigoDeSucessoOuLancaException(resposta);
                    
                    return resposta.ObterConteudo()
                        .LerComoString();
                })
                : throw ThrowEnderecoRequisicaoInvalido(nameof(enderecoRequisicao));
        
        /// <inheritdoc />
        public Task<XDocument> ObterEnderecosComoXmlAsync(EnderecoRequisicao enderecoRequisicao)
            => enderecoRequisicao.EhValido()
                ? Task.Run(async () => 
                {
                    IViaCepRequisicaoPor<EnderecoRequisicao> requisicao = _requisicaoPorEnderecoFactory.NovaRequisicaoXml(enderecoRequisicao);
                    IViaCepResposta resposta = await _cliente.ObterRespostaAsync(requisicao.ToUri);
                    
                    GaranteCodigoDeSucessoOuLancaException(resposta);
                    
                    return resposta.ObterConteudo()
                        .LerComoXml();
                })
                : throw ThrowEnderecoRequisicaoInvalido(nameof(enderecoRequisicao));
       
    }
}