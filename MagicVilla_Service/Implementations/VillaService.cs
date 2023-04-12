using MagicVilla_Data.Entities;
using MagicVilla_Repository.Interfaces;
using MagicVilla_Service.Interfaces;

namespace MagicVilla_Service.Implementations
{
    public class VillaService : IVillaService
    {
        private IVillaRepository VillaRepository { get; }

        public VillaService(IVillaRepository villaRepository)
        {
            VillaRepository = villaRepository;
        }

        public async Task<IEnumerable<Villa>> GetVillasAsync()
        {
            return await VillaRepository.GetVillasAsync();
        }

        public async Task<Villa> GetVillaAsync(int id)
        {
            return await VillaRepository.GetVillaAsync(id);
        }

        public bool IsExist(string name)
        {
            return VillaRepository.IsExist(name);
        }

        public async Task CreateVillaAsync(Villa villa)
        {
            await VillaRepository.CreateVillaAsync(villa);
        }

        public async Task DeleteVillaAsync(Villa villa)
        {
            await VillaRepository.DeleteVillaAsync(villa);
        }

        public async Task UpdateVillaAsync(Villa villa)
        {
            await VillaRepository.UpdateVillaAsync(villa);
        }
    }
}
