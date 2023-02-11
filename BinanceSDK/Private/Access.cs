namespace BinanceSDK.Private
{
	public class Access
	{
		public readonly string ApiKey;
		public readonly string SecretKey;


		public Access(string apiKey, string secretKey)
		{
			ApiKey = apiKey;
			SecretKey = secretKey;
		}
	}
}
