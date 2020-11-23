using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Informe
    {
        public int InformeID { get; set; }
        public DateTime Fecha { get; set; }
        public Empleado EmpleadoConfecciona { get; set; }
        public Empleado EmpleadoInformado { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
    }
}
