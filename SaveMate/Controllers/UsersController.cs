using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaveMate.ApplicationDbContext;
using SaveMate.Models;
using SaveMate.Repositories.IRepository;

namespace SaveMate.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
          var users= await _userRepository.GetAllAsync();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
                
            
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,DateOfBirth,CreatedAt")] User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.AddAsync(user);
                user.CreatedAt  = DateTime.UtcNow;
                await _userRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetByIdAsync(id);
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
                  await _userRepository.UpdateAsync(user);
                    await _userRepository.SaveAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetByIdAsync(id);
               
            if (user == null) return NotFound();


            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
           await _userRepository.DeleteAsync(user);

            await _userRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        
        private  bool UserExists(int id)
        {
             return _userRepository.GetByIdAsync(id) != null;
        }

    }
}
