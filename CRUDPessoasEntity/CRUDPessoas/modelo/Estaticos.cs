using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDPessoas.modelo
{
    public static class Estaticos
    {
        // Pessoa atualmente selecionada
        public static Pessoa pessoa { get; set; } = new Pessoa();

        // Lista pública de pessoas para uso pelo UI
        public static List<Pessoa> listaPessoas { get; set; } = new List<Pessoa>();
    }
}
