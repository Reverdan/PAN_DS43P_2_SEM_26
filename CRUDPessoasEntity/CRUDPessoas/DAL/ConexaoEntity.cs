using CRUDPessoas.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDPessoas.DAL
{
    public class ConexaoEntity : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0BMMDJG\SQLEXPRESS;
            Initial Catalog=ds34p;User ID=sa;
            Password=unip;Encrypt=False");
        }
    }
}
