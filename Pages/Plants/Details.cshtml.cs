#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Y23_DirtDwellers.Models;

namespace Y23_DirtDwellers.Pages.Plants
{
    public class DetailsModel : PageModel
    {
        private readonly DBContext _context;

        public DetailsModel(DBContext context)
        {
            _context = context;
        }

        public Y23_DirtDwellers.Models.Plant Plant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plant = await _context.Plants.FirstOrDefaultAsync(m => m.PlantId == id);

            if (Plant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
