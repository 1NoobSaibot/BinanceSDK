using BinanceSDK.Helpers.WebClient;

namespace BinanceSDK.Public
{
	public class PublicRestRaw
	{
		private readonly string _domain = "https://api.binance.com";
		private readonly IWebClient _client;


		public PublicRestRaw()
		{
			_client = new MyClient();
		}


		public Task<string> GetExchangeInfo()
		{
			const string route = "/api/v3/exchangeInfo";
			return _Get(_domain + route);
		}


		public Task<string> GetTickersAsync()
		{
			const string route = "/api/v3/ticker/24hr";
			return _Get(_domain + route);
		}


		public Task<string> GetSystemStatusAsync()
		{
			const string route = "/sapi/v1/system/status";
			return _Get(_domain + route);
		}

		public Task Ping()
		{
			const string route = "/api/v3/ping";
			return _Get(_domain + route);
		}


		private Task<string> _Get(string url)
		{
			var req = new HttpRequestMessage(HttpMethod.Get, url);
			return _client.Send(req);
		}
	}
}