using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BankTransaction.StartupOwin))]

namespace BankTransaction
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
