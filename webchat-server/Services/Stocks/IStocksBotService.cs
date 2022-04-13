using jobsity_chat_app.Entities;

namespace jobsity_chat_app.Services.Stocks
{
    public interface IStocksBotService
    {
        public BotResponse BotCommand(string code);
    }
}