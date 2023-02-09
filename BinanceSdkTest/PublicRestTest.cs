using BinanceSDK.Public;

namespace BinanceSdkTest
{
	[TestClass]
	public class PublicRestTest
	{
		[TestMethod]
		public void ShouldGetTickers()
		{
			PublicRest client = new PublicRest();
			var tickers = client.GetTickers();
			Assert.IsNotNull(tickers);
			Assert.IsTrue(tickers.Length > 0);
		}
	}
}