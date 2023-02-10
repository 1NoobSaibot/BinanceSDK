namespace BinanceSDK.DTO
{
	public enum TimeInForce
	{
		/// <summary>
		/// Good Til Canceled
		/// An order will be on the book unless the order is canceled.
		/// </summary>
		GTC,

		/// <summary>
		/// Immediate Or Cancel
		/// An order will try to fill the order as much as it can before the order expires.
		/// </summary>
		IOC,

		/// <summary>
		/// Fill or Kill
		/// An order will expire if the full order cannot be filled upon execution.
		/// </summary>
		FOK
	}
}
