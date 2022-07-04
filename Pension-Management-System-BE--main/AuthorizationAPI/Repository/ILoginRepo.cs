using AuthorizationAPI.Models;

namespace AuthorizationAPI.Repository
{
    public interface ILoginRepo
    {
        public string Login(Credentials request);
        public bool Registration(Credentials request);
    }
}
