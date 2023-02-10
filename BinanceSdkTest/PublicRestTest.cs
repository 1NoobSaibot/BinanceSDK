using BinanceSDK.DTO.V1;
using BinanceSDK.Public;

namespace BinanceSdkTest
{
	[TestClass]
	public class PublicRestTest
	{
		private PublicRest client = new PublicRest();

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
	}
}