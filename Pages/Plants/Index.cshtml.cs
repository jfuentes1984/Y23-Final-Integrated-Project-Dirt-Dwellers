#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Y23_DirtDwellers.Models;

namespace Y23_DirtDwellers.Pages.Plants
{
    public class IndexModel : PageModel
    {
        private readonly DBContext _context;

        public IndexModel(DBContext context)
        {
            _context = context;
        }

        public IList<Y23_DirtDwellers.Models.Plant> Plants { get; set; }
        public string? UserEmail { get; set; }
        public int? UType { get; set; }
        public async Task OnGetAsync()
        {
            Plants = await _context.Plants.ToListAsync();
            if (User.Identity != null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                if (claimsIdentity.IsAuthenticated)
                {
                    var email = claimsIdentity.FindFirst(ClaimTypes.Email);

                    if (email != null)
                    {
                        UserEmail = email.Value;

                    }
                    // foreach (var cl in claimsIdentity.Claims)
                    // {
                    //    
                    // }
                }
            }

        }
    }
}
