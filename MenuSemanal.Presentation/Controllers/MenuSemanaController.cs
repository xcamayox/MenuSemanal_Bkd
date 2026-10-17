using MenuSemanal.Application.DTOs;
using MenuSemanal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemanal.Presentation.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class MenuSemanaController : ControllerBase
    {
        private readonly IMenuSemanaService _menusemanaService;

        public MenuSemanaController(IMenuSemanaService menusemanaService)
        {
            _menusemanaService = menusemanaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var platos = await _menusemanaService.GetAllAsync();
            return Ok(platos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plato = await _menusemanaService.GetByIdAsync(id);
            if (plato == null) return NotFound();
            return Ok(plato);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuSemanaDto dto)
        {
            var nuevoPlato = await _menusemanaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPlato.Id }, nuevoPlato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMenuSemanaDto dto)
        {
            var result = await _menusemanaService.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _menusemanaService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

