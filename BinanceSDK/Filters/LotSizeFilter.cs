using BinanceSDK.Helpers;

namespace BinanceSDK.Filters
{
	/// <summary>
	/// The LOT_SIZE filter defines the quantity (aka "lots" in auction terms) rules for a symbol.
	/// </summary>
	public class LotSizeFilter
  {
		/// <summary>
		/// minQty defines the minimum quantity/icebergQty allowed.
		/// </summary>
		public readonly decimal MinQuantity;

		/// <summary>
		/// maxQty defines the maximum quantity/icebergQty allowed.
		/// </summary>
		public readonly decimal MaxQuantity;

		/// <summary>
		/// stepSize defines the intervals that a quantity/icebergQty can be increased/decreased by.
		/// </summary>
		public readonly decimal StepSize;


		public bool IsValid(decimal quantity)
		{
			if (quantity < MinQuantity || quantity > MaxQuantity)
			{
				return false;
			}

			return (quantity - MinQuantity).Mod(StepSize) == 0m;
		}
	}
}
