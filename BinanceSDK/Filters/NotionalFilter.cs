namespace BinanceSDK.Filters
{
	/*
		The NOTIONAL filter defines the acceptable notional range allowed for an order on a symbol.

		applyMinToMarket determines whether the minNotional will be applied to MARKET orders.

		applyMaxToMarket determines whether the maxNotional will be applied to MARKET orders.

		In order to pass this filter, the notional (price * quantity) has to pass the following conditions:

		price * quantity <= maxNotional
		price * quantity >= minNotional
		For MARKET orders, the average price used over the last avgPriceMins minutes will be used for calculation.

		If the avgPriceMins is 0, then the last price will be used.
	 */
	public class NotionalFilter
	{
		public readonly decimal MinNotional;
		public readonly bool ApplyMinToMarket;
		public readonly decimal MaxNotional;
		public readonly bool ApplyMaxToMarket;
		/// <summary>
		/// "avgPriceMins": 5
		/// </summary>
		public readonly int ForLastMinutes;
	}
}
