using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3
{
	public class RateLimit
	{
		[JsonProperty("rateLimitType")]
		public RateLimitType Type;

		[JsonProperty("interval")]
		public RateLimitInterval Interval;

		[JsonProperty("intervalNum")]
		public int IntervalNum;

		[JsonProperty("limit")]
		public int Limit;
	}
}
