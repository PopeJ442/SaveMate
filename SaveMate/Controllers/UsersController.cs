using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SaveMate.ApplicationDbContext;
using SaveMate.Models;
using SaveMate.Repositories;
using SaveMate.Repositories.IRepository;
using SaveMate.Services;
using SaveMate.Services.IService;
using SaveMate.ViewModel;

namespace SaveMate.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public UsersController(IUserService userRepository, IAccountService accountService)
        {
            _userService = userRepository;
            _accountService = accountService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            var user = await _userService.GetByIdAsync(id);
            var accounts = await _accountService.GetAccountsByUserIdAsync(id);

            var viewmodel = new UserAccountViewModel
            {
                user  = user,
                account = accounts
            
            
            };
            return View(viewmodel);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,DateOfBirth,CreatedAt")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatedAt = DateTime.UtcNow;
             await _userService.AddAsync(user);
             
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,DateOfBirth,CreatedAt")] User user)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                  await _userService.UpdateAsync(user);
                    await _userService.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (UserExists (user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            var user = await _userService.GetByIdAsync(id);
               
            if (user == null) return NotFound();


            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(User user)
        {
          
            await _userService.DeleteAsync(user.UserId);

            return RedirectToAction(nameof(Index));
        }

        
        private  bool UserExists(int id)
        {
             return _userService.GetByIdAsync(id) != null;
        }

    }
}
