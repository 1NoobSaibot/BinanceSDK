using BinanceSDK.DTO;
using BinanceSDK.Helpers.WebClient;

namespace BinanceSDK.Private
{
	public class PrivateRestRaw : IDisposable
	{
		private readonly string _domain = "https://api.binance.com";
		private readonly Access _access;
		private readonly SignerHmac _signerHmac;
		private IWebClient _client;


		public PrivateRestRaw(Access access)
			: this(access, new MyClient())
		{ }


		internal PrivateRestRaw(Access access, IWebClient client)
		{
			_access = access;
			_client = client;
			_signerHmac = new SignerHmac(access.SecretKey);
		}


		public async Task<string> GetApiKeyPermissions()
		{
			const string route = "/sapi/v1/account/apiRestrictions";
			return await _Get(route);
		}


		public async Task<string> GetCoinsAsync()
		{
			const string route = "/sapi/v1/capital/config/getall";
			return await _Get(route);
		}


		/// <summary>
		/// The query time period must be less then 30 days
		/// Support query within the last one month only
		/// If startTime and endTime not sent, return records of the last 7 days by default
		/// </summary>
		/// <param name="type"></param>
		/// <param name="startTime"></param>
		/// <param name="endTime"></param>
		/// <param name="limit"></param>
		/// <param name="recvWindow"></param>
		/// <returns></returns>
		public async Task<string> GetDailyAccountSnapshotAsync(
			SnapshotType type,
			long startTime = 0,
			long endTime = 0,
			int limit = 7,
			long recvWindow = 0
		)
		{
			const string route = "/sapi/v1/accountSnapshot";
			string query = $"type={type}";
			if (startTime != 0)
			{
				query += $"&startTime={startTime}";
			}
			if (endTime != 0)
			{
				query += $"endTime={endTime}";
			}
			if (limit != 7)
			{
				query += $"&limit={limit}";
			}
			if (recvWindow != 0)
			{
				query += $"&reqvWindow={recvWindow}";
			}

			return await _Get(route, query);
		}


		public async Task TestNewOrder()
		{
			const string route = "/api/v3/order/test";
			await _Post(route);
		}


		public async Task<string> Withdraw(
			string coin,
			string address,
			decimal amount
		)
		{
			const string route = "/sapi/v1/capital/withdraw/apply";
			string query = $"coin={coin}&address={address}&amount={amount}";

			return await _Post(route, query);
		}


		private static long _TS()
		{
			return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		}


		public void Dispose()
		{
			if (_client is IDisposable disposable)
			{
				disposable.Dispose();
			}
			_signerHmac.Dispose();
		}


		private Task<string> _Get(string route, string? query = null)
		{
			return _Send(route, query, HttpMethod.Get);
		}


		private Task<string> _Post(string route, string? query = null)
		{
			return _Send(route, query, HttpMethod.Post);
		}


		private Task<string> _Send(string route, string? query, HttpMethod method)
		{
			if (string.IsNullOrEmpty(query))
			{
				query = $"timestamp={_TS()}";
			}
			else
			{
				query += $"&timestamp={_TS()}";
			}

			string signature = _signerHmac.Sign(query);
			string url = $"{_domain}{route}?{query}&signature={signature}";

			var req = new HttpRequestMessage(method, url);
			req.Headers.Add("X-MBX-APIKEY", _access.ApiKey);

			return _client.Send(req);
		}
	}
}