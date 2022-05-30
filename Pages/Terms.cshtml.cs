using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Y23_DirtDwellers.Pages;

public class TermsofUseModel : PageModel
{
    private readonly ILogger<TermsofUseModel> _logger;

    public TermsofUseModel(ILogger<TermsofUseModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

