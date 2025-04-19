using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciplesNETCoreDemo.Interfaces;
using SolidPrinciplesNETCoreDemo.Models;

namespace SolidPrinciplesNETCoreDemo.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void Notify(User user)
        {
            // Logique d'envoi d'email
            Console.WriteLine($"Email envoyé à {user.Email} pour l'utilisateur {user.Name}.");
        }
    }
}
