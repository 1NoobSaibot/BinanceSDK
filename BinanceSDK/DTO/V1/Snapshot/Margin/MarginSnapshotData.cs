using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot.Margin
{
	public sealed class MarginSnapshotData {
		[JsonProperty("totalAssetOfBtc")]
		public decimal TotalAssetOfBtc;

		[JsonProperty("marginLevel")]
		public decimal MarginLevel;

		[JsonProperty("totalLiabilityOfBtc")]
		public decimal TotalLiabilityOfBtc;

		[JsonProperty("totalNetAssetOfBtc")]
		public decimal TotalNetAssetOfBtc;

		[JsonProperty("userAssets")]
		public UserAsset[]? UserAssets;
	}
}
