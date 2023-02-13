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


		// TODO: Find out how to test it without register margin and futures account
		/* [TestMethod]
		public async Task ShouldGetMarginDailyAccountSnapshot()
		{
			var snapshot = await client.GetMarginDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("margin", snapshot.Snapshots[0].Type);
		}


		[TestMethod]
		public async Task ShouldGetFuturesDailyAccountSnapshot()
		{
			var snapshot = await client.GetFuturesDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("Futures", snapshot.Snapshots[0].Type);
		}*/
	}
}