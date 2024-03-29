﻿namespace BinanceSDK.Helpers.WebClient
{
	/// <summary>
	/// This class was created to wrap HttpClient
	/// and to throw errors always when we get bad responce status
	/// </summary>
	internal class MyClient : IWebClient, IDisposable
	{
		private HttpClient _httpClient = new HttpClient();

		public async Task<string> Send(HttpRequestMessage message)
		{
			var res = await _httpClient.SendAsync(message);
			
			// TODO
			/* 
			HTTP 4XX return codes are used for malformed requests; the issue is on the sender's side.
			HTTP 403 return code is used when the WAF Limit (Web Application Firewall) has been violated.
			HTTP 409 return code is used when a cancelReplace order partially succeeds. (e.g. if the cancellation of the order fails but the new order placement succeeds.)
			HTTP 429 return code is used when breaking a request rate limit.
			HTTP 418 return code is used when an IP has been auto-banned for continuing to send requests after receiving 429 codes.
			HTTP 5XX return codes are used for internal errors; the issue is on Binance's side. It is important to NOT treat this as a failure operation; the execution status is UNKNOWN and could have been a success.
			*/
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
