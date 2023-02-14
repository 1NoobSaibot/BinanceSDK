using BinanceSDK.DTO.V1;
using BinanceSDK.DTO.V3;

namespace BinanceSDK.Public
{
	public interface IPublicRest
	{
		Task<ExchangeInfo> GetExchangeInfo();

		/// <summary>
		/// Best price/qty on the order book for a symbol or symbols.
		/// </summary>
		Task<BookTicker[]> GetOrderBookTickers();
		Task<SystemStatus> GetSystemStatusAsync();
		Task<Ticker[]> GetTickersAsync();
		Task<TickerPriceChangeFull[]> Get24hrTickerPriceChangeStatistics();
		Task Ping();
	}
}