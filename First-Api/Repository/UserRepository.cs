using First_Api.Data;
using First_Api.Models;
using Microsoft.EntityFrameworkCore;
using First_Api.Repository.Interface;

namespace First_Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<List<UserModel>> Get()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.IdUser == id);
        }

        public async Task<UserModel> Post(UserModel user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Put(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            userById.IdUser = user.IdUser;
            userById.NameUser = user.NameUser;
            userById.PasswordUser = user.PasswordUser;
            userById.EmailUser = user.EmailUser;

            _dbContext.User.Update(userById);
            await _dbContext.SaveChangesAsync();
            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);
            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.User.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
