using BinanceSDK.DTO.V1;
using Newtonsoft.Json;

namespace BinanceSDK.Private
{
	public class PrivateRest : IPrivateRest
	{
		private readonly PrivateRestRaw _rawApi;


		public PrivateRest(Access access) {
			_rawApi = new PrivateRestRaw(access);
		}


		public async Task<Coin[]> GetCoinsAsync()
		{
			string json = await _rawApi.GetCoinsAsync();
			return JsonConvert.DeserializeObject<Coin[]>(json)!;
		}
	}
}