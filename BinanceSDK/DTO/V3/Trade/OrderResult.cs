using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3.Trade
{
	public class OrderResult : OrderAck
	{
		[JsonProperty("price")]
		public decimal Price;

		[JsonProperty("origQty")]
		public decimal OriginQuantity;

		[JsonProperty("executedQty")]
		public decimal ExecutedQuantity;

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

		/// <summary>
		/// This is only visible if the field was populated on order placement.
		/// </summary>
		[JsonProperty("strategyId")]
		public long StrategyID;

		/// <summary>
		/// This is only visible if the field was populated on order placement.
		/// </summary>
		[JsonProperty("strategyType")]
		public long StrategyType;

		[JsonProperty("workingTime")]
		public long WorkingTime;

		[JsonProperty("selfTradePreventionMode")]
		public TradePreventionMode SelfTradePreventionMode;
	}
}
