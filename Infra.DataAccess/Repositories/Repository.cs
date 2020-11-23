using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repositories
{
    public abstract class Repository
    {
        private readonly string CadenaDeConexionSQL;

        public Repository()
        {
            CadenaDeConexionSQL = "Data Source = SISTEMAS3; Initial Catalog = Informes; Integrated Security = True";
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(CadenaDeConexionSQL);
        }

    }
}
