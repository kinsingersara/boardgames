using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using boardgamestore_skinsinger.Data;
using boardgamestore_skinsinger.Data.Models;

namespace boardgamestore_skinsinger.Pages.BoardGames
{
    public class EditModel : PageModel
    {
        private readonly boardgamestore_skinsinger.Data.ApplicationDbContext _context;

        public EditModel(boardgamestore_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BoardGame BoardGame { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BoardGame == null)
            {
                return NotFound();
            }

            var boardgame =  await _context.BoardGame.FirstOrDefaultAsync(m => m.Id == id);
            if (boardgame == null)
            {
                return NotFound();
            }
            BoardGame = boardgame;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BoardGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardGameExists(BoardGame.Id))
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

        private bool BoardGameExists(int id)
        {
          return (_context.BoardGame?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
