using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.DTOs
{
    public class PlatoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public bool Usado { get; set; }
    }

    public class CreatePlatoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public bool Usado { get; set; }
    }

    public class UpdatePlatoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public bool Usado { get; set; }
    }
}
