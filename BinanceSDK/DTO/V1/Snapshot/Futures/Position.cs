using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1.Snapshot.Futures
{
	public class Position
	{
		[JsonProperty("entryPrice")]
		public decimal EntryPrice;

		[JsonProperty("markPrice")]
		public decimal MarkPrice;

		[JsonProperty("positionAmt")]
		public decimal PositionAmount;

		[JsonProperty("symbol")]
		public string Symbol;

		[JsonProperty("unRealizedProfit")]
		public decimal UnrealizedProfit;
	}
}
