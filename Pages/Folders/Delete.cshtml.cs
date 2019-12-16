using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SsrExample.Data;
using SsrExample.Models;

namespace SsrExample.Pages.Folders
{
    public class DeleteModel : PageModel
    {
        private readonly SsrExample.Data.FolderContext _context;

        public DeleteModel(SsrExample.Data.FolderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Folder Folder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Folder = await _context.Folder.FirstOrDefaultAsync(m => m.ID == id);

            if (Folder == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Folder = await _context.Folder.FindAsync(id);

            if (Folder != null)
            {
                _context.Folder.Remove(Folder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
