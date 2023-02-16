using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3.Trade
{
	public class CancelOrderResponse
	{
		[JsonProperty("symbol")]
		public string? Symbol;

		[JsonProperty("origClientOrderId")]
		public string? OrigClientOrderID;

		[JsonProperty("orderId")]
		public long OrderID;

		/// <summary>
		/// Unless part of an OCO, the value will always be -1.
		/// </summary>
		[JsonProperty("orderListId")]
		public long OrderListID;

		[JsonProperty("clientOrderId")]
		public string? ClientOrderID;

		[JsonProperty("price")]
		public decimal Price;

		[JsonProperty("origQty")]
		public decimal OrigQty;

		[JsonProperty("executedQty")]
		public decimal ExecutedQty;

		[JsonProperty("cummulativeQuoteQty")]
		public decimal CummulativeQuoteQty;

		[JsonProperty("status")]
		public OrderStatus Status;

		[JsonProperty("timeInForce")]
		public TimeInForce TimeInForce;

		[JsonProperty("type")]
		public OrderType Type;

		[JsonProperty("side")]
		public OrderSide Side;

		[JsonProperty("selfTradePreventionMode")]
		public TradePreventionMode SelfTradePreventionMode;
	}
}
