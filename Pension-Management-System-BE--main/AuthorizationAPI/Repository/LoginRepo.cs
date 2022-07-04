using AuthorizationAPI.Models;
using AuthorizationAPI.Provider;

namespace AuthorizationAPI.Repository
{
    public class LoginRepo : ILoginRepo
    {
        private readonly ILoginProvider _provider;

        public LoginRepo(ILoginProvider provider)
        {
            _provider = provider;
        }

        public string Login(Credentials request)
        {
            return _provider.Login(request);
        }

        public bool Registration(Credentials request)
        {
            return _provider.Registration(request);
        }
    }
}
