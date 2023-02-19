using BinanceSDK.DTO.V3.Trade;
using BinanceSDK.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class PriceFilter : Filter
	{
		private const string MinPriceKey = "minPrice";
		private const string MaxPriceKey = "maxPrice";
		private const string TickSizeKey = "tickSize";

		public override FilterType Type => FilterType.PRICE_FILTER;

		/// <summary>
		/// minPrice defines the minimum price/stopPrice allowed; disabled on minPrice == 0.
		/// </summary>
		[JsonProperty(MinPriceKey)]
		public readonly decimal MinPrice;

		/// <summary>
		/// maxPrice defines the maximum price/stopPrice allowed; disabled on maxPrice == 0.
		/// </summary>
		[JsonProperty(MaxPriceKey)]
		public readonly decimal MaxPrice;

		/// <summary>
		/// tickSize defines the intervals that a price/stopPrice can be increased/decreased by; disabled on tickSize == 0.
		/// </summary>
		[JsonProperty(TickSizeKey)]
		public readonly decimal TickSize;


		internal PriceFilter(JObject jo)
		{
			MinPrice = jo[MinPriceKey]!.Value<decimal>();
			MaxPrice = jo[MaxPriceKey]!.Value<decimal>();
			TickSize = jo[TickSizeKey]!.Value<decimal>();
		}


		public PriceFilter(decimal min, decimal max, decimal tickSize)
		{
			MinPrice = min;
			MaxPrice = max;
			TickSize = tickSize;
		}


		public bool IsValid(TradeRequest orderReq)
		{
			if (orderReq.Price == null)
			{
				return true;
			}

			return IsPriceValid((decimal)orderReq.Price);
		}


		public bool IsPriceValid(decimal price)
		{
			if (price < MinPrice)
			{
				return false;
			}

			if (MaxPrice > 0 && price > MaxPrice)
			{
				return false;
			}

			// price mod tickSize MUST BE 0
			if (TickSize == 0)
			{
				return true;
			}

			return price.Mod(TickSize) == 0;
		}
	}
}
