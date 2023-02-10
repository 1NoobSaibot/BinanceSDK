namespace BinanceSDK.DTO
{
	public enum OrderStatus
	{
		/// <summary>
		/// The order has been accepted by the engine.
		/// </summary>
		NEW,
		/// <summary>
		/// A part of the order has been filled.
		/// </summary>
		PARTIALLY_FILLED,
		/// <summary>
		/// The order has been completed.
		/// </summary>
		FILLED,
		/// <summary>
		/// The order has been canceled by the user.
		/// </summary>
		CANCELED,
		/// <summary>
		/// Currently unused
		/// </summary>
		PENDING_CANCEL,
		/// <summary>
		/// The order was not accepted by the engine and not processed.
		/// </summary>
		REJECTED,
		/// <summary>
		/// The order was canceled according to the order type's rules
		/// (e.g. LIMIT FOK orders with no fill, LIMIT IOC or MARKET orders that partially fill)
		/// or by the exchange,
		/// (e.g. orders canceled during liquidation, orders canceled during maintenance)
		/// </summary>
		EXPIRED,
		/// <summary>
		/// The order was canceled by the exchange due to STP trigger.
		/// (e.g. an order with EXPIRE_TAKER will match with existing orders on the book with the same account or same tradeGroupId)
		/// </summary>
		EXPIRED_IN_MATCH,
	}
}
