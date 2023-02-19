using BinanceSDK.DTO.V3.Trade;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceSDK.Filters
{
	internal class PercentPriceBySideFilter : Filter
	{
		private const string BidMultiplierUpKey = "bidMultiplierUp";
		private const string BidMultiplierDownKey = "bidMultiplierDown";
		private const string AskMultiplierUpKey = "askMultiplierUp";
		private const string AskMultiplierDownKey = "askMultiplierDown";
		private const string AvgPriceMinsKey = "avgPriceMins";

		public override FilterType Type => FilterType.PERCENT_PRICE_BY_SIDE;

		[JsonProperty(BidMultiplierUpKey)]
		public decimal BidMultiplierUp;

		[JsonProperty(BidMultiplierDownKey)]
		public decimal BidMultiplierDown;

		[JsonProperty(AskMultiplierUpKey)]
		public decimal AskMultiplierUp;

		[JsonProperty(AskMultiplierDownKey)]
		public decimal AskMultiplierDown;

		[JsonProperty(AvgPriceMinsKey)]
		public decimal AvgPriceMins;


		internal PercentPriceBySideFilter(JObject jo)
		{
			BidMultiplierUp = jo[BidMultiplierUpKey]!.Value<decimal>();
			BidMultiplierDown = jo[BidMultiplierDownKey]!.Value<decimal>();
			AskMultiplierUp = jo[AskMultiplierUpKey]!.Value<decimal>();
			AskMultiplierDown = jo[AskMultiplierDownKey]!.Value<decimal>();
			AvgPriceMins = jo[AvgPriceMinsKey]!.Value<decimal>();
		}
	}
}
