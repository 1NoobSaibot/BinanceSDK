using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
	public class NotionalFilter : Filter
	{
		private const string MinNotionalKey = "minNotional";
		private const string ApplyMinToMarketKey = "applyMinToMarket";
		private const string MaxNotionalKey = "maxNotional";
		private const string ApplyMaxToMarketKey = "applyMaxToMarket";
		private const string AvgPriceMinsKey = "avgPriceMins";

		public override FilterType Type => FilterType.NOTIONAL;

		[JsonProperty(MinNotionalKey)]
		public readonly decimal MinNotional;

		[JsonProperty(ApplyMinToMarketKey)]
		public readonly bool ApplyMinToMarket;

		[JsonProperty(MaxNotionalKey)]
		public readonly decimal MaxNotional;

		[JsonProperty(ApplyMaxToMarketKey)]
		public readonly bool ApplyMaxToMarket;

		/// <summary>
		/// "avgPriceMins": 5
		/// </summary>
		[JsonProperty(AvgPriceMinsKey)]
		public readonly int ForLastMinutes;


		internal NotionalFilter(JObject jo)
		{
			MinNotional = jo[MinNotionalKey]!.Value<decimal>();
			ApplyMinToMarket = jo[ApplyMinToMarketKey]!.Value<bool>();
			MaxNotional = jo[MaxNotionalKey]!.Value<decimal>();
			ApplyMaxToMarket = jo[ApplyMaxToMarketKey]!.Value<bool>();
			ForLastMinutes = jo[AvgPriceMinsKey]!.Value<int>();
		}
	}
}
