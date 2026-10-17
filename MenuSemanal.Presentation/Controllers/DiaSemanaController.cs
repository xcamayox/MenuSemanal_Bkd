using MenuSemanal.Application.DTOs;
using MenuSemanal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemanal.Presentation.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DiaSemanaController : ControllerBase
    {
        private readonly IDiaSemanaService _diasemanaService;

        public DiaSemanaController(IDiaSemanaService diasemanaService)
        {
            _diasemanaService = diasemanaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _diasemanaService.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _diasemanaService.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

       
    }
}

