using Dapper;
using Domain.Model.Abstractions;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repositories
{
    public class InformeRepository : MasterRepository, IInformeRepository
    {
        public int Add(Informe entidad)
        {
            int affectedRows;
            using (var connection = GetSqlConnection())
            {
                var procedure = "[InsertarInformes]";
                var values = new
                {
                    Fecha = entidad.Fecha,
                    EmpleadoIDConfecciona = entidad.EmpleadoConfecciona.Empleadoid,
                    EmpleadoIDInformado = entidad.EmpleadoInformado.Empleadoid,
                    Motivo = entidad.Motivo,
                    Descripcion = entidad.Descripcion
                };
                affectedRows = connection.Execute(procedure,values,commandType:CommandType.StoredProcedure) ;
            }
            return affectedRows;
        }

        public int Delete(int idPK)
        {
            throw new NotImplementedException();
        }

        public int Edit(Informe entidad)
        {
            throw new NotImplementedException();
        }

        public Informe GetInforme(int InformeID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Informe>> GetInformesAsync()
        {
            IEnumerable<Informe> informes;
            using (var connection = GetSqlConnection())
            {
                var sql = "SELECT * FROM informes";
                //var sql = "SELECT InformeID " +
                //            ",Fecha " +
                //            ",EmpleadoIDConfecciona " +
                //            ",EmpleadoIDInformado " +
                //            ",Motivo " +
                //            ",Descripcion " +
                //            "FROM Informes i " +
                //            "INNER JOIN Empleados e ON i.EmpleadoIDConfecciona = e.EmpleadoID";

                //informes = await connection.QueryAsync<Informe, Empleado, Informe>(sql, (Informe,Empleado) => {
                //        Informe.EmpleadoConfecciona = Empleado;
                //        return Informe;
                //    },
                //    splitOn: "EmpleadoID");
                informes = await connection.QueryAsync<Informe>(sql);
            }
            return informes.ToList();
         }

        public IEnumerable<Informe> GetInformesRealizados(int EmpleadoIDConfecciona)
        {
            List<Informe> informes;
            using (var connection = GetSqlConnection())
            {
                var procedure = "ObtenerInformesPorEmpleadoIDConfecciona";
                var values = new
                {
                    EmpleadoIDConfecciona = EmpleadoIDConfecciona
                };
                informes = connection.Query<Informe>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
            return informes;
        }

        public IEnumerable<Informe> GetInformesRealizados(string NombreEmpleadoConfecciona)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Informe> GetInformesRecibidos(int EmpleadoIDInformado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Informe> GetInformesRecibidos(string NombreEmpleadoInformado)
        {
            throw new NotImplementedException();
        }

    }
}
