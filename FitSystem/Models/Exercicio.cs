using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class Exercicio
    {
        public int ExercicioId { get; set; }
        public string TipoExercicio { get; set; }
        public string ExercicioDesc { get; set; }
    }
}