using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CartaoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarCartoes = await _context.CartaoCredito.ToListAsync();
                return Ok(listarCartoes);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<CartaoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartaoCredito cartao)
        {
            try
            {
                _context.Add(cartao);
                await _context.SaveChangesAsync();
                return Ok(cartao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CartaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CartaoCredito cartao)
        {
            try
            {
                if(id != cartao.Id)
                {
                    return NotFound();
                }
                else
                {
                     _context.Update(cartao);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "O cartão foi atualizado com exito!" } );
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CartaoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cartao = await _context.CartaoCredito.FindAsync(id);
                
                if (cartao == null)
                {
                    return NotFound();
                }
                _context.CartaoCredito.Remove(cartao);
                await _context.SaveChangesAsync();
                return Ok(new { message = "O cartão foi eliminado com exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
