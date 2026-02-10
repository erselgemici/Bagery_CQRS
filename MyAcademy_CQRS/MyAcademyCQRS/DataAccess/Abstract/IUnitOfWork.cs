using System.Threading.Tasks;

namespace MyAcademyCQRS.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        Task SaveChangesAsync();
    }
}
