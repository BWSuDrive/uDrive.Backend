using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace uDrive.Backend.Pages.Areas.Secretariat.Pages.Verify
{
    [Authorize(Policy = "Secretaries")]

    public class IndexModel : PageModel
    {
        private readonly UserManager<Person> _userManager;
        private readonly IUserStore<Person> _userStore;
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<Person> userManager,
            IUserStore<Person> userStore,
            ILogger<IndexModel> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _logger = logger;
            _context = context;
        }

        public string CurrentFilter { get; set; }

        [BindProperty]
        public string Id{ get; set; }

        [BindProperty]
        public List<Person> Users { get; set; }

        public async Task OnGetAsync(string searchString) => await PopulateAsync(searchString);

        public async Task PopulateAsync(string searchString)
        {
            var getUsers = await _context.Persons.ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                getUsers = getUsers.Where(x => x.Lastname.Contains(searchString) || x.Firstname.Contains(searchString)).ToList();
            }
            var persons = getUsers.Where(x => !x.Verified);
            Users = persons.ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var us = await _userManager.FindByIdAsync(Id).ConfigureAwait(false);
            us.Verified = true;
            us.PhoneNumberConfirmed = true;
            await _userManager.AddToRoleAsync(us,UDriveRoles.Person).ConfigureAwait(false);
            await _context.SaveChangesAsync();
            await PopulateAsync("");
            return Page();

        }
    }
}
