# NovoBanco
Criação de Projeto para validação de Teste Prático - Desenvolvedor (MegaWork)
Projeto Desenvolvido em Asp.Net Core 3.1
FrontEnd em Bootstrap.
Banco de dados SQL Server.
Construído em Arquitetura DDD com princípios SOLID.

#Rodar o Projeto
- Foi realizado a inclusão do Migration "init" na camada de arquitetura
- Criar um banco de dados "NovoBanco" em SQL Server
- Selecionar o projeto NovoBanco.Api como "Set as StartUp Project"
- no Package Manage Console, selecionar o projeto Infraestrutura/NovoBanco.Infraestrutura
- Atualizar o banco com o seguinte comando no PM Console
  - EntityFrameworkCore\update-database init
- Após atualização do banco, clicar com botão direito na solution -> properties: Multiple startup projects:
  - NovoBanco.Api
  - NovoBanco.Web
- Rodar o projeto.
