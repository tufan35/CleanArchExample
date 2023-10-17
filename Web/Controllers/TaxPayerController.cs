using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxPayerController : ControllerBase
    {
        readonly TaxPayerService _taxPayerService;

        public TaxPayerController ( TaxPayerService taxPayerService, AdvisorService advisorService )
        {
            _taxPayerService = taxPayerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxPayer>>> GetAll ()
        {
            var taxPayers = await _taxPayerService.GetAllTaxPayersAsync();
            return Ok(taxPayers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaxPayer ( Guid id )
        {
            var taxPayer = await _taxPayerService.GetTaxPayerById(id);
            if (taxPayer == null)
                return NotFound();
            return Ok(taxPayer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaxPayer ( [FromBody] TaxPayer taxPayer )
        {
            await _taxPayerService.CreateTaxPayerAsync(taxPayer);
            return CreatedAtAction(nameof(GetTaxPayer), new { id = taxPayer.Id }, taxPayer);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxPayer ( Guid id, [FromBody] TaxPayer taxPayer )
        {
            if (id != taxPayer.Id)
            {
                return BadRequest();
            }

            var existingItem = await _taxPayerService.GetTaxPayerById(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            await _taxPayerService.UpdateTaxPayerAsync(taxPayer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxPayer ( TaxPayer taxPayer )
        {
            var item = await _taxPayerService.GetTaxPayerById(taxPayer.Id);
            if (item == null)
            {
                return NotFound();
            }

            await _taxPayerService.DeleteTaxPayerAsync(taxPayer);
            return NoContent();
        }

    }
}
