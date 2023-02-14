using BinanceSDK.DTO.V1;
using BinanceSDK.DTO.V3;
using Newtonsoft.Json;

namespace BinanceSDK.Public
{
	public class PublicRest : IPublicRest
	{
		private readonly PublicRestRaw _rawApi = new PublicRestRaw();


		public async Task<ExchangeInfo> GetExchangeInfo()
		{
			string json = await _rawApi.GetExchangeInfo();
			return JsonConvert.DeserializeObject<ExchangeInfo>(json)!;
		}


		public async Task<BookTicker[]> GetOrderBookTickers()
		{
			string json = await _rawApi.GetOrderBookTickers();
			return JsonConvert.DeserializeObject<BookTicker[]>(json)!;
		}


		public async Task<SystemStatus> GetSystemStatusAsync()
		{
			string json = await _rawApi.GetSystemStatusAsync();
			return JsonConvert.DeserializeObject<SystemStatus>(json)!;
		}


		public async Task<Ticker[]> GetTickersAsync()
		{
			string json = await _rawApi.GetTickersAsync();
			return JsonConvert.DeserializeObject<Ticker[]>(json)!;
		}


		public async Task<TickerPriceChangeFull[]> Get24hrTickerPriceChangeStatistics()
		{
			string json = await _rawApi.Get24hrTickerPriceChangeStatistic();
			return JsonConvert.DeserializeObject<TickerPriceChangeFull[]>(json)!;
		}


		public Task Ping()
		{
			return _rawApi.Ping();
		}
	}
}