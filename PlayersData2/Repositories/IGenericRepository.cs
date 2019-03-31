using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData2.Repositories
{
    interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetByID(int ID);
        void Insert(T entity);
        void Delete(int ID);
        void Update(T entity);
        void Save();
    }
}
