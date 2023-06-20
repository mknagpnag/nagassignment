using Microsoft.AspNetCore.Mvc;

namespace OrgDetails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrgDetailsController : ControllerBase
    {
        private readonly ILogger<OrgDetailsController> _logger;

        private readonly OrgDetailsContext _context;
        public OrgDetailsController(ILogger<OrgDetailsController> logger, OrgDetailsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetEmployeeDetails")]
        public IEnumerable<EmployeeDetail> Get()
        {
            return _context.EmployeeDetails.ToList();
        }
    }
}