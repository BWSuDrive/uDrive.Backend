using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace uDrive.Backend.Pages.Areas.Secretariat.Pages.Drivers
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
        public List<Person> Users { get; set; }

        [BindProperty]
        public Driver NewDriver { get; set; }

        [BindProperty]
        public DrivingLicence Licence { get; set; }
        public async Task OnGetAsync(string searchString) => await PopulateAsync(searchString);
        
        public async Task PopulateAsync(string searchString) {
            var getUsers = await _context.Persons.AsTracking().Include(drivers => drivers.Driver).ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                getUsers = getUsers.Where(x => x.Lastname.Contains(searchString) || x.Firstname.Contains(searchString)).ToList();
            }
            var persons = getUsers.Where(x => x.Driver is null);
            Users = persons.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
         

            var addLicence = await _context.DrivingLicences.AddAsync(Licence).ConfigureAwait(false);
            var saveLicence = addLicence.Entity;
            if (saveLicence is null)
            {
                return NotFound();
            }

            NewDriver.IdDrivinglicense = saveLicence.Id;
            var addDriver = await _context.Drivers.AddAsync(NewDriver).ConfigureAwait(false);
            var saveDriver = addDriver.Entity;
            if (saveDriver is null)
            {
                return NotFound();
            }
            var us = await _userManager.FindByIdAsync(NewDriver.IdPerson).ConfigureAwait(false);
            if (us is null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(us, UDriveRoles.Driver);
            await _context.SaveChangesAsync();
            await PopulateAsync("");
            return Page();

        }
    }
}
