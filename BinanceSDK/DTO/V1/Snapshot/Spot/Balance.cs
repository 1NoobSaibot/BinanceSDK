using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot.Spot
{
	public class Balance {
		[JsonProperty("asset")]
		public string? Asset;

		[JsonProperty("free")]
		public decimal Free;

		[JsonProperty("locked")]
		public decimal Locked;
	}
}
