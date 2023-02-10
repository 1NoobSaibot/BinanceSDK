using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1
{
	public class SystemStatus
	{
		public const int NormalStatusCode = 0;
		public const int MaintenanceStatusCode = 1;
		public const string NormalStatusMessage = "normal";
		public const string MaintenanceStatusMessage = "system_maintenance";

		[JsonProperty("status")]
		public int Code;

		[JsonProperty("msg")]
		public string? Message;
	}
}
