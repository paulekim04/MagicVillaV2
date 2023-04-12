using MagicVilla_Data.Entities;
using MagicVilla_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Repository.Implementations
{
    public class VillaRepository : IVillaRepository
    {
        public ApplicationContext Context { get; }

        public VillaRepository(ApplicationContext context)
        {
            Context = context;
        }

        public async Task CreateVillaAsync(Villa villa)
        {
            await Context.Villas.AddAsync(villa);

            await Context.SaveChangesAsync();
        }

        public async Task DeleteVillaAsync(Villa villa)
        {
            Context.Villas.Remove(villa);

            await Context.SaveChangesAsync();
        }

        public async Task<Villa> GetVillaAsync(int id)
        {
            return await Context.Villas.SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Villa>> GetVillasAsync()
        {
            return await Context.Villas.ToListAsync();
        }

        public bool IsExist(string name)
        {
            var isExist = Context.Villas.FirstOrDefault(v => v.Name.ToLower() == name.ToLower());

            return isExist != null ? true : false;
        }

        public async Task UpdateVillaAsync(Villa villa)
        {
            var villaRecord = await GetVillaAsync(villa.Id);

            villaRecord.Amenity = villa.Amenity;
            villaRecord.Details = villa.Details;
            villaRecord.ImageUrl = villa.ImageUrl;
            villaRecord.Name = villa.Name;
            villaRecord.Occupancy = villa.Occupancy;
            villaRecord.Rate = villa.Rate;
            villa.Sqft = villa.Sqft;

            await Context.SaveChangesAsync();
        }
    }
}
