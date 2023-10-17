using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        readonly AdvisorService _advisorService;

        public AdvisorController (AdvisorService advisorService )
        {
            _advisorService = advisorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvisor ( [FromBody] Advisor advisor )
        {

            await _advisorService.CreateAdvisorAsync(advisor);
            return Ok();
            
        }
    }
}
