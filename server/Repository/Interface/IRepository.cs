using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T>
    {
        public Task<List<T>> getAllAsync();
        public Task<T> getAsync(int id);
        public Task deleteAsync(int id);
        public Task updateAsync(int id,T entity);
        public Task Post(T item);
        public Task<T> addItemAsync(T item);
    }
}
