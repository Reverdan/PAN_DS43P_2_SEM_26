using CrudPessoasNoite.modelo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CrudPessoasNoite.DAL
{
    public class PessoaDAO
    {
        public void cadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                Conexao.Conectar();

                string comandoSql = "INSERT INTO Pessoas (nome, rg, cpf) VALUES (@nome, @rg, @cpf)";

                SqlCommand comando = new SqlCommand(comandoSql, Conexao.con);

                comando.Parameters.AddWithValue("@nome", pessoa.nome);
                comando.Parameters.AddWithValue("@rg", pessoa.rg);
                comando.Parameters.AddWithValue("@cpf", pessoa.cpf);

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Conexao.mensagem = "Erro de banco de dados ao cadastrar pessoa: " + ex.Message;
            }
            catch (Exception ex)
            {
                Conexao.mensagem = "Erro inesperado ao cadastrar pessoa: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public Pessoa pesquisarPessoaPorId(Pessoa pessoa)
        {
            try
            {
                Conexao.Conectar();

                string comandoSql = "SELECT id, nome, rg, cpf FROM Pessoas WHERE id = @id";
                SqlCommand comando = new SqlCommand(comandoSql, Conexao.con);
                comando.Parameters.AddWithValue("@id", pessoa.id);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    pessoa.id = Convert.ToInt32(reader["id"]);
                    pessoa.nome = reader["nome"].ToString();
                    pessoa.rg = reader["rg"].ToString();
                    pessoa.cpf = reader["cpf"].ToString();
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Conexao.mensagem = "Erro de banco de dados ao pesquisar pessoa: " + ex.Message;
            }
            catch (Exception ex)
            {
                Conexao.mensagem = "Erro inesperado ao pesquisar pessoa: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }

            return pessoa;
        }

        public void editarPessoa(Pessoa pessoa)
        {
            try
            {
                Conexao.Conectar();

                string comandoSql = "UPDATE Pessoas SET nome = @nome, rg = @rg, cpf = @cpf WHERE id = @id";

                SqlCommand comando = new SqlCommand(comandoSql, Conexao.con);

                comando.Parameters.AddWithValue("@id", pessoa.id);
                comando.Parameters.AddWithValue("@nome", pessoa.nome);
                comando.Parameters.AddWithValue("@rg", pessoa.rg);
                comando.Parameters.AddWithValue("@cpf", pessoa.cpf);

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Conexao.mensagem = "Erro de banco de dados ao editar pessoa: " + ex.Message;
            }
            catch (Exception ex)
            {
                Conexao.mensagem = "Erro inesperado ao editar pessoa: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public void excluirPessoa(Pessoa pessoa)
        {
            try
            {
                Conexao.Conectar();

                string comandoSql = "DELETE FROM Pessoas WHERE id = @id";

                SqlCommand comando = new SqlCommand(comandoSql, Conexao.con);

                comando.Parameters.AddWithValue("@id", pessoa.id);

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Conexao.mensagem = "Erro de banco de dados ao excluir pessoa: " + ex.Message;
            }
            catch (Exception ex)
            {
                Conexao.mensagem = "Erro inesperado ao excluir pessoa: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public List<Pessoa> pesquisarPessoaPorNome(Pessoa pessoa)
        {
            List<Pessoa> listaPessoas = new List<Pessoa>();
            try
            {
                Conexao.Conectar();

                string comandoSql = "SELECT id, nome, rg, cpf FROM Pessoas WHERE nome LIKE @nome";
                SqlCommand comando = new SqlCommand(comandoSql, Conexao.con);
                comando.Parameters.AddWithValue("@nome", "%" + pessoa.nome + "%");

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Pessoa pessoaRetorno = new Pessoa();
                    pessoaRetorno.id = Convert.ToInt32(reader["id"]);
                    pessoaRetorno.nome = reader["nome"].ToString();
                    pessoaRetorno.rg = reader["rg"].ToString();
                    pessoaRetorno.cpf = reader["cpf"].ToString();

                    listaPessoas.Add(pessoaRetorno);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Conexao.mensagem = "Erro de banco de dados ao pesquisar pessoa por nome: " + ex.Message;
            }
            catch (Exception ex)
            {
                Conexao.mensagem = "Erro inesperado ao pesquisar pessoa por nome: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }

            return listaPessoas;
        }
    }
}
