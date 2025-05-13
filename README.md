
# UserManagement

O **UserManagement** é uma aplicação desenvolvida em .NET com o objetivo de gerenciar usuários de forma eficiente e escalável.
Utilizando uma arquitetura em camadas, o projeto promove a separação de responsabilidades, facilitando a manutenção, testes e evolução da aplicação.

## 🔧 Tecnologias Utilizadas

- .NET (C#)
- ASP.NET Core
- Entity Framework Core
- xUnit para testes unitários
- Arquitetura em camadas (API, Application, Domain, Infra)

## 📁 Estrutura do Projeto

- `UserManagement.API`: Contém os controladores e configurações da API RESTful.
- `UserManagement.Application`: Inclui os casos de uso e a lógica de aplicação.
- `UserManagement.Domain`: Define as entidades e interfaces do domínio.
- `UserManagement.Infra`: Implementa os repositórios e acesso a dados.
- `UserManagement.UnitTests`: Projetos de testes unitários para garantir a qualidade do código.

## 🚀 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/GabrielF13/UserManagement.git
   cd UserManagement
   ```

2. Restaure as dependências:
   ```bash
   dotnet restore
   ```

3. Execute a aplicação:
   ```bash
   dotnet run --project UserManagement.API
   ```

4. Acesse a API em `https://localhost:5001` ou `http://localhost:5000`.

## ✅ Executando os Testes

Para rodar os testes unitários:
```bash
dotnet test UserManagement.UnitTests
```

## 📌 Funcionalidades

- Cadastro de usuários
- Atualização de informações de usuários
- Listagem de usuários
- Remoção de usuários
- Validações de entrada
- Testes unitários para os principais casos de uso

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
