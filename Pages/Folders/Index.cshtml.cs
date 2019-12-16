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
    public class IndexModel : PageModel
    {
        private readonly SsrExample.Data.FolderContext _context;

        public IndexModel(SsrExample.Data.FolderContext context)
        {
            _context = context;
        }

        public IList<Folder> Folder { get;set; }

        public async Task OnGetAsync()
        {
            Folder = await _context.Folder.ToListAsync();
        }
    }
}
