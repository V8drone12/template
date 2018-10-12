using System.Collections.Generic;
using System.Threading.Tasks;
using __Namespace__.__Service__.Data.Model.Models;

namespace __Namespace__.__Service__.Data.Interfaces
{
    public interface I__Service__DbContext
    {
        Task<IEnumerable<__Service__Entity>> Add__Service__s(IEnumerable<__Service__Entity> _services);
        Task<bool> Delete__Service__(int id);
        Task<__Service__Entity> Get__Service__(int id);
        Task<IEnumerable<__Service__Entity>> Get__Service__s();
        Task<int> Update__Service__(__Service__Entity _service);
    }
}