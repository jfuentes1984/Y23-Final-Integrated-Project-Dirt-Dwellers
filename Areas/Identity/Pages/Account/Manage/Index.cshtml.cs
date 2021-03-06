// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Y23_DirtDwellers.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly SignInManager<SiteUser> _signInManager;

        public IndexModel(
            UserManager<SiteUser> userManager,
            SignInManager<SiteUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>

            // [Display(Name = "Username")]
            // public string Username { get; set; }
            [Phone]
            [Display(Name = "Phone Number")]
            public string Phone { get; set; }
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Street Number")]
            [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
            public int StreetNumber { get; set; }
            [Display(Name = "Street Name")]
            public string StreetName { get; set; }
            [Display(Name = "Postal Code")]
            [RegularExpression(@"^[A-Za-z][0-9][A-Za-z][ ]*[0-9][A-Za-z][0-9]$", ErrorMessage = "Please enter postal code in A1A 1A1 format")]
            public string PostalCode { get; set; }
            [Display(Name = "City")]
            public string City { get; set; }
            [Display(Name = "Province")]
            public string Province { get; set; }

            [Display(Name = "Upload Your Picture!")]
            public string Picture { get; set; }

            [Display(Name = "User Type")]
            public UserType UserType { get; set; }

        }

        private async Task LoadAsync(SiteUser user)
        {
            var userEmail = await _userManager.GetEmailAsync(user);
            // var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Email = userEmail;

            Input = new InputModel
            {
                // Username = user.Username,
                Phone = user.Phone,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StreetNumber = user.StreetNumber,
                StreetName = user.StreetName,
                PostalCode = user.PostalCode,
                City = user.City,
                Province = user.Province,
                Picture = user.Picture,
                UserType = user.UserType
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.Phone = Input.Phone != user.Phone ? Input.Phone : user.Phone;
            // user.Username = Input.Username != user.Username ? Input.Username : user.Username;
            user.FirstName = Input.FirstName != user.FirstName ? Input.FirstName : user.FirstName;
            user.LastName = Input.LastName != user.LastName ? Input.LastName : user.LastName;
            user.StreetNumber = Input.StreetNumber != user.StreetNumber ? Input.StreetNumber : user.StreetNumber;
            user.StreetName = Input.StreetName != user.StreetName ? Input.StreetName : user.StreetName;
            user.PostalCode = Input.PostalCode != user.PostalCode ? Input.PostalCode : user.PostalCode;
            user.City = Input.City != user.City ? Input.City : user.City;
            user.Province = Input.Province != user.Province ? Input.Province : user.Province;
            user.Picture = Input.Picture != user.Picture ? Input.Picture : user.Picture;
            user.UserType = Input.UserType != user.UserType ? Input.UserType : user.UserType;
            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
