using BinanceSDK.Helpers;

namespace BinanceSDK.Private
{
	public class PrivateRestRaw
	{
		private readonly string _domain = "https://api.binance.com";
		private readonly Access _access;
		private readonly SignerHmac _signerHmac;


		public PrivateRestRaw(Access access) {
			_access = access;
			_signerHmac = new SignerHmac(access.SecretKey);
		}


		public async Task<string> GetCoinsAsync()
		{
			const string route = "/sapi/v1/capital/config/getall";
			string query = $"timestamp={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
			string signature = _signerHmac.Sign(query);

			string url = $"{_domain}{route}?{query}&signature={signature}";
			using (MyClient client = new MyClient())
			{
				var req = new HttpRequestMessage(HttpMethod.Get, url);
				req.Headers.Add("X-MBX-APIKEY", _access.ApiKey);
				
				return await client.Send(req);
			}
		}
	}
}