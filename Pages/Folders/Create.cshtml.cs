using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SsrExample.Data;
using SsrExample.Models;

namespace SsrExample.Pages.Folders
{
    public class CreateModel : PageModel
    {
        private readonly SsrExample.Data.FolderContext _context;

        public CreateModel(SsrExample.Data.FolderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Folder Folder { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Folder.Add(Folder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
