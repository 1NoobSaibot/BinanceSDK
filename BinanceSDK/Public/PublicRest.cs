using BinanceSDK.DTO.V3;
using Newtonsoft.Json;

namespace BinanceSDK.Public
{
	public class PublicRest
	{
		private PublicRestRaw _rawApi = new PublicRestRaw();

		public Ticker[] GetTickers()
		{
			string json = _rawApi.GetTickers();
			return JsonConvert.DeserializeObject<Ticker[]>(json)!;
		}
	}
}