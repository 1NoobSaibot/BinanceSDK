using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class ExchangeMaxNumIcebergOrdersFilter : Filter
	{
		private const string MaxNumIcebergOrdersKey = "maxNumIcebergOrders";

		public override FilterType Type => FilterType.EXCHANGE_MAX_NUM_ICEBERG_ORDERS;

		[JsonProperty(MaxNumIcebergOrdersKey)]
		public readonly int MaxNumIcebergOrders;


		internal ExchangeMaxNumIcebergOrdersFilter(JObject jo)
		{
			MaxNumIcebergOrders = jo[MaxNumIcebergOrdersKey]!.Value<int>();
		}
	}
}
