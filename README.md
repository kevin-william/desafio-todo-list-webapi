# To-Do List 

Web app de uma lista de tarefas.

## Começando



### Pré-requisito


Para que este Web app funcione é necessário que o usuário tenha instalado em sua máquina
os seguintes recursos: 

**Microsoft® SQL Server® 2017 Express**
**Microsoft® Visual Studio® 2017**
**Node v8.0 ou mais recente**
**@angular/cli**


### Instalando

Neste repositório, dentro da pasta web-api, existe o arquivo Tarefas.sql. Ele é o script para criar o database necessário. 

Após executar o script, abra a solução web-api no Visual studio e recompile o projeto para garantir que o mesmo
faça download de suas dependências.Defina o projeto ToDoList.Web como projeto de inicialização e execute a solução.

É necessário definir a string para conexão no banco de dados. É possível encontrar o arquivo de configuração appsettings.json no 
diretório web-api\ToDoList.Web\ 

Para executar o front-end é necessário ter instalado o @angular/cli. Abra a pasta front-end no console e execute o comando npm install para que as dependências sejam baixadas. feito isso, basta executar o projeto com o comando ng serve --open

--open é opcional, mas faz com que seja aberta uma janela no navegador com a index do projeto. 


## Navegando pelo projeto

###index

Ao iniciar o projeto, o usuário será direcionado para a tela principal. Nela é exibida a lista
de todas as suas tarefas. 
Na barra lateral existe um link para criação de uma nova tarefa, assim como no topo da lista. 
Ainda nessa tela é possível alterar ou remover uma tarefa clicando nos respectivos botões de 
cada tarefa listada.
Ao clicar em exibir detalhes da lista, o usuário será direcionado para a tela de detalhe da tarefa.

###Cadastro de Nova Tarefa

Para cadastrar uma nova tarefa, é necessário preencher os campos TÍTULO e DESCRIÇÃO presentes 
no formulário.

###Detalhe de tarefa

Na tela de detalhes de determinada tarefa é possível visualizar as sub-tarefas pertencentes a 
tal tarefa, se a mesma assim possuir. 
É possível adicionar uma nova sub-tarefa ao clicar no botão para adicionar nova sub-tarefa.
Além disso, é possível alterar, remover e marcar uma sub-tarefa como finalizada. 

###Cadastro de Nova Sub-tarefa

Para cadastrar uma nova sub-tarefa, vá tela de detalhes de tarefa e selecione a opção ADICIONAR SUB-TAREFA  é necessário preencher os campos TÍTULO e DESCRIÇÃO presentes 
no formulário. 


## Desenvolvido com as seguintes tecnologias

* [asp.NET CORE](https://docs.microsoft.com/en-us/aspnet/core/index?view=aspnetcore-2.1) - Web Framework usado.
* [Nuget](https://docs.microsoft.com/en-us/nuget/) - Gerenciador de dependências .NET.
* [NPM](https://docs.npmjs.com/) - Gerenciador de dependências JavScript.
* [Entity framework Core](https://docs.microsoft.com/pt-br/ef/core/) - Framework da camada de persistência.


## Versão
V 1.0.0

## Autor

* **Kevin William Rodrigues** - [github](https://github.com/kevin-william)


## Licensa

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

