using BinanceSDK.DTO.V1;
using BinanceSDK.Public;

namespace BinanceSdkTest.Public
{
	[TestClass]
	public class PublicRestTest
	{
		private IPublicRest client = new PublicRest();


		[TestMethod]
		public async Task ShouldGetExchangeInfo()
		{
			var info = await client.GetExchangeInfo();
			Assert.IsNotNull(info);
			Assert.AreNotEqual(0, info.Symbols!.Length);
		}


		[TestMethod]
		public async Task ShouldGetOrderBookTickers()
		{
			var tickers = await client.GetOrderBookTickers();
			Assert.IsNotNull(tickers);
			Assert.AreNotEqual(0, tickers.Length);
		}


		[TestMethod]
		public async Task ShouldGetTickers()
		{
			var tickers = await client.GetTickersAsync();
			Assert.IsNotNull(tickers);
			Assert.IsTrue(tickers.Length > 0);
		}


		[TestMethod]
		public async Task ShouldGetSystemStatus()
		{
			var status = await client.GetSystemStatusAsync();
			Assert.IsNotNull(status);
			Assert.IsTrue(
				status.Code == SystemStatus.NormalStatusCode
				|| status.Code == SystemStatus.MaintenanceStatusCode
			);
			Assert.IsTrue(
				status.Message == SystemStatus.NormalStatusMessage
				|| status.Message == SystemStatus.MaintenanceStatusMessage
			);
		}


		[TestMethod]
		public async Task ShouldGetTickerPriceChangeStatistics()
		{
			var res = await client.Get24hrTickerPriceChangeStatistics();
			Assert.IsNotNull(res);
			Assert.AreNotEqual(0, res.Length);
		}


		[TestMethod]
		public async Task ShouldPing()
		{
			await client.Ping();
		}
	}
}