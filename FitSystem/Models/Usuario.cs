using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Treino> Treinos { get; set; }

    }
}