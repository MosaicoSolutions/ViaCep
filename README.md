# ViaCep
Um módulo para a consulta de endereços usando o Web Service da ViaCep.

## Características

* Fácil manipulação.
* Retorna todos os formatos (Json, Xml, Piped, Querty).
* Uso da Interface Fluent.
* Uso de Callback Methods.

## Como Utilizar

Existem duas formas de consultar endereços.

* Consultando por Cep.

Crie uma instância da classe `Cep` ou use uma `string` se preferir.

``` c#
var cep = new Cep("01001000");

var endereco = ViaCep.ObterEndereco(cep); // ViaCep.ObterEndereco("01001000");

```
Nesse caso o endereço será retornado como uma instância da classe [Endereco](MosaicoSolutions.ViaCep/Modelos/Endereco.cs).
Se desejar retornar como outros formatos:

``` c#
var endereco = ViaCep.ObterEnderecoComoJson(cep); //ViaCep.ObterEnderecoComoJson("01001000");
```
Você ainda pode retornar com `Xml`, `Piped`, ou `Querty` utilizando os métodos `ObterEnderecoComoXml` , `ObterEnderecoComoPiped` e 
`ObterEnderecoComoQuerty`, respectivamente, ambos métodos da classe `ViaCep`.

* Consultando por Endereco

A consulta também pode ser realizada a partir de três parâmetros: Sigla do estado, Nome da Cidade, e Nome do Logradouro.

``` c#
var requisicao = new EnderecoRequisicao {
                    UF = UF.RS,
                    Cidade = "Porto Alegre",
                    Logradouro = "Olavo"
                }

var enderecos = ViaCep.ObterEnderecos(requisicao);
```
Neste exemplo será pesquisado na cidade de "Porto Algre/RS" por todos os logradouros que contenham "Olavo" em seu nome. 
Quando o nome da cidade ou do logradouro não contiver ao menos três caracteres o código de retorno será um 400 (Bad Request).

O resultado desta consulta é um `IEnumerable<Endereco>` contendo todos os resultados. 
