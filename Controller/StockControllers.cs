using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using api.Mappers;
using api.Dtos;
using api.Dtos.Stock; // Ensure this is the correct namespace for StockDto
namespace api.Controller
{
    [Route("/api/stock/")]
    [ApiController]
    public class StockControllers: ControllerBase
    {
       public StockControllers(ApplicationDBContext context)
        {
            _context = context;
        }
        private readonly ApplicationDBContext _context;
        [HttpGet]
      public IActionResult GetAll()
      {
        var stocks =_context.Stocks.ToList().Select(s=>s.ToStockDto());
        return Ok(stocks);
      }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
        [HttpPost]
        public IActionResult Creeate([FromBody] StockDto stockDto)
        {
            var stock = stockDto.ToModel();
            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
        }
    }
}