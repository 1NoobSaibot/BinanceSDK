namespace BinanceSDK.Helpers.WebClient
{
	/// <summary>
	/// This class was created to wrap HttpClient
	/// and to throw errors always when we get bad responce status
	/// </summary>
	internal interface IWebClient
	{
		Task<string> Send(HttpRequestMessage message);
	}
}
