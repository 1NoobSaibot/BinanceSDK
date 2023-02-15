using BinanceSDK.Helpers.Request;

namespace BinanceSDK.DTO.V3.Trade
{
	public class TradeRequest : Req
	{
		[Query("symbol")]
		public readonly string Symbol;

		[Query("side")]
		public readonly OrderSide Side;

		[Query("type")]
		public readonly OrderType Type;

		[Query("timeInForce")]
		public TimeInForce? TimeInForce;

		[Query("quantity")]
		public decimal? Quantity;

		[Query("quoteOrderQty")]
		public decimal? QuoteOrderQuantity;

		[Query("price")]
		public decimal? Price;
		/// <summary>
		/// A unique id among open orders.Automatically generated if not sent.
		/// </summary>
		[Query("newClientOrderId")]
		public string? NewClientOrderId;

		[Query("strategyId")]
		public int? StrategyId;

		/// <summary>
		/// The value cannot be less than 1000000.
		/// </summary>
		[Query("strategyType")]
		public int? StrategyType;

		/// <summary>
		/// Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.
		/// </summary>
		[Query("stopPrice")]
		public decimal? StopPrice;

		/// <summary>
		/// Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.
		/// For more details on SPOT implementation on trailing stops, please refer to Trailing Stop FAQ
		/// </summary>
		[Query("trailingDelta")]
		public long? TrailingDelta;

		/// <summary>
		/// Used with LIMIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT to create an iceberg order.
		/// </summary>
		[Query("icebergQty")]		
		public decimal? IcebergQty;

		/// <summary>
		/// Set the response JSON.ACK, RESULT, or FULL;
		/// MARKET and LIMIT order types default to FULL, all other orders default to ACK.
		/// </summary>
		[Query("newOrderRespType")]
		public OrderResponceType? NewOrderRespType;

		[Query("selfTradePreventionMode")]
		public TradePreventionMode? SelfTradePreventionMode;


		private TradeRequest(string symbol, OrderSide side, OrderType type) {
			Symbol = symbol;
			Side = side;
			Type = type;
		}


		public static TradeRequest BuyMarket(string symbol, decimal quantity)
		{
			var req = new TradeRequest(symbol, OrderSide.BUY, OrderType.MARKET);
			req.Quantity = quantity;
			return req;
		}
	}
}
