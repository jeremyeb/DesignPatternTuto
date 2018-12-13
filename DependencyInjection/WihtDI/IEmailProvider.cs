namespace DependencyInjection.WihtDI
{
    public interface IEmailProvider
    {
        void RegisterUser(string username, string password);
        void SendEmail(string emailAddress, string message);
    }
}