using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Biblioteka_Web_ver2.Models;

namespace Biblioteka_Web_ver2.Pages.Forms
{
    public class ViewModel : PageModel
    {
        private readonly AppDbContext _context;


        public ViewModel(AppDbContext context)
        {
            _context = context;
        }

        
        public IEnumerable<ViewBook> ViewBooks;
        public void OnGet()
        {
            ViewBooks=_context.Books.Select(x=>new ViewBook { Id=x.Id, Title=x.Title, Author=x.Author }).ToList().OrderBy(n=>n.Title);
            
            
           
        }
        public void OnPost(int Id)
        {
            RedirectToPage("/Forms/Details");
        }
    }
}
