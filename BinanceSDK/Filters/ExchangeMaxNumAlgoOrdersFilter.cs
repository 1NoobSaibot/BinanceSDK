using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class ExchangeMaxNumAlgoOrdersFilter : Filter
	{
		private const string MaxNumAlgoOrdersKey = "maxNumAlgoOrders";

		public override FilterType Type => FilterType.EXCHANGE_MAX_NUM_ALGO_ORDERS;

		[JsonProperty(MaxNumAlgoOrdersKey)]
		public readonly int MaxNumAlgoOrders;


		internal ExchangeMaxNumAlgoOrdersFilter(JObject jo)
		{
			MaxNumAlgoOrders = jo[MaxNumAlgoOrdersKey]!.Value<int>();
		}
	}
}
