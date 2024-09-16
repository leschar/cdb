# Projeto CDB - Web API e Aplica��o Angular

Este reposit�rio cont�m uma solu��o que combina uma API desenvolvida com **C# Web API** no **.NET Framework 4.8.1** e uma aplica��o **Angular 17** para a interface do usu�rio. A solu��o tamb�m inclui testes de unidade utilizando **xUnit**.

## �ndice

- [Requisitos](#requisitos)
- [Clonando o Projeto](#clonando-o-projeto)
- [Instala��o](#instala��o)
- [Configura��o do IIS no Windows](#configura��o-do-iis-no-windows)
- [Executando a API e a Aplica��o Angular](#executando-a-api-e-a-aplica��o-angular)
- [Executando os Testes](#executando-os-testes)

## Requisitos

Para rodar este projeto, voc� precisar� ter os seguintes softwares instalados em sua m�quina:

- **.NET Framework 4.8.1**
- **Visual Studio 2022** com os pacotes de desenvolvimento .NET e ASP.NET instalados
- **Node.js** (vers�o 18 ou superior) com o **npm** (gerenciador de pacotes do Node)
- **Angular CLI** (vers�o 17)
- **IIS (Internet Information Services)** habilitado no Windows

## Clonando o Projeto

Para clonar este reposit�rio, siga os passos abaixo:

1. Abra o terminal de sua escolha.
2. Navegue at� o diret�rio onde deseja clonar o reposit�rio.
3. Execute o comando:

```bash
git clone https://github.com/seu-usuario/repositorio.git
```
4. Ap�s o clone, navegue at� o diret�rio do projeto:

```bash
cd ProjetoCdb/src
```
## Instala��o
1. Instalando as Depend�ncias do Projeto Angular
Navegue at� o diret�rio AngularWeb dentro do projeto e instale as depend�ncias:
```bash
cd Web/AngularWeb
npm install
```
2. Instalando as Depend�ncias do Projeto Web API
Abra o Visual Studio, navegue at� o diret�rio WebApi/ApiServer e abra a solu��o (.sln). O Visual Studio ir� restaurar as depend�ncias automaticamente ao carregar o projeto.

3. Instalando os Pacotes NuGet
Certifique-se de que todos os pacotes NuGet est�o atualizados. No Visual Studio, clique com o bot�o direito no projeto ApiServer, depois em Gerenciar Pacotes NuGet e clique em Restaurar
ou
Ao abrir o Visual Studio v� em Tools => Nuget Package Manager => Package Manager Console e ao abrir a janela digite.
```bash
dotnet restore
```

**Configura��o do IIS no Windows**
Para configurar o IIS (Internet Information Services) para rodar a API:

Abra o Painel de Controle e v� para Programas > Ativar ou desativar recursos do Windows.
Marque a caixa para Internet Information Services e certifique-se de que os componentes essenciais est�o habilitados (como o Servidor Web e o ASP.NET).
Verifique se o IIS esta funcionando abrindo o browser e digiando http://localhost, devera abrir a tela padrao do IIS.

**Executando a API e a Aplica��o Angular**
1. Executando a API
Para rodar a API com o IIS Express no Visual Studio:

No Visual Studio, selecione o projeto ApiServer.
Clique no bot�o Iniciar ou pressione F5 para rodar o projeto.
Se estiver usando o IIS, certifique-se de que o site est� rodando corretamente no Gerenciador do IIS.

2. Executando a Aplica��o Angular
No terminal, navegue at� o diret�rio AngularWeb e execute o seguinte comando:
```bash
ng s
```
O terminal ir� indicar a porta em que a aplica��o Angular estar� funcionando, copie e cole no browser.


1. Executando os Testes de Unidade
Para rodar os testes de unidade no Visual Studio v� em Teste Explore e selecione como deseja executar:

No Visual Studio, selecione o projeto ApiServer.

### Observa��o
Existem outras maneiras de executar a aplica��o, mas n�o abordarei neste teste.



