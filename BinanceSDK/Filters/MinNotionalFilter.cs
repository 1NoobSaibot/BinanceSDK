namespace BinanceSDK.Filters
{
	/// <summary>
	/// The MIN_NOTIONAL filter defines the minimum notional value allowed for an order on a symbol.
	/// An order's notional value is the price * quantity.
	/// If the order is an Algo order (e.g. STOP_LOSS_LIMIT),
	/// then the notional value of the stopPrice * quantity will also be evaluated.
	/// If the order is an Iceberg Order,
	/// then the notional value of the price * icebergQty will also be evaluated.
	/// applyToMarket determines whether or not the MIN_NOTIONAL filter will also be applied to MARKET orders.
	/// Since MARKET orders have no price, the average price is used over the last avgPriceMins minutes.
	/// avgPriceMins is the number of minutes the average price is calculated over.
	/// 0 means the last price is used.
	/// </summary>
	/// TODO: Find out how to implement this filter
	public class MinNotionalFilter
	{
		public readonly decimal MinNotional;
		public readonly bool ApplyToMarket;
		public readonly decimal AveragePriceForLastMinutes;
	}
}
