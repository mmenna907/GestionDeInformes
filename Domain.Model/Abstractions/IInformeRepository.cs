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
        IEnumerable<Informe> GetInformes(int EmpleadoID);

        IEnumerable<Informe> GetInformes(string EmpleadoNombre);

    }
}
