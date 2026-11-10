using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<SelectListItem> ListZombieTypeDisponible()
        {
            var zombieTypesDispos = _dbContext.ZombieTypes.Where(zt => zt.IsDisponible)
                .Select(zt => new SelectListItem
                {
                    Text = zt.TypeName,
                    Value = zt.Id.ToString()
                }
                ).ToList();
            return zombieTypesDispos;
        }
    }
}
