using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class Treino
    {
        public int TreinoId { get; set; }
        public virtual ICollection<ExercicioTreino> diaA { get; set; }
        public virtual ICollection<ExercicioTreino> diaB { get; set; }
        public virtual ICollection<ExercicioTreino> diaC { get; set; }
        public virtual ICollection<ExercicioTreino> diaD { get; set; }
        public virtual ICollection<ExercicioTreino> diaE { get; set; }
    }
}