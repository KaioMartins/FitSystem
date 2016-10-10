using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class BDContext : DbContext
    {
        public DbSet<Exercicio> Exercicio { get; set; }
        public DbSet<ExercicioTreino> ExercicioTreino { get; set; }
        public DbSet<Treino> Treino { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoExercicio> TipoExercicio { get; set; }
        public DbSet<Dia> Dia { get; set; }
    }
}