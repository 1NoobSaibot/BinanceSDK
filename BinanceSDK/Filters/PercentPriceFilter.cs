using BinanceSDK.DTO.V3.Trade;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	// TODO: Find out what is it and test it
	public class PercentPriceFilter : Filter
	{
		private const string MultiplierUpKey = "multiplierUp";
    private const string MultiplierDownKey = "multiplierDown";
    private const string AvgPriceMinsKey = "avgPriceMins";

		public override FilterType Type => FilterType.PERCENT_PRICE;

		[JsonProperty(MultiplierUpKey)]
		public readonly decimal MultiplierUp;

		[JsonProperty(MultiplierDownKey)]
		public readonly decimal MultiplierDown;

		[JsonProperty(AvgPriceMinsKey)]
		public readonly decimal WeightedAveragePrice;


		public PercentPriceFilter(decimal mulUp, decimal mulDown, decimal weightedAvgPrice)
		{
			MultiplierUp = mulUp;
			MultiplierDown = mulDown;
			WeightedAveragePrice = weightedAvgPrice;
		}


		internal PercentPriceFilter(JObject jo)
		{
			MultiplierUp = jo[MultiplierUpKey]!.Value<decimal>();
			MultiplierDown = jo[MultiplierDownKey]!.Value<decimal>();
			WeightedAveragePrice = jo[AvgPriceMinsKey]!.Value<decimal>();
		}


		/// <summary>
		/// price <= weightedAveragePrice * multiplierUp
		/// price >= weightedAveragePrice * multiplierDown
		/// </summary>
		public bool IsPriceValid(decimal price)
		{
			if (price > WeightedAveragePrice * MultiplierUp)
			{
				return false;
			}

			if (price < WeightedAveragePrice * MultiplierDown)
			{
				return false;
			}

			return true;
		}

		public bool IsValid(TradeRequest orderReq)
		{
			if (orderReq.Price == null)
			{
				return true;
			}

			return IsPriceValid((decimal)orderReq.Price);
		}
	}
}
