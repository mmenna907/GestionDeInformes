using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;

namespace Domain.Model.Abstractions
{
    public interface IInformeRepository : IGenericRepository<Informe>
    {
        Informe GetInforme(int InformeID);
        Task<IEnumerable<Informe>> GetInformesAsync();
        IEnumerable<Informe> GetInformesRealizados(int EmpleadoIDConfecciona);
        IEnumerable<Informe> GetInformesRealizados(string NombreEmpleadoConfecciona);
        IEnumerable<Informe> GetInformesRecibidos(int EmpleadoIDInformado);
        IEnumerable<Informe> GetInformesRecibidos(string NombreEmpleadoInformado);

    }
}
