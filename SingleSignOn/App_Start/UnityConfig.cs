using SSO.Repository.Implementation;
using SSO.Repository.Interface;
using SSO.Service.Implementation;
using SSO.Service.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SingleSignOn
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //Injection of Repositories Dependencies
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IDatabaseRepository, DatabaseRepository>();       

            //Injection of Services Dependencies
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<ICryptographyService, CryptographyService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}