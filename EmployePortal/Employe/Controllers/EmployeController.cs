using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employe.Models;
using Microsoft.AspNetCore.Mvc;
using Employe.Data;
using Employe.Models.Entity;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employe.Controllers
{
    public class EmployeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

       public EmployeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeViewModel viewModel)
        {
            var worker = new Worker
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Salary = viewModel.Salary,
                DateOfBirth = viewModel.DateOfBirth,
                Department = viewModel.Department,
                subscribed = viewModel.subscribed

            };
            await dbContext.Workers.AddAsync(worker);
            await dbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
           var workers= await dbContext.Workers.ToListAsync();

            return View(workers);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var worker = await dbContext.Workers.FindAsync(Id);

            return View(worker);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Worker viewWorker)
        {
            if (!ModelState.IsValid)
            {
                return View(viewWorker);
            }
            var worker = await dbContext.Workers.FindAsync(viewWorker.Id);
            if(worker is not null)
            {
                worker.Name = viewWorker.Name;
                worker.Email = viewWorker.Email;
                worker.Salary = viewWorker.Salary;
                worker.DateOfBirth = viewWorker.DateOfBirth;
                worker.Department = viewWorker.Department;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employe");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Worker viewWorker)
        {

            var worker = await dbContext.Workers.FindAsync(viewWorker.Id);
            if(worker is not null)
            {
                dbContext.Workers.Remove(worker);
                 await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Employe");
        }
    }
}

