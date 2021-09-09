using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FCSE_IT_Project.Startup))]
namespace FCSE_IT_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
