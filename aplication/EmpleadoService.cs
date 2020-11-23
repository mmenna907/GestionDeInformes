using Domain.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.DataAccess.Repositories;
using Domain.Model.Entities;
//using UI.Desktop.ViewModels;

namespace aplication
{
    public class EmpleadoService
    {
        IEmpleadoRepository empleadoRepository;
        public EmpleadoService()
        {
            empleadoRepository = new EmpleadoRepository();
        }

        public IEnumerable<Empleado> GetEmpleados(string nombreEmpleado)
        {
            var empleados = empleadoRepository.getEmpleados(nombreEmpleado);
            return empleados;
        }
        public IEnumerable<Empleado> GetEmpleados()
        {
            var empleados = empleadoRepository.getEmpleados();
            return empleados;
        }

    }
}
