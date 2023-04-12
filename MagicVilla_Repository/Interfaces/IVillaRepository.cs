using MagicVilla_Data.Entities;

namespace MagicVilla_Repository.Interfaces
{
    public interface IVillaRepository
    {
        Task<IEnumerable<Villa>> GetVillasAsync();
        Task<Villa> GetVillaAsync(int id);
        bool IsExist(string name);
        Task CreateVillaAsync(Villa villa);
        Task DeleteVillaAsync(Villa villa);
        Task UpdateVillaAsync(Villa villa);
    }
}
