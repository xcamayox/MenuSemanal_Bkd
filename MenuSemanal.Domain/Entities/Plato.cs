using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Domain.Entities
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public bool Usado { get; set; }
        public string FotoUrl { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }

    }
}
