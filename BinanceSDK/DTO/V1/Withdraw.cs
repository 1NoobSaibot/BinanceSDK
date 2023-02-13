using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1
{
	public class Withdraw
	{
		/// <summary>
		/// E.g.: "7213fea8e94b4a5593d507237e5a555b"
		/// </summary>
		[JsonProperty("id")]
		public string? ID;
	}
}
