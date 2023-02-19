using BinanceSDK.DTO.V3.Trade;
using BinanceSDK.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	/// <summary>
	/// The LOT_SIZE filter defines the quantity (aka "lots" in auction terms) rules for a symbol.
	/// </summary>
	public class LotSizeFilter : Filter
  {
		private const string MinQuantityKey = "minQty";
		private const string MaxQuantityKey = "maxQty";
		private const string StepSizeKey = "stepSize";

		public override FilterType Type => FilterType.LOT_SIZE;

		/// <summary>
		/// minQty defines the minimum quantity/icebergQty allowed.
		/// </summary>
		[JsonProperty(MinQuantityKey)]
		public readonly decimal MinQuantity;

		/// <summary>
		/// maxQty defines the maximum quantity/icebergQty allowed.
		/// </summary>
		[JsonProperty(MaxQuantityKey)]
		public readonly decimal MaxQuantity;

		/// <summary>
		/// stepSize defines the intervals that a quantity/icebergQty can be increased/decreased by.
		/// </summary>
		[JsonProperty(StepSizeKey)]
		public readonly decimal StepSize;


		internal LotSizeFilter(JObject jo)
		{
			MinQuantity = jo[MinQuantityKey]!.Value<decimal>();
			MaxQuantity = jo[MaxQuantityKey]!.Value<decimal>();
			StepSize = jo[StepSizeKey]!.Value<decimal>();
		}

		public bool IsValid(TradeRequest orderReq)
		{
			if (orderReq.Quantity == null)
			{
				return true;
			}

			decimal quantity = (decimal)orderReq.Quantity;
			if (quantity < MinQuantity)
			{
				return false;
			}

			if (MaxQuantity > 0 && quantity > MaxQuantity)
			{
				return false;
			}

			return (quantity - MinQuantity).Mod(StepSize) == 0m;
		}
	}
}
