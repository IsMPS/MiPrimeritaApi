using AutoMapper;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;
using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;

namespace MiPrimeritaAPI.BL.Implementations
{
    public class UserBL : IUserBL
    {
        public IMapper mapper { get; set; }
        public IUserDAL userDAL { get; set; }

        public UserBL(IUserDAL UserDAL, IMapper mapper)
        {
            this.userDAL = UserDAL;
            this.mapper = mapper;
        }

        public List<UserDTO> GetUsers()
        {
            var users = userDAL.GetUsers();
            var UserDTOs = mapper.Map<List<UserDTO>>(users);
            return UserDTOs;
        }

        public bool Insert(UserDTO a)
        {
            var user = userDAL.GetUser(a.Email);
            if (user == null)
            {
                user = mapper.Map<User>(a);

                userDAL.Insert(user);

                return true;
            }
            return false;
        }

        public UserDTO? GetUser(String Email)
        {
            var user = userDAL.GetUser(Email);
            if (user != null)
            {
                var userDTO = mapper.Map<UserDTO>(user);
                return userDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
