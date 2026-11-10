using System.Xml.Linq;
using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Services
{
    public class ZombieTypeService : ServiceBaseAsync<ZombieType>, IZombieTypeService
    {
        public ZombieTypeService(ZombiePartyDbContext dbContext) : base(dbContext)
        {
            
        }
        public bool HasAssociatedZombies(ZombieType entity)
        {
            if (entity.Zombies.Count != 0) return true;
            else return false;
        }

        public override async Task DeleteAsync(int id)
        {
            ZombieType zombieType = await this.GetByIdAsync(id);
            if (zombieType == null)
            {
                return;
            }
            else if (HasAssociatedZombies(zombieType))
            {
                zombieType.IsDisponible = false;
                await this.EditAsync(zombieType);
            }
            else
            {
                await base.DeleteAsync(id);
            }
        }
    }
}
