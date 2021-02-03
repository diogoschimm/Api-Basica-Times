# Api básica de Times e Jogos
Projeto de exemplo para cadastrar jogos e times. Esse projeto é usado para treinamento.

## Setup

Abra seu SQL Server e execute o script de criação do banco de dados.

```tsql
create database DbTimes; 
go
use DbTimes; 

create table Time (
	idTime int primary key identity(1,1) not null,
	nomeTime varchar(100) not null
);
create table Jogo (
	idJogo int primary key identity(1,1) not null,
	idTimeMandante int not null,
	qtdGolsTimeMandante int not null,
	idTimeVisitante int not null,
	qtdGolsTimeVisitante int not null,
	foreign key (idTimeMandante) references Time (idTime),
	foreign key (idTimeVisitante) references Time (idTime),
);

 insert into Time (nomeTime) values ('Boa Esporte');
 insert into Time (nomeTime) values ('Brusque');
 insert into Time (nomeTime) values ('Criciúma');
 insert into Time (nomeTime) values ('Ituano');
 insert into Time (nomeTime) values ('Londrina');
 insert into Time (nomeTime) values ('São Bento');
 insert into Time (nomeTime) values ('São José-RS');
 insert into Time (nomeTime) values ('Tombense'); 
 insert into Time (nomeTime) values ('Volta Redonda');
 insert into Time (nomeTime) values ('Ypiranga-RS');
```

Altere a String de Conexão dentro do arquivo StringConexao.cs coloque o nome do seu computador e o nome da instância do seu SQL Server.  
A String de conexão usa o modelo de autenticação integrado do Windows, se o seu SQL Server utilizar apenas Login e Senha do Banco você deve alterar a String de Conexão, trocando a opção "Integrated Security=SSPI" para "User Id=SeuUser;Password=SuaPassword;", onde o SeuUser e SuaPassword devem ser o usuário e senha respectivamente.

```c#
namespace ApiCrud
{
    public static class StringConexao
    {
        public static string DefaultConnection => 
              "Data Source=EST-BT13\\SQL2017;Initial Catalog=DbTimes;Integrated Security=SSPI;";
    }
}
```

## EndPoints
  
A API possui dois Endpoints principais que aceitam os métodos HTTP GET, PUT, POST e DELETE sendo eles respectivamente
  
/api/time  
  
/api/jogo  
  

## Testando a API

Utilize o Postman ou o Insominia para testar os métodos de GET, POST, PUT e DELETE dos Controllers de Jogo e Time.

Postman  
https://www.postman.com/  

Insomnia  
https://insomnia.rest/  





