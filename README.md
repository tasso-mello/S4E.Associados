# S4E-Associados - README

**Tecnologias Utilizadas:**
- .NET Core 6
- JavaScript
- jQuery
- HTML
- SQL Server

**Configuração e Execução:**

1. Modifique a propriedade `CanCreateDatabase` no arquivo de configuração `appsettings.Development.json` da API para `true` se desejar criar a base de dados automaticamente.

2. Certifique-se de ter uma instância do SQL Server em execução localmente, pois a base de dados será criada localmente.

3. Modifique a propriedade `CanCreateInitialSeed` no arquivo de configuração `appsettings.Development.json` da API para `true` se desejar executar um seed inicial.

4. Abra o projeto com `Visual Studio 2022` e eelecione a `api.S4E.Associados` como o projeto de inicialização.

5. Execute o projeto da API.

6. O `swagger` será aberto automaticamente. Caso não abra, acesse: https://localhost:7050/swagger/index.html

7. Abra o arquivo `index.html` dentro da pasta `website` no navegador para interagir com a aplicação.

**Funcionalidades:**
- Para adicionar um novo associado, clique no botão "Novo Associado".

- Para adicionar uma nova empresa, clique no botão "Nova Empresa".

- Para editar ou excluir um item, dê um duplo clique na linha da tabela.
