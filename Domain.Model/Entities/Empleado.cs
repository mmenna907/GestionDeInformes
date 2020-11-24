using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Empleado
    {
        public int Empleadoid { get; set; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }

        public override string ToString()
        {
            return Legajo + " " + Nombre;
        }
    }
}
