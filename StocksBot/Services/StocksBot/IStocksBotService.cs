using jobsity_chat_app.Models;

namespace StocksBot.Services.StocksBot
{
    public interface IStocksBotService
    {
        Stock GetStock(string code);
    }
}