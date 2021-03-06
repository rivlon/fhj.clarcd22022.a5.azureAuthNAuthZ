using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccesAzureStorageWebApp.Models;

namespace AccesAzureStorageWebApp.Pages.Storage_MSI
{
    public class DeleteModel : PageModel
    {
        private readonly AccesAzureStorageWebApp.Data.CommentsContext _context;
        public DeleteModel(AccesAzureStorageWebApp.Data.CommentsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Comment> comments = await _context.GetComments();
            Comment = comments.FirstOrDefault(m => m.Name == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Comment> comments = await _context.GetComments();
            Comment = comments.FirstOrDefault(m => m.Name == id);

            if (Comment != null)
            {
                await _context.DeleteComment(Comment);
            }

            return RedirectToPage("./Index");
        }
    }
}
