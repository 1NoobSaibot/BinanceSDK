namespace BinanceSDK.Helpers
{
	/// <summary>
	/// This class was created to wrap HttpClient
	/// and to throw errors always when we get bad responce status
	/// </summary>
	internal class MyClient : IDisposable
	{
		private HttpClient _httpClient = new HttpClient();

		public async Task<string> Send(HttpRequestMessage message)
		{
			var res = await _httpClient.SendAsync(message);

			if (res.IsSuccessStatusCode == false)
			{
				var errorMessage = await res.Content.ReadAsStringAsync();
				var e = new Exception($"Server returns an error status={res.StatusCode} and message=\"{errorMessage}\"");
				e.Data.Add("Status", res.StatusCode);
				e.Data.Add("Message", errorMessage);
				e.Data.Add("Request", message);
				e.Data.Add("Response", res);
				throw e;
			}

			return await res.Content.ReadAsStringAsync();
		}

		public void Dispose()
		{
			_httpClient.Dispose();
		}
	}
}
