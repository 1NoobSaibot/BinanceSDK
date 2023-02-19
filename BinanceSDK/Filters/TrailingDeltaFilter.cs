using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BinanceSDK.Filters
{
	public class TrailingDeltaFilter : Filter
	{
		private const string MinTrailingAboveDeltaKey = "minTrailingAboveDelta";
    private const string MaxTrailingAboveDeltaKey = "maxTrailingAboveDelta";
    private const string MinTrailingBelowDeltaKey = "minTrailingBelowDelta";
    private const string MaxTrailingBelowDeltaKey = "maxTrailingBelowDelta";

		public override FilterType Type => FilterType.TRAILING_DELTA;

		[JsonProperty(MinTrailingAboveDeltaKey)]
		public readonly int MinTrailingAboveDelta;

		[JsonProperty(MaxTrailingAboveDeltaKey)]
		public readonly int MaxTrailingAboveDelta;

		[JsonProperty(MinTrailingBelowDeltaKey)]
		public readonly int MinTrailingBelowDelta;

		[JsonProperty(MaxTrailingBelowDeltaKey)]
		public readonly int MaxTrailingBelowDelta;


		internal TrailingDeltaFilter(JObject jo)
		{
			MinTrailingAboveDelta = jo[MinTrailingAboveDeltaKey]!.Value<int>();
			MaxTrailingAboveDelta = jo[MaxTrailingAboveDeltaKey]!.Value<int>();
			MinTrailingBelowDelta = jo[MinTrailingBelowDeltaKey]!.Value<int>();
			MaxTrailingBelowDelta = jo[MaxTrailingBelowDeltaKey]!.Value<int>();
		}
	}
}
