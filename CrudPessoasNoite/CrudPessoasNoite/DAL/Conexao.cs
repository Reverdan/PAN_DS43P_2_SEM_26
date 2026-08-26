using System;
using System.Collections.Generic;
using System.Text;

/*
create database ds34p
go
use ds34p
go
create table Pessoas
(
	id int primary key identity(1,1),
	nome varchar(50) not null,
	rg varchar(11),
	cpf varchar(13)
)

Data Source=DESKTOP-0BMMDJG\SQLEXPRESS;Initial Catalog=ds34p;User ID=sa;Password=***********;Encrypt=False
*/

namespace CrudPessoasNoite.DAL
{
    internal class Conexao
    {
    }
}
