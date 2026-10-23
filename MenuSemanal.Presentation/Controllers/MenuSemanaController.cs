using MenuSemanal.Application.DTOs;
using MenuSemanal.Application.Interfaces;
using MenuSemanal.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var menus = await _menusemanaService.GetAllAsync();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menu = await _menusemanaService.GetByIdAsync(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuSemanaDto dto)
        {
            var nuevoMenu = await _menusemanaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevoMenu.Id }, nuevoMenu);
        }

        [HttpPost("reemplazar")]
        public async Task<IActionResult> ReemplazarMenuAsync([FromBody] List<MenuSemanaDto> dto)
        {
            var nuevoMenu = await _menusemanaService.ReemplazarMenuAsync(dto);
            if (!nuevoMenu) return NotFound();
            return NoContent();
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

        [HttpDelete("Limpiar/{idusuario}")]
        public async Task<IActionResult> DeleteByUsuario(int idusuario)
        {
            var result = await _menusemanaService.DeleteByUsuario(idusuario);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

