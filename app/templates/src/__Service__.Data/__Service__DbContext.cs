using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using __Namespace__.__Service__.Data.Interfaces;
using __Namespace__.__Service__.Data.Model.Models;

namespace __Namespace__.__Service__.Data
{
    public class __Service__DbContext : DbContext, I__Service__DbContext
    {
        public __Service__DbContext()
        {
            //Database.EnsureCreated();
        }

        public __Service__DbContext(DbContextOptions<__Service__DbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        // Declare your Db Sets
        public DbSet<__Service__Entity> __Service__Entities { get; set; }

        public async Task<IEnumerable<__Service__Entity>> Get__Service__s()
        {
            return await __Service__Entities.ToListAsync();
        }

        public async Task<__Service__Entity> Get__Service__(int id)
        {
            return await __Service__Entities.FindAsync(id);
        }

        public async Task<int> Update__Service__(__Service__Entity _service)
        {
            Entry(_service).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<__Service__Entity>> Add__Service__s(IEnumerable<__Service__Entity> _services)
        {
            __Service__Entities.AddRange(_services);
            await SaveChangesAsync();
            return _services;
        }

        public async Task<bool> Delete__Service__(int id)
        {
            var testEntity = await __Service__Entities.FindAsync(id);
            if (testEntity == null)
            {
                return false;
            }

            __Service__Entities.Remove(testEntity);
            await SaveChangesAsync();

            return true;
        }


    }
}
