using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace uDrive.Backend.Pages.Areas.Secretariat.Pages.AddToRole
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
        public string Id { get; set; }

        [BindProperty]
        public List<Person> Users { get; set; } = new List<Person>();

        public async Task OnGetAsync(string searchString) => await PopulateAsync(searchString);

        public async Task PopulateAsync(string searchString)
        {
            CurrentFilter = searchString;

            var getUsers = await _context.Persons.ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
               getUsers= getUsers.Where( x => x.Lastname.Contains(searchString) || x.Firstname.Contains(searchString)).ToList();
            }
            foreach (var user in getUsers)
            {
                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                if (!roles.Contains("Secretary"))
                {
                    Users.Add(user);
                }
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var us = await _userManager.FindByIdAsync(Id).ConfigureAwait(false);
            await _userManager.AddToRoleAsync(us, UDriveRoles.Secretary).ConfigureAwait(false);

            await _context.SaveChangesAsync();
            await PopulateAsync("");
            return Page();

        }
    }
}
