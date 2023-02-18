using BinanceSDK.DTO;
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

			foreach (var coin in coins)
			{
				foreach (var network in coin.Networks!)
				{
					_Check(network.WithdrawIntegerMultiple);
				}
			}
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


		// TODO: We need 10 dollars to test it
		/* [TestMethod]
		public async Task ShouldPlaceAndCancelRealOrder()
		{
			var req = TradeRequest.BuyLimit("BTCUSDT", 10, 1);
			await client.TestNewOrder(req);

			var order = await client.PlaceOrderAck(req);

			var cancelOrderData = await client.CancelOrder(order.MakeCancelRequest());
			Assert.AreEqual(OrderStatus.CANCELED, cancelOrderData.Status);
		} */


		private void _CheckTickSize(decimal tickSize)
		{
			string[] validValues = new string[]
			{
				"1",
				"0",
				"0,1",
				"0,01",
				"0,001",
				"0,0001",
				"0,00001",
				"0,000001",
				"0,0000001",
				"0,00000001"
			};

			string str = tickSize.ToString();
			foreach (var valid in validValues)
			{
				if (str == valid)
				{
					return;
				}
			}


			throw new Exception($"Got invalid value ({str})");
		}
	}
}