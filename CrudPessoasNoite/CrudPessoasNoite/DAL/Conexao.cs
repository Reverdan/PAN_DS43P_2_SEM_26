using Microsoft.Data.SqlClient;
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
    public class Conexao
    {
		public static SqlConnection con = new SqlConnection();
		public static string mensagem;
		public static string stringConexao =
            @"Data Source=DESKTOP-0BMMDJG\SQLEXPRESS;
			Initial Catalog=ds34p;User ID=sa;
			Password=unip;Encrypt=False";
		public static SqlConnection Conectar()
		{
			mensagem = "";
			try
			{
				if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.ConnectionString = stringConexao;
                    con.Open();
                }
            }
			catch (SqlException e)
			{
				mensagem = e.Message;
			}
			return con;
		}

		public static void Desconectar()
		{
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (SqlException e)
            {
                mensagem = e.Message;
            }
        }
    }
}
