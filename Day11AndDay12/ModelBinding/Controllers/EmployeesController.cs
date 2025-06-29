using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;
 

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        
        //Employees/Index  => all the employees
        public ActionResult Index()
        {
            List<Employee> emps = Employee.GetAllEmployees();
            //List<Employee> emps = new List<Employee>();
            //emps.Add(new Employee { EmpNo = 1, Name = "Rohan", Basic = 12345, DeptNo = 10 });
            //emps.Add(new Employee { EmpNo = 2, Name = "Shubham", Basic = 12345, DeptNo = 10 });
            //emps.Add(new Employee { EmpNo = 3, Name = "Kajal", Basic = 12345, DeptNo = 10 });
            return View(emps);
        }

        // GET: EmployeesController/Details/5
        //Employees/Details/1
        public ActionResult Details(int id) // single employee
        {
            Employee obj = Employee.GetSingleEmployee(id);
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Kajal";
            //obj.Basic = 12345;
            //obj.DeptNo = 10;
            //ViewBag.obj = obj;
            if(obj == null)
            {
                ViewBag.m = "Employee not found";
                
            }       
                return View(obj);       
        }

        // GET: EmployeesController/Create
        //Employees/Create
        //[HttpGet] by default get
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost] // post request
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
            //    try
            //    {
            //        string Name = collection["Name"];
            //        string EmpNo = collection["EmpNo"];
            //        string Basic = collection["Basic"];
            //        string DeptNo = collection["DeptNo"];
            //        //Employee emp = new Employee();
            //        //return RedirectToAction(nameof(Index));
            //        return RedirectToAction("Index");
            //    }
            //    catch
            //    {
            //        return View();
            //    }
        //}
        // ensure the Html name Attribute is same as the Create( para name)
        //public ActionResult Create(int EmpNo,string Name,decimal Basic,int DeptNo)
        ////public ActionResult Create(int EmpNo,string Name,decimal Basic,int DeptNo, IFormCollection collection)
        //{
        //    try
        //    {

        //        //return RedirectToAction(nameof(Index));
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //Model Binding - ensure the property name are same asa the hTML control name
        public ActionResult Create(Employee obj)
        {
            try
            {
                Employee.Insert(obj);
                //return RedirectToAction(nameof(Index));
                ViewBag.message = "Congretulation";
                //return RedirectToAction("Index");
                return View();
            }
            catch (Exception ex) {

                //ViewBag.message = ex.Message;
                ViewBag.message = "Enter the correct id";
                    return View();
                }


            }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        
        public ActionResult Delete(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
