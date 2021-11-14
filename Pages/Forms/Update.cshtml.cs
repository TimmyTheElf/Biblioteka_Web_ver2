using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using Biblioteka_Web_ver2.Models;

namespace Biblioteka_Web_ver2.Pages.Forms
{
    public class UpdateModel : PageModel
    {
        private readonly AppDbContext _context;


        public UpdateModel(AppDbContext context)

        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public IActionResult OnPost(int id)
        {
            
            if (ModelState.IsValid)
            {
                foreach (var file in Request.Form.Files)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    Book.Cover = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                }

                var item = _context.Books.Find(id);
                item.Title = Book.Title;
                item.Author = Book.Author;
                item.Description = Book.Description;
                if (Book.Cover != null)
                {
                    item.Cover = Book.Cover;
                }
                _context.SaveChanges();
                return RedirectToPage("/Forms/View");
            }
            else
            {
                return Page();
            }
        }
        public void OnGet(int id)
        {
            Book = _context.Books.Find(id);
        }
    }
}
