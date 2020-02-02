# Cashback

> ### Api Contruida com .Net Core 3.0
> Caso não possua instalado clique <a href="https://dotnet.microsoft.com/download/dotnet-core/3.0">aqui</a> para baixar. 

## Descrição

Projeto desenvolvido utilizando arquitetura DDD **(Domain-Driven-Design)** juntamente com **Unit Of Work** e **Data Tansfer Object (DTO)**

- Swagger utilizado para documentação das rotas.

## Rodar o projeto

- Executar o comando `update-database` que ele gerará o banco a partir das migrations já criadas no projeto.
- Após executar o comando basta rodar normalmente o projeto onde ele já inicializará com a rota apontando para o Swagger

## Representação dos dados no banco:
|Id|CreatedAt|UpdatedAt|Name|LastName|Email|CPF|Password|
|--|---------|---------|----|--------|-----|---|--------|
|80bb70dc-5b2c-4cd6-b691-581c684ac835|02/02/2020 14:33:43|02/02/2020 14:33:43|Boticario|Perfumes|cashback@boticario.com|15350946056|$2a$11$EHfH39q6QbqEnotiKJJylu4x3MZPA4tRzN/dF.g6FqqDLIPs83P46|

## Utilizar o Swagger

- Para autenticar na api vá no Endpoint Login -> Clique no botão "Try Out" no (lado direito) e utilize a seguinte request:

- `
{
  "email": "cashback@boticario.com",
  "password": "123456"
}
`
- Clique no botão Azul "Execute" para obter o token

> ## Injetando token nos Endpoints:

- Clique no botão Authorize no Lado direito da tela: 

<img src="https://imgur.com/Gvt2Alv.png" width="700" height="300"> 

- Insira o Token e clique em Authorize como na imagem abaixo:

<img  src="https://imgur.com/BBS7Ktp.png" width="600" height="300"> 

- Pronto! todos os endpoints passarão a usar o token de Autenticação.




