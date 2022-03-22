using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios.Models;
using usuarios.Repositories;

namespace usuarios.DataAccess
{
    public class AdminRepository:Repository<tbl_admin>,IAdminRepository
    {
        public AdminRepository(string conectionString) : base (conectionString)
        {

        }

        public tbl_admin ValidateAdmin(string usuario, string contraseña)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@usuario", usuario);
            parameters.Add("@contraseña", contraseña);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<tbl_admin>(
                    "dbo.ValidateAdmin", parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
