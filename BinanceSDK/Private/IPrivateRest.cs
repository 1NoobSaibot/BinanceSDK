using BinanceSDK.DTO.V1;
using BinanceSDK.DTO.V1.Snapshot.Futures;
using BinanceSDK.DTO.V1.Snapshot.Margin;
using BinanceSDK.DTO.V1.Snapshot.Spot;
using BinanceSDK.DTO.V1.Snapshot;

namespace BinanceSDK.Private
{
	public interface IPrivateRest
	{
		/// <summary>
		/// Get information of coins (available for deposit and withdraw) for user.
		/// </summary>
		Task<Coin[]> GetCoinsAsync();


		#region Getting Snapshots
		Task<SnapshotResponce<SpotSnapshotData>> GetSpotDailyAccountSnapshot(
			long startTime = 0,
			long endTime = 0,
			int limit = 7,
			long recvWindow = 0
		);


		Task<SnapshotResponce<MarginSnapshotData>> GetMarginDailyAccountSnapshot(
			long startTime = 0,
			long endTime = 0,
			int limit = 7,
			long recvWindow = 0
		);


		Task<SnapshotResponce<FuturesSnapshotData>> GetFuturesDailyAccountSnapshot(
			long startTime = 0,
			long endTime = 0,
			int limit = 7,
			long recvWindow = 0
		);
		#endregion

		Task<Withdraw> Withdraw(string coin, string address, decimal amount);
	}
}