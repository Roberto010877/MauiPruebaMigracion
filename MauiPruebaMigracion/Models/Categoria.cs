using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPruebaMigracion.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
