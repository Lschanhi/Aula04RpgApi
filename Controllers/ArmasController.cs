using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {


        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }

         [HttpGet ("GetAll")]
            public async Task<IActionResult> Get()
            {
                try
                {
                    List<Armas> lista = await _context.TB_ARMAS.ToListAsync();
                    return Ok(lista);
                
                }
                    catch (System.Exception ex)
                {
                
                    return BadRequest(ex.Message);
                }

        }



   
    }
}