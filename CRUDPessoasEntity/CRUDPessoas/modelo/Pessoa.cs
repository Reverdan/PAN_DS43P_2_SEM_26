using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUDPessoas.modelo
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        [MinLength(3)]
        public string nome { get; set; }

        [MaxLength(11)]
        public string rg { get; set; }

        [MaxLength(13)]
        public string cpf { get; set; }
    }
}
