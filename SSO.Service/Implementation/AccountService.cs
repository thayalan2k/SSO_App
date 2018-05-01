using SSO.Model.DomainObject;
using SSO.Repository.Interface;
using SSO.Service.Interface;
using System;

namespace SSO.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICryptographyService _cryptographyService;
        public AccountService(IAccountRepository accountRepository, 
            ICryptographyService cryptographyService)
        {
            _accountRepository = accountRepository;
            _cryptographyService = cryptographyService;
        }

        public bool Login(UserAuthenticate model)
        {
            if (model == null)
                throw new Exception("User cannot be empty.");

            if (string.IsNullOrEmpty(model.Username) 
                || string.IsNullOrEmpty(model.Password))
                throw new Exception("Username or password cannot be empty.");

            model.Password = _cryptographyService.Encrypt(model.Password);
            return _accountRepository.VerifyUser(model);
        }
    }
}
