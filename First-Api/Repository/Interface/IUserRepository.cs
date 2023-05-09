using First_Api.Models;

namespace First_Api.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserModel>> Get();
        Task<UserModel> GetById(int id);
        Task<UserModel> Post(UserModel user);
        Task<UserModel> Put(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
