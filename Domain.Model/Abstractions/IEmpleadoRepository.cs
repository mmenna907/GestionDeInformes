using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;

namespace Domain.Model.Abstractions
{
    public interface IEmpleadoRepository: IGenericRepository<Empleado>
    {
        Empleado getEmpleado(int EmpleadoID);
        IEnumerable<Empleado> getEmpleados(string NombreEmpleado);
        IEnumerable<Empleado> getEmpleados();
    }
}
