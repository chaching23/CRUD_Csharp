using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dishes.Models;

namespace dishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var users = dbContext.Users.ToList();

            User someUser = dbContext.Users.FirstOrDefault(user => user.UserId == 1);

            List<User> result = dbContext.Users
                .OrderByDescending(user => user.CreatedAt)
                .ToList();
    
            return View(users);
        }




        [HttpGet("new")]
        public IActionResult New() => View();

        





        [HttpPost("create")]
        public IActionResult Create(User newUser)
        {
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }









        [HttpGet("user/{userid}")]

        public IActionResult Show(int userid)
        {
            User somebody = dbContext.Users.FirstOrDefault(u => u.UserId == userid);

            if(somebody == null)

                return RedirectToAction("Index");

            return View(somebody);
        }








        [HttpPost("user/{userId}/update")]
        public IActionResult Update(User user, int userId)
        {
            User toUpdate = dbContext.Users.FirstOrDefault(u => u.UserId == userId);

            if(toUpdate == null)
                return RedirectToAction("Index");

            toUpdate.Name = user.Name;
            toUpdate.Chef = user.Chef;
            toUpdate.Taste = user.Taste;
            toUpdate.Calories = user.Calories;
            toUpdate.Description = user.Description;



            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }










        [HttpGet("user/{userId}/delete")]
        public IActionResult Delete(int userId)
        {
            User toDelete = dbContext.Users.FirstOrDefault(u => u.UserId == userId);

            if(toDelete == null)
                return RedirectToAction("Index");

            dbContext.Users.Remove(toDelete);

            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
