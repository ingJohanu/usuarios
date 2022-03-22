using System;
using usuarios.Repositories;

namespace usuarios.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAdminRepository Admin { get; }
        IUsersRepository Users { get; }
        IPublicacionRepository Publicacion { get; }
        
    }
}
