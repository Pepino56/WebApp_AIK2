using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp_AIK2_Pluhar.Data;
using WebApp_AIK2_Pluhar.Models;

namespace WebApp_AIK2_Pluhar.Pages
{
    public class Index2Model : PageModel
    {
        private readonly AppDbContext _dbContext;

        public Index2Model(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public int Value { get; set; }

        [BindProperty]
        public bool Success { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost(int value, bool success)
        {
           Console.WriteLine($"Value: {Value}, Success: {Success}");

            if (!ModelState.IsValid)
            {                
                return Page();
            }
            var credit = new Credit
            {
                Created = DateTime.Now,
                Value = Value,
                Success = Success
            };

            _dbContext.Credits.Add(credit);
            _dbContext.SaveChanges();

            return RedirectToPage();
        }
    }
}
