using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Biblioteka_Web_ver2.Models;
using System.IO;

namespace Biblioteka_Web_ver2.Pages.Forms
{
    public class AddNewItemModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddNewItemModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public async Task<IActionResult> OnPostAsync()
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
                await _context.AddAsync(Book);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Forms/View");
            }
            else return Page();
        }


        public void OnGet()
        {
        }


    }
}
