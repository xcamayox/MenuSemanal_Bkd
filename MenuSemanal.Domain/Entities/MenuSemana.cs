using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Domain.Entities
{
    public class MenuSemana
    {
        public int Id { get; set; }
        public int IdDia { get; set; }
        public int IdPlato { get; set; }
        public int IdCategoria { get; set; }
    }
}
