using BinanceSDK.Helpers.WebClient;

namespace BinanceSDK.Public
{
	public class PublicRestRaw
	{
		private readonly string _domain = "https://api.binance.com";

		public async Task<string> GetTickersAsync()
		{
			const string route = "/api/v3/ticker/24hr";
			using (MyClient client = new MyClient())
			{
				var req = new HttpRequestMessage(HttpMethod.Get, _domain + route);
				return await client.Send(req);
			}
		}


		public async Task<string> GetSystemStatusAsync()
		{
			const string route = "/sapi/v1/system/status";
			using (MyClient client = new MyClient())
			{
				HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, _domain + route);
				return await client.Send(req);
			}
		}
	}
}