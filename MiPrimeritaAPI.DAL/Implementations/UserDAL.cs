using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public IESContext Context { get; set; }

        public UserDAL(IESContext Context)
        {
            this.Context = Context;
        }

        public User? GetUser(string Email)
        {
            return Context.User.FirstOrDefault(user=>user.Email==Email);
        }

        public List<User> GetUsers()
        {
            return Context.User.ToList();
            
        }

        public void Insert(User a)
        {
            Context.User.Add(a);
            Context.SaveChanges();
        }


    }
}
