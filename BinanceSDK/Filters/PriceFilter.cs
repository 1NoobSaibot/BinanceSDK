namespace BinanceSDK.Filters
{
	public class PriceFilter
	{
		/// <summary>
		/// minPrice defines the minimum price/stopPrice allowed; disabled on minPrice == 0.
		/// </summary>
		public readonly decimal MinPrice;

		/// <summary>
		/// maxPrice defines the maximum price/stopPrice allowed; disabled on maxPrice == 0.
		/// </summary>
		public readonly decimal MaxPrice;

		/// <summary>
		/// tickSize defines the intervals that a price/stopPrice can be increased/decreased by; disabled on tickSize == 0.
		/// </summary>
		public readonly decimal TickeSize;


		public PriceFilter(decimal minPrice, decimal maxPrice, decimal tickSize)
		{
			MinPrice = minPrice;
			MaxPrice = maxPrice;
			TickeSize = tickSize;
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
			if (TickeSize == 0)
			{
				return true;
			}

			decimal res = price / TickeSize;
			return (res - ((int)res)) == 0m;
		}
	}
}
