using ZombieParty.Models;

namespace ZombieParty.Services
{
    public interface IZombieService : IServiceBaseAsync<Zombie>
    {
        public Task<List<Zombie>> GetAllByZombieTypeAsync(int zombieTypeId);
        public Task<List<Zombie>> GetAllIndexAsync();
        public bool ZombieNameExist(string name);

    }
}
