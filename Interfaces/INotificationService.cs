using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciplesNETCoreDemo.Models;

namespace SolidPrinciplesNETCoreDemo.Interfaces
{
    public interface INotificationService
    {
        void Notify(User user);
    }


}
