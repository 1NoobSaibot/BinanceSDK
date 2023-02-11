using BinanceSDK.Private;

namespace BinanceSdkTest
{
	[TestClass]
	public class PrivateRestTest
	{
		private PrivateRest client = new PrivateRest(Env.Access);


		[TestMethod]
		public async Task ShouldGetCoins()
		{
			var coins = await client.GetCoinsAsync();
			Assert.IsNotNull(coins);
			Assert.IsTrue(coins.Length > 0);
		}
	}
}