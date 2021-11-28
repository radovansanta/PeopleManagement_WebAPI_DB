using System;
using System.Linq;
using System.Threading.Tasks;
using DNP_Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DNP_Assignment2.Services
{
    public class UserDBServices
    {
        private DbCon dbCon;
        
        public UserDBServices(DbCon dbCon)
        {
            this.dbCon = dbCon;
        }
        
        public User ValidateUser(string email, string password)
        {
            User user = dbCon.Users.ToListAsync().Result.FirstOrDefault(takenUser => takenUser.Email.Equals(email));
            
            if (user==null)
            {
                throw new Exception("User not found");
            }

            if (!user.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return user;
        }
        
        public async Task AddUser(User user)
        {
            EntityEntry<User> addedUser = await dbCon.Users.AddAsync(user);
            await dbCon.SaveChangesAsync();
        }
        
    }
}