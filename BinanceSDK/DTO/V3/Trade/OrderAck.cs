using Newtonsoft.Json;

namespace BinanceSDK.DTO.V3.Trade
{
	public class OrderAck
	{
		[JsonProperty("symbol")]
		public string? Symbol;

		[JsonProperty("orderId")]
		public long ID;

		/// <summary>
		/// Unless OCO, value will be -1
		/// </summary>
		[JsonProperty("orderListId")]
		public long OrderListID; 

		/// <summary>
		/// E.g.: "6gCrw2kRUAF9CvJDGP16IP"
		/// </summary>
		[JsonProperty("clientOrderId")]
		public string? ClientOrderID;
		
		[JsonProperty("transactTime")]
		public long TransactTime;
	}
}
