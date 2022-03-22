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
    public class UseRepositoy : Repository<tbl_users>, IUsersRepository
    {
        public UseRepositoy(string connectionSrting) : base(connectionSrting)
        {

        }
        public IEnumerable<tbl_users> UsersPagedList(int page, int rows)
        {
            var Parameters = new DynamicParameters();
            Parameters.Add("@page", page);
            Parameters.Add("@rows", rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<tbl_users>("dbo.UsuariosPagedList",
                   Parameters,
                   commandType: System.Data.CommandType.StoredProcedure);
            };
        }

    }
}
