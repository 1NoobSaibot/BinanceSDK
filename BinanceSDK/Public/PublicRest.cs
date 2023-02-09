using BinanceSDK.DTO.V3;
using Newtonsoft.Json;

namespace BinanceSDK.Public
{
	public class PublicRest
	{
		private PublicRestRaw _rawApi = new PublicRestRaw();

		public async Task<Ticker[]> GetTickersAsync()
		{
			string json = await _rawApi.GetTickersAsync();
			return JsonConvert.DeserializeObject<Ticker[]>(json)!;
		}
	}
}