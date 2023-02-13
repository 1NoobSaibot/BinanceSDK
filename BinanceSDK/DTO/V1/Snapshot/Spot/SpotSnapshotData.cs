using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot.Spot
{
	public sealed class SpotSnapshotData {
		[JsonProperty("balances")]
		public Balance[]? Balances;

		[JsonProperty("totalAssetOfBtc")]
		public decimal TotalAssetOfBtc;
	}
}
