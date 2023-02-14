using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3
{
	public class TickerPriceChangeFull
	{
		/// <summary>
		/// E.g.: "BNBBTC"
		/// </summary>
		[JsonProperty("symbol")]
		public string? SymbolName;

		[JsonProperty("priceChange")]
		public decimal PriceChange;

		[JsonProperty("priceChangePercent")]
		public decimal PriceChangePercent;

		[JsonProperty("weightedAvgPrice")]
		public decimal WeightedAvgPrice;

		[JsonProperty("prevClosePrice")]
		public decimal PrevClosePrice;

		[JsonProperty("lastPrice")]
		public decimal LastPrice;

		[JsonProperty("lastQty")]
		public decimal LastQty;

		[JsonProperty("bidPrice")]
		public decimal BidPrice;

		[JsonProperty("bidQty")]
		public decimal BidQty;

		[JsonProperty("askPrice")]
		public decimal AskPrice;

		[JsonProperty("askQty")]
		public decimal AskQty;

		[JsonProperty("openPrice")]
		public decimal OpenPrice;

		[JsonProperty("highPrice")]
		public decimal HighPrice;

		[JsonProperty("lowPrice")]
		public decimal LowPrice;

		[JsonProperty("volume")]
		public decimal Volume;

		[JsonProperty("quoteVolume")]
		public decimal QuoteVolume;

		[JsonProperty("openTime")]
		public long OpenTime;

		[JsonProperty("closeTime")]
		public long CloseTime;

		[JsonProperty("firstId")]
		public long FirstId;

		[JsonProperty("lastId")]
		public long LastId;

		[JsonProperty("count")]
		public int Count;
	}
}
