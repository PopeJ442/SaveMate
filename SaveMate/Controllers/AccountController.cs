using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaveMate.Models;
using SaveMate.Models.Enums;
using SaveMate.Services.IService;

namespace SaveMate.Controllers
{
    public class AccountController : Controller
    {
        
            private readonly IAccountService _accountService;

            public AccountController(IAccountService accountService)
            {
                _accountService = accountService;
            }

     
            public async Task<IActionResult> Index(int userId)
            {
                var accounts = await _accountService.GetAccountsByUserIdAsync(userId);
                return View(accounts);
            }

       
            public async Task<IActionResult> Details(Guid id)
            {
                var account = await _accountService.GetByIdAsync(id);
                if (account == null) return NotFound();
                return View(account);
            }

          
            public IActionResult Create()
            {
            ViewBag.PredefinedTypes = Enum.GetValues(typeof(AccountType))
                                 .Cast<AccountType>()
                                 .Select(t => new SelectListItem { Value = t.ToString(), Text = t.ToString() })
                                 .ToList();
            return View();
            }

        
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Account account)
            {
                if (!ModelState.IsValid)
                {
                    return View(account);
                }

                try
                {
                    await _accountService.AddAsync(account);
                    return RedirectToAction(nameof(Index), new { userId = account.UserId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
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
                    await _accountService.DeleteAsync(id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View();
                }
            }
        }

    }
