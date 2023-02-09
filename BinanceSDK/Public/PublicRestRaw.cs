using BinanceSDK.Helpers;

namespace BinanceSDK.Public
{
	public class PublicRestRaw
	{
		public async Task<string> GetTickersAsync()
		{
			string url = "https://api.binance.com" + "/api/v3/ticker/24hr";
			using (MyClient client = new MyClient())
			{
				HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, url);
				return await client.Send(req);
			}
		}
	}
}