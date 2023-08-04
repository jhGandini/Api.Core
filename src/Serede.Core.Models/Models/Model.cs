using Flunt.Notifications;

namespace Serede.Core.Models;
public abstract class Model : Notifiable<Notification>
{
    public abstract void Validar();
}