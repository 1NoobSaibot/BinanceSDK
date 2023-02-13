using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot.Margin
{
	public class UserAsset {
		[JsonProperty("asset")]
		public string? Asset;

		[JsonProperty("free")]
		public decimal Free;

		[JsonProperty("locked")]
		public decimal Locked;

		[JsonProperty("borrowed")]
		public decimal Borrowed;

		[JsonProperty("interest")]
		public decimal Interest;

		[JsonProperty("netAsset")]
		public decimal NetAsset;
	}
}
