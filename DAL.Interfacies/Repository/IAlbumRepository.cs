using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.Repository;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IAlbumRepository:IRepository<DalAlbum>
    {
        IEnumerable<DalAlbum> GetByUserId(int userId );
        IEnumerable<DalAlbum> GetByPredicate(Expression<Func<DalAlbum, bool>> f);
    }

    
}
