﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class Exercicio
    {
        public int ExercicioId { get; set; }
        public string ExercicioDesc { get; set; }
        
        public int TipoExercicioId { get; set; }
        [ForeignKey("TipoExercicioId")]
        public virtual TipoExercicio TipoExercicio { get; set; }
    }
}