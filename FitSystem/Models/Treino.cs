using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class Treino
    {
        public int TreinoId { get; set; }

        public int ExercicioTreinoId{ get; set; }
        [ForeignKey("ExercicioTreinoId")]
        public virtual ExercicioTreino Dia { get; set; }

        
        
    }
}