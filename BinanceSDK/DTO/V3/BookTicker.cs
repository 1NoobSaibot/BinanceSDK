using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3
{
	public class BookTicker
	{
		[JsonProperty("symbol")]
		public string? SymbolName;

		[JsonProperty("bidPrice")]
		public decimal BidPrice;

		[JsonProperty("bidQty")]
		public decimal BidQuantity;

		[JsonProperty("askPrice")]
		public decimal AskPrice;

		[JsonProperty("askQty")]
		public decimal AskQuantity;
	}
}
