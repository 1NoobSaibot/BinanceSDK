using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3
{
	public class Ticker
	{
		[JsonProperty("symbol")]
		public string Symbol;

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

		/// <summary>
		/// TODO: Check the value
		/// </summary>
		[JsonProperty("lastQty")]
		public decimal LastPriceQuote;

		[JsonProperty("bidPrice")]
		public decimal BidPrice;

		/// <summary>
		/// TODO: Check the value
		/// </summary>
		[JsonProperty("bidQty")]
		public decimal BidQuote;

		[JsonProperty("askPrice")]
		public decimal AskPrice;

		/// <summary>
		/// TODO: Check the value
		/// </summary>
		[JsonProperty("askQty")]
		public decimal AskPriceQuote;

		[JsonProperty("openPrice")]
		public decimal OpenPrice;

		[JsonProperty("highPrice")]
		public decimal HighPrice;

		[JsonProperty("lowPrice")]
		public decimal LowPrice;

		[JsonProperty("volume")]
		public decimal Volume;

		[JsonProperty("quoteVolume")]
		public decimal VolumeQuote;

		[JsonProperty("openTime")]
		public long OpenTime;

		[JsonProperty("closeTime")]
		public long CloseTime;

		[JsonProperty("firstId")]
		public long FirstTradeId;

		[JsonProperty("lastId")]
		public long LastTraadeId;

		[JsonProperty("count")]
		public int TradeCount;
	}
}
