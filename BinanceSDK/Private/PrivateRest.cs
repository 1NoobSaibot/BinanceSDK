using BinanceSDK.DTO;
using BinanceSDK.DTO.V1;
using BinanceSDK.DTO.V1.Snapshot;
using BinanceSDK.DTO.V1.Snapshot.Futures;
using BinanceSDK.DTO.V1.Snapshot.Margin;
using BinanceSDK.DTO.V1.Snapshot.Spot;
using BinanceSDK.DTO.V3.Trade;
using BinanceSDK.Helpers.WebClient;
using Newtonsoft.Json;

namespace BinanceSDK.Private
{
	public class PrivateRest : IPrivateRest
	{
		private readonly PrivateRestRaw _rawApi;


		public PrivateRest(Access access) {
			_rawApi = new PrivateRestRaw(access);
		}


		internal PrivateRest(Access access, IWebClient client) {
			_rawApi = new PrivateRestRaw(access, client);
		}


		public async Task<ApiKeyPermission> GetKeyPermission()
		{
			string json = await _rawApi.GetApiKeyPermissions();
			return JsonConvert.DeserializeObject<ApiKeyPermission>(json)!;
		}


		public async Task<Coin[]> GetCoinsAsync()
		{
			string json = await _rawApi.GetCoinsAsync();
			return JsonConvert.DeserializeObject<Coin[]>(json)!;
		}


		#region GettingSnapshots
		public async Task<SnapshotResponce<SpotSnapshotData>> GetSpotDailyAccountSnapshot(
			long startTime = 0,
			long endTime = 0,
			int limit = 7,
			long recvWindow = 0
		)
		{
			string json = await _rawApi.GetDailyAccountSnapshotAsync(
				SnapshotType.SPOT,
				startTime,
				endTime,
				limit,
				recvWindow
			);
			return JsonConvert.DeserializeObject<SnapshotResponce<SpotSnapshotData>>(json)!;
		}


		public async Task<SnapshotResponce<MarginSnapshotData>> GetMarginDailyAccountSnapshot(
			long startTime = 0,
			long endTime = 0,
			int limit = 7,
			long recvWindow = 0
		)
		{
			string json = await _rawApi.GetDailyAccountSnapshotAsync(
				SnapshotType.MARGIN,
				startTime,
				endTime,
				limit,
				recvWindow
			);
			return JsonConvert.DeserializeObject<SnapshotResponce<MarginSnapshotData>>(json)!;
		}


		public async Task<SnapshotResponce<FuturesSnapshotData>> GetFuturesDailyAccountSnapshot(
			long startTime = 0,
			long endTime = 0,
			int limit = 7,
			long recvWindow = 0
		)
		{
			string json = await _rawApi.GetDailyAccountSnapshotAsync(
				SnapshotType.FUTURES,
				startTime,
				endTime,
				limit,
				recvWindow
			);
			return JsonConvert.DeserializeObject<SnapshotResponce<FuturesSnapshotData>>(json)!;
		}
		#endregion


		public Task TestNewOrder(TradeRequest req)
		{
			return _rawApi.TestNewOrder(req);
		}


		public async Task<Withdraw> Withdraw(string coin, string address, decimal amount)
		{
			string json = await _rawApi.Withdraw(coin, address, amount);
			return JsonConvert.DeserializeObject<Withdraw>(json)!;
		}
	}
}