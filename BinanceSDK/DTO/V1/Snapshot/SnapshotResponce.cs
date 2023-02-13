using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot
{
	public class SnapshotResponce<T>
	{
		/// <summary>
		/// 200 for success; others are error codes
		/// </summary>
		[JsonProperty("code")]
		public int Code;

		[JsonProperty("msg")]
		public string Message = string.Empty;

		[JsonProperty("snapshotVos")]
		public SnapshotBody<T>[]? Snapshots;
	}
}
