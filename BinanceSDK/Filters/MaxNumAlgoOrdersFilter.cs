using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class MaxNumAlgoOrdersFilter : Filter
	{
		private const string MaxNumAlgoOrdersKey = "maxNumAlgoOrders";

		public override FilterType Type => FilterType.MAX_NUM_ALGO_ORDERS;

		[JsonProperty(MaxNumAlgoOrdersKey)]
		public readonly int MaxNumAlgoOrders;


		internal MaxNumAlgoOrdersFilter(JObject jo)
		{
			MaxNumAlgoOrders = jo[MaxNumAlgoOrdersKey]!.Value<int>();
		}
	}
}
