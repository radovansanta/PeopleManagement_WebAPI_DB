using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNP_Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DNP_Assignment2.Services
{
    public class AdultDBServices
    {
        private DbCon dbCon;
        
        public AdultDBServices(DbCon dbCon)
        {
            this.dbCon = dbCon;
        }
        
        public async Task<IList<Adult>> GetAdults()
        {
            return await dbCon.Adults.Include(a => a.JobTitle).ToListAsync();
        }
        
        public async Task AddAdult(Adult adult)
        {
            EntityEntry<Adult> addedAdult = await dbCon.Adults.AddAsync(adult);
            await dbCon.SaveChangesAsync();
        }
        
        public async Task DeleteAdult(int adultId)
        {
            Adult toDelete = await dbCon.Adults.FirstOrDefaultAsync(t => t.Id == adultId);
            if (toDelete != null)
            {
                dbCon.Adults.Remove(toDelete);
                await dbCon.SaveChangesAsync();
            }
        }
        
        public async Task UpdateAdult(Adult updatedAdult)
        {
            var adultExist = GetAdults().Result.FirstOrDefault(p => p.Id == updatedAdult.Id);
            if (adultExist != null)
            {
                dbCon.Remove(adultExist);
                await dbCon.Adults.AddAsync(updatedAdult);
                await dbCon.SaveChangesAsync();
            }
        }
        
        public IList<Adult> SearchAdult(string type, string value)
        {
            if(type == "firstName")
            {
                return GetAdults().Result.Where(
                    adult => adult.FirstName.ToLower().Contains(value.ToLower())).ToList();
            }
            if(type == "lastName")
            {
                return GetAdults().Result.Where(
                    adult => adult.LastName.ToLower().Contains(value.ToLower())).ToList();
            }
            if(type == "id")
            {
                return GetAdults().Result.Where(
                    adult => adult.Id.ToString().Contains(value)).ToList();
            }
            return GetAdults().Result;
        }
    }
}