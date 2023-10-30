﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using boardgamestore_skinsinger.Data;
using boardgamestore_skinsinger.Data.Models;

namespace boardgamestore_skinsinger.Pages.BoardGames
{
    public class DeleteModel : PageModel
    {
        private readonly boardgamestore_skinsinger.Data.ApplicationDbContext _context;

        public DeleteModel(boardgamestore_skinsinger.Data.ApplicationDbContext context)
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

            var boardgame = await _context.BoardGame.FirstOrDefaultAsync(m => m.Id == id);

            if (boardgame == null)
            {
                return NotFound();
            }
            else 
            {
                BoardGame = boardgame;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BoardGame == null)
            {
                return NotFound();
            }
            var boardgame = await _context.BoardGame.FindAsync(id);

            if (boardgame != null)
            {
                BoardGame = boardgame;
                _context.BoardGame.Remove(BoardGame);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
