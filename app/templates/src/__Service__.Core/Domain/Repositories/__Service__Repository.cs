using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using __Namespace__.__Service__.Core.Domain.Models;
using __Namespace__.__Service__.Core.Domain.Repositories.Interfaces;
using __Namespace__.__Service__.Data.Interfaces;
using __Namespace__.__Service__.Data.Model.Models;

namespace __Namespace__.__Service__.Core.Domain.Repositories
{
    public class __Service__Repository : I__Service__Repository
    {
        private readonly IMapper _mapper;
        private readonly I__Service__DbContext _context;

        public __Service__Repository(IMapper mapper, I__Service__DbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }
        
        public async Task<IEnumerable<__Service__Dto>> Get__Service__s()
        {
            var entities = await _context.Get__Service__s();

            return _mapper
                .Map<IEnumerable<__Service__Entity>, 
                    IEnumerable<__Service__Dto>>
                        (entities);
        }

        public async Task<__Service__Dto> Get__Service__(int id)
        {
            var testEntity = await _context.Get__Service__(id);
            
            return _mapper
                .Map<__Service__Entity, __Service__Dto>(testEntity);
        }

        public async Task Update__Service__(__Service__Dto _serviceDto)
        {
            var entity = _mapper.Map<__Service__Dto, __Service__Entity>(_serviceDto);

            await _context.Update__Service__(entity);
        }
        
        public async Task<IEnumerable<__Service__Dto>> Add__Service__s(IEnumerable<__Service__Dto> _ServiceDtos)
        {
            var entities = await _context.Add__Service__s(_mapper.Map<IEnumerable<__Service__Dto>, IEnumerable<__Service__Entity>>(_ServiceDtos));
            return _mapper
                .Map<IEnumerable<__Service__Entity>,
                    IEnumerable<__Service__Dto>>
                        (entities);
        }
        
        public async Task<bool> Delete__Service__(int id)
        {
            return await _context.Delete__Service__(id);
        }
    }
}
