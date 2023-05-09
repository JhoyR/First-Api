using First_Api.Models;
using First_Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;


namespace First_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> Get()
        {
            List<UserModel> contacts = await _userRepository.Get();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetbyId(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Post([FromBody] UserModel userModel)
        {
            userModel = await _userRepository.Post(userModel);
            return Ok(userModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UserModel user, int id)
        {
            user.IdUser = id;
            try
            {
                if (user.IdUser == id)
                {
                    await _userRepository.Put(user, id);
                    return Ok($"Contato com id={id} atualizado com sucesso.");
                }
                else
                {
                    return BadRequest("Dados inconsistentes.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Request inválido. " + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool deleted = await _userRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
