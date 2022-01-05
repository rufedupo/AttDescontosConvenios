using AttDescontosConvenios.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AttDescontosConvenios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly IConvenioService _convenioService;

        public MainController(IConvenioService convenioService)
        {
            _convenioService = convenioService;
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarConvenios()
        {
            try
            {
                await _convenioService.AtualizarConvenios();

                return Ok(new { Success = true, Message = "Dados consultados com sucesso." });
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}
