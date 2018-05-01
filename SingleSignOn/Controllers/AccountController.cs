using SingleSignOn.Mapper;
using SingleSignOn.Models;
using SSO.Service.Interface;
using System.Web.Mvc;
using System.Web.Security;

namespace SingleSignOn.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserAuthenticateMapper _userAuthenticateMapper;
        public AccountController(IAccountService accountService, 
            UserAuthenticateMapper userAuthenticateMapper)
        {
            _accountService = accountService;
            _userAuthenticateMapper = userAuthenticateMapper;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _accountService.Login(_userAuthenticateMapper.ToDomainModel(model));
            if (result)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");              
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }       
        }
    }
}