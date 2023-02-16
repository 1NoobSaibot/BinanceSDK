using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3.Trade
{
	public class OrderFull : OrderResult
	{
		[JsonProperty("fills")]
		public OrderFill[]? Fills;
	}


	public class OrderFill
	{
		[JsonProperty("price")]
		public decimal Price;

		[JsonProperty("qty")]
		public decimal Quantity;

		[JsonProperty("commission")]
		public decimal Comission;

		[JsonProperty("commissionAsset")]
		public string? CommissionAsset;

		[JsonProperty("tradeId")]
		public long TradeID;
	}
}
