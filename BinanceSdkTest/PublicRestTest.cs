using BinanceSDK.Public;

namespace BinanceSdkTest
{
	[TestClass]
	public class PublicRestTest
	{
		[TestMethod]
		public async Task ShouldGetTickers()
		{
			PublicRest client = new PublicRest();
			var tickers = await client.GetTickersAsync();
			Assert.IsNotNull(tickers);
			Assert.IsTrue(tickers.Length > 0);
		}
	}
}