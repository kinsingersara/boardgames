using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using boardgamestore_skinsinger.Data;
using boardgamestore_skinsinger.Data.Models;

namespace boardgamestore_skinsinger.Pages.BoardGames
{
    public class CreateModel : PageModel
    {
        private readonly boardgamestore_skinsinger.Data.ApplicationDbContext _context;

        public CreateModel(boardgamestore_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BoardGame BoardGame { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BoardGame == null || BoardGame == null)
            {
                return Page();
            }

            _context.BoardGame.Add(BoardGame);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
