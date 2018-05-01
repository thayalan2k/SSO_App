using SSO.Model.DomainObject;

namespace SSO.Service.Interface
{
    public interface IAccountService
    {
        bool Login(UserAuthenticate model);
    }
}
