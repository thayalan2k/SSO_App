using SingleSignOn.Models;
using SSO.Model.DomainObject;

namespace SingleSignOn.Mapper
{
    public class UserAuthenticateMapper
    {
        public UserAuthenticate ToDomainModel(LoginViewModel viewModel)
        {
            return new UserAuthenticate
            {
                Username = viewModel.Username,
                Password = viewModel.Password
            };
        }
    }
}