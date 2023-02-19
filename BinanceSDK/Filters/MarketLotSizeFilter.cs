using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class MarketLotSizeFilter : Filter
	{
		private const string MinQtyKey = "minQty";
    private const string MaxQtyKey = "maxQty";
    private const string StepSizeKey = "stepSize";

		public override FilterType Type => FilterType.MARKET_LOT_SIZE;

		[JsonProperty(MinQtyKey)]
		public readonly decimal MinQty;

		[JsonProperty(MaxQtyKey)]
		public readonly decimal MaxQty;

		[JsonProperty(StepSizeKey)]
		public readonly decimal StepSize;

		internal MarketLotSizeFilter(JObject jo)
		{
			MinQty = jo[MinQtyKey]!.Value<decimal>();
			MaxQty = jo[MaxQtyKey]!.Value<decimal>();
			StepSize = jo[StepSizeKey]!.Value<decimal>();
		}
	}
}
