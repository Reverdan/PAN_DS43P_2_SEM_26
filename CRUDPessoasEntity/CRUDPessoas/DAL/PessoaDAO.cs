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
                AppDbContext contexto = new AppDbContext();
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
                AppDbContext contexto = new AppDbContext();
                pessoa = contexto.Pessoas.Find(pessoa.id);
                if (pessoa == null)
                    this.mensagem = "Não existe este ID";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro de BD";
            }
            return pessoa;
        }

        public void EditarPessoa(Pessoa pessoa)
        {
            this.mensagem = "";
            try
            {
                AppDbContext contexto = new AppDbContext();
                contexto.Entry(pessoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                contexto.SaveChanges();
                this.mensagem = "Pessoa editada";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro de BD";
            }
        }

        public void ExcluirPessoa(Pessoa pessoa)
        {
            this.mensagem = "";
            try
            {
                AppDbContext contexto = new AppDbContext();
                contexto.Remove(pessoa);
                contexto.SaveChanges();
                this.mensagem = "Pessoa excluida";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro de BD";
            }
        }

        public List<Pessoa> PesquisarPessoaPorNome(Pessoa pessoa)
        {
            this.mensagem = "";
            List<Pessoa> listaPessoas = new List<Pessoa>();
            try
            {
                AppDbContext contexto = new AppDbContext();
                listaPessoas = contexto.Pessoas
                    .Where(p => p.nome.Contains(pessoa.nome))
                    .OrderBy(p => p.nome)
                    .ToList();
            }
            catch (Exception ex)
            {
                this.mensagem = "Erro de BD";
            }
            return listaPessoas;
        }
    }
}
