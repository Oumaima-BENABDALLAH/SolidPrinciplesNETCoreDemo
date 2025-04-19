using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciplesNETCoreDemo.Models;

namespace SolidPrinciplesNETCoreDemo.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Delete(int id);
    }
}
