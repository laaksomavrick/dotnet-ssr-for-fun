using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SsrExample.Data;
using SsrExample.Models;

namespace SsrExample.Pages.Folders
{
    public class EditModel : PageModel
    {
        private readonly SsrExample.Data.FolderContext _context;

        public EditModel(SsrExample.Data.FolderContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Folder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FolderExists(Folder.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FolderExists(int id)
        {
            return _context.Folder.Any(e => e.ID == id);
        }
    }
}
