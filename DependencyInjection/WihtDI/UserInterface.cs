using System;

namespace DependencyInjection.WihtDI
{
    public class UserInterface1
    {
        private readonly IEmailProvider emailProvider;

        public UserInterface1(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider ?? throw new ArgumentNullException();
        }

        public void SendEmail(string emailAddress, string password, string message)
        {
            emailProvider.RegisterUser(emailAddress, message);
            emailProvider.SendEmail(emailAddress, message);
        }
    }

    public class UserInterface2
    {
        private IEmailProvider emailProvider;

        public UserInterface2()
        {
        }

        /// <summary>
        /// Property SEtter inject
        /// </summary>
        public IEmailProvider EmailService
        {
            get { return emailProvider; }
            set { emailProvider = value; }
        }


        public void SendEmail(string emailAddress, string password, string message)
        {
            emailProvider?.RegisterUser(emailAddress, message);
            emailProvider?.SendEmail(emailAddress, message);
        }
    }
}
