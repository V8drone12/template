using System.Collections.Generic;
using System.Threading.Tasks;
using __Namespace__.__Service__.Core.Domain.Models;

namespace __Namespace__.__Service__.Core.Domain.Repositories.Interfaces
{
    public interface I__Service__Repository
    {
        Task<IEnumerable<__Service__Dto>> Get__Service__s();
        Task<__Service__Dto> Get__Service__(int id);
        Task Update__Service__(__Service__Dto _serviceDto);
        Task<IEnumerable<__Service__Dto>> Add__Service__s(IEnumerable<__Service__Dto> _ServiceDtos);
        Task<bool> Delete__Service__(int id);
    }
}
