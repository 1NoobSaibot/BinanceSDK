using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class ExchangeMaxNumOrdersFilter : Filter
	{
		private const string MaxNumOrdersKey = "maxNumOrders";

		public override FilterType Type => FilterType.EXCHANGE_MAX_NUM_ORDERS;

		[JsonProperty(MaxNumOrdersKey)]
		public readonly int MaxNumOrders;


		internal ExchangeMaxNumOrdersFilter(JObject jo)
		{
			MaxNumOrders = jo[MaxNumOrdersKey]!.Value<int>();
		}
	}
}
