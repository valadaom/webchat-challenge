using jobsity_chat_app.Models;
using Microsoft.AspNetCore.Mvc;
using StocksBot.Services.StocksBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksBotController : ControllerBase
    {
        private readonly IStocksBotService _stocksBotService;

        public StocksBotController(IStocksBotService stocksBotService)
        {
            _stocksBotService = stocksBotService;
        }

        [HttpGet("getStock")]
        public ActionResult<Stock> GetStock([FromQuery]string stockCode)
        {
            try
            {
                Stock stock = _stocksBotService.GetStock(stockCode);
                return Ok(stock);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
