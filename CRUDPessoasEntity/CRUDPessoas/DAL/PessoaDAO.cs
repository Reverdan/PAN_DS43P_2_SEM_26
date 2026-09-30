using CRUDPessoas.modelo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDPessoas.DAL
{
    public class PessoaDAO
    {
        public String mensagem;

        public void CadastrarPessoa(Pessoa pessoa)
        {
            this.mensagem = "";
            try
            {
                ConexaoEntity contexto = new ConexaoEntity();
                contexto.Pessoas.Add(pessoa);
                contexto.SaveChanges();
                this.mensagem = "Pessoa cadastrada com sucesso.";
            }
            catch (Exception ex)
            {
                this.mensagem = "Erro ao cadastrar pessoa: " + ex.Message;
            }
            
        }

        public Pessoa PesquisarPessoaPorId(Pessoa pessoa)
        {
            this.mensagem = "";
            try
            {
                ConexaoEntity contexto = new ConexaoEntity();
                pessoa = contexto.Pessoas.Where(p => p.id == pessoa.id).FirstOrDefault();
                if (pessoa == null)
                    this.mensagem = "Não existe este ID";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro de conexão com BD";
            }
            return pessoa;
        }

        public void EditarPessoa(Pessoa pessoa)
        {
            try
            {
                ConexaoEntity contexto = new ConexaoEntity();
                contexto.Entry(pessoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                contexto.SaveChanges();
                this.mensagem = "Pessoa editada";
            }
            catch (Exception ex)
            {
                this.mensagem = "Erro ao editar pessoa: " + ex.Message;
            }
        }

        public void ExcluirPessoa(Pessoa pessoa)
        {
            try
            {
                ConexaoEntity contexto = new ConexaoEntity();
                contexto.Remove(pessoa);
                contexto.SaveChanges();
                this.mensagem = "Pessoa excluida"; 
            }
            catch (Exception ex)
            {
                this.mensagem = "Erro ao excluir pessoa: " + ex.Message;
            }
        }

        public List<Pessoa> PesquisarPessoaPorNome(Pessoa pessoa)
        {
            List<Pessoa> listaPessoas = new List<Pessoa>();
            try
            {
                using (var contexto = new ConexaoEntity())
                {
                    listaPessoas = contexto.Pessoas
                        .Where(p => p.nome.ToLower().Contains(pessoa.nome.ToLower()))
                        .ToList();

                    if (!listaPessoas.Any())
                        this.mensagem = "Nenhuma pessoa encontrada com esse nome.";
                    
                }
            }
            catch (Exception ex)
            {
                this.mensagem = "Erro ao pesquisar pessoa: " + ex.Message;
            }

            return listaPessoas;
        }
    }
}
