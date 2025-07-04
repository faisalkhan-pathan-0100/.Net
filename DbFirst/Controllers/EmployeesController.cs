using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirst.Models;

namespace DbFirst.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Jkjune25Context _context;

        public EmployeesController(Jkjune25Context context)
        {
            _context = context;
        }

        //public async IActionResult Index()
        //public async Task<IActionResult> Index()
        //{
        //    //List<Employee> emps = Employee.GetAllEmployees(){  // old way
        //    //    return View(emps);

        //    //var emps = _context.Employees.Include("DeptNoNavigation"); // dept name not shown
        //    //var emps = _context.Employees.Include(e => e.DeptNoNavigation);//deford execution
        //    //var emps = _context.Employees.Include(e => e.DeptNoNavigation).ToList();//immidiated execution
        //    //Task t = _context.Employees.Include(e => e.DeptNoNavigation).ToListAsync();//run on seperate thread
        //    var emps =await _context.Employees.Include(e => e.DeptNoNavigation).ToListAsync();//run on seperate thread

        //    return View(emps);
        // }

        //GET: Employees
        public async Task<IActionResult> Index()
        {
            var jkjune25Context = _context.Employees.Include(e => e.DeptNoNavigation);
            return View(await jkjune25Context.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.DeptNoNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpNo,Name,Basic,DeptNo")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(employee); // metch collection of releted to take time if there is more and more tables in the DB
                _context.Employees.Add(employee);//UMAD - set it currently in collection and letteerly store to database here just track the state  of chnage(UMAD)
                await _context.SaveChangesAsync();// now save all the chnages to Database
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo", employee.DeptNo);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo", employee.DeptNo);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpNo,Name,Basic,DeptNo")] Employee employee)
        {
            if (id != employee.EmpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee); // save in collection like DataSet and keep track of the chnages
                    _context.Employees.Update(employee);
                    await _context.SaveChangesAsync(); // save at this in Database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpNo))
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
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo", employee.DeptNo);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id) // rendering the employee before delete
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.DeptNoNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee); // remove from Database directely
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmpNo == id);
        }
    }
}
