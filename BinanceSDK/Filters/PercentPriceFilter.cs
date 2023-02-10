namespace BinanceSDK.Filters
{
	// TODO: Find out what is it and test it
	public class PercentPriceFilter
	{
		public readonly decimal MultiplierUp;
		public readonly decimal MultiplierDown;
		public readonly decimal WeightedAveragePrice;

		public PercentPriceFilter(decimal mulUp, decimal mulDown, decimal weightedAvgPrice)
		{
			MultiplierUp = mulUp;
			MultiplierDown = mulDown;
			WeightedAveragePrice = weightedAvgPrice;
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
	}
}
