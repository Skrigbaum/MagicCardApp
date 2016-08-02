using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagicFontEnd.Startup))]
namespace MagicFontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
