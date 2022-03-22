using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios.UnitOfWork;
using usuarios.Repositories;


namespace usuarios.DataAccess
{
    public class ServicesUnitOfWork : IUnitOfWork
    {
        public ServicesUnitOfWork(string connectionString)
        {
            Users = new UseRepositoy(connectionString);
            Admin = new AdminRepository(connectionString);
            Publicacion = new PublicacionRepository(connectionString);
        }
        public IAdminRepository Admin { get; private set; }
        public IUsersRepository Users { get; private set; }
        public IPublicacionRepository Publicacion { get; private set; }

        
    }
}
