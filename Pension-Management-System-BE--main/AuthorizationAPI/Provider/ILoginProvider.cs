using AuthorizationAPI.Models;

namespace AuthorizationAPI.Provider
{
    public interface ILoginProvider
    {
        public string Login(Credentials request);
        public bool Registration(Credentials request);
    }
}
