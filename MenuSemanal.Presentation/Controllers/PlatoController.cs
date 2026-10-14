using MenuSemanal.Application.DTOs;
using MenuSemanal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemanal.Presentation.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PlatosController : ControllerBase
    {
        private readonly IPlatoService _platoService;

        public PlatosController(IPlatoService platoService)
        {
            _platoService = platoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var platos = await _platoService.GetAllAsync();
            return Ok(platos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plato = await _platoService.GetByIdAsync(id);
            if (plato == null) return NotFound();
            return Ok(plato);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlatoDto dto)
        {
            var nuevoPlato = await _platoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPlato.Id }, nuevoPlato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePlatoDto dto)
        {
            var result = await _platoService.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _platoService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

