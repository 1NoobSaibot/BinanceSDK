using BinanceSDK.DTO.V3;
using Newtonsoft.Json;
using System.Net;

namespace BinanceSDK
{
	public class PublicRest
	{
		public Ticker[] GetTickers()
		{
			string url = "https://api.binance.com" + "/api/v3/ticker/24hr";
			string json = String.Empty;

			using (WebClient client = new WebClient())
			{
				json = client.DownloadString(url);
			}

			Ticker[] tickers = JsonConvert.DeserializeObject<Ticker[]>(json);

			return tickers;
		}
	}
}