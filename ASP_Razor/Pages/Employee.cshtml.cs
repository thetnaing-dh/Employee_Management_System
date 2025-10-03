using ASP_Razor.Data;
using ASP_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Razor.Pages
{
    public class EmployeeModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Employee> Employees { get; set; } = new List<Employee>();

        [BindProperty]
        public Employee NewEmployee { get; set; } = new Employee();

        public bool IsEditing { get; set; } = false;

        public EmployeeModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {          
            NewEmployee ??= new Employee();
            Employees = _context.Employees.ToList();
        }

        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(NewEmployee);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid && NewEmployee?.Id > 0)
            {
                var existingEmployee = _context.Employees.Find(NewEmployee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = NewEmployee.Name;
                    existingEmployee.Age = NewEmployee.Age;
                    _context.Employees.Update(existingEmployee);
                    _context.SaveChanges();
                }
            }

            IsEditing = false;
            NewEmployee = new Employee();
            Employees = _context.Employees.ToList();
            return Page();
        }

        public IActionResult OnPostEdit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                NewEmployee = employee;
                IsEditing = true;
            }

            Employees = _context.Employees.ToList();
            return Page();
        }

        public IActionResult OnPostCancel()
        {
            IsEditing = false;
            NewEmployee = new Employee();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}