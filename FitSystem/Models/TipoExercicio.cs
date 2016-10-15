using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitSystem.Models
{
    public class TipoExercicio
    {
        
        public int TipoExercicioId { get; set; }
        public string TipoExercicioDesc { get; set; }
        
    }
}