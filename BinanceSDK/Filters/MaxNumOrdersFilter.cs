using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class MaxNumOrdersFilter : Filter
	{
		private const string MaxNumOrdersKey = "maxNumOrders";

		public override FilterType Type => FilterType.MAX_NUM_ORDERS;

		[JsonProperty(MaxNumOrdersKey)]
		public readonly int MaxNumOrders;


		internal MaxNumOrdersFilter(JObject jo)
		{
			MaxNumOrders = jo[MaxNumOrdersKey]!.Value<int>();
		}
	}
}
