using Flunt.Notifications;

namespace Serede.CoreApi.ViewModel;
public abstract class Result : Notifiable<Notification>
{
    public object Data { get; set; }
    public int Count { get; set; }

}
