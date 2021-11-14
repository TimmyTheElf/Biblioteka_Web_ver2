using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Biblioteka_Web_ver2.Models;

namespace Biblioteka_Web_ver2.Pages.Forms
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;


        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        public void OnGet(int Id)
        {
            Book = _context.Books.Find(Id);


        }
        public IActionResult OnPostDelete(int id)
        {
            var item = _context.Books.Find(id);
            _context.Books.Remove(item);
            _context.SaveChanges();
            return RedirectToPage("/Forms/View");
        }
    }
}
