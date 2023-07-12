# TesteRelacionamentoAPI
Esse é um repositório de estudos de Web API do .NET Core 7.0 utilizando o EntityFramework e o ORM para a criação e alteração de duas tabelas no SQL Server + integração com uma API externa do ViaCep utilizando a biblioteca Refit. <br>
---
<p> - Neste projeto experimental de estudos, a estrutura fica definida em uma tabela de Colaboradores, Dependentes e InfoCep.</p>

<p>
 
> <strong>Colaboradores podem ter nenhum ou múltiplos Dependentes;</strong> <br>
> <strong>Dependentes não podem existir sem um Colaborador;</strong> <br>
> <strong>O CEP do colaborador deve ser informado no modelo 'XXXXX-XXX';</strong> <br>

</p>

# INSTRUÇÕES PARA PRIMEIRA EXECUÇÃO
<p>
No VS Code:<br>
 1. <strong>`dotnet restore .\APIRelacionamento.csproj`</strong> na pasta principal do projeto para restaurar as dependências utilizadas. <br>
 2. Utilizar o <strong>`dotnet tool update --global dotnet-ef`</strong> para rodar a migration num novo repositório. <br>
 3. <strong>`dotnet run`</strong> para executar o projeto <br> 
 4. Utilizar o <strong>`localhost:XXXX/swagger`</strong> para abrir visualização com o swagger. 
</p>

# Exemplos de Scheama Swagger
<h2>POST Colaborador</h2>
<p>
 
```
{
  "nome": "string",
  "salario": 0,
  "cepColaborador": "XXXXX-XXX"
}
```
</p>
<h2>POST Dependente</h2>
<p>

```
{
  "nome": "string",
  "sobrenome": "string",
  "idColaborador": 0
}
```
</p>
