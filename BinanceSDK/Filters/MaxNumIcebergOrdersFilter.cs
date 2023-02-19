using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class MaxNumIcebergOrdersFilter : Filter
	{
		private const string MaxNumIcebergOrdersKey = "maxNumIcebergOrders";

		public override FilterType Type => FilterType.MAX_NUM_ICEBERG_ORDERS;

		[JsonProperty(MaxNumIcebergOrdersKey)]
		public readonly int MaxNumIcebergOrders;


		internal MaxNumIcebergOrdersFilter(JObject jo)
		{
			MaxNumIcebergOrders = jo[MaxNumIcebergOrdersKey]!.Value<int>();
		}
	}
}
