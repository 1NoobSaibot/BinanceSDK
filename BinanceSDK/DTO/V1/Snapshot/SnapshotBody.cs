using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot
{
	public class SnapshotBody<T>
	{
		[JsonProperty("data")]
		public T? Data;

		[JsonProperty("type")]
		public string? Type;

		[JsonProperty("updateTime")]
		public long UpdatedAt;
	}
}
