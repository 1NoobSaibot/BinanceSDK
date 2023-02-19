using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class MaxPositionFilter : Filter
	{
		private const string MaxPositionKey = "maxPosition";

		public override FilterType Type => FilterType.MAX_POSITION;

		[JsonProperty(MaxPositionKey)]
		public readonly decimal MaxPosition;


		internal MaxPositionFilter(JObject jo)
		{
			MaxPosition = jo[MaxPositionKey]!.Value<decimal>();
		}
	}
}
