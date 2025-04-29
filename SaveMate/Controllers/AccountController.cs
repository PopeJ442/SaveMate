using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaveMate.Models.Enums;
using SaveMate.Models;
using SaveMate.Services.IService;

namespace SaveMate.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;

        }


        public async Task<IActionResult> Index(int id)
        {
            var account = new Account 
            {
            UserId = id,
            
            };
            var accounts = await _accountService.GetAccountsByUserIdAsync(id);
            var users = await _userService.GetAllUsers();

            return View(accounts);
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }


        public IActionResult Create(int id)
        {
            var account = new Account
            {
                UserId = id,

            };

            ViewBag.PredefinedTypes = Enum.GetValues(typeof(AccountType))
                                 .Cast<AccountType>()
                                 .Select(t => new SelectListItem { Value = t.ToString(), Text = t.ToString(), })
                                 .ToList();

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account account)
        {

            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    var key = entry.Key;
                    var errors = entry.Value.Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }


                return View(account);
            }

            try
            {
                await _accountService.AddAsync(account);
                return RedirectToAction("Index", "Account", new { id = account.UserId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.PredefinedTypes = Enum.GetValues(typeof(AccountType))
                                     .Cast<AccountType>()
                                     .Select(t => new SelectListItem { Value = t.ToString(), Text = t.ToString() })
                                     .ToList();
                return View(account);
            }
        }



        public async Task<IActionResult> Edit(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Account account)
        {
            if (id != account.AccountId) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(account);
            }

            try
            {
                await _accountService.UpdateAsync(account);
                return RedirectToAction(nameof(Index), new { userId = account.UserId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(account);
            }
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var account = await _accountService.GetByIdAsync(id);
                await _accountService.DeleteAsync(id);
                return RedirectToAction(nameof(Index), new { userId = account.UserId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

    }
}
