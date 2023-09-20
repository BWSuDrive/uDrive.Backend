using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;
using Microsoft.AspNetCore.Authorization;

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

        public List<Person> Users { get; set; }

        public void OnGet()
        {

            Users = _context.Persons.ToList();

        }
    }
}
