using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciplesNETCoreDemo.Interfaces;
using SolidPrinciplesNETCoreDemo.Models;
using SolidPrinciplesNETCoreDemo.Repositories;

namespace SolidPrinciplesNETCoreDemo.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration; // Ajoutez cette ligne

        public UserService(IUserRepository userRepository, INotificationService notificationService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
            _configuration = configuration; // Initialisez la variable
        }

        public void RegisterUser(User user)
        {
            _userRepository.Add(user);
            _notificationService.Notify(user);
        }

        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
      
    }
}
