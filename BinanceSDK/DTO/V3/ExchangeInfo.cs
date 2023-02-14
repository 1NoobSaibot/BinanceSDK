using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3
{
	public class ExchangeInfo
	{
		[JsonProperty("timezone")]
		public string? Timezone;

		[JsonProperty("serverTime")]
		public long ServerTime;

		/// <summary>
		/// These are defined in the `ENUM definitions` section under `Rate Limiters (rateLimitType)`.
		/// All limits are optional
		/// </summary>
		[JsonProperty("rateLimits")]
		public RateLimit[]? RateLimits;

		// TODO: Make Filter as a big universal class with nullable fields
		/// <summary>
		/// These are the defined filters in the `Filters` section.
		/// All filters are optional.
		/// </summary>
		[JsonProperty("exchangeFilters")]
		public Dictionary<string, object>[]? ExchangeFilters;

		[JsonProperty("symbols")]
		public Symbol[]? Symbols;
	}
}
