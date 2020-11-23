using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repositories
{
    public abstract class MasterRepository: Repository
    {
        protected List<SqlParameter> parameters;
        protected int ExecuteNonQuery(string transactSql)
        {
            //insertar, modificar y eliminar
            using (var conexion = GetSqlConnection()) //using sirve para implementar la interfaz desechable dispose
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transactSql;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parameters)
                    {
                        comando.Parameters.Add(item);
                    }
                    int resultado = comando.ExecuteNonQuery();
                    parameters.Clear();
                    return resultado;
                }
            }
        }
        protected DataTable ExecuteReader(string transactSql)
        {
            //Consultar
            using (var conexion = GetSqlConnection()) //using sirve para implementar la interfaz desechable dispose
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transactSql;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parameters)
                    {
                        comando.Parameters.Add(item);
                    }
                    SqlDataReader reader = comando.ExecuteReader();//podria haber utilizado using para liberar el readear pero luego se utiliza el dispose
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();//Alternativa al comando using
                        parameters.Clear();
                        return tabla;
                    }
                }
            }
        }//FIN METODO EXECUTE READER
    }
}
