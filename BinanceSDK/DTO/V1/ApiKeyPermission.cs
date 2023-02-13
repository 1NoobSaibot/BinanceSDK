using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1
{
	public class ApiKeyPermission
	{
		[JsonProperty("ipRestrict")]
		public bool IpRestricted;

		[JsonProperty("createTime")]
		public long CreatedAt;

		/// <summary>
		/// This option allows you to withdraw via API.
		/// You must apply the IP Access Restriction filter in order to enable withdrawals
		/// </summary>
		[JsonProperty("enableWithdrawals")]
		public bool WithdrawEnabled;

		/// <summary>
		/// This option authorizes this key to transfer funds
		/// between your master account and your sub account instantly
		/// </summary>
		[JsonProperty("enableInternalTransfer")]
		public bool InternalTransferEnabled;

		/// <summary>
		/// Authorizes this key to be used
		/// for a dedicated universal transfer API
		/// to transfer multiple supported currencies.
		/// Each business's own transfer API rights are not affected
		/// by this authorization
		/// </summary>
		[JsonProperty("permitsUniversalTransfer")]
		public bool PermitsUniversalTransfer;

		/// <summary>
		/// Authorizes this key to Vanilla options trading
		/// </summary>
		[JsonProperty("enableVanillaOptions")]
		public bool VanillaOptionsEnabled;

		[JsonProperty("enableReading")]
		public bool ReadingEnabled;

		/// <summary>
		/// API Key created before your futures account opened does not support futures API service
		/// </summary>
		[JsonProperty("enableFutures")]
		public bool FuturesEnabled;

		/// <summary>
		/// This option can be adjusted after the Cross Margin account transfer is completed
		/// </summary>
		[JsonProperty("enableMargin")]
		public bool MarginEnabled;

		[JsonProperty("enableSpotAndMarginTrading")]
		public bool SpotAndMarginTradingEnabled;

		/// <summary>
		/// Expiration time for spot and margin trading permission
		/// </summary>
		[JsonProperty("tradingAuthorityExpirationTime")]
		public long TradingAuthorityExpirationTime;
	}
}
