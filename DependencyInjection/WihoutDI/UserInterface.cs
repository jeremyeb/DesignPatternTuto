namespace DependencyInjection.WihoutDI
{
    public class UserInterface
    {
        private readonly OutlookEmailProvider outlookEmailProvider;

        public UserInterface()
        {
            outlookEmailProvider = new OutlookEmailProvider();
        }


        public void SendEmail(string emailAddress, string password, string message)
        {
            outlookEmailProvider.RegisterUser(emailAddress, message);
            outlookEmailProvider.SendEmail(emailAddress, message);
        }
    }
}
