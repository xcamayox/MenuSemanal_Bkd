using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.DTOs
{
    public class MenuSemanaDto
    {
        public int Id { get; set; }
        public int IdDia { get; set; }
        public int IdCategoria { get; set; }
        public int IdPlato { get; set; }
        public int IdUsuario { get; set; }
        
    }

    public class CreateMenuSemanaDto
    {
        public int IdDia { get; set; }
        public int IdCategoria { get; set; }
        public int IdPlato { get; set; }
        public int IdUsuario { get; set; }
    }

    public class UpdateMenuSemanaDto
    {
        public int IdDia { get; set; }
        public int IdCategoria { get; set; }
        public int IdPlato { get; set; }
        public int IdUsuario { get; set; }
    }
}
