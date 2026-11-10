using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Services
{
    public class ZombieTypeService : ServiceBaseAsync<ZombieType>, IZombieTypeService
    {
        public ZombieTypeService(ZombiePartyDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
