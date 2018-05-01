using SSO.Model.DomainObject;

namespace SSO.Repository.Interface
{
    public interface IAccountRepository
    {
        bool VerifyUser(UserAuthenticate model);
    }
}
