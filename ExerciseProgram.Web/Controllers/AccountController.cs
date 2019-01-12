using ExerciseProgram.Gui.Mvc.Services;
using ExerciseProgram.Models.InputModels;
using System.Web.Mvc;

namespace ExerciseProgram.Gui.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService = new AccountService();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterInputModel model)
        {
            _accountService.RegisterUser(model);

            return View();
        }
    }
}