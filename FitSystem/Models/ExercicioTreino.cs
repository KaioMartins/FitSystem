using FitSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class ExercicioTreino
    {
        public int ExercicioTreinoId { get; set; }
        public int Repeticao { get; set; }
        public int Serie { get; set; }

        public int DiaId { get; set; }
        [ForeignKey("DiaId")]
        public virtual Dia Dia { get; set; }

        public int ExercicioId { get; set; }
        [ForeignKey("ExercicioId")]
        public virtual Exercicio Exercicio { get; set; }
    }
}