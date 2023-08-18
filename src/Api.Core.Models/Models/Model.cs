using Flunt.Notifications;

namespace Api.Core.Models.Models;
public abstract class Model : Notifiable<Notification>
{
    public abstract void Validar();
}