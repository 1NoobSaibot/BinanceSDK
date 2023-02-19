using BinanceSDK.Helpers.WebClient;

namespace BinanceSdkTest.Helpers
{
	internal class FakeWebClient : IWebClient
	{
		private string? _nextJson;

		public void SetNextREsponceData(string? json)
		{
			_nextJson = json;
		}

		public async Task<string> Send(HttpRequestMessage message)
		{
			await Task.Run(() => {});
			return _nextJson ?? string.Empty;
		}
	}
}
