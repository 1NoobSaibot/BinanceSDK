using BinanceSDK.DTO.V3.Trade;
using BinanceSDK.Private;

namespace BinanceSdkTest.Private
{
	[TestClass]
	public class PrivateRestTest
	{
		private IPrivateRest client = new PrivateRest(Env.Access);


		[TestMethod]
		public async Task ShouldGetKeyPermission()
		{
			var res = await client.GetKeyPermission();
			Assert.IsNotNull(res);
		}


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


		[TestMethod]
		public async Task ShouldTestNewOrder()
		{
			var req = TradeRequest.BuyMarket("BTCUSDT", 1);
			await client.TestNewOrder(req);
		}
	}
}