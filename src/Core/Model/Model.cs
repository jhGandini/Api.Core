using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serede.CoreApi.Model;
public abstract class Model : Notifiable<Notification>
{
    public abstract void Validar();
}