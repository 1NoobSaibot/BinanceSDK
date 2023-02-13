using BinanceSDK.DTO.V1;
using BinanceSDK.DTO.V3;

namespace BinanceSDK.Public
{
	public interface IPublicRest
	{
		Task<Ticker[]> GetTickersAsync();
		Task<SystemStatus> GetSystemStatusAsync();
		Task Ping();
	}
}