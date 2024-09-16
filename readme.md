# Projeto CDB - Web API e Aplicação Angular

Este repositório contém uma solução que combina uma API desenvolvida com **C# Web API** no **.NET Framework 4.8.1** e uma aplicação **Angular 17** para a interface do usuário. A solução também inclui testes de unidade utilizando **xUnit**.

## Índice

- [Requisitos](#requisitos)
- [Clonando o Projeto](#clonando-o-projeto)
- [Instalação](#instalação)
- [Configuração do IIS no Windows](#configuração-do-iis-no-windows)
- [Executando a API e a Aplicação Angular](#executando-a-api-e-a-aplicação-angular)
- [Executando os Testes](#executando-os-testes)

## Requisitos

Para rodar este projeto, você precisará ter os seguintes softwares instalados em sua máquina:

- **.NET Framework 4.8.1**
- **Visual Studio 2022** com os pacotes de desenvolvimento .NET e ASP.NET instalados
- **Node.js** (versão 18 ou superior) com o **npm** (gerenciador de pacotes do Node)
- **Angular CLI** (versão 17)
- **IIS (Internet Information Services)** habilitado no Windows

## Clonando o Projeto

Para clonar este repositório, siga os passos abaixo:

1. Abra o terminal de sua escolha.
2. Navegue até o diretório onde deseja clonar o repositório.
3. Execute o comando:

```bash
git clone https://github.com/seu-usuario/repositorio.git
```
4. Após o clone, navegue até o diretório do projeto:

```bash
cd ProjetoCdb/src
```
## Instalação
1. Instalando as Dependências do Projeto Angular
Navegue até o diretório AngularWeb dentro do projeto e instale as dependências:
```bash
cd Web/AngularWeb
npm install
```
2. Instalando as Dependências do Projeto Web API
Abra o Visual Studio, navegue até o diretório WebApi/ApiServer e abra a solução (.sln). O Visual Studio irá restaurar as dependências automaticamente ao carregar o projeto.

3. Instalando os Pacotes NuGet
Certifique-se de que todos os pacotes NuGet estão atualizados. No Visual Studio, clique com o botão direito no projeto ApiServer, depois em Gerenciar Pacotes NuGet e clique em Restaurar
ou
Ao abrir o Visual Studio vá em Tools => Nuget Package Manager => Package Manager Console e ao abrir a janela digite.
```bash
dotnet restore
```

**Configuração do IIS no Windows**
Para configurar o IIS (Internet Information Services) para rodar a API:

Abra o Painel de Controle e vá para Programas > Ativar ou desativar recursos do Windows.
Marque a caixa para Internet Information Services e certifique-se de que os componentes essenciais estão habilitados (como o Servidor Web e o ASP.NET).
Verifique se o IIS esta funcionando abrindo o browser e digiando http://localhost, devera abrir a tela padrao do IIS.

**Executando a API e a Aplicação Angular**
1. Executando a API
Para rodar a API com o IIS Express no Visual Studio:

No Visual Studio, selecione o projeto ApiServer.
Clique no botão Iniciar ou pressione F5 para rodar o projeto.
Se estiver usando o IIS, certifique-se de que o site está rodando corretamente no Gerenciador do IIS.

2. Executando a Aplicação Angular
No terminal, navegue até o diretório AngularWeb e execute o seguinte comando:
```bash
ng s
```
O terminal irá indicar a porta em que a aplicação Angular estará funcionando, copie e cole no browser.


1. Executando os Testes de Unidade
Para rodar os testes de unidade no Visual Studio vá em Teste Explore e selecione como deseja executar:

No Visual Studio, selecione o projeto ApiServer.

### Observação
Existem outras maneiras de executar a aplicação, mas não abordarei neste teste.



