using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot.Futures
{
	public class Asset
	{
		[JsonProperty("asset")]
		public string? Name;

		[JsonProperty("marginBalance")]
		public decimal MarginBalance;

		[JsonProperty("walletBalance")]
		public decimal WalletBalance;
	}
}
