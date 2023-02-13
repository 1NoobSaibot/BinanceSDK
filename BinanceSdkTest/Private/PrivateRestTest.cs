using BinanceSDK.Private;

namespace BinanceSdkTest.Private
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


		[TestMethod]
		public async Task ShouldGetSpotDailyAccountSnapshot()
		{
			var snapshot = await client.GetSpotDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			foreach (var shot in snapshot!.Snapshots!)
			{
				Assert.AreEqual("spot", shot!.Type);
			}
		}
	}
}