using MagicVilla_Data.Entities;

namespace MagicVilla_Service.Interfaces
{
    public interface IVillaService
    {
        Task<IEnumerable<Villa>> GetVillasAsync();
        Task<Villa> GetVillaAsync(int id);
        bool IsExist(string name);
        Task CreateVillaAsync(Villa villa);
        Task DeleteVillaAsync(Villa villa);
        Task UpdateVillaAsync(Villa villa);
    }
}
