CREATE DATABASE ToDoList;

use ToDoList
go 

Create table Tarefas(
	
	IdTarefa int Identity(1,1) primary key,
	Descricao varchar(max) not null,
	Titulo varchar(50) not null,
	Finalizado bit not null	
)

Create table SubTarefas(	
	
	IdSubTarefa int Identity(1,1) primary key,
	IdTarefa int not null,
	Descricao varchar(max) not null,
	Titulo varchar(50) not null,
	Finalizado bit not null,
	CONSTRAINT fk_subTarefa_01
    FOREIGN KEY (IdTarefa)
    REFERENCES Tarefas(IdTarefa)
    ON DELETE CASCADE    
);	
