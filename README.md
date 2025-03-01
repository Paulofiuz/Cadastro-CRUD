# Cadastro API

Este é um projeto de uma API de cadastro de usuários utilizando ASP.NET Core, Entity Framework Core e SQL Server.

## Descrição

A API permite realizar operações CRUD (Criar, Ler, Atualizar, Excluir) de usuários em um banco de dados SQL Server. O projeto é baseado em uma arquitetura simples de repositório e depende da injeção de dependência para gerenciar os repositórios de dados.

## Tecnologias Utilizadas

- **ASP.NET Core 6+**
- **Entity Framework Core**
- **SQL Server**
- **C#**

## Funcionalidades

- Criar um novo usuário.
- Obter todos os usuários cadastrados.
- Obter um usuário por ID.
- Atualizar os dados de um usuário.
- Excluir um usuário.

## Estrutura do Projeto

O projeto é dividido nas seguintes camadas:

1. **Data**: Contém o contexto do banco de dados (`AppDbContext`).
2. **Repositories**: Contém a interface e a implementação do repositório de usuários (`IUsuarioRepository` e `UsuarioRepository`).
3. **Controllers**: Contém os controladores da API, que expõem as rotas para os endpoints.

## Como Rodar o Projeto

### Pré-requisitos

- .NET 6 ou superior
- SQL Server (local ou em nuvem)
- Visual Studio ou outro editor de código de sua preferência

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/cadastro-api.git
