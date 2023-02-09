using System.Net;

namespace BinanceSDK.Public
{
	public class PublicRestRaw
	{
		public string GetTickers()
		{
			string url = "https://api.binance.com" + "/api/v3/ticker/24hr";
			using (WebClient client = new WebClient())
			{
				return client.DownloadString(url);
			}
		}
	}
}