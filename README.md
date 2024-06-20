# SistemaClientesApp

Este é o SistemaClientesApp, um projeto ASP.NET API desenvolvido com EntityFramework Code First. O projeto está estruturado em camadas de Apresentação, Domínio e Infraestrutura.

## Descrição

O SistemaClientesApp é uma aplicação de exemplo que demonstra o desenvolvimento de uma API ASP.NET usando o EntityFramework Code First. Ele permite o gerenciamento básico de clientes em um banco de dados.

## Estrutura do Projeto

O projeto está organizado em três camadas principais:

- **Apresentação**: Esta camada contém os controladores da API e é responsável por lidar com as requisições HTTP e fornecer as respostas.
- **Domínio**: Esta camada contém as entidades de domínio e as interfaces dos repositórios.
- **Infraestrutura**: Esta camada contém a implementação concreta dos repositórios, contexto do banco de dados e quaisquer outras classes relacionadas à infraestrutura de dados.

## Requisitos

- Visual Studio 2022 (ou versão posterior)
- .NET SDK 6.0 (ou versão posterior)
- SQL Server (ou outro banco de dados compatível com o EntityFramework)

## Configuração do Banco de Dados

Para executar o projeto, siga estas etapas:

1. Altere a string de conexão na classe `DataContext` localizada na camada de Infraestrutura para apontar para o seu banco de dados.
2. Abra o Console do Gerenciador de Pacotes no Visual Studio e execute o comando `update-database` para aplicar as migrações e criar o banco de dados.

## Carga Inicial de Dados

O projeto inclui um arquivo `script.sql` que pode ser utilizado para fazer uma carga inicial de dados no banco de dados. Execute este script no seu banco de dados para inserir os dados de exemplo.

## Como Usar

1. Clone este repositório em sua máquina local.
2. Abra o projeto no Visual Studio 2022.
3. Configure o banco de dados conforme descrito acima.
4. Execute o projeto pressionando F5 ou através do menu de depuração.
5. Acesse a API por meio das URLs fornecidas e utilize um cliente HTTP para fazer requisições.

## Contribuindo

Contribuições são bem-vindas! Se você quiser contribuir para este projeto, por favor, abra uma issue para discutir as mudanças que você gostaria de fazer.

## Autores

Este projeto foi desenvolvido por [Seu Nome] e é mantido por [Nome do Mantenedor].