using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3
{
	public class Symbol
	{
		[JsonProperty("symbol")]
		public string? Name;

		[JsonProperty("status")]
		public SymbolStatus Status;

		[JsonProperty("baseAsset")]
		public string? BaseAsset;

		[JsonProperty("baseAssetPrecision")]
		public int BaseAssetPrecision;

		[JsonProperty("quoteAsset")]
		public string? QuoteAsset;

		[JsonProperty("quotePrecision")]
		public int QuotePrecission;

		[JsonProperty("quoteAssetPrecision")]
		public int QuoteAssetPrecission;

		[JsonProperty("orderTypes")]
		public OrderType[]? OrderTypes;

		[JsonProperty("icebergAllowed")]
		public bool IcebergAllowed;

		[JsonProperty("ocoAllowed")]
		public bool OcoAllowed;

		[JsonProperty("quoteOrderQtyMarketAllowed")]
		public bool QuoteOrderQtyMarketAllowed;

		[JsonProperty("allowTrailingStop")]
		public bool TrailingStopAllowed;

		[JsonProperty("cancelReplaceAllowed")]
		public bool CancelReplaceAllowed;

		[JsonProperty("isSpotTradingAllowed")]
		public bool IsSpotTradingAllowed;

		[JsonProperty("isMarginTradingAllowed")]
		public bool IsMarginTradingAllowed;

		/// <summary>
		/// These are defined in the Filters section.
		/// All filters are optional
		/// </summary>
		[JsonProperty("filters")]
		public Dictionary<string, object>[]? Filters;

		[JsonProperty("permissions")]
		public SymbolPermissions[]? Permissions;

		[JsonProperty("defaultSelfTradePreventionMode")]
		public string? DefaultSelfTradePreventionMode;

		[JsonProperty("allowedSelfTradePreventionModes")]
		public string[]? AllowedSelfTradePreventionModes;
	}
}
