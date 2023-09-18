using Microsoft.AspNetCore.Mvc;

using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace uDrive.Backend.Api.Controllers.V1;

[Produces(Application.Json)]
[Consumes(Application.Json)]

[Route("api/[controller]")]
[ApiController]
public class RESTTestController : ControllerBase
{
    private readonly ILogger<RESTTestController> _logger;

    public RESTTestController(ILogger<RESTTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        return Ok("Hello World");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok("Hello World, your id is " + id);
    }

    public class TestPost
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Number { get; set; }
        public DateTime TestDate { get; set; }

    }


    [HttpPost]
    public async Task<ActionResult<TestPost>> PostAsync(TestPost testPost)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (testPost.Id == "-1")
        {
            return BadRequest("Negativ Id");
        }

        return Ok();
    }
}
