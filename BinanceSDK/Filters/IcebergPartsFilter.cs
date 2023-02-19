using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class IcebergPartsFilter : Filter
	{
		private const string LimitKey = "limit";

		public override FilterType Type => FilterType.ICEBERG_PARTS;

		[JsonProperty(LimitKey)]
		public int Limit;


		internal IcebergPartsFilter(JObject jo)
		{
			Limit = jo[LimitKey]!.Value<int>();
		}
	}
}
