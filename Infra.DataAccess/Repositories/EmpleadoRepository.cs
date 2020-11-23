using Dapper;
using Domain.Model.Abstractions;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repositories
{
    public class EmpleadoRepository : MasterRepository, IEmpleadoRepository
    {
        private string insert = "InsertarEmpleado";
        public int Add(Empleado entidad)
        {
            parameters = new List<SqlParameter>
            {
                new SqlParameter("@Legajo", entidad.Legajo),
                new SqlParameter("@NombreEmpleado", entidad.Nombre),
                new SqlParameter("@Dni", entidad.Dni),
                new SqlParameter("@Direccion", entidad.Direccion)

            };
            return ExecuteNonQuery(insert);
        }

        public int Delete(int idPK)
        {
            throw new NotImplementedException();
        }

        public int Edit(Empleado entidad)
        {
            throw new NotImplementedException();
        }

        public Empleado getEmpleado(int EmpleadoID)
        {
            Empleado result;
            using (var connection = GetSqlConnection())
            {
                var sql = "exec [[dbo].[ObtenerEmpleadoPorID]] @EmpleadoID";
                var values = new { EmpleadoID = EmpleadoID };
                result = connection.QuerySingle<Empleado>(sql, values);
            }
            return result;
        }

        public IEnumerable<Empleado> getEmpleados(string NombreEmpleado)
        {
            IEnumerable<Empleado> results;
            using (var connection = GetSqlConnection())
            {
                var procedure = "dbo.ObtenerEmpleados";
                var values = new { NombreEmpleado = NombreEmpleado };
                results = connection.Query<Empleado>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
            return results;
        }
        public IEnumerable<Empleado> getEmpleados()
        {
            IEnumerable<Empleado> results;
            using (var connection = GetSqlConnection())
            {
                var sql = "SELECT * FROM Empleados";
                results = connection.Query<Empleado>(sql).ToList();
            }
            return results;
        }
    }
}
