using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot.Futures
{
	public class FuturesSnapshotData {
		[JsonProperty("assets")]
		public Asset[]? Assets;

		[JsonProperty("position")]
		public Position[]? Positions;
	}
}
