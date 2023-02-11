using BinanceSDK.DTO.V1;

namespace BinanceSDK.Private
{
	public interface IPrivateRest
	{
		/// <summary>
		/// Get information of coins (available for deposit and withdraw) for user.
		/// </summary>
		Task<Coin[]> GetCoinsAsync();
	}
}