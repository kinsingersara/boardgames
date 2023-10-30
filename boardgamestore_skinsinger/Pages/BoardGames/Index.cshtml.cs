using System;
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
    public class IndexModel : PageModel
    {
        private readonly boardgamestore_skinsinger.Data.ApplicationDbContext _context;

        public IndexModel(boardgamestore_skinsinger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BoardGame> BoardGame { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BoardGame != null)
            {
                BoardGame = await _context.BoardGame.ToListAsync();
            }
        }
    }
}
